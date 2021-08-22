﻿using System.Windows.Forms;
using SonDepremlerLibrary.Sabitler;
using SonDepremlerLibrary.Sistem;

namespace SonDepremlerUI.Formlar
{
    public class ToolStripMenuAyarlar
    {
        private readonly FrmSonDepremler _frmSonDepremler;
        private readonly Ayar _ayar;

        public ToolStripMenuAyarlar(FrmSonDepremler frmSonDepremler)
        {
            _frmSonDepremler = frmSonDepremler;

            _ayar = new Ayar();
        }

        public void DakikaAraligi()
        {
            foreach (ToolStripMenuItem nesne in _frmSonDepremler.tsmiGuncellemeSikligi.DropDownItems)
                nesne.Checked = false;

            GuncellemeAraligi aralik = (GuncellemeAraligi) _ayar.Yukle("Dakika");
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

            GosterimSayisi gosterim = (GosterimSayisi) _ayar.Yukle("DepremSayi");
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

            bool ses = (bool) _ayar.Yukle("Ses");
            if (ses)
                _frmSonDepremler.tsmiAcik.Checked = true;
            else
                _frmSonDepremler.tsmiKapali.Checked = true;
        }
    }
}