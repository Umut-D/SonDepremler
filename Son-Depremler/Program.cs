using System;
using System.Windows.Forms;

namespace Son_Depremler
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmSonDepremler());
        }
    }
}