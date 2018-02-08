namespace Ryr.XrmToolBox.SolutionInstaller
{
    partial class InstallSolution
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReleaseNotes = new System.Windows.Forms.RichTextBox();
            this.messageLabel = new System.Windows.Forms.Label();
            this.installButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.lbSolutions = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbConnections = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.messageLabel);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1643, 1092);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Install Solutions";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.lbConnections);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.lbSolutions);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.txtReleaseNotes);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 39);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1637, 1050);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(3, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 38);
            this.label3.TabIndex = 2;
            this.label3.Text = "Release Notes";
            // 
            // txtReleaseNotes
            // 
            this.txtReleaseNotes.Location = new System.Drawing.Point(3, 415);
            this.txtReleaseNotes.Name = "txtReleaseNotes";
            this.txtReleaseNotes.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtReleaseNotes.Size = new System.Drawing.Size(1616, 618);
            this.txtReleaseNotes.TabIndex = 3;
            this.txtReleaseNotes.Text = "";
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(21, 34);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(89, 38);
            this.messageLabel.TabIndex = 0;
            this.messageLabel.Text = "Install";
            // 
            // installButton
            // 
            this.installButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.installButton.Location = new System.Drawing.Point(1189, 1122);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(275, 54);
            this.installButton.TabIndex = 1;
            this.installButton.Text = "Install Solutions";
            this.installButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(1486, 1122);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(169, 53);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // lbSolutions
            // 
            this.lbSolutions.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSolutions.FormattingEnabled = true;
            this.lbSolutions.ItemHeight = 37;
            this.lbSolutions.Location = new System.Drawing.Point(3, 182);
            this.lbSolutions.Name = "lbSolutions";
            this.lbSolutions.Size = new System.Drawing.Size(857, 189);
            this.lbSolutions.TabIndex = 5;
            this.lbSolutions.SelectedIndexChanged += new System.EventHandler(this.lbSolutions_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "Connections";
            // 
            // lbConnections
            // 
            this.lbConnections.Enabled = false;
            this.lbConnections.FormattingEnabled = true;
            this.lbConnections.ItemHeight = 37;
            this.lbConnections.Location = new System.Drawing.Point(3, 41);
            this.lbConnections.Name = "lbConnections";
            this.lbConnections.Size = new System.Drawing.Size(857, 78);
            this.lbConnections.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 38);
            this.label2.TabIndex = 7;
            this.label2.Text = "Solutions";
            // 
            // InstallSolution
            // 
            this.AcceptButton = this.installButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1672, 1210);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.installButton);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstallSolution";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Install Solutions";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtReleaseNotes;
        private System.Windows.Forms.Button installButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ListBox lbSolutions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbConnections;
        private System.Windows.Forms.Label label2;
    }
}