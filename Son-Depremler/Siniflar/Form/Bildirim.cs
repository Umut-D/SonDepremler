using System;
using System.Drawing;
using System.Windows.Forms;
using Son_Depremler.Properties;
using Son_Depremler.Siniflar.Araclar;

namespace Son_Depremler.Siniflar.Form
{
    public class Bildirim
    {
        private string _sonDepremSaati, _sonDepremYeri, _sonDepremBuyuklugu;

        public void Goster(ListViewItem lvNesnesi)
        {
            _sonDepremSaati = lvNesnesi.Text.Replace("Bugün ", "");
            _sonDepremBuyuklugu = lvNesnesi.SubItems[4].Text;
            _sonDepremYeri = lvNesnesi.SubItems[5].Text;

            UyariSesiCal();
            SimgeBildirimiGoster();
        }

        private void UyariSesiCal()
        {
            bool sesDurum = (bool) Settings.Default["Ses"]; // TOdo Ayarlara mı aktarsam?
            if (sesDurum)
            {
                Ses ses = new Ses();
                ses.Oynat();
            }
        }

        private void SimgeBildirimiGoster()
        {
            using (NotifyIcon simge = new NotifyIcon())
            {
                simge.Visible = true;
                simge.Icon = SystemIcons.Information;
                simge.BalloonTipTitle = @"Son Deprem";
                simge.BalloonTipText = $@"Saat: {_sonDepremSaati} {Environment.NewLine} Yer: {_sonDepremYeri} {Environment.NewLine} Büyüklük: {_sonDepremBuyuklugu}";

                simge.ShowBalloonTip(7000);
            }
        }

        public string SonrakiGuncellemeZamani()
        {
            int dakika = (int) Settings.Default["Dakika"];
            DateTime sonGuncelleme = DateTime.Now;
            string sonrakiGuncelleme = sonGuncelleme.AddMinutes(dakika).ToLongTimeString();

            string bilgi = $"Son Güncelleme: {sonGuncelleme.ToLongTimeString()} (Bir sonraki güncelleme: {sonrakiGuncelleme})";

            return bilgi;
        }
    }
}