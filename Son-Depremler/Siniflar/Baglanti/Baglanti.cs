using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace Son_Depremler.Siniflar.Baglanti
{
    public sealed class Baglanti : Internet
    {
        public static void VeriAl()
        {
            if (NetKontrol())
            {
                HtmlDocument htmlBelge = BelgeOku();
                BilgileriOku(htmlBelge);
            }
            else
            {
                MessageBox.Show(@"Maalesef internet bağlantınız yok.", @"Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static HtmlDocument BelgeOku()
        {
            WebResponse webDonusDegeri = Baglan();
            StreamReader oku = new StreamReader(webDonusDegeri.GetResponseStream() ?? throw new InvalidOperationException());

            HtmlDocument htmlBelge = new HtmlDocument();
            htmlBelge.Load(oku);

            return htmlBelge;
        }

        private static WebResponse Baglan()
        {
            string webAdres = @"http://www.koeri.boun.edu.tr/scripts/lst7.asp";
            WebRequest webIstemi = WebRequest.Create(webAdres);
            WebResponse webDonusDegeri = webIstemi.GetResponse();
            return webDonusDegeri;
        }

        private static void BilgileriOku(HtmlDocument htmlBelge)
        {
            HtmlNodeCollection depremBilgileri = htmlBelge.DocumentNode.SelectNodes("/html/body/pre/text()[1]");

            string degerler = string.Empty;
            foreach (HtmlNode depremler in depremBilgileri)
                degerler = depremler.OuterHtml;

            BilgileriYaz(degerler);
        }

        private static void BilgileriYaz(string degerler)
        {
            File.WriteAllText(Environment.CurrentDirectory + "//depremler", degerler, Encoding.UTF8);
        }
    }
}