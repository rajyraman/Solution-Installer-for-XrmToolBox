using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Octokit;
using Ryr.XrmToolBox.SolutionInstaller.DefinitionClasses;
using Ryr.XrmToolBox.SolutionInstaller.DockPanels;
using Ryr.XrmToolBox.SolutionInstaller.Extensions;
using Ryr.XrmToolBox.SolutionInstaller.Properties;
using Ryr.XrmToolBox.SolutionInstaller.Utility;
using WeifenLuo.WinFormsUI.Docking;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;

namespace Ryr.XrmToolBox.SolutionInstaller
{
    public partial class SolutionInstallerPlugin : MultipleConnectionsPluginControlBase, 
        IGitHubPlugin, IPayPalPlugin,
        IHelpPlugin, IMessageBusHost,IStatusBarMessenger
    {
        #region Public Properties
        public string RepositoryName => "Solution-Installer-for-XrmToolBox";
        public string UserName => "rajyraman";
        public string DonationDescription => "Please sponsor my coffee, if you find this tool useful. Thank you.";
        public string EmailAccount => "natraj.y@gmail.com";
        public string HelpUrl => "https://github.com/rajyraman/Solution-Installer-for-XrmToolBox/blob/master/README.md";
        public event EventHandler<StatusBarMessageEventArgs> SendMessageToStatusBar;
        public event EventHandler<MessageBusEventArgs> OnOutgoingMessage;
        #endregion

        #region Public Members
        public List<ConnectionDetail> ConnectedOrgs { get; }
        public SolutionInstallerPlugin()
        {
            InitializeComponent();
            var dockMessager = new DockMessager(this);
            this.mainDockPanel.Theme = new VS2015BlueTheme();
            _solutionsDock = new GitHubSolutionsDockContent(dockMessager);
            _solutionsDock.Show(this.mainDockPanel, DockState.DockLeft);

            _releasesDock = new GitHubReleasesDockContent(dockMessager);
            _releasesDock.Show(this.mainDockPanel, DockState.Document);

            _installedSolutionsDock = new InstalledSolutionsDockContent(dockMessager);
            _installedSolutionsDock.Show(this.mainDockPanel, DockState.Document);

            TabIcon = Resources.Logo;
            ConnectedOrgs = new List<ConnectionDetail>();

            _gitHubClient = new GitHubClient(new ProductHeaderValue("xrmtoolbox-solutions-installer"));
            if (SettingsManager.Instance.TryLoad(typeof(SolutionInstallerPlugin), out Settings settings) &&
                !string.IsNullOrEmpty(settings.GitHubKey))
            {
                tstGitHubKey.Text = settings.GitHubKey;
            }

            if (!string.IsNullOrEmpty(tstGitHubKey.Text))
            {
                _gitHubClient.Credentials = new Credentials(tstGitHubKey.Text);
            }
        }
        public ListViewItem[] Repos { get; set; }
        public List<ListViewGroup> RepoAuthorGroup { get; set; }
        #endregion

        #region Private Members
        private List<OwnerRepo> _ownerRepos;
        private const string SOLUTION_FETCH = @"
                        <fetch distinct='false' no-lock='false' mapping='logical'>
                          <entity name='solution'>
                            <attribute name='friendlyname' />
                            <attribute name='uniquename' />
                            <attribute name='publisherid' />
                            <attribute name='version' />
                            <attribute name='installedon' />
                            <attribute name='ismanaged' />
                            <filter type='and'>
                              <filter type='and'>
                                <condition attribute='isvisible' operator='eq' value='1' />
                              </filter>
                            </filter>
                            <order attribute='friendlyname' descending='false' />
                          </entity>
                        </fetch>";
        private readonly GitHubClient _gitHubClient;
        private ListViewItem[] _releases;
        private GitHubSolutionsDockContent _solutionsDock;
        private GitHubReleasesDockContent _releasesDock;
        private InstalledSolutionsDockContent _installedSolutionsDock; 
        #endregion

        #region Private Methods
        private void tsbClose_Click(object sender, EventArgs e)
        {
            SettingsManager.Instance.Save(typeof(SolutionInstallerPlugin), new Settings
            {
                GitHubKey = tstGitHubKey.Text
            });
            CloseTool();
        }

        private void tsbRetrieveSolutions_Click(object sender, EventArgs e)
        {
            _solutionsDock.LvGitHubSolutions.Groups.Clear();
            _solutionsDock.LvGitHubSolutions.Items.Clear();
            SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(""));
            _solutionsDock.TxtSearch.Text = "";

            ExecuteMethod(LoadSolutionsFromGitHub);
        }

