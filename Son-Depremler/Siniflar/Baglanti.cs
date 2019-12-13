using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace Son_Depremler.Siniflar
{
    public sealed class Baglanti : Internet
    {
        public static void VeriAl()
        {
            const string webAdres = @"http://www.koeri.boun.edu.tr/scripts/lst7.asp";

            if (Kontrol())
            {
                HtmlDocument htmlBelge = new HtmlDocument();
                WebRequest webIstemi = WebRequest.Create(webAdres);
                WebResponse webDonusDegeri = webIstemi.GetResponse();
                StreamReader oku =
                    new StreamReader(webDonusDegeri.GetResponseStream() ?? throw new InvalidOperationException());

                // HtmlAgilityPack ile web sitesindeki 'ilgili düğümü' ayıklayıp çek
                htmlBelge.Load(oku);
                HtmlNodeCollection depremBilgileri = htmlBelge.DocumentNode.SelectNodes("/html/body/pre/text()[1]");

                // Tüm deprem bilgilerini aktar
                string degerler = string.Empty;
                foreach (HtmlNode depremler in depremBilgileri)
                {
                    degerler = depremler.OuterHtml;
                }

                // Dönen değerlerdeki deprem bilgilerini alıp yaz
                File.WriteAllText(Environment.CurrentDirectory + "//depremler", degerler, Encoding.UTF8);
            }
            else
            {
                MessageBox.Show(@"Maalesef internet bağlantınız yok.", @"Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public static void Guncelle()
        {
            try
            {
                // Web sitesine RSS okuyucu olarak istem yapmak gerek. Yoksa istek reddedilmekte
                WebClient webIstemcisi = new WebClient();
                webIstemcisi.Headers.Add("user-agent", "MyRSSReader/1.0");

                const string versiyonAdres = @"https://raw.githubusercontent.com/Umut-D/umutd.com/master/assets/program-versions/son-depremler.xml";
                XmlReader xmlOku = XmlReader.Create(webIstemcisi.OpenRead(versiyonAdres) ?? throw new InvalidOperationException());
                while (xmlOku.Read())
                {
                    // XML dosyasında eksi ile baslayan alan bulunmazsa okuma yapma
                    if (xmlOku.NodeType != XmlNodeType.Element || xmlOku.Name != "depremler" || !xmlOku.HasAttributes)
                        continue;

                    string sunucudakiVersiyon = xmlOku.GetAttribute("version");

                    // ToDo Her yeni versiyonda bu alan ve sunucudaki XML dosyası güncellecek
                    const string guncelVersiyon = "1.07";
                    if (sunucudakiVersiyon == guncelVersiyon)
                    {
                        MessageBox.Show(@"Program günceldir. Yeni versiyon çıkana kadar şimdilik en iyisi bu.", @"Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DialogResult guncelleDiyalog = MessageBox.Show(@"Yeni bir güncelleme var. Evet evet, programı " + sunucudakiVersiyon + @" versiyonuna yükselttim. Yenilikler var. Web sayfasına girip indirmek ister misiniz?", @"Güncelle", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                        if (guncelleDiyalog == DialogResult.OK)
                            Process.Start("http://www.umutd.com/programlar/son-depremler");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Bağlantıda istenmeyen bir hata meydana geldi.", @"Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}