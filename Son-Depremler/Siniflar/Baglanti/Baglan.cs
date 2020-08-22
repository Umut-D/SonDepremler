using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace Son_Depremler.Siniflar.Baglanti
{
    public sealed class Baglan : Internet
    {
        readonly Deprem _deprem = new Deprem();

        public void VeriAl()
        {
            if (NetKontrol())
            {
                HtmlDocument htmlBelge = Indir();
                Oku(htmlBelge);
            }
            else
            {
                MessageBox.Show(@"Maalesef internet bağlantınız yok.", @"Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private string SunucuSec()
        {
            Random rastgeleSayi = new Random();
            int sayi = rastgeleSayi.Next(3);
            string webAdres = @"http://www.koeri.boun.edu.tr/scripts/lst" + sayi + ".asp";

            return webAdres;
        }

        private HtmlDocument Indir()
        {
            HtmlWeb web = new HtmlWeb
            {
                BrowserTimeout = new TimeSpan(0)
            };
            HtmlDocument htmlBelge = web.LoadFromBrowser(SunucuSec());

            return htmlBelge;
        }

        private void Oku(HtmlDocument htmlBelge)
        {
            HtmlNodeCollection depremBilgileri = htmlBelge.DocumentNode.SelectNodes("/html/body/pre/text()[1]");

            string degerler = string.Empty;
            foreach (HtmlNode depremler in depremBilgileri)
                degerler = depremler.OuterHtml;

            Kaydet(degerler);
            depremBilgileri.Clear();
        }

        // İndirilen Html dosyasını gizle
        private void Gizle()
        {
            File.SetAttributes(_deprem.Dizin, FileAttributes.Hidden);
        }

        private void Kaydet(string degerler)
        {
            using (FileStream dosyaAkis = new FileStream(_deprem.Dizin, FileMode.OpenOrCreate))
            {
                using (StreamWriter yaz = new StreamWriter(dosyaAkis, Encoding.UTF8))
                {
                    yaz.Write(degerler);
                }
            }

            Gizle();
        }
    }
}