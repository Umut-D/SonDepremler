using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;
using Son_Depremler.Properties;
using static Son_Depremler.Siniflar.Form.Sabitler.GuncellemeAraligi;
using static Son_Depremler.Siniflar.Form.Sabitler.GosterimSayisi;

namespace Son_Depremler.Siniflar.Form
{
    public class Araclar : Sabitler
    {
        private readonly FrmSonDepremler _frmSonDepremler;

        public Araclar(FrmSonDepremler frmSonDepremler)
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

        // Gelen tip değerine ilgili ayarı (Dakika-Ses) kaydet
        public void Ayarla<T>(T deger, string ayarAdi)
        {
            Settings.Default[ayarAdi] = deger;
            Settings.Default.Save();
            _frmSonDepremler.FrmSonDepremler_Load(this, null);
        }

        public void Dakika()
        {
            foreach (ToolStripMenuItem nesne in _frmSonDepremler.tsmiGuncellemeSikligi.DropDownItems)
                nesne.Checked = false;

            GuncellemeAraligi guncellemeAraligi = (GuncellemeAraligi) Settings.Default["Dakika"];
            switch (guncellemeAraligi)
            {
                case Bir:
                    _frmSonDepremler.tsmi1Dakika.Checked = true;
                    break;
                case Bes:
                    _frmSonDepremler.tsmi5Dakika.Checked = true;
                    break;
                case On:
                    _frmSonDepremler.tsmi10Dakika.Checked = true;
                    break;
                case OnBes:
                    _frmSonDepremler.tsmi15Dakika.Checked = true;
                    break;
                case Otuz:
                    _frmSonDepremler.tsmi30Dakika.Checked = true;
                    break;
            }
        }

        public void DepremSayisi()
        {
            foreach (ToolStripMenuItem nesne in _frmSonDepremler.tsmiDepremSayisi.DropDownItems)
                nesne.Checked = false;

            GosterimSayisi gosterimSayisi = (GosterimSayisi) Settings.Default["DepremSayi"];
            switch (gosterimSayisi)
            {
                case Yirmi:
                    _frmSonDepremler.tsmi20Deprem.Checked = true;
                    break;
                case Elli:
                    _frmSonDepremler.tsmi50Deprem.Checked = true;
                    break;
                case Yuz:
                    _frmSonDepremler.tsmi100Deprem.Checked = true;
                    break;
                case YuzElli:
                    _frmSonDepremler.tsmi150Deprem.Checked = true;
                    break;
                case IkiYuz:
                    _frmSonDepremler.tsmi200Deprem.Checked = true;
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
    }
}