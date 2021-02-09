﻿using System;
using System.Windows.Forms;
using HtmlAgilityPack;
using Son_Depremler.Siniflar.Internet;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace Son_Depremler.Siniflar.Araclar
{
    public sealed class HtmlBelgesi
    {
        private readonly Baglanti _baglanti;

        public HtmlBelgesi(Baglanti baglanti)
        {
            _baglanti = baglanti;
        }

        public void VeriAl()
        {
            if (_baglanti.InternetVarMi())
            {
                HtmlDocument htmlBelge = Indir();
                HtmlDegerleriniOku(htmlBelge);
            }
        }

        private HtmlDocument Indir()
        {
            HtmlWeb web = new HtmlWeb
            {
                BrowserTimeout = new TimeSpan(0)
            };
            HtmlDocument htmlBelgeYukle = web.LoadFromBrowser(SecilenSunucuAdresi());

            return htmlBelgeYukle;
        }

        private string SecilenSunucuAdresi()
        {
            int sunucuNo = new Random().Next(3);
            string adres = $"http://www.koeri.boun.edu.tr/scripts/lst{sunucuNo}.asp";

            return adres;
        }

        private void HtmlDegerleriniOku(HtmlDocument htmlBelge)
        {
            try
            {
                HtmlNodeCollection bilgiler = DugumdekiBilgileriAl(htmlBelge);
                string degerler = HtmlIceriginiAl(bilgiler);

                HtmlKaydet(degerler);
            }
            catch (Exception hata)
            {
                MessageBox.Show($@"Şöyle acayip bir {hata.Message} hata oldu!", @"Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private HtmlNodeCollection DugumdekiBilgileriAl(HtmlDocument htmlBelge)
        {
            string okunacakDugum = "/html/body/pre/text()[1]";
            HtmlNodeCollection bilgiler = htmlBelge?.DocumentNode?.SelectNodes(okunacakDugum);

            return bilgiler;
        }

        private string HtmlIceriginiAl(HtmlNodeCollection bilgiler)
        {
            if (bilgiler == null || bilgiler.Count <= 0)
                return "";

            string degerler = string.Empty;
            foreach (HtmlNode depremler in bilgiler)
                degerler = depremler.OuterHtml;

            return degerler;
        }

        private void HtmlKaydet(string degerler)
        {
            Dosya dosya = new Dosya();
            dosya.Kaydet(degerler);
        }
    }
}