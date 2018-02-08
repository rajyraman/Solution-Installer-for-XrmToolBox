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
using Ryr.XrmToolBox.SolutionInstaller.Extensions;
using Ryr.XrmToolBox.SolutionInstaller.Properties;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;

namespace Ryr.XrmToolBox.SolutionInstaller
{
    public partial class SolutionInstallerPlugin : MultipleConnectionsPluginControlBase, 
        IGitHubPlugin, IPayPalPlugin,
        IHelpPlugin, IMessageBusHost,IStatusBarMessenger
    {
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

        public List<ConnectionDetail> ConnectedOrgs { get; }

        public SolutionInstallerPlugin()
        {
            InitializeComponent();
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

        private readonly GitHubClient _gitHubClient;
        private ListViewItem[] _gitHubSolutions;
        private List<ListViewGroup> _lvGroups;

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
            lvGitHubSolutions.Groups.Clear();
            lvGitHubSolutions.Items.Clear();

            ExecuteMethod(LoadSolutionsFromGitHub);
        }

        private void EnableItems()
        {
            gbGitHubSolutions.Enabled = true;
            tsbInstallSolution.Enabled = true;
        }

        private void LoadSolutionsInCRM()
        {
            lvInstalledSolutions.Groups.Clear();
            lvInstalledSolutions.Items.Clear();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieving managed solutions already installed..",
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
                    var orgsAndSolutions = (Dictionary<ConnectionDetail, List<Entity>>) args.Result;
                    lvInstalledSolutions.Groups.AddRange(
                        orgsAndSolutions
                            .Select(x => new ListViewGroup(x.Key.ConnectionName, x.Key.ConnectionName))
                            .ToArray());
                    foreach (var orgsAndSolution in orgsAndSolutions)
                    {
                        var baseUrl = orgsAndSolution.Key.OriginalUrl.NormaliseUrl();
                        foreach (var solution in orgsAndSolution.Value)
                        {
                            lvInstalledSolutions.Items.Add(new ListViewItem
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
                                Group = lvInstalledSolutions.Groups[orgsAndSolution.Key.ConnectionName]
                            });
                        }
                    }

                    lvInstalledSolutions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
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
                    var repoList =_gitHubClient.Repository.Content
                        .GetAllContents("rajyraman", "Solution-Installer-for-XrmToolBox", "db.json").Result;
                    _ownerRepos = new JavaScriptSerializer()
                                    .Deserialize<List<OwnerRepo>>(repoList[0].Content);
                    SendMessageToStatusBar?.Invoke(this, 
                        new StatusBarMessageEventArgs($"Retrieved {_ownerRepos.Count} solutions from GitHub"));
                    _ownerRepos.ToList().ForEach(r =>
                    {
                        var user = _gitHubClient.User.Get(r.Owner).Result;
                        lvGitHubSolutions.AddGroup($"{user.Name} (@{user.Login})", r.Owner);
                    });
                    _lvGroups = lvGitHubSolutions.Groups.Cast<ListViewGroup>().ToList();
                    var downloadableAssets = new List<Asset>();

                    foreach (var ownerRepo in _ownerRepos)
                    {
                        var releases = new List<Release>();
                        foreach (var repo in ownerRepo.Repos)
                        {
                            worker.ReportProgress(0, $"Retrieving releases for {repo} from GitHub..");
                            var allReleases = _gitHubClient.Repository.Release.GetAll(ownerRepo.Owner, repo).Result;
                            var lastThreeReleases = allReleases
                                                    .Take(3)
                                                    .OrderByDescending(r => r.CreatedAt.DateTime)
                                                    .ToList();
                            releases.AddRange(lastThreeReleases);
                        }
                        foreach (var release in releases)
                        {
                            var latestAssets = (release.Assets
                                .Where(a => a.ContentType == "application/x-zip-compressed" ||
                                            a.ContentType == "application/zip")
                                .Select(a => new Asset
                                {
                                    ReleaseUrl = release.HtmlUrl,
                                    RepoName = release.Name,
                                    Owner = ownerRepo.Owner,
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
                        ShowErrorNotification($"Rate Limit reached. Maximum number of requests per hour is {rateLimitException.Limit}. Please use your GitHub API key or try again after {rateLimitException.Reset.DateTime.ToLocalTime():t}.", new Uri("https://developer.github.com/v3/#rate-limiting"));
                        return;
                    }
                    EnableItems();
                    ShowInfoNotification("Install unmanaged and pre-release solutions with caution", null);
                    var downloadableAssets = (List<Asset>) args.Result;
                    _gitHubSolutions = downloadableAssets.Select(asset => new ListViewItem
                    {
                        Text = asset.RepoName,
                        SubItems =
                        {
                            asset.Name,
                            asset.AssetPublishedAt,
                            asset.IsPreRelease.ToYesNo(),
                            asset.AssetTag,
                            asset.DownloadCount.ToString()
                        },
                        ToolTipText = asset.AssetBody,
                        Tag = asset,
                        ForeColor = asset.IsPreRelease ? Color.PaleVioletRed : Color.Black,
                        Group = lvGitHubSolutions.Groups[asset.Owner]
                    }).ToArray();
                    lvGitHubSolutions.Items.AddRange(_gitHubSolutions);
                    lvGitHubSolutions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                },
                ProgressChanged = e => SetWorkingMessage(e.UserState.ToString())
            });
        }

        private void lvGitHubSolutions_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvGitHubSolutions.Sort(e.Column);
        }

