using System;
using System.Diagnostics;
using System.Linq;
using Ryr.XrmToolBox.SolutionInstaller.Extensions;
using System.Windows.Forms;
using Octokit;
using WeifenLuo.WinFormsUI.Docking;
using Label = System.Windows.Forms.Label;

namespace Ryr.XrmToolBox.SolutionInstaller.DockPanels
{
    public class GitHubSolutionsDockContent : DockContent
    {
        private ListView lvGitHubSolutions;
        private ColumnHeader projectName;
        private ColumnHeader stars;
        private TextBox txtSearch;
        private ColumnHeader repoDescription;
        private SolutionInstallerPlugin _parent;
        private GroupBox groupBox1;
        private DockMessager _messager;

        public GitHubSolutionsDockContent(DockMessager messager)
        {
            InitializeComponent();
            _messager = messager;
        }

        public ListView LvGitHubSolutions => lvGitHubSolutions;
        public TextBox TxtSearch => txtSearch;

        private void InitializeComponent()
        {
            this.lvGitHubSolutions = new System.Windows.Forms.ListView();
            this.projectName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stars = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.repoDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvGitHubSolutions
            // 
            this.lvGitHubSolutions.CheckBoxes = true;
            this.lvGitHubSolutions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.projectName,
            this.stars,
            this.repoDescription});
            this.lvGitHubSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvGitHubSolutions.FullRowSelect = true;
            this.lvGitHubSolutions.GridLines = true;
            this.lvGitHubSolutions.Location = new System.Drawing.Point(0, 50);
            this.lvGitHubSolutions.Name = "lvGitHubSolutions";
            this.lvGitHubSolutions.ShowItemToolTips = true;
            this.lvGitHubSolutions.Size = new System.Drawing.Size(1568, 1490);
            this.lvGitHubSolutions.TabIndex = 4;
            this.lvGitHubSolutions.TileSize = new System.Drawing.Size(250, 50);
            this.lvGitHubSolutions.UseCompatibleStateImageBehavior = false;
            this.lvGitHubSolutions.View = System.Windows.Forms.View.Details;
            this.lvGitHubSolutions.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvGitHubSolutions_ColumnClick);
            this.lvGitHubSolutions.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvGitHubSolutions_ItemChecked);
            this.lvGitHubSolutions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvGitHubSolutions_MouseDoubleClick);
            // 
            // projectName
            // 
            this.projectName.Text = "Name";
            this.projectName.Width = 250;
            // 
            // stars
            // 
            this.stars.Text = "Stars";
            // 
            // repoDescription
            // 
            this.repoDescription.Text = "Description";
            this.repoDescription.Width = 200;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(3, 34);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(1562, 38);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1568, 50);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // GitHubSolutionsDockContent
            // 
            this.ClientSize = new System.Drawing.Size(1568, 1540);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.lvGitHubSolutions);
            this.Controls.Add(this.groupBox1);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft;
            this.Name = "GitHubSolutionsDockContent";
            this.Text = "Available GitHub Solutions";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void lvGitHubSolutions_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvGitHubSolutions.Sort(e.Column);
        }

        private void lvGitHubSolutions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var solutionListViewItemTest = ((ListView)sender).HitTest(e.X, e.Y);
            Process.Start(((Repository)solutionListViewItemTest.Item.Tag).HtmlUrl);
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            ListViewItem[] AddMissingGroups()
            {
                return _messager.Repos.Select(x =>
                    {
                        var asset = x.Tag as Repository;
                        if (x.Group == null)
                        {
                            x.Group = _messager.RepoAuthorGroup.FirstOrDefault(g => g.Name == asset.Owner.Login);
                        }

                        return x;
                    })
                    .ToArray();
            }
            var repoOrOwnerName = txtSearch.Text;
            lvGitHubSolutions.BeginUpdate();
            lvGitHubSolutions.Items.Clear();
            lvGitHubSolutions.Groups.AddRange(_messager.RepoAuthorGroup.ToArray());
            if (string.IsNullOrWhiteSpace(repoOrOwnerName))
            {
                lvGitHubSolutions.Items.AddRange(AddMissingGroups());
            }
            else
            {
                var filteredItems = _messager.Repos
                .Where(item =>
                {
                    var repository = item.Tag as Repository;
                    return repository.Owner.Login.IndexOf(repoOrOwnerName, StringComparison.CurrentCultureIgnoreCase) > -1
                            || repository.Name.IndexOf(repoOrOwnerName, StringComparison.CurrentCultureIgnoreCase) > -1;
                }).Select(x =>
                {
                    var repository = x.Tag as Repository;
                    if (x.Group == null)
                    {
                        x.Group = _messager.RepoAuthorGroup.FirstOrDefault(g => g.Name == repository.Owner.Login);
                    }
                    return x;
                })
                .ToArray();
                lvGitHubSolutions.Items.AddRange(filteredItems);
            }
            lvGitHubSolutions.EndUpdate();
        }

        private void lvGitHubSolutions_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            _messager.SolutionChecked(lvGitHubSolutions, e);
        }
    }
}
