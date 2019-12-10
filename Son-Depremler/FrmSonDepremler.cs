using System;
using System.Windows.Forms;
using Son_Depremler.Siniflar;

namespace Son_Depremler
{
    public partial class FrmSonDepremler : Form
    {
        public FrmSonDepremler()
        {
            InitializeComponent();
            FormAraclari = new FormAraclari(this);
        }

        private readonly Depremler _depremler = new Depremler();
        private readonly Bilgilendir _bilgilendir = new Bilgilendir();
        private FormAraclari FormAraclari { get; }

        public void FrmSonDepremler_Load(object sender, EventArgs e)
        {
            ListeleVeBilgilendir();
            FormAraclari.Dakika();
            FormAraclari.Ses();
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

        private void timer_Tick(object sender, EventArgs e)
        {
            ListeleVeBilgilendir();
        }

        private void TsmiGuncelle_Click(object sender, EventArgs e)
        {
            Baglanti.Guncelle();
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

        private void Tsmi1Dakika_Click(object sender, EventArgs e)
        {
            FormAraclari.Ayarla(1, "Dakika");
        }

        private void Tsmi5Dakika_Click(object sender, EventArgs e)
        {
            FormAraclari.Ayarla(5, "Dakika");
        }

        private void Tsmi10Dakika_Click(object sender, EventArgs e)
        {
            FormAraclari.Ayarla(10, "Dakika");
        }

        private void Tsmi15Dakika_Click(object sender, EventArgs e)
        {
            FormAraclari.Ayarla(15, "Dakika");
        }

        private void Tsmi30Dakika_Click(object sender, EventArgs e)
        {
            FormAraclari.Ayarla(30, "Dakika");
        }

        private void CmsKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TsmiAcik_Click(object sender, EventArgs e)
        {
            FormAraclari.Ayarla(true, "Ses");
        }

        private void TsmiKapali_Click(object sender, EventArgs e)
        {
            FormAraclari.Ayarla(false, "Ses");
        }

        private void ListeleVeBilgilendir()
        {
            _depremler.Listele(listView, zamanlayici);
            tsslDurum.Text = _bilgilendir.SonGuncelleme();
        }
    }
}