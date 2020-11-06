using System;
using System.IO;
using System.Windows.Forms;
using Son_Depremler.Siniflar;
using Son_Depremler.Siniflar.Baglanti;
using Son_Depremler.Siniflar.Form;

namespace Son_Depremler
{
    public partial class FrmSonDepremler : Form
    {
        private readonly Depremler _depremler;
        private readonly Bildirimler _bilgilendir;
        private Araclar Araclar { get; }

        public FrmSonDepremler()
        {
            InitializeComponent();
            Araclar = new Araclar(this);
            _depremler = new Depremler();
            _bilgilendir = new Bildirimler();
        }

        public void FrmSonDepremler_Load(object sender, EventArgs e)
        {
            ListeleVeBilgilendir();
            Araclar.Dakika();
            Araclar.Ses();
            Araclar.DepremSayisi();

            toolTip.SetToolTip(btnYenile, "F5 Tuşuyla da yenileme yapılabilir");
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count <= 0)
                return;

            ListViewItem lviSeciliNesne = listView.SelectedItems[0];

            string enlem = lviSeciliNesne.SubItems[1].Text;
            string boylam = lviSeciliNesne.SubItems[2].Text;

            Harita harita = new Harita(enlem, boylam);
            harita.Ac();
        }

        private void BtnYenile_Click(object sender, EventArgs e)
        {
            ListeleVeBilgilendir();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ListeleVeBilgilendir();
        }

        private void TsmiGuncelle_Click(object sender, EventArgs e)
        {
            Guncelle guncelle = new Guncelle();
            guncelle.VersiyonKontrol();
        }

        private void TsmiHakkinda_Click(object sender, EventArgs e)
        {
            _bilgilendir.Hakkinda();
        }

        private void ListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            // Liste görünümünde sütunların kullanıcı tarafından değiştirilmesini engelle
            e.Cancel = true;
            e.NewWidth = listView.Columns[e.ColumnIndex].Width;
        }

        private void FrmSonDepremler_Resize(object sender, EventArgs e)
        {
            // Form küçülüp büyütüldüğünde görüntülenecek mesajlar ve form durumu
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
            // Farenin sol tuşuna basıldığında formu göster
            if (e.Button == MouseButtons.Left)
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
        }

        private void CmsGoster_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void Tsmi20Deprem_Click(object sender, EventArgs e)
        {
            Araclar.Ayarla(20, "DepremSayi");
        }

        private void Tsmi50Deprem_Click(object sender, EventArgs e)
        {
            Araclar.Ayarla(50, "DepremSayi");
        }

        private void Tsmi100Deprem_Click(object sender, EventArgs e)
        {
            Araclar.Ayarla(100, "DepremSayi");
        }

        private void Tsmi150Deprem_Click(object sender, EventArgs e)
        {
            Araclar.Ayarla(150, "DepremSayi");
        }

        private void Tsmi200Deprem_Click(object sender, EventArgs e)
        {
            Araclar.Ayarla(200, "DepremSayi");
        }

        private void Tsmi1Dakika_Click(object sender, EventArgs e)
        {
            Araclar.Ayarla(1, "Dakika");
        }

        private void Tsmi5Dakika_Click(object sender, EventArgs e)
        {
            Araclar.Ayarla(5, "Dakika");
        }

        private void Tsmi10Dakika_Click(object sender, EventArgs e)
        {
            Araclar.Ayarla(10, "Dakika");
        }

        private void Tsmi15Dakika_Click(object sender, EventArgs e)
        {
            Araclar.Ayarla(15, "Dakika");
        }

        private void Tsmi30Dakika_Click(object sender, EventArgs e)
        {
            Araclar.Ayarla(30, "Dakika");
        }

        private void TsmiAcik_Click(object sender, EventArgs e)
        {
            Araclar.Ayarla(true, "Ses");
        }

        private void TsmiKapali_Click(object sender, EventArgs e)
        {
            Araclar.Ayarla(false, "Ses");
        }

        private void CmsKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmSonDepremler_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(_depremler.Deprem.Dizin))
                File.Delete(_depremler.Deprem.Dizin);
        }

        private void ListeleVeBilgilendir()
        {
            _depremler.Listele(listView, zamanlayici);
            tsslDurum.Text = _bilgilendir.SonGuncelleme();
        }

        // F5 tuşuna basılınca yenileme yap
        private void FrmSonDepremler_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                BtnYenile_Click(null, null);
            }
        }
    }
}