        private void EnableItems()
        {
            _solutionsDock.Enabled = true;
            _releasesDock.Enabled = _solutionsDock.LvGitHubSolutions.CheckedItems.Count > 0;
            tsbInstallSolution.Enabled = _releasesDock.LvReleases.CheckedItems.Count > 0;
        }

        private void LoadSolutionsInCRM()
        {
            _installedSolutionsDock.LvInstalledSolutions.Groups.Clear();
            _installedSolutionsDock.LvInstalledSolutions.Items.Clear();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieving solutions already installed..",
                Work = (worker, args) =>
                {
                    var orgsAndSolutions = new Dictionary<ConnectionDetail, List<Entity>>();
                    foreach (var connectedOrg in ConnectedOrgs)
                    {
                        var solutions = connectedOrg.ServiceClient.RetrieveMultiple(
                            new FetchExpression(SOLUTION_FETCH)).Entities.ToList();
                        orgsAndSolutions.Add(connectedOrg, solutions);
                    }

                    args.Result = orgsAndSolutions;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        ShowErrorNotification(args.Error.Message, null);
                        return;
                    }
                    var orgsAndSolutions = (Dictionary<ConnectionDetail, List<Entity>>)args.Result;
                    _installedSolutionsDock.LvInstalledSolutions.Groups.AddRange(
                        orgsAndSolutions
                            .Select(x => new ListViewGroup(x.Key.ConnectionName, x.Key.ConnectionName))
                            .ToArray());
                    foreach (var orgsAndSolution in orgsAndSolutions)
                    {
                        var baseUrl = orgsAndSolution.Key.OriginalUrl.NormaliseUrl();
                        foreach (var solution in orgsAndSolution.Value)
                        {
                            _installedSolutionsDock.LvInstalledSolutions.Items.Add(new ListViewItem
                            {
                                Text = solution.GetAttributeValue<string>("friendlyname"),
                                SubItems =
                                {
                                    solution.GetAttributeValue<string>("uniquename"),
                                    solution.GetAttributeValue<bool>("ismanaged").ToYesNo(),
                                    solution.GetAttributeValue<EntityReference>("publisherid").Name,
                                    solution.GetAttributeValue<string>("version"),
                                    solution.GetAttributeValue<DateTime>("installedon").ToLocalTime().ToString("d")
                                },
                                Tag = $"{baseUrl}main.aspx?etn=solution&id={solution.Id}&newWindow=true&pagetype=entityrecord",
                                Group = _installedSolutionsDock.LvInstalledSolutions.Groups[orgsAndSolution.Key.ConnectionName]
                            });
                        }
                    }

                    _installedSolutionsDock.LvInstalledSolutions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
        }

