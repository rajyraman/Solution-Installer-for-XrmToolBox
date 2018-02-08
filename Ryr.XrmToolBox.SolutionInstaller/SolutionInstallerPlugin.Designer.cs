namespace Ryr.XrmToolBox.SolutionInstaller
{
    partial class SolutionInstallerPlugin
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolutionInstallerPlugin));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tstGitHubKey = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.gbGitHubSolutions = new System.Windows.Forms.GroupBox();
            this.scSolutions = new System.Windows.Forms.SplitContainer();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvGitHubSolutions = new System.Windows.Forms.ListView();
            this.isSolutionSelected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.solution = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.releaseDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.isPreRelease = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.downloadCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbInstalledSolutions = new System.Windows.Forms.GroupBox();
            this.lvInstalledSolutions = new System.Windows.Forms.ListView();
            this.solutionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uniqueName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.isManaged = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.publisher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.installed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.gbSolutions = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tsbRetrieveSolutions = new System.Windows.Forms.ToolStripButton();
            this.tsbInstallSolution = new System.Windows.Forms.ToolStripButton();
            this.tsbUninstall = new System.Windows.Forms.ToolStripButton();
            this.tsbAddOrg = new System.Windows.Forms.ToolStripButton();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.gbGitHubSolutions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scSolutions)).BeginInit();
            this.scSolutions.Panel1.SuspendLayout();
            this.scSolutions.Panel2.SuspendLayout();
            this.scSolutions.SuspendLayout();
            this.gbInstalledSolutions.SuspendLayout();
            this.gbSearch.SuspendLayout();
            this.gbSolutions.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.tsbRetrieveSolutions,
            this.toolStripSeparator1,
            this.tsbInstallSolution,
            this.toolStripSeparator2,
            this.tsbUninstall,
            this.toolStripSeparator4,
            this.tsbAddOrg,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.tstGitHubKey,
            this.toolStripSeparator5});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(2228, 48);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 48);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 48);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 48);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 48);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(220, 45);
            this.toolStripLabel1.Text = "GitHub API Key";
            // 
            // tstGitHubKey
            // 
            this.tstGitHubKey.BackColor = System.Drawing.SystemColors.Window;
            this.tstGitHubKey.Name = "tstGitHubKey";
            this.tstGitHubKey.Size = new System.Drawing.Size(410, 48);
            this.tstGitHubKey.ToolTipText = "Enter a GitHub API Key, if you have one. Calls might be throttled, if you don\'t h" +
    "ave one.";
            this.tstGitHubKey.TextChanged += new System.EventHandler(this.tstGitHubKey_TextChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 48);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 48);
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 48);
            this.scMain.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.gbGitHubSolutions);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.gbInstalledSolutions);
            this.scMain.Size = new System.Drawing.Size(2228, 2232);
            this.scMain.SplitterDistance = 1312;
            this.scMain.SplitterWidth = 10;
            this.scMain.TabIndex = 5;
            // 
            // gbGitHubSolutions
            // 
            this.gbGitHubSolutions.Controls.Add(this.scSolutions);
            this.gbGitHubSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbGitHubSolutions.Enabled = false;
            this.gbGitHubSolutions.Location = new System.Drawing.Point(0, 0);
            this.gbGitHubSolutions.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.gbGitHubSolutions.Name = "gbGitHubSolutions";
            this.gbGitHubSolutions.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.gbGitHubSolutions.Size = new System.Drawing.Size(1312, 2232);
            this.gbGitHubSolutions.TabIndex = 0;
            this.gbGitHubSolutions.TabStop = false;
            this.gbGitHubSolutions.Text = "Available GitHub Solutions";
            // 
            // scSolutions
            // 
            this.scSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scSolutions.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scSolutions.Location = new System.Drawing.Point(8, 45);
            this.scSolutions.Name = "scSolutions";
            this.scSolutions.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scSolutions.Panel1
            // 
            this.scSolutions.Panel1.Controls.Add(this.gbSearch);
            this.scSolutions.Panel1.Controls.Add(this.label1);
            this.scSolutions.Panel1MinSize = 10;
            // 
            // scSolutions.Panel2
            // 
            this.scSolutions.Panel2.Controls.Add(this.gbSolutions);
            this.scSolutions.Size = new System.Drawing.Size(1296, 2178);
            this.scSolutions.SplitterDistance = 40;
            this.scSolutions.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(3, 39);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(1290, 43);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            // 
            // lvGitHubSolutions
            // 
            this.lvGitHubSolutions.CheckBoxes = true;
            this.lvGitHubSolutions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.isSolutionSelected,
            this.downloadCount,
            this.solution,
            this.releaseDate,
            this.isPreRelease,
            this.tag});
            this.lvGitHubSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvGitHubSolutions.FullRowSelect = true;
            this.lvGitHubSolutions.GridLines = true;
            this.lvGitHubSolutions.Location = new System.Drawing.Point(3, 39);
            this.lvGitHubSolutions.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.lvGitHubSolutions.Name = "lvGitHubSolutions";
            this.lvGitHubSolutions.ShowItemToolTips = true;
            this.lvGitHubSolutions.Size = new System.Drawing.Size(1290, 2092);
            this.lvGitHubSolutions.TabIndex = 0;
            this.lvGitHubSolutions.TileSize = new System.Drawing.Size(250, 50);
            this.lvGitHubSolutions.UseCompatibleStateImageBehavior = false;
            this.lvGitHubSolutions.View = System.Windows.Forms.View.Details;
            this.lvGitHubSolutions.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvGitHubSolutions_ColumnClick);
            this.lvGitHubSolutions.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvGitHubSolutions_ItemChecked);
            this.lvGitHubSolutions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvGitHubSolutions_MouseDoubleClick);
            // 
            // isSolutionSelected
            // 
            this.isSolutionSelected.Text = "";
            // 
            // solution
            // 
            this.solution.Text = "Solution";
            // 
            // releaseDate
            // 
            this.releaseDate.Text = "Release Date";
            // 
            // isPreRelease
            // 
            this.isPreRelease.Text = "Pre-release";
            // 
            // tag
            // 
            this.tag.Text = "Tag";
            // 
            // downloadCount
            // 
            this.downloadCount.Text = "Downloads";
            // 
            // gbInstalledSolutions
            // 
            this.gbInstalledSolutions.Controls.Add(this.lvInstalledSolutions);
            this.gbInstalledSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInstalledSolutions.Location = new System.Drawing.Point(0, 0);
            this.gbInstalledSolutions.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.gbInstalledSolutions.Name = "gbInstalledSolutions";
            this.gbInstalledSolutions.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.gbInstalledSolutions.Size = new System.Drawing.Size(906, 2232);
            this.gbInstalledSolutions.TabIndex = 0;
            this.gbInstalledSolutions.TabStop = false;
            this.gbInstalledSolutions.Text = "Dynamics CRM/365 Solutions";
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
            this.lvInstalledSolutions.Location = new System.Drawing.Point(8, 45);
            this.lvInstalledSolutions.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.lvInstalledSolutions.MultiSelect = false;
            this.lvInstalledSolutions.Name = "lvInstalledSolutions";
            this.lvInstalledSolutions.ShowItemToolTips = true;
            this.lvInstalledSolutions.Size = new System.Drawing.Size(890, 2178);
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
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.txtSearch);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSearch.Location = new System.Drawing.Point(0, 0);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(1296, 40);
            this.gbSearch.TabIndex = 2;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Search";
            // 
            // gbSolutions
            // 
            this.gbSolutions.Controls.Add(this.lvGitHubSolutions);
            this.gbSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSolutions.Location = new System.Drawing.Point(0, 0);
            this.gbSolutions.Name = "gbSolutions";
            this.gbSolutions.Size = new System.Drawing.Size(1296, 2134);
            this.gbSolutions.TabIndex = 1;
            this.gbSolutions.TabStop = false;
            this.gbSolutions.Text = "Available Solutions";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(23, 45);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tsbRetrieveSolutions
            // 
            this.tsbRetrieveSolutions.Image = ((System.Drawing.Image)(resources.GetObject("tsbRetrieveSolutions.Image")));
            this.tsbRetrieveSolutions.Name = "tsbRetrieveSolutions";
            this.tsbRetrieveSolutions.Size = new System.Drawing.Size(275, 45);
            this.tsbRetrieveSolutions.Text = "Retrieve Solutions";
            this.tsbRetrieveSolutions.Click += new System.EventHandler(this.tsbRetrieveSolutions_Click);
            // 
            // tsbInstallSolution
            // 
            this.tsbInstallSolution.Enabled = false;
            this.tsbInstallSolution.Image = ((System.Drawing.Image)(resources.GetObject("tsbInstallSolution.Image")));
            this.tsbInstallSolution.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInstallSolution.Name = "tsbInstallSolution";
            this.tsbInstallSolution.Size = new System.Drawing.Size(233, 45);
            this.tsbInstallSolution.Text = "Install Solution";
            this.tsbInstallSolution.Click += new System.EventHandler(this.tsbInstallSolution_Click);
            // 
            // tsbUninstall
            // 
            this.tsbUninstall.Image = ((System.Drawing.Image)(resources.GetObject("tsbUninstall.Image")));
            this.tsbUninstall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUninstall.Name = "tsbUninstall";
            this.tsbUninstall.Size = new System.Drawing.Size(270, 45);
            this.tsbUninstall.Text = "Uninstall Solution";
            this.tsbUninstall.Click += new System.EventHandler(this.tsbUninstall_Click);
            // 
            // tsbAddOrg
            // 
            this.tsbAddOrg.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddOrg.Image")));
            this.tsbAddOrg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddOrg.Name = "tsbAddOrg";
            this.tsbAddOrg.Size = new System.Drawing.Size(211, 45);
            this.tsbAddOrg.Text = "Add Instance";
            this.tsbAddOrg.Click += new System.EventHandler(this.tsbAddOrg_Click);
            // 
            // SolutionInstallerPlugin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.toolStripMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "SolutionInstallerPlugin";
            this.Size = new System.Drawing.Size(2228, 2280);
            this.Load += new System.EventHandler(this.SolutionInstallerPlugin_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.gbGitHubSolutions.ResumeLayout(false);
            this.scSolutions.Panel1.ResumeLayout(false);
            this.scSolutions.Panel1.PerformLayout();
            this.scSolutions.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scSolutions)).EndInit();
            this.scSolutions.ResumeLayout(false);
            this.gbInstalledSolutions.ResumeLayout(false);
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.gbSolutions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbRetrieveSolutions;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbInstallSolution;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.GroupBox gbGitHubSolutions;
        private System.Windows.Forms.GroupBox gbInstalledSolutions;
        private System.Windows.Forms.ListView lvInstalledSolutions;
        private System.Windows.Forms.ColumnHeader solutionName;
        private System.Windows.Forms.ColumnHeader uniqueName;
        private System.Windows.Forms.ColumnHeader version;
        private System.Windows.Forms.ColumnHeader installed;
        private System.Windows.Forms.ListView lvGitHubSolutions;
        private System.Windows.Forms.ColumnHeader solution;
        private System.Windows.Forms.ColumnHeader releaseDate;
        private System.Windows.Forms.ColumnHeader tag;
        private System.Windows.Forms.ColumnHeader isSolutionSelected;
        private System.Windows.Forms.ColumnHeader downloadCount;
        private System.Windows.Forms.ColumnHeader publisher;
        private System.Windows.Forms.ColumnHeader isManaged;
        private System.Windows.Forms.ColumnHeader isPreRelease;
        private System.Windows.Forms.ToolStripButton tsbAddOrg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tstGitHubKey;
        private System.Windows.Forms.SplitContainer scSolutions;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbUninstall;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.GroupBox gbSolutions;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
