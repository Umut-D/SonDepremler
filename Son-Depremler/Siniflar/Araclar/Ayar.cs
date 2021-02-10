using Son_Depremler.Properties;

namespace Son_Depremler.Siniflar.Araclar
{
    public class Ayar
    {
        private readonly FrmSonDepremler _frmSonDepremler;

        public Ayar(FrmSonDepremler frmSonDepremler)
        {
            _frmSonDepremler = frmSonDepremler;
        }

        public object Yukle(string ayarAdi)
        {
            return Settings.Default[ayarAdi];
        }

        public void Kaydet<T>(T deger, string ayarAdi)
        {
            Settings.Default[ayarAdi] = deger;
            Settings.Default.Save();

            _frmSonDepremler.FrmSonDepremler_Load(null, null);
        }
    }
}