using Left4DeadAddonsDownloader.Core.Models.Entities;
using Left4DeadAddonsDownloader.Core.Models.Interfaces;
using Left4DeadAddonsDownloader.UI.Models;
using System;
using System.Windows.Forms;

namespace Left4DeadAddonsDownloader.UI.Views
{
    public partial class SetupForm : FormModel
    {
        #region Fields

        private IAppSettingsRepository _appSettingsRepository;

        #endregion

        #region Constructors

        public SetupForm(IAppSettingsRepository appSettingsRepository)
        {
            InitializeComponent();
            this._appSettingsRepository = appSettingsRepository;
            this.InitializeForm();
        }

        #endregion

        #region Events

        private void SetupForm_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void buttonChooseTemporaryDownloadFolder_Click(object sender, EventArgs e)
        {
            this.textBoxTemporaryDownloadFolder.Text = this.OpenFolderDialog(this.textBoxTemporaryDownloadFolder);
        }

        private void buttonChooseLeft4DeadAddonsFolder_Click(object sender, EventArgs e)
        {
            this.textBoxLeft4DeadAddonsFolder.Text = this.OpenFolderDialog(this.textBoxLeft4DeadAddonsFolder);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.SaveSetup();
        }

        private void radioButtonYes_CheckedChanged(object sender, EventArgs e)
        {
            this.EnableDisableCredentials(true);
        }

        private void radioButtonNo_CheckedChanged(object sender, EventArgs e)
        {
            this.EnableDisableCredentials(false);
        }

        private void buttonToggleViewChar_Click(object sender, EventArgs e)
        {
            this.ToogleViewChar();
        }

        #endregion

        #region Methods

        private void InitializeForm()
        {
            this.EnableDisableCredentials(false);
        }

        private void LoadData()
        {
            AppSettings appSettings = _appSettingsRepository.Details(null);
            this.textBoxTemporaryDownloadFolder.Text = appSettings.Config.TemporaryDownloadFolder;
            this.textBoxDownloadListUrl.Text = appSettings.Config.DownloadListUrl;
            this.textBoxLeft4DeadAddonsFolder.Text = appSettings.Config.Left4DeadAddonsFolder;
            this.textBoxUrlListFile.Text = appSettings.Config.UrlListFile;

            if (appSettings.Config.Method.Equals("web"))
                this.radioButtonWeb.Checked = true;
            else
                this.radioButtonFile.Checked = true;

            if (appSettings.Credential.Enabled)
                this.radioButtonYes.Checked = true;
            else
                this.radioButtonNo.Checked = true;

            this.textBoxUser.Text = appSettings.Credential.User;
            this.textBoxPassword.Text = appSettings.Credential.Password;
        }

        private void SaveSetup()
        {
            if (this.CheckAllFieldsFromForm())
            {
                MessageBox.Show(this, "Fill all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _appSettingsRepository.Update(new AppSettings()
            {
                Config = new Config()
                {
                    TemporaryDownloadFolder = this.textBoxTemporaryDownloadFolder.Text,
                    DownloadListUrl = this.textBoxDownloadListUrl.Text,
                    Left4DeadAddonsFolder = this.textBoxLeft4DeadAddonsFolder.Text,
                    UrlListFile = this.textBoxUrlListFile.Text,
                    Method = this.radioButtonWeb.Checked ? "web" : "file",
                    IsConfigured = true
                },
                Credential = new Credential()
                {
                    Enabled = this.radioButtonYes.Checked ? true: false,
                    User = this.textBoxUser.Text,
                    Password = this.textBoxPassword.Text
                }
            });

            MessageBox.Show(this, "Done", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string OpenFolderDialog(TextBox textBox)
        {
            return this.folderBrowserDialog.ShowDialog() == DialogResult.OK
                ? this.folderBrowserDialog.SelectedPath
                : textBox.Text;
        }

        private bool CheckAllFieldsFromForm()
        {
            foreach (Control control in this.groupBoxConfig.Controls)
            {
                if (control is TextBox && string.IsNullOrEmpty(((TextBox)control).Text))
                    return true;
            }

            return false;
        }

        private void EnableDisableCredentials(bool flag)
        {
            this.textBoxUser.Enabled = flag;
            this.textBoxPassword.Enabled = flag;
            this.textBoxUser.Text = string.Empty;
            this.textBoxPassword.Text = string.Empty;
        }

        private void ToogleViewChar()
        {
            if (this.textBoxPassword.PasswordChar == '*')
                this.textBoxPassword.PasswordChar = char.MinValue;
            else
                this.textBoxPassword.PasswordChar = '*';
        }

        #endregion
    }
}
