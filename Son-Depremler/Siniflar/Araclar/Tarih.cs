using System;

namespace Son_Depremler.Siniflar.Araclar
{
    public class Tarih
    {
        private string _simdikiSaat, _oncekiGun;
        private readonly Deprem _deprem;

        public Tarih(Deprem deprem)
        {
            _deprem = deprem;
        }

        public void Duzelt(string tarih)
        {
            TurkiyeSaati();

            _deprem.Tarih = Convert.ToDateTime(tarih).ToString("dd/MM/yyyy");
            if (_deprem.Tarih.StartsWith(_simdikiSaat))
                _deprem.Tarih = Gun("Bugün", tarih);
            else if (_deprem.Tarih.StartsWith(_oncekiGun))
                _deprem.Tarih = Gun("Dün", tarih);
        }

        private static string Gun(string gun, string tarih)
        {
            return $"{gun} {Convert.ToDateTime(tarih):HH:mm:ss}";
        }

        private void TurkiyeSaati()
        {
            _simdikiSaat = UtcZamanFarki(3);
            _oncekiGun = UtcZamanFarki(-24);
        }

        private string UtcZamanFarki(int saat)
        {
            return DateTime.UtcNow.Add(new TimeSpan(saat, 0, 0)).Date.ToString("dd/MM/yyyy");
        }
    }
}