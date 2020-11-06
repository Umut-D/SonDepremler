using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Son_Depremler.Properties;
using Son_Depremler.Siniflar.Form;
using Son_Depremler.Siniflar.Baglanti;

namespace Son_Depremler.Siniflar
{
    class Depremler
    {
        public Deprem Deprem { get; set; }
        private readonly Araclar _araclar;
        private readonly Bildirimler _bilgilendir;
        private string _ilkZaman, _sonZaman;

        public Depremler()
        {
            Deprem = new Deprem();
            _araclar =  new Araclar(null);
            _bilgilendir = new Bildirimler();
        }

        // İndirilen sayfayı ayrıştır ve listeye taşı
        private void ListeOlustur(ListView lvListe, int depremSayisi)
        {
            lvListe.Items.Clear();

            Baglan baglan = new Baglan();
            baglan.VeriAl();
            VerileriOku(lvListe, depremSayisi);

            _araclar.DepremSiddetiRenklendir(lvListe);
            _bilgilendir.SonGuncelleme();

            _ilkZaman = lvListe.Items[0].Text;
            SonDepremZamaniniKiyasla(_ilkZaman, _sonZaman, lvListe);
        }

        private void VerileriOku(ListView lvListe, int depremSayisi)
        {
            using (FileStream dosyaAkis = new FileStream(Deprem.Dizin, FileMode.OpenOrCreate))
            {
                using (StreamReader oku = new StreamReader(dosyaAkis, Encoding.UTF8))
                {
                    List<string> satirlar = new List<string>();
                    string okunanSatir;
                    while ((okunanSatir = oku.ReadLine()) != null)
                        satirlar.Add(okunanSatir);

                    for (int satir = 6; satir < depremSayisi; satir++)
                        NesneleriOku(lvListe, satirlar, satir);
                }
            }
        }

        private void NesneleriOku(ListView lvListe, List<string> satirlar, int satir)
        {
            try
            {
                if (satirlar.Count > 0)
                {
                    List<string> dizi = new List<string>(Regex.Split(satirlar[satir], @"[ \t]{2,}"));
                    Liste(dizi);

                    LviNesnesineEkle(lvListe);
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show($@"Şöyle bir {hata.Message} hata oldu!", @"Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Liste(List<string> dizi)
        {
            TarihDuzenle(dizi[0]);
            Deprem.Enlem = dizi[1];
            Deprem.Boylam = dizi[2];
            Deprem.Derinlik = dizi[3];
            Deprem.Siddet = dizi[5];
            Deprem.Yer = dizi[7];
        }

        private void TarihDuzenle(string tarih)
        {
            // Türkiye saatini al (Türkiye saati UTC+3)
            string turkiyeTarih = DateTime.UtcNow.Add(new TimeSpan(3, 0, 0)).Date.ToString("dd/MM/yyyy");

            // Dünkü Türkiye saatini al
            string dunkuTurkiyeTarih = DateTime.UtcNow.Add(new TimeSpan(-24, 0, 0)).Date.ToString("dd/MM/yyyy");

            //Eğer türkiye saati ile gün aynı ise gün aynı ise bugün, dünse dün yaz
            Deprem.Tarih = Convert.ToDateTime(tarih).ToString("dd/MM/yyyy");
            if (Deprem.Tarih.StartsWith(turkiyeTarih))
                Deprem.Tarih = "Bugün " + Convert.ToDateTime(tarih).ToString("HH:mm:ss");
            else if (Deprem.Tarih.StartsWith(dunkuTurkiyeTarih))
                Deprem.Tarih = "Dün " + Convert.ToDateTime(tarih).ToString("HH:mm:ss");
        }

        private void LviNesnesineEkle(ListView lvListe)
        {
            ListViewItem lviNesnesi = new ListViewItem(Deprem.Tarih);
            lviNesnesi.SubItems.Add(Deprem.Enlem);
            lviNesnesi.SubItems.Add(Deprem.Boylam);
            lviNesnesi.SubItems.Add(Deprem.Derinlik);
            lviNesnesi.SubItems.Add(Deprem.Siddet);
            lviNesnesi.SubItems.Add(Deprem.Yer);
            lvListe.Items.Add(lviNesnesi);
        }

        private void SonDepremZamaniniKiyasla(string ilkZaman, string sonZaman, ListView lvListe)
        {
            _ilkZaman = ilkZaman;
            _sonZaman = sonZaman;

            if (_ilkZaman != _sonZaman)
                _bilgilendir.SonDeprem(lvListe);
        }

        public void Listele(ListView lvListe, Timer zamanlayici)
        {
            // Web sitesinden çekilen verideki deprem bilgileri 6. satırdan başlıyor
            int depremSayi = (int) Settings.Default["DepremSayi"] + 6;
            ListeOlustur(lvListe, depremSayi);

            _sonZaman = lvListe.Items[0].Text;

            int dakika = (int) Settings.Default["Dakika"];
            _araclar.TimerSifirla(zamanlayici, dakika);
        }
    }
}