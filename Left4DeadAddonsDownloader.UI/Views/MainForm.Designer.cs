
namespace Left4DeadAddonsDownloader.UI.Views
{
    partial class MainForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemService = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDownloadedFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSystem,
            this.toolStripMenuItemHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItemSystem
            // 
            this.toolStripMenuItemSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemService,
            this.toolStripMenuItemDownloadedFiles,
            this.toolStripMenuItemSeparator1,
            this.toolStripMenuItemSetup,
            this.toolStripMenuItemExit});
            this.toolStripMenuItemSystem.Name = "toolStripMenuItemSystem";
            this.toolStripMenuItemSystem.Size = new System.Drawing.Size(57, 20);
            this.toolStripMenuItemSystem.Text = "System";
            // 
            // toolStripMenuItemService
            // 
            this.toolStripMenuItemService.Name = "toolStripMenuItemService";
            this.toolStripMenuItemService.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemService.Text = "Service";
            this.toolStripMenuItemService.Click += new System.EventHandler(this.toolStripMenuItemService_Click);
            // 
            // toolStripMenuItemSeparator1
            // 
            this.toolStripMenuItemSeparator1.Name = "toolStripMenuItemSeparator1";
            this.toolStripMenuItemSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItemSetup
            // 
            this.toolStripMenuItemSetup.Name = "toolStripMenuItemSetup";
            this.toolStripMenuItemSetup.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemSetup.Text = "Setup";
            this.toolStripMenuItemSetup.Click += new System.EventHandler(this.toolStripMenuItemSetup_Click);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemExit.Text = "Exit";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // toolStripMenuItemDownloadedFiles
            // 
            this.toolStripMenuItemDownloadedFiles.Name = "toolStripMenuItemDownloadedFiles";
            this.toolStripMenuItemDownloadedFiles.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemDownloadedFiles.Text = "Downloaded Files";
            this.toolStripMenuItemDownloadedFiles.Click += new System.EventHandler(this.toolStripMenuItemDownloadedFiles_Click);
            // 
            // toolStripMenuItemHelp
            // 
            this.toolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAbout});
            this.toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
            this.toolStripMenuItemHelp.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItemHelp.Text = "Help";
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemAbout.Text = "About";
            this.toolStripMenuItemAbout.Click += new System.EventHandler(this.toolStripMenuItemAbout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Left 4 Dead Addons Downloader";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSystem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemService;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDownloadedFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItemSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSetup;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;        
    }
}