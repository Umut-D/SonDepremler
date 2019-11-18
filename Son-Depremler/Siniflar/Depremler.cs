using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Son_Depremler.Siniflar
{
    class Depremler
    {
        public string IlkZaman { get; set; }
        public string SonZaman { get; set; }
        readonly Bilgilendirme _bilgilendirme = new Bilgilendirme();

        // Son deprem zamanını kıyasla (Kullanıcıya bilgilendirme mesajı göstermek için gerekli)
        private void ZamanKiyasla(string ilkZaman, string sonZaman, ListView lvListe)
        {
            IlkZaman = ilkZaman;
            SonZaman = sonZaman;

            if (IlkZaman != sonZaman)
                _bilgilendirme.SonDeprem(lvListe);
        }

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

                ListViewItem lviNesnesi = new ListViewItem(dizi[0]); // Tarih
                lviNesnesi.SubItems.Add(dizi[1]); // Enlem
                lviNesnesi.SubItems.Add(dizi[2]); // Boylam
                lviNesnesi.SubItems.Add(dizi[3]); // Derinlik
                lviNesnesi.SubItems.Add(dizi[5]); // Şiddet
                lviNesnesi.SubItems.Add(dizi[7]); // Yer

                lvListe.Items.Add(lviNesnesi);
            }

            IlkZaman = lvListe.Items[0].Text;

            OlcekRenklendir(lvListe);
            _bilgilendirme.SonGuncelleme();
            ZamanKiyasla(IlkZaman, SonZaman, lvListe);
        }

        public void Listele(ListView lvListe, Timer zamanlayici)
        {
            ListeOlustur(lvListe);

            SonZaman = lvListe.Items[0].Text;

            TimerSifirla(zamanlayici);
        }

        // Depremlerin şiddetine göre renklendirme yap
        private static void OlcekRenklendir(ListView lvListe)
        {
            foreach (ListViewItem lvNesne in lvListe.Items)
            {
                lvNesne.UseItemStyleForSubItems = false;

                for (int i = 0; i < 1; i++)
                {
                    double olcek = Convert.ToDouble(lvNesne.SubItems[4].Text);
                    if (olcek <= 29)
                    {
                        lvNesne.SubItems[4].BackColor = Color.GreenYellow;
                        lvNesne.SubItems[4].ForeColor = Color.Black;
                    }
                    else if (olcek >= 30 && olcek <= 41)
                    {
                        lvNesne.SubItems[4].BackColor = Color.DarkGreen;
                        lvNesne.SubItems[4].ForeColor = Color.White;
                    }
                    else if (olcek >= 42 && olcek <= 60)
                    {
                        lvNesne.SubItems[4].BackColor = Color.Orange;
                        lvNesne.SubItems[4].ForeColor = Color.Black;
                    }
                    else if (olcek >= 61 && olcek <= 73)
                    {
                        lvNesne.SubItems[4].BackColor = Color.OrangeRed;
                        lvNesne.SubItems[4].ForeColor = Color.White;
                    }
                    else // Allah korusun
                    {
                        lvNesne.SubItems[4].BackColor = Color.DarkRed;
                        lvNesne.SubItems[4].ForeColor = Color.White;
                    }
                }
            }
        }

        private void TimerSifirla(Timer zamanlayici)
        {
            zamanlayici.Stop();
            zamanlayici.Start();
            zamanlayici.Interval = 1000 * 60 * 5; // 5 dakikada bir istem yap
        }
    }
}