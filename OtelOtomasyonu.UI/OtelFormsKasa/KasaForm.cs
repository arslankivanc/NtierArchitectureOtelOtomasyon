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
    public partial class KasaForm : Form
    {
        public KasaForm()
        {
            InitializeComponent();
        }
        KasaORM kOrm = new KasaORM();
        private void btnEkle_Click(object sender, EventArgs e)
        {
            Kasa k = new Kasa();
            if (txtAdi.Text == null || txtAdi.Text == "")
            {
                MessageBox.Show("Kasa adını giriniz", "Kasa Adı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAdi.Focus();
                return;
            }
            k.Adi =Tools.ToTitleCase(txtAdi.Text);
            k.Aciklama =Tools.ToTitleCase(txtAciklama.Text);

            bool sonuc = kOrm.Insert(k);
            if (sonuc)
            {
                MessageBox.Show("Kasa Eklendi", "Kasa Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = kOrm.Select();
                Tools.Temizle(this);
                txtAdi.Focus();
            }
            else
            {
                MessageBox.Show("Kasa eklenmedi\n -Benzer iki kasa eklenemez", "Kasa Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void KasaForm_Load(object sender, EventArgs e)
        {
            Text = "Kasalar - Kasa";
            dataGridView1.DataSource = kOrm.Select();
            dataGridView1.Columns[0].Visible = false;
            btnGuncelle.Visible = false;
            btnIptal.Visible = false;

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

        private void silToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            if (id <= 0)
            {
                MessageBox.Show("Silinecek eleman yoktur");
            }
            else
            {
                Kasa k = new Kasa();
                k.Id = id;
                bool sonuc = kOrm.Delete(k);
                if (sonuc)
                {
                    MessageBox.Show("Kasa Silindi", "Kasa Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = kOrm.Select();
                    dataGridView1.Focus();
                }
                else
                {
                    MessageBox.Show("Kasa Silinmedi\n", "Kasa Silme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnGuncelle_Click_1(object sender, EventArgs e)
        {
            if (txtAdi.Text == null || txtAdi.Text == "")
            {
                MessageBox.Show("Kasa adını giriniz", "Kasa Adı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAdi.Focus();
                return;
            }
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            if (id <= 0)
            {
                MessageBox.Show("Güncellenecek kasa yoktur", "Kasa Yok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Kasa k = new Kasa();
                k.Id = id;
                k.Adi = Tools.ToTitleCase(txtAdi.Text);
                k.Aciklama = Tools.ToTitleCase(txtAciklama.Text);

                bool sonuc = kOrm.Updated(k);
                if (sonuc)
                {
                    MessageBox.Show("Kasa Güncellendi", "Kasa Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Kasa Güncellenmedi\n", "Kasa Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                dataGridView1.DataSource = kOrm.Select();
                Tools.ButtonVisibleControl(this.dataGridView1, this.btnEkle, this.btnGuncelle, this.btnIptal);
                Tools.Temizle(this);
                dataGridView1.Focus();
            }
        }

        private void btnIptal_Click_1(object sender, EventArgs e)
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
                txtAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtAciklama.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                btnEkle.Visible = false;
                dataGridView1.Enabled = false;
                btnGuncelle.Visible = true;
                btnIptal.Visible = true;
            }
        }
    }
}
