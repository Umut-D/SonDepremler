using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Son_Depremler.Properties;

namespace Son_Depremler.Siniflar.Araclar
{
    public class Dosya
    {
        private readonly string _dizin = Directory.GetCurrentDirectory() + "//depremler";

        public void Oku(ListView lvListe)
        {
            using (FileStream akis = new FileStream(_dizin, FileMode.OpenOrCreate))
            {
                using (StreamReader oku = new StreamReader(akis, Encoding.UTF8))
                {
                    List<string> satirlar = SatirlariOku(oku);

                    ListeOku(lvListe, satirlar);
                }
            }
        }

        private static void ListeOku(ListView lvListe, List<string> satirlar)
        {
            DepremListesi depremListesi = new DepremListesi(lvListe);

            // Web sitesinden çekilen verideki deprem bilgileri 6. satırdan başlıyor
            int gosterilecekDepremSayisi = (int) Settings.Default["DepremSayi"] + 6;
            for (int satir = 6; satir < gosterilecekDepremSayisi; satir++)
                depremListesi.NesneleriOku(satirlar, satir);
        }

        private List<string> SatirlariOku(StreamReader oku)
        {
            List<string> satirlar = new List<string>();
            string okunanSatir;

            while ((okunanSatir = oku.ReadLine()) != null)
                satirlar.Add(okunanSatir);

            return satirlar;
        }

        public void Kaydet(string degerler)
        {
            using (FileStream akis = new FileStream(_dizin, FileMode.OpenOrCreate))
            {
                using (StreamWriter yaz = new StreamWriter(akis, Encoding.UTF8))
                {
                    yaz.Write(degerler);
                }
            }

            HtmlDosyasiniGizle();
        }

        private void HtmlDosyasiniGizle()
        {
            File.SetAttributes(_dizin, FileAttributes.Hidden);
        }

        public void CikistaHtmlDosyasiniSil()
        {
            if (File.Exists(_dizin))
                File.Delete(_dizin);
        }
    }
}