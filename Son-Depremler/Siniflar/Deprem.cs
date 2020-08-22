using System.IO;

namespace Son_Depremler.Siniflar
{
    class Deprem
    {
        public string Tarih { get; set; }
        public string Enlem { get; set; }
        public string Boylam { get; set; }
        public string Derinlik { get; set; }
        public string Siddet { get; set; }
        public string Yer { get; set; }

        public string Dizin => Directory.GetCurrentDirectory() + "//depremler";
        public string Dugum => "/html/body/pre/text()[1]";
    }
}