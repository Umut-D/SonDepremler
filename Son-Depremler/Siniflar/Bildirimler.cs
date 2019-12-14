using System;
using System.Drawing;
using System.Windows.Forms;
using Son_Depremler.Properties;
using Son_Depremler.Siniflar.Form;

namespace Son_Depremler.Siniflar
{
    class Bildirimler
    {
        private readonly Araclar _araclar = new Araclar(null);

        // Son depremi gösteren bilgi ekranını aktif et
        public void SonDeprem(ListView lvListe)
        {
            string zaman = Convert.ToDateTime(lvListe.Items[0].Text).ToShortTimeString();
            string yer = lvListe.Items[0].SubItems[5].Text;
            string buyukluk = lvListe.Items[0].SubItems[4].Text;

            bool sesDurum = (bool) Settings.Default["Ses"];
            if (sesDurum)
            {
                _araclar.SesCal();
            }

            NotifyIcon bildirim = new NotifyIcon
            {
                Visible = true,
                Icon = SystemIcons.Information,
                BalloonTipTitle = @"Son Deprem", BalloonTipText = @"Saat: " + zaman + Environment.NewLine + @"Yer: " + yer + Environment.NewLine + @"Büyüklük: " + buyukluk
            };

            bildirim.ShowBalloonTip(7000);
            bildirim.Dispose();
        }

        public string SonGuncelleme()
        {
            int dakika = (int) Settings.Default["Dakika"];

            DateTime tarih = DateTime.Now;
            string yazi = "Son Güncelleme: " + tarih.ToLongTimeString() + " (Bir sonraki güncelleme: " + tarih.AddMinutes(dakika).ToLongTimeString() + ")";

            return yazi;
        }

        public void Hakkinda()
        {
            MessageBox.Show(@"Bu program ile; Boğaziçi Üniversitesi, Kandilli Rasathanesi ve Deprem Araştırma Enstitüsü (KRDAE) aracılığıyla sağlanan deprem verilerini istediniz zaman aralıklarında görebilirsiniz." + Environment.NewLine + Environment.NewLine + @"Ayrıca, ilgili deprem(ler)e tıklayarak mevcut tarayıcınızda depremin olduğu yeri Google Haritalar sayfasında görüntüleyebilirsiniz.", @"Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}