using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Son_Depremler.Properties;

namespace Son_Depremler.Siniflar
{
    class Depremler
    {
        private string _ilkZaman;
        private string _sonZaman;
        private readonly FormAraclari _formAraclari = new FormAraclari(null);
        private readonly Bilgilendir _bilgilendir = new Bilgilendir();

        // İndirilen sayfayı ayrıştır ve listeye taşı
        private void ListeOlustur(ListView lvListe)
        {
            lvListe.Items.Clear();
            Baglanti.VeriAl();

            List<string> satirlar = new List<string>(File.ReadAllLines(Environment.CurrentDirectory + "//depremler", Encoding.UTF8));
            for (int j = 7; j < 27; j++)
            {
                List<string> dizi = new List<string>(Regex.Split(satirlar[j], @"[ \t]{2,}"));

                ListViewItem lviNesnesi = new ListViewItem(dizi[0]); // Tarih
                lviNesnesi.SubItems.Add(dizi[1]); // Enlem
                lviNesnesi.SubItems.Add(dizi[2]); // Boylam
                lviNesnesi.SubItems.Add(dizi[3]); // Derinlik
                lviNesnesi.SubItems.Add(dizi[5]); // Şiddet
                lviNesnesi.SubItems.Add(dizi[7]); // Yer
                lvListe.Items.Add(lviNesnesi);
            }

            _formAraclari.DepremSiddetiRenklendir(lvListe);
            _bilgilendir.SonGuncelleme();

            _ilkZaman = lvListe.Items[0].Text;
            ZamanKiyasla(_ilkZaman, _sonZaman, lvListe);
        }

        public void Listele(ListView lvListe, Timer zamanlayici)
        {
            ListeOlustur(lvListe);

            int dakika = (int)Settings.Default["Dakika"];

            _sonZaman = lvListe.Items[0].Text;
            _formAraclari.TimerSifirla(zamanlayici, dakika);
        }

        // Son deprem zamanını kıyasla (Kullanıcıya bilgilendirme mesajı göstermek için gerekli)
        private void ZamanKiyasla(string ilkZaman, string sonZaman, ListView lvListe)
        {
            _ilkZaman = ilkZaman;
            _sonZaman = sonZaman;

            if (_ilkZaman != _sonZaman)
                _bilgilendir.SonDeprem(lvListe);
        }
    }
}