using Left4DeadAddonsDownloader.Core.Models.Entities;
using Left4DeadAddonsDownloader.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Left4DeadAddonsDownloader.UI.Views
{
    public partial class DownloadedFilesForm : Form
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
            }

            foreach (FileDownloaded fileDownloaded in _fileDownloadedRepository.Select())
            {
                this.dataGridViewDownloadedFiles.Rows.Add
                    (
                        fileDownloaded.Name
                        , fileDownloaded.Size
                        , fileDownloaded.UrlOrigin
                    );
            }
        }

        #endregion
    }
}
