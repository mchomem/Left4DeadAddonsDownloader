using Left4DeadAddonsDownloader.Core.Models.Interfaces;
using System;
using System.Windows.Forms;

namespace Left4DeadAddonsDownloader.UI.Views
{
    public partial class ServiceForm : Form
    {
        #region Fields

        private readonly IExecutorService _executorService;

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
            this.ExcuteService();
        }

        private void ExcuteService()
        {
            _executorService.Start();

            MessageBox.Show(this, "Done", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}
