using System.Diagnostics;
using System.Windows.Forms;
using Ryr.XrmToolBox.SolutionInstaller.DefinitionClasses;

namespace Ryr.XrmToolBox.SolutionInstaller.DockPanels
{
    public class GitHubReleasesDockContent : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        private ListView lvReleases;
        private ColumnHeader isReleaseSelected;
        private ColumnHeader releaseDownloadCount;
        private ColumnHeader dateOfRelease;
        private ColumnHeader isReleasePre;
        private ColumnHeader releaseTags;
        private DockMessager _messager;

        public GitHubReleasesDockContent(DockMessager messager)
        {
            InitializeComponent();
            _messager = messager;
        }

        public ListView LvReleases => lvReleases;

        private void InitializeComponent()
        {
            this.lvReleases = new System.Windows.Forms.ListView();
            this.isReleaseSelected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.releaseDownloadCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateOfRelease = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.isReleasePre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.releaseTags = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvReleases
            // 
            this.lvReleases.CheckBoxes = true;
            this.lvReleases.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.isReleaseSelected,
            this.releaseDownloadCount,
            this.dateOfRelease,
            this.isReleasePre,
            this.releaseTags});
            this.lvReleases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReleases.FullRowSelect = true;
            this.lvReleases.GridLines = true;
            this.lvReleases.Location = new System.Drawing.Point(0, 0);
            this.lvReleases.Name = "lvReleases";
            this.lvReleases.Size = new System.Drawing.Size(1007, 1320);
            this.lvReleases.TabIndex = 1;
            this.lvReleases.UseCompatibleStateImageBehavior = false;
            this.lvReleases.View = System.Windows.Forms.View.Details;
            this.lvReleases.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvReleases_ItemChecked);
            this.lvReleases.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvReleases_MouseDoubleClick);
            // 
            // isReleaseSelected
            // 
            this.isReleaseSelected.Text = "Name";
            // 
            // releaseDownloadCount
            // 
            this.releaseDownloadCount.Text = "Downloads";
            // 
            // dateOfRelease
            // 
            this.dateOfRelease.Text = "Release Date";
            // 
            // isReleasePre
            // 
            this.isReleasePre.Text = "Pre-Release";
            // 
            // releaseTags
            // 
            this.releaseTags.Text = "Tags";
            // 
            // GitHubReleasesDockContent
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1007, 1320);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.lvReleases);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Name = "GitHubReleasesDockContent";
            this.Text = "Releases";
            this.ResumeLayout(false);

        }

        private void lvReleases_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            _messager.ReleasesChecked(LvReleases.CheckedItems.Count);
        }

        private void lvReleases_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var solutionListViewItemTest = ((ListView)sender).HitTest(e.X, e.Y);
            Process.Start(((Asset)solutionListViewItemTest.Item.Tag).BrowserDownloadUrl);
        }
    }
}
