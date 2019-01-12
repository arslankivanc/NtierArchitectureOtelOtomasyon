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
    public partial class OdaTurleriForm : Form
    {
        public OdaTurleriForm()
        {
            InitializeComponent();
        }
        OdaTurleriORM otOrm = new OdaTurleriORM();
        private void OdaTurleriForm_Load(object sender, EventArgs e)
        {
            Text = "Tanımlar - Oda Türleri";
            btnGuncelle.Visible = false;
            btnIptal.Visible = false;

            dataGridView1.DataSource = otOrm.Select();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            //Constructer ezildi.
            OdaTurleri ot = new OdaTurleri
            {
                Adi = Tools.ToTitleCase(txtAdi.Text),
                Aciklama =Tools.ToTitleCase(txtAciklama.Text),
                Aktif = true
            };
            if (txtAdi.Text == null || txtAdi.Text == "")
            {
                MessageBox.Show("Oda türünün adını giriniz", "Oda Türü Adı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAdi.Focus();
                return;
            }
            bool sonuc = otOrm.Insert(ot);
            if (sonuc)
            {
                MessageBox.Show("Oda Türü Eklendi", "Oda Türü Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = otOrm.Select();
                Tools.Temizle(this);
                txtAdi.Focus();
            }
            else
            {
                MessageBox.Show("Oda türü eklenmedi\n -Aynı isimde oda türü eklenemez", "Oda Türü Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            if (id <= 0)
            {
                MessageBox.Show("Silinecek eleman yoktur", "Oda Türü Silme", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            else
            {
                OdaTurleri ot = new OdaTurleri();
                ot.Id = id;
                bool sonuc = otOrm.Delete(ot);
                if (sonuc)
                {
                    MessageBox.Show("Oda Türü Silindi", "Oda Türü Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = otOrm.Select();
                    dataGridView1.Focus();
                }
                else
                {
                    MessageBox.Show("Oda Türü  Silinmedi\n", "Oda Türü  Silme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtAdi.Text == null || txtAdi.Text == "")
            {
                MessageBox.Show("Oda türünün adını giriniz", "Oda Türü Adı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAdi.Focus();
                return;
            }
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            if (id <= 0)
            {
                MessageBox.Show("Güncellenecek oda türü yoktur", "Oda Türü Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                OdaTurleri o = new OdaTurleri();
                o.Id = id;
                o.Adi = Tools.ToTitleCase(txtAdi.Text);
                o.Aciklama = Tools.ToTitleCase(txtAciklama.Text);

                bool sonuc = otOrm.Updated(o);
                if (sonuc)
                {
                    MessageBox.Show("Oda Türü Güncellendi", "Oda Türü Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Oda Türü Güncellenmedi\n", "Oda Türü Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                dataGridView1.DataSource = otOrm.Select();
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
    }
}
