using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Son_Depremler.Properties;
using Son_Depremler.Siniflar.Form;

namespace Son_Depremler.Siniflar
{
    class Depremler
    {
        private string _ilkZaman;
        private string _sonZaman;
        private readonly Araclar _araclar = new Araclar(null);
        private readonly Bildirimler _bilgilendir = new Bildirimler();

        // İndirilen sayfayı ayrıştır ve listeye taşı
        private void ListeOlustur(ListView lvListe, int depremSayisi)
        {
            lvListe.Items.Clear();

            Baglanti.Baglanti.VeriAl();
            VerileriOku(lvListe, depremSayisi);

            _araclar.DepremSiddetiRenklendir(lvListe);
            _bilgilendir.SonGuncelleme();

            _ilkZaman = lvListe.Items[0].Text;
            SonDepremZamaniniKiyasla(_ilkZaman, _sonZaman, lvListe);
        }

        private void VerileriOku(ListView lvListe, int depremSayisi)
        {
            List<string> satirlar = new List<string>(File.ReadAllLines(Environment.CurrentDirectory + "//depremler", Encoding.UTF8));
            for (int satir = 7; satir < depremSayisi; satir++)
                NesneleriOku(lvListe, satirlar, satir);
        }

        private static void NesneleriOku(ListView lvListe, List<string> satirlar, int satir)
        {
            List<string> dizi = new List<string>(Regex.Split(satirlar[satir], @"[ \t]{2,}"));

            ListViewItem lviNesnesi = new ListViewItem(dizi[0]); // Tarih
            lviNesnesi.SubItems.Add(dizi[1]); // Enlem
            lviNesnesi.SubItems.Add(dizi[2]); // Boylam
            lviNesnesi.SubItems.Add(dizi[3]); // Derinlik
            lviNesnesi.SubItems.Add(dizi[5]); // Şiddet
            lviNesnesi.SubItems.Add(dizi[7]); // Yer
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