using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace Son_Depremler.Siniflar
{
    public class Baglanti
    {
        private static string _adres = @"http://www.koeri.boun.edu.tr/scripts/lst7.asp";
        private static string _guncellemeAdres = @"https://raw.githubusercontent.com/Umut-D/umutd.com/master/assets/program-versions/son-depremler.xml";
        private static string _versiyon = "1.00";
        
        // İnternet bağlatısını kontrol etmek için wininet.dll'yi kullanıp işletim sistemi kaynaklarına eriş
        [DllImport("wininet.dll", CharSet = CharSet.Auto)]
        private static extern bool InternetGetConnectedState(ref InternetConnectionStateFlags lpdwFlags, int dwReserved);

        [Flags]
        private enum InternetConnectionStateFlags
        {
            INTERNET_CONNECTION_MODEM = 0x01,
            INTERNET_CONNECTION_LAN = 0x02,
            INTERNET_CONNECTION_PROXY = 0x04,
            INTERNET_RAS_INSTALLED = 0x10,
            INTERNET_CONNECTION_OFFLINE = 0x20,
            INTERNET_CONNECTION_CONFIGURED = 0x40
        }

        private static bool InternetKontrol()
        {
            InternetConnectionStateFlags flags = 0;
            bool durum = InternetGetConnectedState(ref flags, 0);

            if (durum)
                return true;

            return false;
        }

        public static void VeriCek()
        {
            if (InternetKontrol())
            {
                HtmlDocument htmlBelge = new HtmlDocument();
                WebRequest webIstemi = WebRequest.Create(_adres);
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

                XmlReader xmlOku = XmlReader.Create(webIstemcisi.OpenRead(_guncellemeAdres) ?? throw new InvalidOperationException());

                while (xmlOku.Read())
                {
                    // XML dosyasında eksi ile baslayan alan bulunmazsa okuma yapma
                    if (xmlOku.NodeType != XmlNodeType.Element || xmlOku.Name != "depremler" || !xmlOku.HasAttributes)
                        continue;

                    _versiyon = xmlOku.GetAttribute("version");

                    if (_versiyon == "1.00")
                        MessageBox.Show(@"Program günceldir. Yeni versiyon çıkana kadar şimdilik en iyisi bu.", @"Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        DialogResult guncelleDiyalog = MessageBox.Show(@"Yeni bir güncelleme var. Evet evet, programı " + _versiyon +
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