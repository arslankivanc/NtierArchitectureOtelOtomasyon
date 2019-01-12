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
    public partial class KategoriForm : Form
    {
        public KategoriForm()
        {
            InitializeComponent();
        }

        private void KategoriForm_Load(object sender, EventArgs e)
        {
            Text = "Tanımlar - Kategoriler";
            btnGuncelle.Visible = false;
            btnIptal.Visible = false;
            dataGridView1.DataSource = kOrm.Select();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
        }
        KategoriORM kOrm = new KategoriORM();
        private void btnEkle_Click(object sender, EventArgs e)
        {
            Kategoriler k = new Kategoriler();
            k.Adi =Tools.ToTitleCase(txtKategoriAdi.Text);
            if (txtKategoriAdi.Text == null || txtKategoriAdi.Text == "")
            {
                MessageBox.Show("Kategori adını giriniz.", "Kategori Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtKategoriAdi.Focus();
                return;
            }
            bool sonuc = kOrm.Insert(k);
            if (sonuc)
            {
                MessageBox.Show("Kategori Eklendi", "Kategori Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = kOrm.Select();
                Tools.Temizle(this);
                txtKategoriAdi.Focus();
            }
            else
            {
                MessageBox.Show("Kategori Eklenmedi\n", "Kategori Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Kategoriler k = new Kategoriler();
                k.Id = id;
                bool sonuc = kOrm.Delete(k);
                if (sonuc)
                {
                    MessageBox.Show("Kategori Silindi", "Kategori Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = kOrm.Select();
                    dataGridView1.Focus();
                }
                else
                {
                    MessageBox.Show("Kategori Silinmedi\n", "Kategori Silme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                Tools.MouseDownControl(e, this.dataGridView1, this.contextMenuStrip1, this.silToolStripMenuItem);           
        }

        private void contextMenuStrip1_MouseLeave(object sender, EventArgs e)
        {
            contextMenuStrip1.Visible = false;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtKategoriAdi.Text == null || txtKategoriAdi.Text == "")
            {
                MessageBox.Show("Kategori adını giriniz.", "Kategori Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtKategoriAdi.Focus();
                return;
            }
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            if (id <= 0)
            {
                MessageBox.Show("Güncellenecek kategori yoktur", "Kategori Yok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Kategoriler k = new Kategoriler();
                k.Id = id;
                k.Adi =Tools.ToTitleCase(txtKategoriAdi.Text);

                bool sonuc = kOrm.Updated(k);
                if (sonuc)
                {
                    MessageBox.Show("Kategori Güncellendi", "Kategori Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Kategori Güncellenmedi\n", "Kategori Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                txtKategoriAdi.Text = dataGridView1.CurrentRow.Cells["Adi"].Value.ToString();
                btnEkle.Visible = false;
                dataGridView1.Enabled = false;
                btnGuncelle.Visible = true;
                btnIptal.Visible = true;
            }
        }
    }
}
