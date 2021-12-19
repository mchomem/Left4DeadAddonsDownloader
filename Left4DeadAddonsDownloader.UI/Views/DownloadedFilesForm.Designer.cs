
namespace Left4DeadAddonsDownloader.UI.Views
{
    partial class DownloadedFilesForm
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
            this.groupBoxRecords = new System.Windows.Forms.GroupBox();
            this.labelTotalRecords = new System.Windows.Forms.Label();
            this.dataGridViewDownloadedFiles = new System.Windows.Forms.DataGridView();
            this.groupBoxRecords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDownloadedFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxRecords
            // 
            this.groupBoxRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxRecords.Controls.Add(this.labelTotalRecords);
            this.groupBoxRecords.Controls.Add(this.dataGridViewDownloadedFiles);
            this.groupBoxRecords.Location = new System.Drawing.Point(12, 12);
            this.groupBoxRecords.Name = "groupBoxRecords";
            this.groupBoxRecords.Size = new System.Drawing.Size(806, 391);
            this.groupBoxRecords.TabIndex = 1;
            this.groupBoxRecords.TabStop = false;
            this.groupBoxRecords.Text = "Records";
            // 
            // labelTotalRecords
            // 
            this.labelTotalRecords.Location = new System.Drawing.Point(6, 352);
            this.labelTotalRecords.Name = "labelTotalRecords";
            this.labelTotalRecords.Size = new System.Drawing.Size(794, 36);
            this.labelTotalRecords.TabIndex = 2;
            this.labelTotalRecords.Text = "Total records: 0";
            this.labelTotalRecords.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridViewDownloadedFiles
            // 
            this.dataGridViewDownloadedFiles.AllowUserToAddRows = false;
            this.dataGridViewDownloadedFiles.AllowUserToResizeColumns = false;
            this.dataGridViewDownloadedFiles.AllowUserToResizeRows = false;
            this.dataGridViewDownloadedFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDownloadedFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewDownloadedFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDownloadedFiles.Location = new System.Drawing.Point(6, 22);
            this.dataGridViewDownloadedFiles.Name = "dataGridViewDownloadedFiles";
            this.dataGridViewDownloadedFiles.ReadOnly = true;
            this.dataGridViewDownloadedFiles.RowHeadersVisible = false;
            this.dataGridViewDownloadedFiles.RowTemplate.Height = 25;
            this.dataGridViewDownloadedFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDownloadedFiles.Size = new System.Drawing.Size(794, 327);
            this.dataGridViewDownloadedFiles.TabIndex = 1;
            // 
            // DownloadedFilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 415);
            this.Controls.Add(this.groupBoxRecords);
            this.Name = "DownloadedFilesForm";
            this.Text = "Downloaded Files";
            this.Load += new System.EventHandler(this.DownloadedFilesForm_Load);
            this.groupBoxRecords.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDownloadedFiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxRecords;
        private System.Windows.Forms.DataGridView dataGridViewDownloadedFiles;
        private System.Windows.Forms.Label labelTotalRecords;
    }
}