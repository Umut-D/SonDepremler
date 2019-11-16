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
        }

        readonly Depremler _depremler = new Depremler();
        readonly Bilgilendirme _bilgilendirme = new Bilgilendirme();

        private void FrmSonDepremler_Load(object sender, EventArgs e)
        {
            ListeleVeBilgilendir();
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem lviSeciliNesne = listView.SelectedItems[0];

                Harita harita = new Harita
                {
                    Enlem = lviSeciliNesne.SubItems[1].Text,
                    Boylam = lviSeciliNesne.SubItems[2].Text
                };

                harita.Ac();
            }
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
            _bilgilendirme.Hakkinda();
        }

        // Liste görünümünde sütunların kullanıcı tarafından değiştirilmesini engelle
        private void ListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView.Columns[e.ColumnIndex].Width;
        }

        private void ListeleVeBilgilendir()
        {
            _depremler.Listele(listView, zamanlayici);
            tsslDurum.Text = _bilgilendirme.SonGuncelleme();
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
            // Bağlam menüsü > Göster
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void CmsKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}