using SonDepremlerLibrary.Sistem;

namespace SonDepremlerUI.Formlar
{
    public static class FormExtension
    {
        public static void KaydetVeFormYenile<T>(this Ayar ayar, FrmSonDepremler frmSonDepremler, T sayi, string tur)
        {
            ayar.Kaydet(sayi, tur);
            frmSonDepremler.FrmSonDepremler_Load(null, null);
        }
    }
}