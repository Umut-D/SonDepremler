using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace Son_Depremler.Siniflar
{
    public class Baglanti
    {
        private static string Adres { get; } = @"http://www.koeri.boun.edu.tr/scripts/lst7.asp";
        private static string GuncellemeAdres => @"https://raw.githubusercontent.com/Umut-D/umutd.com/master/assets/program-versions/son-depremler.xml";
        private static string Versiyon { get; set; } = "1.00";

        // İnternet bağlantısının olup olmadığını Google'a ping atarak test et
        private static bool InternetKontrol()
        {
            PingReply pingDurum = new Ping().Send("www.google.com", 1000);

            if (pingDurum?.Status == IPStatus.Success)
                return true;

            return false;
        }

        public static void VeriCek()
        {
            if (InternetKontrol())
            {
                HtmlDocument htmlBelge = new HtmlDocument();
                WebRequest webIstemi = WebRequest.Create(Adres);
                WebResponse webDonusDegeri = webIstemi.GetResponse();
                StreamReader oku = new StreamReader(webDonusDegeri.GetResponseStream() ?? throw new InvalidOperationException());

                // HtmlAgilityPack ile ilgili düğümü okuu
                htmlBelge.Load(oku);
                HtmlNodeCollection depremBilgisiAlanlari = htmlBelge.DocumentNode.SelectNodes("/html/body/pre/text()[1]");

                // Deprem bilgilerini ilgili değişkene aktarmaya başla
                string degerler = string.Empty;
                foreach (HtmlNode depremler in depremBilgisiAlanlari)
                    degerler = depremler.OuterHtml;

                // Dönen değerlerdeki deprem bilgilerini alıp yaz
                File.WriteAllText(Environment.CurrentDirectory + "//depremler", degerler, Encoding.UTF8);
            }
            else
            {
                MessageBox.Show(@"Maalesef internet bağlantınız yok.", @"Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Guncelle()
        {
            try
            {
                // Web sitesine RSS okuyucu olarak istem yapmak gerek. Yoksa istek reddedilmekte
                WebClient webIstemcisi = new WebClient();
                webIstemcisi.Headers.Add("user-agent", "MyRSSReader/1.0");

                XmlReader xmlOku =
                    XmlReader.Create(webIstemcisi.OpenRead(GuncellemeAdres) ?? throw new InvalidOperationException());

                while (xmlOku.Read())
                {
                    // XML dosyasında eksi ile baslayan alan bulunmazsa okuma yapma
                    if (xmlOku.NodeType != XmlNodeType.Element || xmlOku.Name != "depremler" || !xmlOku.HasAttributes)
                        continue;

                    Versiyon = xmlOku.GetAttribute("version");

                    if (Versiyon == "1.00")
                        MessageBox.Show(@"Program günceldir. Yeni versiyon çıkana kadar şimdilik en iyisi bu.", @"Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        DialogResult guncelleDiyalog = MessageBox.Show(
                            @"Yeni bir güncelleme var. Evet evet, programı " + Versiyon +
                            @" versiyonuna yükselttim. Yenilikler var. Web sayfasına girip indirmek ister misiniz?", @"Güncelle", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                        if (guncelleDiyalog == DialogResult.OK)
                            Process.Start("http://www.umutd.com/programlar/son-depremler");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Bağlantıda istenmeyen bir hata meydana geldi.", @"Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}