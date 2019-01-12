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
    public partial class KasaHareketTipForm : Form
    {
        public KasaHareketTipForm()
        {
            InitializeComponent();
        }
        KasaHareketTipORM kOrm = new KasaHareketTipORM();
        private void KasaHareketTipForm_Load(object sender, EventArgs e)
        {
            Text = "Kasalar - Kasa Hareket Tipi";
            btnGuncelle.Visible = false;
            btnIptal.Visible = false;
            dataGridView1.DataSource = kOrm.Select();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtKasaHarAdi.Text == null || txtKasaHarAdi.Text == "")
            {
                MessageBox.Show("Kasa hareket tipi boş geçilemez", "Kasa Hareket Tip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtKasaHarAdi.Focus();
                return;
            }

            KasaHareketTip k = new KasaHareketTip();
            k.Adi =Tools.ToTitleCase(txtKasaHarAdi.Text);
            bool sonuc = kOrm.Insert(k);
            if (sonuc)
            {
                MessageBox.Show("Kasa hareketi tanımlandı", "Kasa Hareket Tip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = kOrm.Select();
                Tools.Temizle(this);
                txtKasaHarAdi.Focus();
            }
            else
            {
                MessageBox.Show("Kasa hareket tipi eklenmedi\n - Aynı isimde kasa hareketi tanımlanamaz", "Kasa hareket Tip Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            if (id <= 0)
            {
                MessageBox.Show("Silinecek eleman yoktur");
            }
            else
            {
                KasaHareketTip k = new KasaHareketTip();
                k.Id = id;
                bool sonuc = kOrm.Delete(k);
                if (sonuc)
                {
                    MessageBox.Show("Kasa Hareket Tipi inaktif oldu", "Kasa Hareket Tipi Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = kOrm.Select();
                    dataGridView1.Focus();
                }
                else
                {
                    MessageBox.Show("Kasa Hareket Tipi Silinmedi\n", "Kasa Hareket Tipi Silme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void contextMenuStrip1_MouseLeave(object sender, EventArgs e)
        {
            contextMenuStrip1.Visible = false;
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                Tools.MouseDownControl(e, this.dataGridView1, this.contextMenuStrip1, this.silToolStripMenuItem);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtKasaHarAdi.Text == null || txtKasaHarAdi.Text == "")
            {
                MessageBox.Show("Kasa hareket tipi boş geçilemez", "Kasa Hareket Tip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtKasaHarAdi.Focus();
                return;
            }
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            if (id <= 0)
            {
                MessageBox.Show("Güncellenecek Kasa Hareket Tipi yoktur", "Kasa Hareket Tipi Yok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                KasaHareketTip kst = new KasaHareketTip();
                kst.Id = id;
                kst.Adi = Tools.ToTitleCase(txtKasaHarAdi.Text);

                bool sonuc = kOrm.Updated(kst);
                if (sonuc)
                {
                    MessageBox.Show("Kasa Hareket Tipi Güncellendi", "Kasa Hareket Tipi Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Kasa Hareket Tipi Güncellenmedi\n", "Kasa Hareket Tipi Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                dataGridView1.DataSource = kOrm.Select();
                Tools.ButtonVisibleControl(this.dataGridView1, this.btnEkle, this.btnGuncelle, this.btnIptal);
                Tools.Temizle(this);
                dataGridView1.Focus();
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Tools.Temizle(this);
            Tools.ButtonVisibleControl(this.dataGridView1, this.btnEkle, this.btnGuncelle, this.btnIptal);
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Tools.MouseDoubleClick(e, this.dataGridView1) == false)
            {
                return;
            }
            else
            {
                txtKasaHarAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                btnEkle.Visible = false;
                dataGridView1.Enabled = false;
                btnGuncelle.Visible = true;
                btnIptal.Visible = true;
            }
        }
    }
}
