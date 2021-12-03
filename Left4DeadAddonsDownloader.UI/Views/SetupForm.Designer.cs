
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
            this.groupBoxConfig = new System.Windows.Forms.GroupBox();
            this.radioButtonFile = new System.Windows.Forms.RadioButton();
            this.radioButtonWeb = new System.Windows.Forms.RadioButton();
            this.labelMethod = new System.Windows.Forms.Label();
            this.textBoxUrlListFile = new System.Windows.Forms.TextBox();
            this.labelUrlListFile = new System.Windows.Forms.Label();
            this.buttonChooseLeft4DeadAddonsFolder = new System.Windows.Forms.Button();
            this.labelLeft4DeadAddonsFolder = new System.Windows.Forms.Label();
            this.textBoxLeft4DeadAddonsFolder = new System.Windows.Forms.TextBox();
            this.textBoxDownloadListUrl = new System.Windows.Forms.TextBox();
            this.labelDownloadListUrl = new System.Windows.Forms.Label();
            this.buttonChooseTemporaryDownloadFolder = new System.Windows.Forms.Button();
            this.textBoxTemporaryDownloadFolder = new System.Windows.Forms.TextBox();
            this.labelTemporaryDownloadFolder = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBoxCredential = new System.Windows.Forms.GroupBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.radioButtonNo = new System.Windows.Forms.RadioButton();
            this.radioButtonYes = new System.Windows.Forms.RadioButton();
            this.labelEnabled = new System.Windows.Forms.Label();
            this.buttonToggleViewChar = new System.Windows.Forms.Button();
            this.groupBoxConfig.SuspendLayout();
            this.groupBoxCredential.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(516, 347);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 5;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(597, 347);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBoxConfig
            // 
            this.groupBoxConfig.Controls.Add(this.radioButtonFile);
            this.groupBoxConfig.Controls.Add(this.radioButtonWeb);
            this.groupBoxConfig.Controls.Add(this.labelMethod);
            this.groupBoxConfig.Controls.Add(this.textBoxUrlListFile);
            this.groupBoxConfig.Controls.Add(this.labelUrlListFile);
            this.groupBoxConfig.Controls.Add(this.buttonChooseLeft4DeadAddonsFolder);
            this.groupBoxConfig.Controls.Add(this.labelLeft4DeadAddonsFolder);
            this.groupBoxConfig.Controls.Add(this.textBoxLeft4DeadAddonsFolder);
            this.groupBoxConfig.Controls.Add(this.textBoxDownloadListUrl);
            this.groupBoxConfig.Controls.Add(this.labelDownloadListUrl);
            this.groupBoxConfig.Controls.Add(this.buttonChooseTemporaryDownloadFolder);
            this.groupBoxConfig.Controls.Add(this.textBoxTemporaryDownloadFolder);
            this.groupBoxConfig.Controls.Add(this.labelTemporaryDownloadFolder);
            this.groupBoxConfig.Location = new System.Drawing.Point(12, 12);
            this.groupBoxConfig.Name = "groupBoxConfig";
            this.groupBoxConfig.Size = new System.Drawing.Size(660, 183);
            this.groupBoxConfig.TabIndex = 3;
            this.groupBoxConfig.TabStop = false;
            this.groupBoxConfig.Text = "Config";
            // 
            // radioButtonFile
            // 
            this.radioButtonFile.AutoSize = true;
            this.radioButtonFile.Location = new System.Drawing.Point(229, 138);
            this.radioButtonFile.Name = "radioButtonFile";
            this.radioButtonFile.Size = new System.Drawing.Size(43, 19);
            this.radioButtonFile.TabIndex = 12;
            this.radioButtonFile.TabStop = true;
            this.radioButtonFile.Text = "File";
            this.radioButtonFile.UseVisualStyleBackColor = true;
            // 
            // radioButtonWeb
            // 
            this.radioButtonWeb.AutoSize = true;
            this.radioButtonWeb.Checked = true;
            this.radioButtonWeb.Location = new System.Drawing.Point(174, 138);
            this.radioButtonWeb.Name = "radioButtonWeb";
            this.radioButtonWeb.Size = new System.Drawing.Size(49, 19);
            this.radioButtonWeb.TabIndex = 11;
            this.radioButtonWeb.TabStop = true;
            this.radioButtonWeb.Text = "Web";
            this.radioButtonWeb.UseVisualStyleBackColor = true;
            // 
            // labelMethod
            // 
            this.labelMethod.AutoSize = true;
            this.labelMethod.Location = new System.Drawing.Point(6, 142);
            this.labelMethod.Name = "labelMethod";
            this.labelMethod.Size = new System.Drawing.Size(49, 15);
            this.labelMethod.TabIndex = 10;
            this.labelMethod.Text = "Method";
            // 
            // textBoxUrlListFile
            // 
            this.textBoxUrlListFile.Location = new System.Drawing.Point(174, 109);
            this.textBoxUrlListFile.Name = "textBoxUrlListFile";
            this.textBoxUrlListFile.Size = new System.Drawing.Size(160, 23);
            this.textBoxUrlListFile.TabIndex = 9;
            // 
            // labelUrlListFile
            // 
            this.labelUrlListFile.AutoSize = true;
            this.labelUrlListFile.Location = new System.Drawing.Point(6, 112);
            this.labelUrlListFile.Name = "labelUrlListFile";
            this.labelUrlListFile.Size = new System.Drawing.Size(67, 15);
            this.labelUrlListFile.TabIndex = 8;
            this.labelUrlListFile.Text = "Url List File:";
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
            // groupBoxCredential
            // 
            this.groupBoxCredential.Controls.Add(this.buttonToggleViewChar);
            this.groupBoxCredential.Controls.Add(this.textBoxPassword);
            this.groupBoxCredential.Controls.Add(this.labelPassword);
            this.groupBoxCredential.Controls.Add(this.textBoxUser);
            this.groupBoxCredential.Controls.Add(this.labelUser);
            this.groupBoxCredential.Controls.Add(this.radioButtonNo);
            this.groupBoxCredential.Controls.Add(this.radioButtonYes);
            this.groupBoxCredential.Controls.Add(this.labelEnabled);
            this.groupBoxCredential.Location = new System.Drawing.Point(12, 201);
            this.groupBoxCredential.Name = "groupBoxCredential";
            this.groupBoxCredential.Size = new System.Drawing.Size(654, 125);
            this.groupBoxCredential.TabIndex = 6;
            this.groupBoxCredential.TabStop = false;
            this.groupBoxCredential.Text = "Credential";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(173, 76);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(161, 23);
            this.textBoxPassword.TabIndex = 6;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(6, 79);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(60, 15);
            this.labelPassword.TabIndex = 5;
            this.labelPassword.Text = "Password:";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(173, 47);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(161, 23);
            this.textBoxUser.TabIndex = 4;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(6, 50);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(33, 15);
            this.labelUser.TabIndex = 3;
            this.labelUser.Text = "User:";
            // 
            // radioButtonNo
            // 
            this.radioButtonNo.AutoSize = true;
            this.radioButtonNo.Checked = true;
            this.radioButtonNo.Location = new System.Drawing.Point(229, 22);
            this.radioButtonNo.Name = "radioButtonNo";
            this.radioButtonNo.Size = new System.Drawing.Size(41, 19);
            this.radioButtonNo.TabIndex = 2;
            this.radioButtonNo.TabStop = true;
            this.radioButtonNo.Text = "No";
            this.radioButtonNo.UseVisualStyleBackColor = true;
            this.radioButtonNo.CheckedChanged += new System.EventHandler(this.radioButtonNo_CheckedChanged);
            // 
            // radioButtonYes
            // 
            this.radioButtonYes.AutoSize = true;
            this.radioButtonYes.Location = new System.Drawing.Point(174, 22);
            this.radioButtonYes.Name = "radioButtonYes";
            this.radioButtonYes.Size = new System.Drawing.Size(42, 19);
            this.radioButtonYes.TabIndex = 1;
            this.radioButtonYes.Text = "Yes";
            this.radioButtonYes.UseVisualStyleBackColor = true;
            this.radioButtonYes.CheckedChanged += new System.EventHandler(this.radioButtonYes_CheckedChanged);
            // 
            // labelEnabled
            // 
            this.labelEnabled.AutoSize = true;
            this.labelEnabled.Location = new System.Drawing.Point(6, 24);
            this.labelEnabled.Name = "labelEnabled";
            this.labelEnabled.Size = new System.Drawing.Size(52, 15);
            this.labelEnabled.TabIndex = 0;
            this.labelEnabled.Text = "Enabled:";
            // 
            // buttonToggleViewChar
            // 
            this.buttonToggleViewChar.Location = new System.Drawing.Point(340, 76);
            this.buttonToggleViewChar.Name = "buttonToggleViewChar";
            this.buttonToggleViewChar.Size = new System.Drawing.Size(31, 23);
            this.buttonToggleViewChar.TabIndex = 7;
            this.buttonToggleViewChar.UseVisualStyleBackColor = true;
            this.buttonToggleViewChar.Click += new System.EventHandler(this.buttonToggleViewChar_Click);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 382);
            this.Controls.Add(this.groupBoxCredential);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxConfig);
            this.Name = "SetupForm";
            this.Text = "Setup";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.groupBoxConfig.ResumeLayout(false);
            this.groupBoxConfig.PerformLayout();
            this.groupBoxCredential.ResumeLayout(false);
            this.groupBoxCredential.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBoxConfig;
        private System.Windows.Forms.Button buttonChooseLeft4DeadAddonsFolder;
        private System.Windows.Forms.Label labelLeft4DeadAddonsFolder;
        private System.Windows.Forms.TextBox textBoxLeft4DeadAddonsFolder;
        private System.Windows.Forms.TextBox textBoxDownloadListUrl;
        private System.Windows.Forms.Label labelDownloadListUrl;
        private System.Windows.Forms.Button buttonChooseTemporaryDownloadFolder;
        private System.Windows.Forms.TextBox textBoxTemporaryDownloadFolder;
        private System.Windows.Forms.Label labelTemporaryDownloadFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox textBoxUrlListFile;
        private System.Windows.Forms.Label labelUrlListFile;
        private System.Windows.Forms.RadioButton radioButtonFile;
        private System.Windows.Forms.RadioButton radioButtonWeb;
        private System.Windows.Forms.Label labelMethod;
        private System.Windows.Forms.GroupBox groupBoxCredential;
        private System.Windows.Forms.Label labelEnabled;
        private System.Windows.Forms.RadioButton radioButtonNo;
        private System.Windows.Forms.RadioButton radioButtonYes;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Button buttonToggleViewChar;
    }
}