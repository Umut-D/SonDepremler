namespace Son_Depremler
{
    partial class FrmSonDepremler
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSonDepremler));
            this.listView = new System.Windows.Forms.ListView();
            this.chTarih = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEnlem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBoylam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDerinlik = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBuyukluk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chYer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.zamanlayici = new System.Windows.Forms.Timer(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiAyarlar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDepremSayisi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi20Deprem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi50Deprem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi100Deprem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi150Deprem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi200Deprem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGuncellemeSikligi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi1Dakika = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi5Dakika = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi10Dakika = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi15Dakika = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi30Dakika = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBildirimSesi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAcik = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiKapali = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBilgi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGuncelle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHakkinda = new System.Windows.Forms.ToolStripMenuItem();
            this.btnYenile = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsslDurum = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsSagTikMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsGoster = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCikis = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.cmsSagTikMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTarih,
            this.chEnlem,
            this.chBoylam,
            this.chDerinlik,
            this.chBuyukluk,
            this.chYer});
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(12, 27);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(732, 433);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ListView_ColumnWidthChanging);
            this.listView.SelectedIndexChanged += new System.EventHandler(this.ListView_SelectedIndexChanged);
            // 
            // chTarih
            // 
            this.chTarih.Text = "Tarih";
            this.chTarih.Width = 135;
            // 
            // chEnlem
            // 
            this.chEnlem.Text = "Enlem";
            this.chEnlem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chEnlem.Width = 70;
            // 
            // chBoylam
            // 
            this.chBoylam.Text = "Boylam";
            this.chBoylam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chBoylam.Width = 70;
            // 
            // chDerinlik
            // 
            this.chDerinlik.Text = "Derinlik";
            this.chDerinlik.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chBuyukluk
            // 
            this.chBuyukluk.Text = "Büyüklük";
            this.chBuyukluk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chBuyukluk.Width = 70;
            // 
            // chYer
            // 
            this.chYer.Text = "Yer";
            this.chYer.Width = 305;
            // 
            // zamanlayici
            // 
            this.zamanlayici.Interval = 30000;
            this.zamanlayici.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAyarlar,
            this.tsmiBilgi});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(754, 31);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // tsmiAyarlar
            // 
            this.tsmiAyarlar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDepremSayisi,
            this.tsmiGuncellemeSikligi,
            this.tsmiBildirimSesi});
            this.tsmiAyarlar.Name = "tsmiAyarlar";
            this.tsmiAyarlar.Size = new System.Drawing.Size(79, 27);
            this.tsmiAyarlar.Text = "Ayarlar";
            // 
            // tsmiDepremSayisi
            // 
            this.tsmiDepremSayisi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi20Deprem,
            this.tsmi50Deprem,
            this.tsmi100Deprem,
            this.tsmi150Deprem,
            this.tsmi200Deprem});
            this.tsmiDepremSayisi.Name = "tsmiDepremSayisi";
            this.tsmiDepremSayisi.Size = new System.Drawing.Size(308, 30);
            this.tsmiDepremSayisi.Text = "Gösterilecek Deprem Sayısı";
            // 
            // tsmi20Deprem
            // 
            this.tsmi20Deprem.Name = "tsmi20Deprem";
            this.tsmi20Deprem.Size = new System.Drawing.Size(131, 30);
            this.tsmi20Deprem.Text = "20";
            this.tsmi20Deprem.Click += new System.EventHandler(this.Tsmi20Deprem_Click);
            // 
            // tsmi50Deprem
            // 
            this.tsmi50Deprem.Name = "tsmi50Deprem";
            this.tsmi50Deprem.Size = new System.Drawing.Size(131, 30);
            this.tsmi50Deprem.Text = "50";
            this.tsmi50Deprem.Click += new System.EventHandler(this.Tsmi50Deprem_Click);
            // 
            // tsmi100Deprem
            // 
            this.tsmi100Deprem.Name = "tsmi100Deprem";
            this.tsmi100Deprem.Size = new System.Drawing.Size(131, 30);
            this.tsmi100Deprem.Text = "100";
            this.tsmi100Deprem.Click += new System.EventHandler(this.Tsmi100Deprem_Click);
            // 
            // tsmi150Deprem
            // 
            this.tsmi150Deprem.Name = "tsmi150Deprem";
            this.tsmi150Deprem.Size = new System.Drawing.Size(131, 30);
            this.tsmi150Deprem.Text = "150";
            this.tsmi150Deprem.Click += new System.EventHandler(this.Tsmi150Deprem_Click);
            // 
            // tsmi200Deprem
            // 
            this.tsmi200Deprem.Name = "tsmi200Deprem";
            this.tsmi200Deprem.Size = new System.Drawing.Size(131, 30);
            this.tsmi200Deprem.Text = "200";
            this.tsmi200Deprem.Click += new System.EventHandler(this.Tsmi200Deprem_Click);
            // 
            // tsmiGuncellemeSikligi
            // 
            this.tsmiGuncellemeSikligi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi1Dakika,
            this.tsmi5Dakika,
            this.tsmi10Dakika,
            this.tsmi15Dakika,
            this.tsmi30Dakika});
            this.tsmiGuncellemeSikligi.Name = "tsmiGuncellemeSikligi";
            this.tsmiGuncellemeSikligi.Size = new System.Drawing.Size(308, 30);
            this.tsmiGuncellemeSikligi.Text = "Güncelleme Sıklığı";
            // 
            // tsmi1Dakika
            // 
            this.tsmi1Dakika.Name = "tsmi1Dakika";
            this.tsmi1Dakika.Size = new System.Drawing.Size(175, 30);
            this.tsmi1Dakika.Text = "1 dakika";
            this.tsmi1Dakika.Click += new System.EventHandler(this.Tsmi1Dakika_Click);
            // 
            // tsmi5Dakika
            // 
            this.tsmi5Dakika.Name = "tsmi5Dakika";
            this.tsmi5Dakika.Size = new System.Drawing.Size(175, 30);
            this.tsmi5Dakika.Text = "5 dakika";
            this.tsmi5Dakika.Click += new System.EventHandler(this.Tsmi5Dakika_Click);
            // 
            // tsmi10Dakika
            // 
            this.tsmi10Dakika.Name = "tsmi10Dakika";
            this.tsmi10Dakika.Size = new System.Drawing.Size(175, 30);
            this.tsmi10Dakika.Text = "10 dakika";
            this.tsmi10Dakika.Click += new System.EventHandler(this.Tsmi10Dakika_Click);
            // 
            // tsmi15Dakika
            // 
            this.tsmi15Dakika.Name = "tsmi15Dakika";
            this.tsmi15Dakika.Size = new System.Drawing.Size(175, 30);
            this.tsmi15Dakika.Text = "15 dakika";
            this.tsmi15Dakika.Click += new System.EventHandler(this.Tsmi15Dakika_Click);
            // 
            // tsmi30Dakika
            // 
            this.tsmi30Dakika.Name = "tsmi30Dakika";
            this.tsmi30Dakika.Size = new System.Drawing.Size(175, 30);
            this.tsmi30Dakika.Text = "30 dakika";
            this.tsmi30Dakika.Click += new System.EventHandler(this.Tsmi30Dakika_Click);
            // 
            // tsmiBildirimSesi
            // 
            this.tsmiBildirimSesi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAcik,
            this.tsmiKapali});
            this.tsmiBildirimSesi.Name = "tsmiBildirimSesi";
            this.tsmiBildirimSesi.Size = new System.Drawing.Size(308, 30);
            this.tsmiBildirimSesi.Text = "Bildirim Sesi";
            // 
            // tsmiAcik
            // 
            this.tsmiAcik.Name = "tsmiAcik";
            this.tsmiAcik.Size = new System.Drawing.Size(150, 30);
            this.tsmiAcik.Text = "Açık";
            this.tsmiAcik.Click += new System.EventHandler(this.TsmiAcik_Click);
            // 
            // tsmiKapali
            // 
            this.tsmiKapali.Name = "tsmiKapali";
            this.tsmiKapali.Size = new System.Drawing.Size(150, 30);
            this.tsmiKapali.Text = "Kapalı";
            this.tsmiKapali.Click += new System.EventHandler(this.TsmiKapali_Click);
            // 
            // tsmiBilgi
            // 
            this.tsmiBilgi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGuncelle,
            this.tsmiHakkinda});
            this.tsmiBilgi.Name = "tsmiBilgi";
            this.tsmiBilgi.Size = new System.Drawing.Size(58, 27);
            this.tsmiBilgi.Text = "Bilgi";
            // 
            // tsmiGuncelle
            // 
            this.tsmiGuncelle.Name = "tsmiGuncelle";
            this.tsmiGuncelle.Size = new System.Drawing.Size(174, 30);
            this.tsmiGuncelle.Text = "Guncelle";
            this.tsmiGuncelle.Click += new System.EventHandler(this.TsmiGuncelle_Click);
            // 
            // tsmiHakkinda
            // 
            this.tsmiHakkinda.Name = "tsmiHakkinda";
            this.tsmiHakkinda.Size = new System.Drawing.Size(174, 30);
            this.tsmiHakkinda.Text = "Hakkinda";
            this.tsmiHakkinda.Click += new System.EventHandler(this.TsmiHakkinda_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.Image = global::Son_Depremler.Properties.Resources.yenile;
            this.btnYenile.Location = new System.Drawing.Point(717, 0);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(27, 24);
            this.btnYenile.TabIndex = 2;
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.BtnYenile_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslDurum});
            this.statusStrip.Location = new System.Drawing.Point(0, 456);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(754, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip";
            // 
            // tsslDurum
            // 
            this.tsslDurum.Name = "tsslDurum";
            this.tsslDurum.Size = new System.Drawing.Size(0, 15);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "Program hala çalışıyor...";
            this.notifyIcon.BalloonTipTitle = "Son Depremler";
            this.notifyIcon.ContextMenuStrip = this.cmsSagTikMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Bilgilendirme";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // cmsSagTikMenu
            // 
            this.cmsSagTikMenu.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.cmsSagTikMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsGoster,
            this.cmsCikis});
            this.cmsSagTikMenu.Name = "cmsSagTikMenu";
            this.cmsSagTikMenu.Size = new System.Drawing.Size(131, 60);
            // 
            // cmsGoster
            // 
            this.cmsGoster.Name = "cmsGoster";
            this.cmsGoster.Size = new System.Drawing.Size(130, 28);
            this.cmsGoster.Text = "Goster";
            this.cmsGoster.Click += new System.EventHandler(this.CmsGoster_Click);
            // 
            // cmsCikis
            // 
            this.cmsCikis.Name = "cmsCikis";
            this.cmsCikis.Size = new System.Drawing.Size(130, 28);
            this.cmsCikis.Text = "Çıkış";
            this.cmsCikis.Click += new System.EventHandler(this.CmsKapat_Click);
            // 
            // FrmSonDepremler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 478);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.969231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(774, 530);
            this.MinimumSize = new System.Drawing.Size(774, 530);
            this.Name = "FrmSonDepremler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Son Depremler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSonDepremler_FormClosing);
            this.Load += new System.EventHandler(this.FrmSonDepremler_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSonDepremler_KeyDown);
            this.Resize += new System.EventHandler(this.FrmSonDepremler_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.cmsSagTikMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader chBuyukluk;
        private System.Windows.Forms.ColumnHeader chTarih;
        private System.Windows.Forms.ColumnHeader chEnlem;
        private System.Windows.Forms.ColumnHeader chBoylam;
        private System.Windows.Forms.ColumnHeader chDerinlik;
        private System.Windows.Forms.ColumnHeader chYer;
        public System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Timer zamanlayici;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiBilgi;
        private System.Windows.Forms.ToolStripMenuItem tsmiGuncelle;
        private System.Windows.Forms.ToolStripMenuItem tsmiHakkinda;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsslDurum;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip cmsSagTikMenu;
        private System.Windows.Forms.ToolStripMenuItem cmsGoster;
        private System.Windows.Forms.ToolStripMenuItem cmsCikis;
        private System.Windows.Forms.ToolStripMenuItem tsmiAyarlar;
        public System.Windows.Forms.ToolStripMenuItem tsmiGuncellemeSikligi;
        public System.Windows.Forms.ToolStripMenuItem tsmi1Dakika;
        public System.Windows.Forms.ToolStripMenuItem tsmi5Dakika;
        public System.Windows.Forms.ToolStripMenuItem tsmi10Dakika;
        public System.Windows.Forms.ToolStripMenuItem tsmi15Dakika;
        public System.Windows.Forms.ToolStripMenuItem tsmi30Dakika;
        public System.Windows.Forms.ToolStripMenuItem tsmiBildirimSesi;
        public System.Windows.Forms.ToolStripMenuItem tsmiAcik;
        public System.Windows.Forms.ToolStripMenuItem tsmiKapali;
        public System.Windows.Forms.ToolStripMenuItem tsmi20Deprem;
        public System.Windows.Forms.ToolStripMenuItem tsmi50Deprem;
        public System.Windows.Forms.ToolStripMenuItem tsmi100Deprem;
        public System.Windows.Forms.ToolStripMenuItem tsmi150Deprem;
        public System.Windows.Forms.ToolStripMenuItem tsmi200Deprem;
        public System.Windows.Forms.ToolStripMenuItem tsmiDepremSayisi;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

