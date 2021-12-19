using Left4DeadAddonsDownloader.Core.Models.Entities;
using Left4DeadAddonsDownloader.Core.Models.Interfaces;
using Left4DeadAddonsDownloader.UI.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Left4DeadAddonsDownloader.UI.Views
{
    public partial class DownloadedFilesForm : FormModel
    {
        #region Fields

        private IFileDownloadedRepository _fileDownloadedRepository;

        #endregion

        #region Constructors

        public DownloadedFilesForm(IFileDownloadedRepository fileDownloadedRepository)
        {
            InitializeComponent();
            this._fileDownloadedRepository = fileDownloadedRepository;
        }

        #endregion

        #region Events

        private void DownloadedFilesForm_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        #endregion

        #region Methods

        private void LoadData()
        {
            if (this.dataGridViewDownloadedFiles.Columns.Count.Equals(0))
            {
                DataGridViewColumn columnName = new DataGridViewTextBoxColumn();
                columnName.Name = "name";
                columnName.HeaderText = "Name";
                columnName.ReadOnly = true;
                this.dataGridViewDownloadedFiles.Columns.Add(columnName);

                DataGridViewColumn columnSize = new DataGridViewTextBoxColumn();
                columnSize.Name = "size";
                columnSize.HeaderText = "Size";
                columnSize.ReadOnly = true;
                this.dataGridViewDownloadedFiles.Columns.Add(columnSize);

                DataGridViewColumn columnUrl = new DataGridViewTextBoxColumn();
                columnUrl.Name = "url";
                columnUrl.HeaderText = "Url";
                columnUrl.ReadOnly = true;
                this.dataGridViewDownloadedFiles.Columns.Add(columnUrl);

                DataGridViewCheckBoxColumn columnDownloadAgain = new DataGridViewCheckBoxColumn();
                columnDownloadAgain.Name = "DownloadAgain";
                columnDownloadAgain.HeaderText = "Download Again";
                columnDownloadAgain.ReadOnly = false;
                columnDownloadAgain.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridViewDownloadedFiles.Columns.Add(columnDownloadAgain);
            }

            List<FileDownloaded> fileDownloadeds = _fileDownloadedRepository.Select();

            this.labelTotalRecords.Text = $"Total records: { fileDownloadeds.Count }";

            foreach (FileDownloaded item in fileDownloadeds)
            {
                this.dataGridViewDownloadedFiles.Rows.Add
                    (
                        item.Name
                        , item.Size
                        , item.UrlOrigin
                        , item.DownloadAgain
                    );
            }
        }

        #endregion
    }
}