        private void LoadSolutionsFromGitHub()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieving solution feed from GitHub..",
                Work = (worker, args) =>
                {
                    HideNotification();
                    var repoList = _gitHubClient.Repository.Content
                        .GetAllContents("rajyraman", "Solution-Installer-for-XrmToolBox", "db.json").Result;
                    _ownerRepos = new JavaScriptSerializer()
                                    .Deserialize<List<OwnerRepo>>(repoList[0].Content);
                    SendMessageToStatusBar?.Invoke(this,
                        new StatusBarMessageEventArgs($"Retrieved {_ownerRepos.Count} solutions from GitHub"));
                    _ownerRepos.ToList().ForEach(r =>
                    {
                        var user = _gitHubClient.User.Get(r.Owner).Result;
                        _solutionsDock.LvGitHubSolutions.AddGroup($"{user.Name} (@{user.Login})", user.Login);
                    });
                    RepoAuthorGroup = _solutionsDock.LvGitHubSolutions.Groups.Cast<ListViewGroup>().ToList();

                    var repos = new List<Repository>();
                    foreach (var ownerRepo in _ownerRepos)
                    {
                        foreach (var r in ownerRepo.Repos)
                        {
                            worker.ReportProgress(0, $"Retrieving information for {r} from GitHub..");
                            var repo = _gitHubClient.Repository.Get(ownerRepo.Owner, r).Result;
                            repos.Add(repo);
                        }
                    }
                    args.Result = repos;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error?.InnerException is RateLimitExceededException rateLimitException)
                    {
                        HandleRateLimitException(rateLimitException);
                        return;
                    }
                    else if (args.Error != null)
                    {
                        ShowErrorNotification(args.Error.Message, null);
                        return;
                    }
                    EnableItems();
                    var repos = (List<Repository>)args.Result;
                    Repos = repos.Select(r => new ListViewItem
                    {
                        Text = r.Name,
                        SubItems =
                        {
                            r.StargazersCount.ToString(),
                            r.Description
                        },
                        ToolTipText = r.Description,
                        Tag = r,
                        Group = _solutionsDock.LvGitHubSolutions.Groups[r.Owner.Login]
                    }).ToArray();
                    _solutionsDock.LvGitHubSolutions.Items.AddRange(Repos);
                    _solutionsDock.LvGitHubSolutions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                },
                ProgressChanged = e => SetWorkingMessage(e.UserState.ToString())
            });
        }

        private void HandleRateLimitException(RateLimitExceededException rateLimitExceededException)
        {
            ShowErrorNotification(
                $"Rate Limit reached. Maximum number of requests per hour is {rateLimitExceededException.Limit}. Please use your GitHub API key or try again after {rateLimitExceededException.Reset.DateTime.ToLocalTime():t}.",
                new Uri("https://developer.github.com/v3/#rate-limiting"));
            tslGitHubKey.Visible = true;
            tstGitHubKey.Visible = true;
            tssEnd.Visible = true;
            tstGitHubKey.Focus();
        }

        private void tsbAddOrg_Click(object sender, EventArgs e)
        {
            AddAdditionalOrganization();
        }

        private void tsbInstallSolution_Click(object sender, EventArgs e)
        {
            var connections = ConnectedOrgs
                .Select(x => x.ConnectionName).ToArray();

            var assets = _releasesDock.LvReleases.CheckedItems
                .Cast<ListViewItem>()
                .Select(x => (Asset)x.Tag).ToList();

            if (DialogResult.OK ==
                new InstallSolution(connections, assets).ShowDialog(this))
            {
                ExecuteMethod(PublishSolutions);
            }
        }

        private void PublishSolutions()
        {
            var importErrors = new Dictionary<string, string>();
            var watch = new Stopwatch();
            var selectedSolutions = _releasesDock.LvReleases.GetCheckedItems();
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Downloading solution files from GitHub..",
                IsCancelable = true,
                Work = (worker, args) =>
                {
                    HideNotification();
                    watch.Start();
                    using (var webClient = new WebClient())
                    {
                        var solutionFiles = selectedSolutions
                            .Select(x =>
                            {
                                var asset = (Asset)x.Tag;
                                worker.ReportProgress(0, $"Downloading {asset.Name} from GitHub..");
                                return new KeyValuePair<string, byte[]>(asset.Name,
                                    webClient.DownloadData(asset.BrowserDownloadUrl));
                            })
                            .ToList();
                        foreach (var connectedOrg in ConnectedOrgs)
                        {
                            foreach (var s in solutionFiles)
                            {
                                worker.ReportProgress(0,
                                    $"Importing {s.Key} into {connectedOrg.ConnectionName}..");
                                try
                                {
                                    var solutionFormat = Helper.CheckZip(s.Value);
                                    if (solutionFormat != SolutionFormat.Managed)
                                    {
                                        importErrors.Add($"{s.Key}:{connectedOrg.ConnectionName}",
                                            $"SKIPPED Solution {s.Key} as it is {solutionFormat}. ");
                                        continue;
                                    };

                                    connectedOrg.ServiceClient.Execute(
                                        new ImportSolutionRequest
                                        {
                                            CustomizationFile = s.Value
                                        });
                                    worker.ReportProgress(0, $"Imported {s.Key} into {connectedOrg.ConnectionName}.");
                                }
                                catch (FaultException<OrganizationServiceFault> ex)
                                {
                                    importErrors.Add($"{s.Key}:{connectedOrg.ConnectionName}",
                                        $"Org {connectedOrg.ConnectionName}, Solution {s.Key}. " +
                                        $@"{ex?.Detail?.InnerFault?.InnerFault?.Message
                                               ?? ex?.Detail?.InnerFault?.Message
                                               ?? ex?.Detail?.Message
                                               ?? ex?.Message}");
                                }
                            }
                        }

                        args.Result = solutionFiles;
                    }
                },
                PostWorkCallBack = (args) =>
                {
                    watch.Stop();
                    if (args.Error != null)
                    {
                        ShowErrorNotification(args.Error.Message, null);
                        return;
                    }

                    if (importErrors.Any())
                    {
                        ShowErrorNotification(string.Join(Environment.NewLine, importErrors.Select(x => x.Value).ToList()), null);
                        importErrors.Clear();
                    }
                    else
                    {
                        HideNotification();
                        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs($"Imported {selectedSolutions.Length} solutions in {watch.Elapsed.Minutes:00} minute(s) {watch.Elapsed.Seconds:00} seconds"));
                        _installedSolutionsDock.Activate();
                        _solutionsDock.LvGitHubSolutions.ClearCheckedItems();
                    }
                    ExecuteMethod(LoadSolutionsInCRM);
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
        }

        private void tstGitHubKey_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tstGitHubKey.Text))
            {
                _gitHubClient.Credentials = new Credentials(tstGitHubKey.Text);
            }
        }

        private void tsbUninstall_Click(object sender, EventArgs e)
        {
            var messageBusEventArgs = new MessageBusEventArgs("Managed Solution Deletion Tool");
            OnOutgoingMessage?.Invoke(this, messageBusEventArgs);
        }

        private void tsbReset_Click(object sender, EventArgs e)
        {
            _solutionsDock.LvGitHubSolutions.ClearCheckedItems();
            _releasesDock.LvReleases.ClearItems();
        }
        #endregion

        #region Protected Methods
        protected override void ConnectionDetailsUpdated(NotifyCollectionChangedEventArgs e)
        {
            if (e.Action != NotifyCollectionChangedAction.Add) return;

            var newConnections = (from c in e.NewItems.Cast<ConnectionDetail>()
                                  where ConnectedOrgs.All(x => x.ConnectionId != c.ConnectionId)
                                  select c).ToList();
            if (!newConnections.Any()) return;

            ConnectedOrgs.AddRange(newConnections);
            ExecuteMethod(LoadSolutionsInCRM);
        }
        protected override void OnConnectionUpdated(ConnectionUpdatedEventArgs e)
        {
            base.OnConnectionUpdated(e);

            ConnectedOrgs.Add(ConnectionDetail);
            ExecuteMethod(LoadSolutionsInCRM);
        } 
        #endregion

        #region Public Methods
        public void OnIncomingMessage(MessageBusEventArgs message)
        {
            if (message.SourcePlugin != "Managed Solution Deletion Tool") return;

            ExecuteMethod(LoadSolutionsInCRM);
        }

        public void lvGitHubSolutions_ItemChecked(ListView lvGitHubSolutions, ItemCheckedEventArgs icea)
        {
            var lvGitHubSolutionsChecked = lvGitHubSolutions.GetCheckedItems();
            var lvReleasesItems = _releasesDock.LvReleases.GetItems();
            if (lvGitHubSolutionsChecked.Length == 0 && lvReleasesItems.Length == 0) return;
            if (!icea.Item.Checked)
            {
                var releases = (from s in lvGitHubSolutionsChecked
                                let lvGitHubSolutionsTag = (Repository)s.Tag
                                join r in lvReleasesItems on s.Text equals ((Asset)r.Tag).RepoName
                                select r).ToList();
                _releasesDock.LvReleases.RemoveItemsExcept(releases);
                return;
            }
            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Retrieving releases from GitHub..",
                Work = (worker, args) =>
                {
                    if (!(mainDockPanel.ActiveDocument is GitHubReleasesDockContent))
                    {
                        _releasesDock.Activate();
                    }
                    HideNotification();
                    var downloadableAssets = new List<Asset>();
                    var solutions = (from s in lvGitHubSolutionsChecked
                                     let lvGitHubSolutionsTag = (Repository)s.Tag
                                     join r in lvReleasesItems on s.Text equals ((Asset)r.Tag).RepoName into sr
                                     from s2 in sr.DefaultIfEmpty()
                                     where s2 == null
                                     select (Repository)s.Tag).ToList();
                    solutions.ForEach(r =>
                    {
                        if (_releasesDock.LvReleases.GetGroups().Any(g => g.Name == r.Name)) return;

                        _releasesDock.LvReleases.AddGroup(r.Name, r.Name);
                    });
                    RepoAuthorGroup = lvGitHubSolutions.GetGroups();
                    foreach (var repo in solutions)
                    {
                        var releases = new List<Release>();
                        worker.ReportProgress(0, $"Retrieving releases for {repo} from GitHub..");
                        var allReleases = _gitHubClient.Repository.Release.GetAll(repo.Owner.Login, repo.Name).Result;
                        var lastThreeReleases = allReleases
                                                .Take(3)
                                                .OrderByDescending(r => r.CreatedAt.DateTime)
                                                .ToList();
                        releases.AddRange(lastThreeReleases);
                        foreach (var release in releases)
                        {
                            var latestAssets = (release.Assets
                                .Where(a => a.ContentType == "application/x-zip-compressed" ||
                                            a.ContentType == "application/zip")
                                .Select(a => new Asset
                                {
                                    ReleaseUrl = release.HtmlUrl,
                                    RepoName = repo.Name,
                                    Owner = repo.Owner.Login,
                                    BrowserDownloadUrl = a.BrowserDownloadUrl,
                                    Label = a.Label,
                                    Name = a.Name,
                                    Size = a.Size,
                                    UpdatedAt = a.UpdatedAt.DateTime.ToLocalTime().ToString("d"),
                                    IsPreRelease = release.Prerelease,
                                    AssetName = release.Name,
                                    AssetBody = release.Body,
                                    AssetTag = release.TagName,
                                    AssetPublishedAt = release.PublishedAt.Value.DateTime.ToLocalTime().ToString("d"),
                                    DownloadCount = a.DownloadCount
                                })).ToList();
                            downloadableAssets.AddRange(latestAssets);
                        }
                    }
                    args.Result = downloadableAssets;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error?.InnerException is RateLimitExceededException rateLimitException)
                    {
                        HandleRateLimitException(rateLimitException);
                        return;
                    }
                    EnableItems();
                    ShowInfoNotification("Install pre-release solutions with caution", null);
                    var downloadableAssets = (List<Asset>)args.Result;
                    _releases = downloadableAssets.Select(asset => new ListViewItem
                    {
                        Text = asset.Name,
                        SubItems =
                        {
                            asset.DownloadCount.ToString(),
                            asset.AssetPublishedAt,
                            asset.IsPreRelease.ToYesNo(),
                            asset.AssetTag
                        },
                        ToolTipText = asset.AssetBody,
                        Tag = asset,
                        ForeColor = asset.IsPreRelease ? Color.PaleVioletRed : Color.Black,
                        Group = _releasesDock.LvReleases.Groups[asset.RepoName]
                    }).ToArray();
                    _releasesDock.LvReleases.Items.AddRange(_releases);
                    _releasesDock.LvReleases.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                },
                ProgressChanged = e => SetWorkingMessage(e.UserState.ToString())
            });
        }

        public void lvReleases_ItemChecked(int checkedItems)
        {
            tsbInstallSolution.Enabled = checkedItems > 0;
        } 
        #endregion
    }
}