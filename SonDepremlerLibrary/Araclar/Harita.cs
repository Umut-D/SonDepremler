using System.Diagnostics;

namespace SonDepremlerLibrary.Araclar
{
    public class Harita
    {
        public void Ac(string enlem, string boylam)
        {
            string googleLink = @"https://www.google.com/maps/place/";
            string link = $"{googleLink}{enlem}+{boylam}/@{enlem},{boylam},7z";

            Process.Start(link);
        }
    }
}