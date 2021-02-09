using System;
using System.IO;
using System.Media;
using System.Windows.Forms;
using Son_Depremler.Properties;

namespace Son_Depremler.Siniflar.Araclar
{
    public class Ses
    {
        public void Oynat()
        {
            try
            {
                UnmanagedMemoryStream seciliSes = Resources.tone_beep;
                SoundPlayer alarmCal = new SoundPlayer(seciliSes);
                alarmCal.Play();
            }
            catch (Exception)
            {
                MessageBox.Show(@"Ses sorunu yaşandı. Ses kartınızla ilgili bir sorun olabilir. Şöyle bir hata mevcut; {sesHata.Message}", @"Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}