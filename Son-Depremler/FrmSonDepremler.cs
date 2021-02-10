using System;
using System.Windows.Forms;
using Son_Depremler.Siniflar;
using Son_Depremler.Siniflar.Araclar;
using Son_Depremler.Siniflar.Form;
using Son_Depremler.Siniflar.Internet;

namespace Son_Depremler
{
    public partial class FrmSonDepremler : Form
    {
        private Baglanti _baglanti;
        private readonly Ayar _ayar;

        public FrmSonDepremler()
        {
            InitializeComponent();

            _ayar = new Ayar(this);
        }

        public void FrmSonDepremler_Load(object sender, EventArgs e)
        {
            _baglanti = new Baglanti();

            ListeleVeBildirimYap();

            ToolStripAyarlariniYukle();

            toolTip.SetToolTip(btnYenile, "F5 Tuşuyla da yenileme yapılabilir");
        }

        private void ListeleVeBildirimYap()
        {
            DepremListesi depremListesi = new DepremListesi(listView);
            depremListesi.Listele();

            TimerSifirla();

            Bildirim bildirim = new Bildirim();
            tsslDurum.Text = bildirim.SonrakiGuncellemeZamani();

            BtnYenileAktifMi(true);
        }

        private void BtnYenileAktifMi(bool durum)
        {
            btnYenile.Enabled = durum;
        }

        public void TimerSifirla()
        {
            int dakika = (int) _ayar.Yukle("Dakika");

            zamanlayici.Stop();
            zamanlayici.Start();
            zamanlayici.Interval = 1000 * 60 * dakika;
        }

        private void ToolStripAyarlariniYukle()
        {
            ToolStripMenuAyarlar tsmiAyar = new ToolStripMenuAyarlar(this);
            tsmiAyar.DakikaAraligi();
            tsmiAyar.Ses();
            tsmiAyar.GoruntulenecekDepremSayisi();
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count <= 0)
                return;

            string enlem = listView.SelectedItems[0].SubItems[1].Text;
            string boylam = listView.SelectedItems[0].SubItems[2].Text;

            Harita harita = new Harita();
            harita.Ac(enlem, boylam);
        }

        private void ListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView.Columns[e.ColumnIndex].Width;
        }

        private void BtnYenile_Click(object sender, EventArgs e)
        {
            BtnYenileAktifMi(false);

            ListeleVeBildirimYap();
        }

        private void FrmSonDepremler_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                BtnYenile_Click(sender, e);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ListeleVeBildirimYap();
        }

        private void Tsmi20Deprem_Click(object sender, EventArgs e)
        {
            _ayar.Kaydet(20, "DepremSayi");
        }

        private void Tsmi50Deprem_Click(object sender, EventArgs e)
        {
            _ayar.Kaydet(50, "DepremSayi");
        }

        private void Tsmi100Deprem_Click(object sender, EventArgs e)
        {
            _ayar.Kaydet(100, "DepremSayi");
        }

        private void Tsmi150Deprem_Click(object sender, EventArgs e)
        {
            _ayar.Kaydet(150, "DepremSayi");
        }

        private void Tsmi200Deprem_Click(object sender, EventArgs e)
        {
            _ayar.Kaydet(200, "DepremSayi");
        }

        private void Tsmi1Dakika_Click(object sender, EventArgs e)
        {
            _ayar.Kaydet(1, "Dakika");
        }

        private void Tsmi5Dakika_Click(object sender, EventArgs e)
        {
            _ayar.Kaydet(5, "Dakika");
        }

        private void Tsmi10Dakika_Click(object sender, EventArgs e)
        {
            _ayar.Kaydet(10, "Dakika");
        }

        private void Tsmi15Dakika_Click(object sender, EventArgs e)
        {
            _ayar.Kaydet(15, "Dakika");
        }

        private void Tsmi30Dakika_Click(object sender, EventArgs e)
        {
            _ayar.Kaydet(30, "Dakika");
        }

        private void TsmiAcik_Click(object sender, EventArgs e)
        {
            _ayar.Kaydet(true, "Ses");
        }

        private void TsmiKapali_Click(object sender, EventArgs e)
        {
            _ayar.Kaydet(false, "Ses");
        }

        private void FrmSonDepremler_Resize(object sender, EventArgs e)
        {
            switch (WindowState)
            {
                case FormWindowState.Minimized:
                    notifyIcon.Visible = true;
                    notifyIcon.ShowBalloonTip(2000);
                    Hide();
                    break;
                case FormWindowState.Normal:
                    notifyIcon.Visible = false;
                    break;
            }
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            CmsGoster_Click(sender, e);
        }

        private void CmsGoster_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void TsmiGuncelle_Click(object sender, EventArgs e)
        {
            Guncelle guncelle = new Guncelle();
            guncelle.VersiyonKontroluYap(_baglanti);
        }

        private void TsmiHakkinda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Son Depremler programıyla; Boğaziçi Üniversitesi, Kandilli Rasathanesi ve Deprem Araştırma Enstitüsü (KRDAE) aracılığıyla sağlanan deprem verilerini istediniz zaman aralıklarında görebilirsiniz." + Environment.NewLine + Environment.NewLine + @"Ayrıca, ilgili deprem(ler)e tıklayarak mevcut tarayıcınızda depremin olduğu yeri Google Haritalar sayfasında görüntüleyebilirsiniz.", @"Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmSonDepremler_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dosya dosya = new Dosya();
            dosya.CikistaHtmlDosyasiniSil();
        }

        private void CmsKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}