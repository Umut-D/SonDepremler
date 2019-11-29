using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Son_Depremler.Siniflar
{
    class Depremler : FormAraclari
    {
        private string _ilkZaman;
        private string _sonZaman;
        private string _tarih;
        private string _enlem;
        private string _boylam;
        private string _derinlik;
        private string _siddet;
        private string _yer;
        readonly Bilgilendirme _bilgilendirme = new Bilgilendirme();

        // İndirilen sayfayı ayrıştır ve listeye taşı
        private void ListeOlustur(ListView lvListe)
        {
            lvListe.Items.Clear();

            Baglanti.VeriCek();

            // Yazılan bilgileri diziye aktar
            string[] satirlar = File.ReadAllLines(Environment.CurrentDirectory + "//depremler", Encoding.UTF8);

            for (int j = 7; j < 27; j++)
            {
                string[] dizi = Regex.Split(satirlar[j], @"[ \t]{2,}");

                List<Depremler> depremler = new List<Depremler>
                {
                    new Depremler
                    {
                        _tarih = dizi[0],
                        _enlem = dizi[1],
                        _boylam = dizi[2],
                        _derinlik = dizi[3],
                        _siddet = dizi[5],
                        _yer = dizi[7]
                    }
                };

                foreach (Depremler deprem in depremler)
                {
                    ListViewItem lviNesnesi = new ListViewItem(deprem._tarih);
                    lviNesnesi.SubItems.Add(deprem._enlem);
                    lviNesnesi.SubItems.Add(deprem._boylam);
                    lviNesnesi.SubItems.Add(deprem._derinlik);
                    lviNesnesi.SubItems.Add(deprem._siddet);
                    lviNesnesi.SubItems.Add(deprem._yer);

                    lvListe.Items.Add(lviNesnesi);
                }
            }

            OlcekRenklendir(lvListe);

            _bilgilendirme.SonGuncelleme();

            _ilkZaman = lvListe.Items[0].Text;
            ZamanKiyasla(_ilkZaman, _sonZaman, lvListe);
        }

        public void Listele(ListView lvListe, Timer zamanlayici)
        {
            ListeOlustur(lvListe);

            _sonZaman = lvListe.Items[0].Text;

            TimerSifirla(zamanlayici);
        }

        // Son deprem zamanını kıyasla (Kullanıcıya bilgilendirme mesajı göstermek için gerekli)
        private void ZamanKiyasla(string ilkZaman, string sonZaman, ListView lvListe)
        {
            _ilkZaman = ilkZaman;
            _sonZaman = sonZaman;

            if (_ilkZaman != _sonZaman)
                _bilgilendirme.SonDeprem(lvListe);
        }
    }
}