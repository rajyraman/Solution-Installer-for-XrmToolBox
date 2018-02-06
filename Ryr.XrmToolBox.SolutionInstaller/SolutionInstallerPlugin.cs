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
using System.Windows.Forms;
using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Octokit;
using Ryr.XrmToolBox.SolutionInstaller.Extensions;
using Ryr.XrmToolBox.SolutionInstaller.Properties;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;

namespace Ryr.XrmToolBox.SolutionInstaller
{
    public partial class SolutionInstallerPlugin : MultipleConnectionsPluginControlBase, IGitHubPlugin, IPayPalPlugin,
        IHelpPlugin, IStatusBarMessenger
    {
        private readonly Dictionary<string, List<string>> _authorRepos = new Dictionary<string, List<string>>
        {
            {"a33ik", new List<string>{"UltimateWorkflowToolkit"}},
            {"demianrasko", new List<string>{"Dynamics-365-Workflow-Tools"}},
            {"jlattimer", new List<string>{"CRMCodeEditor", "CRMRESTBuilder"}},
            {"rajyraman", new List<string>{"Personal-View-to-System-View"}},
            {"rtebar", new List<string>{"dynamics-custom-emails"}},
            {"scottdurow", new List<string>{"RibbonWorkbench","NetworkView"}},
            {"mscrmtools", new List<string>{"ApplicationParameters"}},
            {"daryllabar", new List<string>{"XrmAutoNumberGenerator"}},
        };

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
                Message = "Retrieving solutions from GitHub..",
                Work = (worker, args) =>
                {
                    HideNotification();
                    _authorRepos.ToList().ForEach(r =>
                    {
                        var user = _gitHubClient.User.Get(r.Key).Result;
                        lvGitHubSolutions.AddGroup($"{user.Name} (@{user.Login})", r.Key);
                    });
                    _lvGroups = lvGitHubSolutions.Groups.Cast<ListViewGroup>().ToList();
                    var downloadableAssets = new List<Asset>();

                    foreach (var authorRepo in _authorRepos)
                    {
                        var releases = new List<Release>();
                        authorRepo.Value.ForEach(x =>
                        {
                            worker.ReportProgress(0, $"Retrieving releases for {x} from GitHub..");
                            releases.AddRange(_gitHubClient.Repository.Release.GetAll(authorRepo.Key, x).Result.Take(3)
                                .OrderByDescending(r => r.CreatedAt.DateTime).ToList());
                        });
                        foreach (var repo in authorRepo.Value)
                        {
                            var lastThreeReleases = _gitHubClient.Repository.Release.GetAll(authorRepo.Key, repo).Result.Take(3)
                                    .OrderByDescending(r => r.CreatedAt.DateTime).ToList();
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
                                    Author = authorRepo.Key,
                                    BrowserDownloadUrl = a.BrowserDownloadUrl,
                                    Label = a.Label,
                                    Name = a.Name,
                                    Size = a.Size,
                                    UpdatedAt = a.UpdatedAt.DateTime.ToString("d"),
                                    IsPreRelease = release.Prerelease,
                                    AssetName = release.Name,
                                    AssetBody = release.Body,
                                    AssetTag = release.TagName,
                                    AssetPublishedAt = release.PublishedAt.Value.DateTime.ToString("d"),
                                    DownloadCount = a.DownloadCount
                                })).ToList();
                            downloadableAssets.AddRange(latestAssets);
                        }
                    }
                    args.Result = downloadableAssets;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error?.InnerException is RateLimitExceededException)
                    {
                        ShowErrorNotification("Rate Limit reached (max 60 requests per hr). Use your GitHub API key or please try again later.", new Uri("https://developer.github.com/v3/#rate-limiting"));
                        return;
                    }
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
                        Group = lvGitHubSolutions.Groups[asset.Author]
                    }).ToArray();
                    lvGitHubSolutions.Items.AddRange(_gitHubSolutions);
                    lvGitHubSolutions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
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
        public string DonationDescription => "Please sponsor my coffee if you find this tool useful. Thank you.";
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
            var solutions = string.Join("\n", lvGitHubSolutions.CheckedItems
                .Cast<ListViewItem>()
                .Select(x => $"👉 {x.SubItems[1].Text} 👈").ToList());
            var connections = string.Join("\n", ConnectedOrgs
                .Select(x => $"👉 {x.ConnectionName} 👈").ToList());
            if (MessageBox.Show(
                    $"Clicking Yes will install \n\n{solutions}\n\n in these organizations \n\n{connections}\n\n\n. Do you want to proceed?",
                    "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No) return;

            ExecuteMethod(PublishSolutions);
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

        internal class Asset
        {
            public string BrowserDownloadUrl { get; set; }
            public string Label { get; set; }
            public string Name { get; set; }
            public int Size { get; set; }
            public string UpdatedAt { get; set; }
            public bool IsPreRelease { get; set; }
            public string AssetName { get; set; }
            public string AssetBody { get; set; }
            public string AssetTag { get; set; }
            public string AssetPublishedAt { get; set; }
            public string RepoName { get; set; }
            public int DownloadCount { get; set; }
            public string Author { get; set; }
            public string ReleaseUrl { get; set; }
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
                        x.Group = _lvGroups.FirstOrDefault(g => g.Name == asset.Author);
                    }

                    return x;
                })
                .ToArray();
            }
            var repoOrAuthorName = txtSearch.Text;
            lvGitHubSolutions.BeginUpdate();
            lvGitHubSolutions.Items.Clear();
            lvGitHubSolutions.Groups.AddRange(_lvGroups.ToArray());
            if (string.IsNullOrWhiteSpace(repoOrAuthorName))
            {
                lvGitHubSolutions.Items.AddRange(AddMissingGroups());
            }
            else
            {
                var filteredItems = _gitHubSolutions
                    .Where(item =>
                    {
                        var asset = item.Tag as Asset;
                        return asset.Author.IndexOf(repoOrAuthorName, StringComparison.CurrentCultureIgnoreCase) > -1
                               || asset.AssetName.IndexOf(repoOrAuthorName, StringComparison.CurrentCultureIgnoreCase) > -1
                               || asset.RepoName.IndexOf(repoOrAuthorName, StringComparison.CurrentCultureIgnoreCase) > -1
                               || asset.Name.IndexOf(repoOrAuthorName, StringComparison.CurrentCultureIgnoreCase) > -1;
                    }).Select(x =>
                    {
                        var asset = x.Tag as Asset;
                        if (x.Group == null)
                        {
                            x.Group = _lvGroups.FirstOrDefault(g=>g.Name == asset.Author);
                        }
                        return x;
                    })
                    .ToArray();
                lvGitHubSolutions.Items.AddRange(filteredItems);
            }
            lvGitHubSolutions.EndUpdate();
        }
    }
}