using OtelOtomasyonu.ORM;
using OtelOtomasyonu.ORM.Entity;
using OtelOtomasyonu.ORM.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelOtomasyonu.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BirimTipForm bt = new BirimTipForm();
        private void birimTipleriToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildForms();
            if (bt.IsDisposed)
            {
                bt = new BirimTipForm();
            }
            bt.MdiParent = this;
            bt.WindowState = FormWindowState.Maximized;

            bt.Show();
        }
        KasaForm kf = new KasaForm();
        private void kasaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildForms();
            if (kf.IsDisposed)
            {
                kf = new KasaForm();
            }
            kf.MdiParent = this;
            kf.WindowState = FormWindowState.Maximized;

            kf.Show();
        }
        KategoriForm ktgForm = new KategoriForm();
        private void kategorilerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildForms();
            if (ktgForm.IsDisposed)
            {
                ktgForm = new KategoriForm();
            }
            ktgForm.MdiParent = this;
            ktgForm.WindowState = FormWindowState.Maximized;

            ktgForm.Show();
        }
        UrunForm urunForm = new UrunForm();
        private void ürünlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildForms();
            if (urunForm.IsDisposed)
            {
                urunForm = new UrunForm();
            }
            urunForm.MdiParent = this;
            urunForm.WindowState = FormWindowState.Maximized;

            urunForm.Show();
        }
        OdaTurleriForm otForm = new OdaTurleriForm();
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildForms();
            if (otForm.IsDisposed)
            {
                otForm = new OdaTurleriForm();
            }
            otForm.MdiParent = this;
            otForm.WindowState = FormWindowState.Maximized;

            otForm.Show();
        }
        OdalarForm odaForm = new OdalarForm();
        private void odalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildForms();
            if (odaForm.IsDisposed)
            {
                odaForm = new OdalarForm();
            }
            odaForm.MdiParent = this;
            odaForm.WindowState = FormWindowState.Maximized;

            odaForm.Show();
        }
        OdaOzelliklerForm odaOzForm = new OdaOzelliklerForm();
        private void odaÖzellikleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildForms();
            if (odaOzForm.IsDisposed)
            {
                odaOzForm = new OdaOzelliklerForm();
            }
            odaOzForm.MdiParent = this;
            odaOzForm.WindowState = FormWindowState.Maximized;

            odaOzForm.Show();
        }
        static void CloseAllMdiChildForms()
        {
            foreach (var form in Application.OpenForms.Cast<Form>().Where(f => f.IsMdiChild).ToArray()) // The ToArray is necessary to build a snapshot
                form.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "Otel Otomasyonu" + "-" + Tools.KullaniciAdSoyad().ToUpper();
            //menuStrip1.Items[3].Visible = false;
            if (PersonellerORM.AktifKullanici.YetkiID == 1) { }
            else if (PersonellerORM.AktifKullanici.YetkiID == 2)
            {
                kasaToolStripMenuItem.Visible = false;
                kasaHareketTipiToolStripMenuItem1.Visible = false;
            }
            else
            {
                menuStrip1.Items[0].Visible = false;
                menuStrip1.Items[1].Visible = false;
                menuStrip1.Items[2].Visible = false;
                menuStrip1.Items[4].Visible = false;
                menuStrip1.Items[5].Visible = false;
                menuStrip1.Items[7].Visible = false;
            }
            çıkışToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            çıkışToolStripMenuItem.BackColor = Color.Red;

            CloseAllMdiChildForms();
            if (musForm.IsDisposed)
            {
                musForm = new MusteriForm();
            }
            musForm.MdiParent = this;
            musForm.WindowState = FormWindowState.Maximized;

            musForm.Show();
        }
        OzelliklerForm ozeForm = new OzelliklerForm();
        private void özelliklerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildForms();
            if (ozeForm.IsDisposed)
            {
                ozeForm = new OzelliklerForm();
            }
            ozeForm.MdiParent = this;
            ozeForm.WindowState = FormWindowState.Maximized;

            ozeForm.Show();
        }
        MusteriForm musForm = new MusteriForm();
        private void müşterilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildForms();
            if (musForm.IsDisposed)
            {
                musForm = new MusteriForm();
            }
            musForm.MdiParent = this;
            musForm.WindowState = FormWindowState.Maximized;

            musForm.Show();
        }
        PersonellerForm pForm = new PersonellerForm();
        private void personellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildForms();
            if (pForm.IsDisposed)
            {
                pForm = new PersonellerForm();
            }
            pForm.MdiParent = this;
            pForm.WindowState = FormWindowState.Maximized;

            pForm.Show();
        }
        SatisForm sf = new SatisForm();
        private void satışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildForms();
            if (sf.IsDisposed)
            {
                sf = new SatisForm();
            }
            sf.MdiParent = this;
            sf.WindowState = FormWindowState.Maximized;

            sf.Show();
        }
        TedarikcilerForm tedForm = new TedarikcilerForm();
        private void tedarikcilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildForms();
            if (tedForm.IsDisposed)
            {
                tedForm = new TedarikcilerForm();
            }
            tedForm.MdiParent = this;
            tedForm.WindowState = FormWindowState.Maximized;

            tedForm.Show();
        }
        SatinAlmaForm saForm = new SatinAlmaForm();
        private void satınAlmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saForm.IsDisposed)
                saForm = new SatinAlmaForm();

            saForm.MdiParent = this;
            saForm.WindowState = FormWindowState.Maximized;

            saForm.Show();
        }
        KasaHareketTipForm khtForm = new KasaHareketTipForm();
        private void kasaHareketTipiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (khtForm.IsDisposed)
            {
                khtForm = new KasaHareketTipForm();
            }
            khtForm.MdiParent = this;
            khtForm.WindowState = FormWindowState.Maximized;

            khtForm.Show();
        }
        KasaHareketForm khForm = new KasaHareketForm();
        private void kasaHareketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (khForm.IsDisposed)
            {
                khForm = new KasaHareketForm();
            }
            khForm.MdiParent = this;
            khForm.WindowState = FormWindowState.Maximized;
            khForm.Show();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SatisDetaylarForm sdForm = new SatisDetaylarForm();
        private void satışDetaylarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sdForm.IsDisposed)
            {
                sdForm = new SatisDetaylarForm();
            }
            sdForm.MdiParent = this;
            sdForm.WindowState = FormWindowState.Maximized;
            sdForm.Show();
        }
    }
}
