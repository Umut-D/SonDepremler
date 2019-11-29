using System.Diagnostics;

namespace Son_Depremler.Siniflar
{
    // Liste görünümüde tıklanan yeri Google Map sayfasında göster
    public class Harita
    {
        private readonly string _enlem;
        private readonly string _boylam;

        public Harita(string enlem, string boylam)
        {
            _enlem = enlem;
            _boylam = boylam;
        }

        public void Ac()
        {
            string duzenliLink = @"https://www.google.com/maps/place/" + _enlem + "+" + _boylam + "/@" + _enlem + "," + _boylam + "," + "7z";

            Process.Start(duzenliLink);
        }
    }
}