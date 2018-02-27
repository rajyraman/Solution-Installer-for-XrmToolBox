using System.Diagnostics;
using Ryr.XrmToolBox.SolutionInstaller.Extensions;
using System.Windows.Forms;

namespace Ryr.XrmToolBox.SolutionInstaller.DockPanels
{
    public class InstalledSolutionsDockContent : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        private ListView lvInstalledSolutions;
        private ColumnHeader solutionName;
        private ColumnHeader uniqueName;
        private ColumnHeader isManaged;
        private ColumnHeader publisher;
        private ColumnHeader version;
        private ColumnHeader installed;
        private DockMessager _messager;

        public InstalledSolutionsDockContent(DockMessager messager)
        {
            InitializeComponent();
            _messager = messager;
        }

        public ListView LvInstalledSolutions => lvInstalledSolutions;

        private void InitializeComponent()
        {
            this.lvInstalledSolutions = new System.Windows.Forms.ListView();
            this.solutionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uniqueName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.isManaged = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.publisher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.installed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvInstalledSolutions
            // 
            this.lvInstalledSolutions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.solutionName,
            this.uniqueName,
            this.isManaged,
            this.publisher,
            this.version,
            this.installed});
            this.lvInstalledSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvInstalledSolutions.FullRowSelect = true;
            this.lvInstalledSolutions.GridLines = true;
            this.lvInstalledSolutions.Location = new System.Drawing.Point(0, 0);
            this.lvInstalledSolutions.Name = "lvInstalledSolutions";
            this.lvInstalledSolutions.Size = new System.Drawing.Size(1199, 1361);
            this.lvInstalledSolutions.TabIndex = 0;
            this.lvInstalledSolutions.UseCompatibleStateImageBehavior = false;
            this.lvInstalledSolutions.View = System.Windows.Forms.View.Details;
            this.lvInstalledSolutions.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvInstalledSolutions_ColumnClick);
            this.lvInstalledSolutions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvInstalledSolutions_MouseDoubleClick);
            // 
            // solutionName
            // 
            this.solutionName.Text = "Solution Name";
            this.solutionName.Width = 266;
            // 
            // uniqueName
            // 
            this.uniqueName.Text = "Unique Name";
            this.uniqueName.Width = 120;
            // 
            // isManaged
            // 
            this.isManaged.Text = "Managed";
            // 
            // publisher
            // 
            this.publisher.Text = "Publisher";
            // 
            // version
            // 
            this.version.Text = "Version";
            // 
            // installed
            // 
            this.installed.Text = "Installed";
            this.installed.Width = 120;
            // 
            // InstalledSolutionsDockContent
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1199, 1361);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.lvInstalledSolutions);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Name = "InstalledSolutionsDockContent";
            this.Text = "Installed Solutions";
            this.ResumeLayout(false);

        }

        private void lvInstalledSolutions_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvInstalledSolutions.Sort(e.Column);
        }

        private void lvInstalledSolutions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var installedSolutionListViewItemTest = ((ListView)sender).HitTest(e.X, e.Y);
            Process.Start(installedSolutionListViewItemTest.Item.Tag.ToString());
        }
    }
}
