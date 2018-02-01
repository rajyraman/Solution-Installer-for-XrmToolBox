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
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRetrieveSolutions = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbInstallSolution = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAddOrg = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tstGitHubKey = new System.Windows.Forms.ToolStripTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvGitHubSolutions = new System.Windows.Forms.ListView();
            this.isSolutionSelected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.solution = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.releaseDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.isPreRelease = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.downloadCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvInstalledSolutions = new System.Windows.Forms.ListView();
            this.solutionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uniqueName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.isManaged = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.publisher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.installed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.tsbAddOrg,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.tstGitHubKey});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(2376, 48);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(44, 45);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbRetrieveSolutions
            // 
            this.tsbRetrieveSolutions.Image = ((System.Drawing.Image)(resources.GetObject("tsbRetrieveSolutions.Image")));
            this.tsbRetrieveSolutions.Name = "tsbRetrieveSolutions";
            this.tsbRetrieveSolutions.Size = new System.Drawing.Size(287, 45);
            this.tsbRetrieveSolutions.Text = "GitHub Solutions";
            this.tsbRetrieveSolutions.Click += new System.EventHandler(this.tsbRetrieveSolutions_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbInstallSolution
            // 
            this.tsbInstallSolution.Image = ((System.Drawing.Image)(resources.GetObject("tsbInstallSolution.Image")));
            this.tsbInstallSolution.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInstallSolution.Name = "tsbInstallSolution";
            this.tsbInstallSolution.Size = new System.Drawing.Size(257, 45);
            this.tsbInstallSolution.Text = "Install Solution";
            this.tsbInstallSolution.Click += new System.EventHandler(this.tsbInstallSolution_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbAddOrg
            // 
            this.tsbAddOrg.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddOrg.Image")));
            this.tsbAddOrg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddOrg.Name = "tsbAddOrg";
            this.tsbAddOrg.Size = new System.Drawing.Size(279, 45);
            this.tsbAddOrg.Text = "Add Target Orgs";
            this.tsbAddOrg.Click += new System.EventHandler(this.tsbAddOrg_Click);
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
            this.tstGitHubKey.Size = new System.Drawing.Size(250, 48);
            this.tstGitHubKey.ToolTipText = "Enter a GitHub API Key, if you have one. Calls might be throttled, if you don\'t h" +
    "ave one.";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 48);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(2376, 1862);
            this.splitContainer1.SplitterDistance = 1400;
            this.splitContainer1.SplitterWidth = 11;
            this.splitContainer1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvGitHubSolutions);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox1.Size = new System.Drawing.Size(1400, 1862);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available GitHub Solutions";
            // 
            // lvGitHubSolutions
            // 
            this.lvGitHubSolutions.CheckBoxes = true;
            this.lvGitHubSolutions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.isSolutionSelected,
            this.solution,
            this.releaseDate,
            this.isPreRelease,
            this.tag,
            this.downloadCount});
            this.lvGitHubSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvGitHubSolutions.FullRowSelect = true;
            this.lvGitHubSolutions.GridLines = true;
            this.lvGitHubSolutions.Location = new System.Drawing.Point(8, 38);
            this.lvGitHubSolutions.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.lvGitHubSolutions.Name = "lvGitHubSolutions";
            this.lvGitHubSolutions.ShowItemToolTips = true;
            this.lvGitHubSolutions.Size = new System.Drawing.Size(1384, 1817);
            this.lvGitHubSolutions.TabIndex = 0;
            this.lvGitHubSolutions.TileSize = new System.Drawing.Size(250, 50);
            this.lvGitHubSolutions.UseCompatibleStateImageBehavior = false;
            this.lvGitHubSolutions.View = System.Windows.Forms.View.Details;
            this.lvGitHubSolutions.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvGitHubSolutions_ColumnClick);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvInstalledSolutions);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox2.Size = new System.Drawing.Size(965, 1862);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dynamics CRM/365 Solutions";
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
            this.lvInstalledSolutions.Location = new System.Drawing.Point(8, 38);
            this.lvInstalledSolutions.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.lvInstalledSolutions.MultiSelect = false;
            this.lvInstalledSolutions.Name = "lvInstalledSolutions";
            this.lvInstalledSolutions.ShowItemToolTips = true;
            this.lvInstalledSolutions.Size = new System.Drawing.Size(949, 1817);
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
            // SolutionInstallerPlugin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "SolutionInstallerPlugin";
            this.Size = new System.Drawing.Size(2376, 1910);
            this.Load += new System.EventHandler(this.SolutionInstallerPlugin_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
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
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
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
    }
}
