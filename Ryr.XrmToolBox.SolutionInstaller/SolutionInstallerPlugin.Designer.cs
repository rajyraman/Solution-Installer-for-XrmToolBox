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
            this.tsbUninstall = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAddOrg = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tslGitHubKey = new System.Windows.Forms.ToolStripLabel();
            this.tstGitHubKey = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.mainDockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.toolStripMenu.SuspendLayout();
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
            this.tsbReset,
            this.toolStripSeparator6,
            this.tslGitHubKey,
            this.tstGitHubKey,
            this.toolStripSeparator5});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(2228, 48);
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
            this.tsbRetrieveSolutions.Size = new System.Drawing.Size(299, 45);
            this.tsbRetrieveSolutions.Text = "Retrieve Solutions";
            this.tsbRetrieveSolutions.Click += new System.EventHandler(this.tsbRetrieveSolutions_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbInstallSolution
            // 
            this.tsbInstallSolution.Enabled = false;
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
            // tsbUninstall
            // 
            this.tsbUninstall.Image = ((System.Drawing.Image)(resources.GetObject("tsbUninstall.Image")));
            this.tsbUninstall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUninstall.Name = "tsbUninstall";
            this.tsbUninstall.Size = new System.Drawing.Size(294, 45);
            this.tsbUninstall.Text = "Uninstall Solution";
            this.tsbUninstall.Click += new System.EventHandler(this.tsbUninstall_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbAddOrg
            // 
            this.tsbAddOrg.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddOrg.Image")));
            this.tsbAddOrg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddOrg.Name = "tsbAddOrg";
            this.tsbAddOrg.Size = new System.Drawing.Size(235, 45);
            this.tsbAddOrg.Text = "Add Instance";
            this.tsbAddOrg.Click += new System.EventHandler(this.tsbAddOrg_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbReset
            // 
            this.tsbReset.Image = ((System.Drawing.Image)(resources.GetObject("tsbReset.Image")));
            this.tsbReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReset.Name = "tsbReset";
            this.tsbReset.Size = new System.Drawing.Size(134, 45);
            this.tsbReset.Text = "Reset";
            this.tsbReset.Click += new System.EventHandler(this.tsbReset_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 48);
            // 
            // tslGitHubKey
            // 
            this.tslGitHubKey.Name = "tslGitHubKey";
            this.tslGitHubKey.Size = new System.Drawing.Size(220, 45);
            this.tslGitHubKey.Text = "GitHub API Key";
            this.tslGitHubKey.Visible = false;
            // 
            // tstGitHubKey
            // 
            this.tstGitHubKey.BackColor = System.Drawing.SystemColors.Window;
            this.tstGitHubKey.Name = "tstGitHubKey";
            this.tstGitHubKey.Size = new System.Drawing.Size(410, 48);
            this.tstGitHubKey.ToolTipText = "Enter a GitHub API Key, if you have one. Calls might be throttled, if you don\'t h" +
    "ave one.";
            this.tstGitHubKey.Visible = false;
            this.tstGitHubKey.TextChanged += new System.EventHandler(this.tstGitHubKey_TextChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 48);
            // 
            // mainDockPanel
            // 
            this.mainDockPanel.AutoSize = true;
            this.mainDockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainDockPanel.DockLeftPortion = 0.6D;
            this.mainDockPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.mainDockPanel.Location = new System.Drawing.Point(0, 48);
            this.mainDockPanel.Name = "mainDockPanel";
            this.mainDockPanel.Size = new System.Drawing.Size(2228, 2232);
            this.mainDockPanel.TabIndex = 6;
            // 
            // SolutionInstallerPlugin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainDockPanel);
            this.Controls.Add(this.toolStripMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "SolutionInstallerPlugin";
            this.Size = new System.Drawing.Size(2228, 2280);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
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
        private System.Windows.Forms.ToolStripButton tsbAddOrg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel tslGitHubKey;
        private System.Windows.Forms.ToolStripTextBox tstGitHubKey;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbUninstall;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripButton tsbReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private WeifenLuo.WinFormsUI.Docking.DockPanel mainDockPanel;
    }
}
