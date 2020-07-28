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
    class Depremler : Deprem
    {
        private string _ilkZaman;
        private string _sonZaman;
        private readonly Araclar _araclar = new Araclar(null);
        private readonly Bildirimler _bilgilendir = new Bildirimler();

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
            List<string> satirlar = new List<string>(File.ReadAllLines(Directory.GetCurrentDirectory() + "//depremler", Encoding.UTF8));
            for (int satir = 7; satir < depremSayisi; satir++)
                NesneleriOku(lvListe, satirlar, satir);
        }

        private void NesneleriOku(ListView lvListe, List<string> satirlar, int satir)
        {
            List<string> dizi = new List<string>(Regex.Split(satirlar[satir], @"[ \t]{2,}"));
            Deprem(dizi);

            LviNesnesineEkle(lvListe);
        }

        private void Deprem(List<string> dizi)
        {
            Tarih = dizi[0];
            Enlem = dizi[1];
            Boylam = dizi[2];
            Derinlik = dizi[3];
            Siddet = dizi[5];
            Yer = dizi[7];
        }

        private void LviNesnesineEkle(ListView lvListe)
        {
            ListViewItem lviNesnesi = new ListViewItem(Tarih);
            lviNesnesi.SubItems.Add(Enlem);
            lviNesnesi.SubItems.Add(Boylam);
            lviNesnesi.SubItems.Add(Derinlik);
            lviNesnesi.SubItems.Add(Siddet);
            lviNesnesi.SubItems.Add(Yer);
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
            // Web sitesinden çekilen verideki deprem bilgileri 7. satırdan başlıyor
            int depremSayi = (int) Settings.Default["DepremSayi"] + 7;
            ListeOlustur(lvListe, depremSayi);

            _sonZaman = lvListe.Items[0].Text;

            int dakika = (int) Settings.Default["Dakika"];
            _araclar.TimerSifirla(zamanlayici, dakika);
        }
    }
}