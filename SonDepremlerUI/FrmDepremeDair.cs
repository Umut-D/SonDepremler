using System.Windows.Forms;

namespace SonDepremlerUI
{
    public partial class FrmDepremeDair : Form
    {
        public FrmDepremeDair()
        {
            InitializeComponent();
        }

        private void FrmDepremeDair_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }
    }
}
