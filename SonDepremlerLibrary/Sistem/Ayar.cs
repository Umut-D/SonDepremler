using SonDepremlerUI.Properties;

namespace SonDepremlerLibrary.Sistem
{
    public class Ayar
    {
        public object Yukle(string ayarAdi)
        {
            return Settings.Default[ayarAdi];
        }

        public void Kaydet<T>(T deger, string ayarAdi)
        {
            Settings.Default[ayarAdi] = deger;
            Settings.Default.Save();
        }
    }
}