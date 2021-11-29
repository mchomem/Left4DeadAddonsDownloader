using Left4DeadAddonsDownloader.Core.Models.Interfaces;
using Left4DeadAddonsDownloader.UI.Models;
using System;
using System.Windows.Forms;

namespace Left4DeadAddonsDownloader.UI.Views
{
    public partial class ServiceForm : FormModel
    {
        #region Fields

        private IExecutorService _executorService;

        #endregion

        #region Constructors

        public ServiceForm(IExecutorService executorService)
        {
            InitializeComponent();
            this._executorService = executorService;
        }

        #endregion

        #region Events

        private void ServiceForm_Load(object sender, EventArgs e)
        {
            if (!this.backgroundWorkerServiceForm.IsBusy)
                this.backgroundWorkerServiceForm.RunWorkerAsync();
        }

        private void backgroundWorkerServiceForm_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            this._executorService.Start(this.backgroundWorkerServiceForm);
        }

        private void backgroundWorkerServiceForm_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            this.RefreshGrieView();
        }

        #endregion

        #region Methods

        private void RefreshGrieView()
        {
            this.dataGridViewLog.Columns.Clear();

            if (this.dataGridViewLog.Columns.Count.Equals(0))
            {
                DataGridViewColumn columnDescription = new DataGridViewTextBoxColumn();
                columnDescription.ReadOnly = true;
                this.dataGridViewLog.Columns.Add(columnDescription);
            }

            foreach (string text in _executorService.GetProgressLog())
            {
                this.dataGridViewLog.Rows.Add(text);
            }
        }

        #endregion
    }
}
