using Left4DeadAddonsDownloader.Core.Models.Entities;
using Left4DeadAddonsDownloader.Core.Models.Interfaces;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Left4DeadAddonsDownloader.UI.Views
{
    public partial class MainForm : Form
    {
        #region Fields

        private IAppSettingsRepository _appSettingsRepository;
        private IExecutorService _executorService;
        private IFileDownloadedRepository _fileDownloadedRepository;

        #endregion

        #region Constructors

        public MainForm(IAppSettingsRepository appSettingsRepository
            , IExecutorService executorService
            , IFileDownloadedRepository fileDownloadedRepository)
        {
            InitializeComponent();
            this._appSettingsRepository = appSettingsRepository;
            this._executorService = executorService;
            this._fileDownloadedRepository = fileDownloadedRepository;
        }

        #endregion

        #region Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.CheckSetup();
        }

        private void toolStripMenuItemService_Click(object sender, EventArgs e)
        {
            this.OpenServiceForm();
        }

        private void toolStripMenuItemDownloadedFiles_Click(object sender, EventArgs e)
        {
            this.OpenDownloadedFilesForm();
        }

        private void toolStripMenuItemSetup_Click(object sender, EventArgs e)
        {
            this.OpenSetupForm();
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            this.Exit();
        }

        private void toolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            this.OpenAboutForm();
        }

        #endregion

        #region Methods

        private void CheckSetup()
        {
            AppSettings appSettings = _appSettingsRepository.Details(null);

            if (!appSettings.Config.IsConfigured)
            {
                MessageBox.Show(this, "It's needed to make the app setup for the first time. The Setup form will be showed for this.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.OpenSetupForm();
            }
            else
                this.OpenServiceForm();
        }

        private void OpenServiceForm()
        {
            ServiceForm serviceForm = new ServiceForm(this._executorService);

            if (!this.FormExitsInMdiParent(serviceForm))
            {
                serviceForm.MdiParent = this;
                serviceForm.Size = new Size(this.Width - 100, this.Height - 100);
                serviceForm.Show();
            }
            else
                serviceForm = null;
        }

        private void OpenDownloadedFilesForm()
        {
            DownloadedFilesForm downloadedFilesForm = new DownloadedFilesForm(this._fileDownloadedRepository);

            if (!this.FormExitsInMdiParent(downloadedFilesForm))
            {
                downloadedFilesForm.MdiParent = this;
                downloadedFilesForm.Show();
            }
            else
                downloadedFilesForm = null;
        }

        private void OpenSetupForm()
        {
            SetupForm setupForm = new SetupForm(this._appSettingsRepository);

            if (!this.FormExitsInMdiParent(setupForm))
            {
                setupForm.MdiParent = this;
                setupForm.Show();
            }
            else
                setupForm = null;
        }

        private void OpenAboutForm()
        {
            AboutForm aboutForm = new AboutForm();

            if (!this.FormExitsInMdiParent(aboutForm))
            {
                aboutForm.MdiParent = this;
                aboutForm.Show();
            }
            else
                aboutForm = null;
        }

        private void Exit()
        {
            Application.Exit();
        }

        private bool FormExitsInMdiParent(object formParameter)
        {
            return this.MdiChildren.Any(x => x.GetType() == formParameter.GetType());
        }

        #endregion
    }
}
