using System.Diagnostics;

namespace Son_Depremler.Siniflar
{
    // Liste görünümüde tıklanan yeri Google Map sayfasında göster
    public class Harita
    {
        public string Enlem { get; set;  }
        public string Boylam { get; set; }

        public void Ac()
        {
            string duzenliLink = @"https://www.google.com/maps/place/" + Enlem + "+" + Boylam + "/@" + Enlem + "," + Boylam + "," + "8z";

            Process.Start(duzenliLink);
        }
    }
}