        private void lvInstalledSolutions_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvInstalledSolutions.Sort(e.Column);
        }

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

        public string RepositoryName => "Solution-Installer-for-XrmToolBox";
        public string UserName => "rajyraman";
        public string DonationDescription => "Please sponsor my coffee, if you find this tool useful. Thank you.";
        public string EmailAccount => "natraj.y@gmail.com";
        public string HelpUrl => "https://github.com/rajyraman/Solution-Installer-for-XrmToolBox/README.md";

        public event EventHandler<StatusBarMessageEventArgs> SendMessageToStatusBar;

        private void tsbAddOrg_Click(object sender, EventArgs e)
        {
            AddAdditionalOrganization();
        }

        private void SolutionInstallerPlugin_Load(object sender, EventArgs e)
        {
            ConnectedOrgs.Add(ConnectionDetail);
            ExecuteMethod(LoadSolutionsInCRM);
        }

        private void lvGitHubSolutions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var solutionListViewItemTest = ((ListView) sender).HitTest(e.X, e.Y);
            Process.Start(((Asset)solutionListViewItemTest.Item.Tag).ReleaseUrl);
        }

        private void tsbInstallSolution_Click(object sender, EventArgs e)
        {
            var solutions = lvGitHubSolutions.CheckedItems
                .Cast<ListViewItem>()
                .Select(x=> x.SubItems[1].Text)
                .ToArray();

            var connections = ConnectedOrgs
                .Select(x => x.ConnectionName).ToArray();

            var releaseNotes = lvGitHubSolutions.CheckedItems
                .Cast<ListViewItem>()
                .Select(x => (Asset)x.Tag).ToList();
            if (DialogResult.OK == 
                new InstallSolution(solutions, connections, releaseNotes).ShowDialog(this))
            {
                ExecuteMethod(PublishSolutions);
            }
        }

        private void PublishSolutions()
        {
            var importErrors = new Dictionary<string, string>();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Downloading solution files from GitHub..",
                IsCancelable = true,
                Work = (worker, args) =>
                {
                    using (var webClient = new WebClient())
                    {
                        var solutions = lvGitHubSolutions.GetCheckedItems()
                            .Select(x =>
                            {
                                var asset = (Asset) x.Tag;
                                worker.ReportProgress(0, $"Downloading {asset.Name} from GitHub..");
                                return new KeyValuePair<string, byte[]>(asset.Name,
                                    webClient.DownloadData(asset.BrowserDownloadUrl));
                            })
                            .ToList();
                        foreach (var connectedOrg in ConnectedOrgs)
                        {
                            foreach (var s in solutions)
                            {
                                worker.ReportProgress(0,
                                    $"Importing {s.Key} to {connectedOrg.ConnectionName}..");
                                try
                                {
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
                                        $"Org {connectedOrg.ConnectionName}, Solution {s.Key}. {ex.Message}");
                                }
                            }
                        }

                        args.Result = solutions;
                    }
                },
                PostWorkCallBack = (args) =>
                {
                    if (importErrors.Any())
                    {
                        ShowErrorNotification(string.Join(Environment.NewLine, importErrors.Select(x=>x.Value).ToList()), null);
                        importErrors.Clear();
                    }
                    ExecuteMethod(LoadSolutionsInCRM);
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
        }

        private void lvInstalledSolutions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var installedSolutionListViewItemTest = ((ListView)sender).HitTest(e.X, e.Y);
            Process.Start(installedSolutionListViewItemTest.Item.Tag.ToString());
        }

        private void tstGitHubKey_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tstGitHubKey.Text))
            {
                _gitHubClient.Credentials = new Credentials(tstGitHubKey.Text);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            ListViewItem[] AddMissingGroups()
            {
                return _gitHubSolutions.Select(x =>
                {
                    var asset = x.Tag as Asset;
                    if (x.Group == null)
                    {
                        x.Group = _lvGroups.FirstOrDefault(g => g.Name == asset.Owner);
                    }

                    return x;
                })
                .ToArray();
            }
            var repoOrOwnerName = txtSearch.Text;
            lvGitHubSolutions.BeginUpdate();
            lvGitHubSolutions.Items.Clear();
            lvGitHubSolutions.Groups.AddRange(_lvGroups.ToArray());
            if (string.IsNullOrWhiteSpace(repoOrOwnerName))
            {
                lvGitHubSolutions.Items.AddRange(AddMissingGroups());
            }
            else
            {
                var filteredItems = _gitHubSolutions
                    .Where(item =>
                    {
                        var asset = item.Tag as Asset;
                        return asset.Owner.IndexOf(repoOrOwnerName, StringComparison.CurrentCultureIgnoreCase) > -1
                               || asset.AssetName.IndexOf(repoOrOwnerName, StringComparison.CurrentCultureIgnoreCase) > -1
                               || asset.RepoName.IndexOf(repoOrOwnerName, StringComparison.CurrentCultureIgnoreCase) > -1
                               || asset.Name.IndexOf(repoOrOwnerName, StringComparison.CurrentCultureIgnoreCase) > -1;
                    }).Select(x =>
                    {
                        var asset = x.Tag as Asset;
                        if (x.Group == null)
                        {
                            x.Group = _lvGroups.FirstOrDefault(g=>g.Name == asset.Owner);
                        }
                        return x;
                    })
                    .ToArray();
                lvGitHubSolutions.Items.AddRange(filteredItems);
            }
            lvGitHubSolutions.EndUpdate();
        }

        private void tsbUninstall_Click(object sender, EventArgs e)
        {
            var messageBusEventArgs = new MessageBusEventArgs("Managed Solution Deletion Tool");
            OnOutgoingMessage?.Invoke(this, messageBusEventArgs);
        }

        public void OnIncomingMessage(MessageBusEventArgs message)
        {
            if (message.SourcePlugin != "Managed Solution Deletion Tool") return;

            ExecuteMethod(LoadSolutionsInCRM);
        }

        public event EventHandler<MessageBusEventArgs> OnOutgoingMessage;

        private void lvGitHubSolutions_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            tsbInstallSolution.Enabled = lvGitHubSolutions.CheckedItems.Count > 0;
        }
    }
}