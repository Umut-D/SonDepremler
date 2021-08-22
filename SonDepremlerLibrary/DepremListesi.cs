using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SonDepremlerLibrary.Araclar;
using SonDepremlerLibrary.Internet;
using SonDepremlerLibrary.Sistem;

namespace SonDepremlerLibrary
{
    public class DepremListesi
    {
        private readonly Deprem _deprem;
        private string _ilkZaman, _sonZaman;
        private readonly ListView _lvListe;
        private Bildirim _bilgilendir;

        public DepremListesi(ListView lvListe)
        {
            _lvListe = lvListe;
            _deprem = new Deprem();
        }

        public void NesneleriOku(List<string> satirlar, int satir)
        {
            try
            {
                if (satirlar.Count <= 0)
                    return;

                List<string> dizi = new List<string>(Regex.Split(satirlar[satir], @"[ \t]{2,}"));
                ListeHazirla(dizi);
            }
            catch (Exception hata)
            {
                MessageBox.Show($@"Şöyle bir {hata.Message} hata oldu!", @"Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ListeHazirla(List<string> dizi)
        {
            Tarih tarih = new Tarih(_deprem);
            tarih.Duzelt(dizi[0]);

            _deprem.Enlem = dizi[1];
            _deprem.Boylam = dizi[2];
            _deprem.Derinlik = dizi[3];
            _deprem.Siddet = dizi[5];
            _deprem.Yer = dizi[7];

            DepremleriLviNesnesineEkle();
        }

        private void DepremleriLviNesnesineEkle()
        {
            ListViewItem lviNesnesi = new ListViewItem(_deprem.Tarih);
            lviNesnesi.SubItems.Add(_deprem.Enlem);
            lviNesnesi.SubItems.Add(_deprem.Boylam);
            lviNesnesi.SubItems.Add(_deprem.Derinlik);
            lviNesnesi.SubItems.Add(_deprem.Siddet);
            lviNesnesi.SubItems.Add(_deprem.Yer);
            _lvListe.Items.Add(lviNesnesi);
        }

        public void Listele()
        {
            ListeOlustur();

            _sonZaman = _lvListe.Items[0].Text;
        }

        private void ListeOlustur()
        {
            _lvListe.Items.Clear();

            HtmlBelgesiOku();

            DosyaOku();

            DepremSiddetineGoreRenklendir();

            BildirimOlustur();

            _ilkZaman = _lvListe.Items[0].Text;
            SonDepremZamaniniKiyasla(_ilkZaman, _sonZaman);
        }

        private static void HtmlBelgesiOku()
        {
            HtmlBelgesi html = new HtmlBelgesi(new Baglanti());
            html.VeriAl();
        }

        private void DosyaOku()
        {
            Dosya dosya = new Dosya();
            dosya.Oku(_lvListe);
        }

        private void DepremSiddetineGoreRenklendir()
        {
            DepremSiddeti siddet = new DepremSiddeti();
            siddet.Renklendir(_lvListe);
        }

        private void BildirimOlustur()
        {
            _bilgilendir = new Bildirim();
            _bilgilendir.SonrakiGuncellemeZamani();
        }

        private void SonDepremZamaniniKiyasla(string ilkZaman, string sonZaman)
        {
            _ilkZaman = ilkZaman;
            _sonZaman = sonZaman;

            if (_ilkZaman != _sonZaman)
                _bilgilendir.Goster(_lvListe.Items[0]);
        }
    }
}