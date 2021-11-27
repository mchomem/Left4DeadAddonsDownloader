
namespace Left4DeadAddonsDownloader.UI.Views
{
    partial class SetupForm
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
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.buttonChooseLeft4DeadAddonsFolder = new System.Windows.Forms.Button();
            this.labelLeft4DeadAddonsFolder = new System.Windows.Forms.Label();
            this.textBoxLeft4DeadAddonsFolder = new System.Windows.Forms.TextBox();
            this.textBoxDownloadListUrl = new System.Windows.Forms.TextBox();
            this.labelDownloadListUrl = new System.Windows.Forms.Label();
            this.buttonChooseTemporaryDownloadFolder = new System.Windows.Forms.Button();
            this.textBoxTemporaryDownloadFolder = new System.Windows.Forms.TextBox();
            this.labelTemporaryDownloadFolder = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(516, 226);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 5;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(597, 226);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.buttonChooseLeft4DeadAddonsFolder);
            this.groupBox.Controls.Add(this.labelLeft4DeadAddonsFolder);
            this.groupBox.Controls.Add(this.textBoxLeft4DeadAddonsFolder);
            this.groupBox.Controls.Add(this.textBoxDownloadListUrl);
            this.groupBox.Controls.Add(this.labelDownloadListUrl);
            this.groupBox.Controls.Add(this.buttonChooseTemporaryDownloadFolder);
            this.groupBox.Controls.Add(this.textBoxTemporaryDownloadFolder);
            this.groupBox.Controls.Add(this.labelTemporaryDownloadFolder);
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(660, 183);
            this.groupBox.TabIndex = 3;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "App Settings";
            // 
            // buttonChooseLeft4DeadAddonsFolder
            // 
            this.buttonChooseLeft4DeadAddonsFolder.Location = new System.Drawing.Point(629, 80);
            this.buttonChooseLeft4DeadAddonsFolder.Name = "buttonChooseLeft4DeadAddonsFolder";
            this.buttonChooseLeft4DeadAddonsFolder.Size = new System.Drawing.Size(25, 23);
            this.buttonChooseLeft4DeadAddonsFolder.TabIndex = 7;
            this.buttonChooseLeft4DeadAddonsFolder.Text = "...";
            this.buttonChooseLeft4DeadAddonsFolder.UseVisualStyleBackColor = true;
            this.buttonChooseLeft4DeadAddonsFolder.Click += new System.EventHandler(this.buttonChooseLeft4DeadAddonsFolder_Click);
            // 
            // labelLeft4DeadAddonsFolder
            // 
            this.labelLeft4DeadAddonsFolder.AutoSize = true;
            this.labelLeft4DeadAddonsFolder.Location = new System.Drawing.Point(6, 83);
            this.labelLeft4DeadAddonsFolder.Name = "labelLeft4DeadAddonsFolder";
            this.labelLeft4DeadAddonsFolder.Size = new System.Drawing.Size(149, 15);
            this.labelLeft4DeadAddonsFolder.TabIndex = 6;
            this.labelLeft4DeadAddonsFolder.Text = "Left 4 Dead Addons Folder:";
            // 
            // textBoxLeft4DeadAddonsFolder
            // 
            this.textBoxLeft4DeadAddonsFolder.Location = new System.Drawing.Point(174, 80);
            this.textBoxLeft4DeadAddonsFolder.Name = "textBoxLeft4DeadAddonsFolder";
            this.textBoxLeft4DeadAddonsFolder.Size = new System.Drawing.Size(449, 23);
            this.textBoxLeft4DeadAddonsFolder.TabIndex = 5;
            // 
            // textBoxDownloadListUrl
            // 
            this.textBoxDownloadListUrl.Location = new System.Drawing.Point(174, 51);
            this.textBoxDownloadListUrl.Name = "textBoxDownloadListUrl";
            this.textBoxDownloadListUrl.Size = new System.Drawing.Size(480, 23);
            this.textBoxDownloadListUrl.TabIndex = 4;
            // 
            // labelDownloadListUrl
            // 
            this.labelDownloadListUrl.AutoSize = true;
            this.labelDownloadListUrl.Location = new System.Drawing.Point(6, 54);
            this.labelDownloadListUrl.Name = "labelDownloadListUrl";
            this.labelDownloadListUrl.Size = new System.Drawing.Size(103, 15);
            this.labelDownloadListUrl.TabIndex = 3;
            this.labelDownloadListUrl.Text = "Download List Url:";
            // 
            // buttonChooseTemporaryDownloadFolder
            // 
            this.buttonChooseTemporaryDownloadFolder.Location = new System.Drawing.Point(629, 22);
            this.buttonChooseTemporaryDownloadFolder.Name = "buttonChooseTemporaryDownloadFolder";
            this.buttonChooseTemporaryDownloadFolder.Size = new System.Drawing.Size(25, 23);
            this.buttonChooseTemporaryDownloadFolder.TabIndex = 2;
            this.buttonChooseTemporaryDownloadFolder.Text = "...";
            this.buttonChooseTemporaryDownloadFolder.UseVisualStyleBackColor = true;
            this.buttonChooseTemporaryDownloadFolder.Click += new System.EventHandler(this.buttonChooseTemporaryDownloadFolder_Click);
            // 
            // textBoxTemporaryDownloadFolder
            // 
            this.textBoxTemporaryDownloadFolder.Location = new System.Drawing.Point(174, 22);
            this.textBoxTemporaryDownloadFolder.Name = "textBoxTemporaryDownloadFolder";
            this.textBoxTemporaryDownloadFolder.Size = new System.Drawing.Size(449, 23);
            this.textBoxTemporaryDownloadFolder.TabIndex = 1;
            // 
            // labelTemporaryDownloadFolder
            // 
            this.labelTemporaryDownloadFolder.AutoSize = true;
            this.labelTemporaryDownloadFolder.Location = new System.Drawing.Point(6, 25);
            this.labelTemporaryDownloadFolder.Name = "labelTemporaryDownloadFolder";
            this.labelTemporaryDownloadFolder.Size = new System.Drawing.Size(162, 15);
            this.labelTemporaryDownloadFolder.TabIndex = 0;
            this.labelTemporaryDownloadFolder.Text = "Temporary Download  Folder:";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 261);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox);
            this.MaximizeBox = false;
            this.Name = "SetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button buttonChooseLeft4DeadAddonsFolder;
        private System.Windows.Forms.Label labelLeft4DeadAddonsFolder;
        private System.Windows.Forms.TextBox textBoxLeft4DeadAddonsFolder;
        private System.Windows.Forms.TextBox textBoxDownloadListUrl;
        private System.Windows.Forms.Label labelDownloadListUrl;
        private System.Windows.Forms.Button buttonChooseTemporaryDownloadFolder;
        private System.Windows.Forms.TextBox textBoxTemporaryDownloadFolder;
        private System.Windows.Forms.Label labelTemporaryDownloadFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}