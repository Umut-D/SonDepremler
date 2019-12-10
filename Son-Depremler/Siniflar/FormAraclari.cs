using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;
using Son_Depremler.Properties;

namespace Son_Depremler.Siniflar
{
    public class FormAraclari
    {
        private readonly FrmSonDepremler _frmSonDepremler;

        public FormAraclari(FrmSonDepremler frmSonDepremler)
        {
            _frmSonDepremler = frmSonDepremler;
        }

        public void DepremSiddetiRenklendir(ListView lvListe)
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

        public void TimerSifirla(Timer zamanlayici, int dakika)
        {
            zamanlayici.Stop();
            zamanlayici.Start();
            zamanlayici.Interval = 1000 * 60 * dakika;
        }

        public void Dakika()
        {
            foreach (ToolStripMenuItem nesne in _frmSonDepremler.tsmiGuncellemeSikligi.DropDownItems)
                nesne.Checked = false;

            int dakika = (int) Settings.Default["Dakika"];
            switch (dakika)
            {
                case 1:
                    _frmSonDepremler.tsmi1Dakika.Checked = true;
                    break;
                case 5:
                    _frmSonDepremler.tsmi5Dakika.Checked = true;
                    break;
                case 10:
                    _frmSonDepremler.tsmi10Dakika.Checked = true;
                    break;
                case 15:
                    _frmSonDepremler.tsmi15Dakika.Checked = true;
                    break;
                case 30:
                    _frmSonDepremler.tsmi30Dakika.Checked = true;
                    break;
            }
        }

        public void Ses()
        {
            foreach (ToolStripMenuItem nesne in _frmSonDepremler.tsmiBildirimSesi.DropDownItems)
                nesne.Checked = false;

            bool ses = (bool) Settings.Default["Ses"];
            if (ses)
                _frmSonDepremler.tsmiAcik.Checked = true;
            else
                _frmSonDepremler.tsmiKapali.Checked = true;
        }

        public void SesCal()
        {
            try
            {
                UnmanagedMemoryStream seciliSes = Resources.tone_beep;
                SoundPlayer alarmCal = new SoundPlayer(seciliSes);
                alarmCal.Play();
            }
            catch (Exception sesHata)
            {
                MessageBox.Show(@"Ses sorunu yaşandı. Ses kartınızla ilgili bir sorun olabilir. Şöyle bir hata mevcut; " + Environment.NewLine + sesHata.Message, @"Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Gelen tip değerine ilgili ayarı (Dakika-Ses) kaydet
        public void Ayarla<T>(T deger, string ayarAdi)
        {
            Settings.Default[ayarAdi] = deger;
            Settings.Default.Save();
            _frmSonDepremler.FrmSonDepremler_Load(this, null);
        }
    }
}