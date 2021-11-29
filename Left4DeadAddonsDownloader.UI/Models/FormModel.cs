using System.Windows.Forms;

namespace Left4DeadAddonsDownloader.UI.Models
{
    public class FormModel: Form
    {
        public FormModel()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
