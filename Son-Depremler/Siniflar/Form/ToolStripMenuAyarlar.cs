using System.Windows.Forms;
using Son_Depremler.Properties;
using Son_Depremler.Siniflar.Sabitler;

namespace Son_Depremler.Siniflar.Form
{
    public class ToolStripMenuAyarlar
    {
        private readonly FrmSonDepremler _frmSonDepremler;

        public ToolStripMenuAyarlar(FrmSonDepremler frmSonDepremler)
        {
            _frmSonDepremler = frmSonDepremler;
        }


        public void DakikaAraligi()
        {
            foreach (ToolStripMenuItem nesne in _frmSonDepremler.tsmiGuncellemeSikligi.DropDownItems)
                nesne.Checked = false;

            GuncellemeAraligi aralik = (GuncellemeAraligi) Settings.Default["Dakika"];
            switch (aralik)
            {
                case GuncellemeAraligi.Bir:
                    _frmSonDepremler.tsmi1Dakika.Checked = true;
                    break;
                case GuncellemeAraligi.Bes:
                    _frmSonDepremler.tsmi5Dakika.Checked = true;
                    break;
                case GuncellemeAraligi.On:
                    _frmSonDepremler.tsmi10Dakika.Checked = true;
                    break;
                case GuncellemeAraligi.OnBes:
                    _frmSonDepremler.tsmi15Dakika.Checked = true;
                    break;
                case GuncellemeAraligi.Otuz:
                    _frmSonDepremler.tsmi30Dakika.Checked = true;
                    break;
            }
        }

        public void GoruntulenecekDepremSayisi()
        {
            foreach (ToolStripMenuItem nesne in _frmSonDepremler.tsmiDepremSayisi.DropDownItems)
                nesne.Checked = false;

            GosterimSayisi gosterim = (GosterimSayisi) Settings.Default["DepremSayi"];
            switch (gosterim)
            {
                case GosterimSayisi.Yirmi:
                    _frmSonDepremler.tsmi20Deprem.Checked = true;
                    break;
                case GosterimSayisi.Elli:
                    _frmSonDepremler.tsmi50Deprem.Checked = true;
                    break;
                case GosterimSayisi.Yuz:
                    _frmSonDepremler.tsmi100Deprem.Checked = true;
                    break;
                case GosterimSayisi.YuzElli:
                    _frmSonDepremler.tsmi150Deprem.Checked = true;
                    break;
                case GosterimSayisi.IkiYuz:
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
    }
}