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
    public partial class TedarikcilerForm : Form
    {
        public TedarikcilerForm()
        {
            InitializeComponent();
        }
        TedarikciORM tOrm = new TedarikciORM();
        private void TedarikcilerForm_Load(object sender, EventArgs e)
        {
            Text = "Tedarikçiler";
            dataGridView1.DataSource = tOrm.Select();
            dataGridView1.Columns[0].Visible = false;
            btnGuncelle.Visible = false;
            btnIptal.Visible = false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Tedarikciler t = new Tedarikciler();
            if ((txtAdi.Text == null || txtAdi.Text == "")
                ||(txtSoyadi.Text==null || txtSoyadi.Text=="")
                ||(txtSirketAdi.Text==null || txtSirketAdi.Text==""))
            {
                MessageBox.Show("Adı,Soyadı,Şirket Adı alanları boş geçilemez","Gerekli Alanlar",MessageBoxButtons.OK,MessageBoxIcon.Question);
                txtAdi.Focus();
                return;
            }
            t.Adi =Tools.ToTitleCase(txtAdi.Text);
            t.Soyadi =Tools.ToTitleCase(txtSoyadi.Text);
            t.SirketAdi =Tools.ToTitleCase(txtSirketAdi.Text);
            t.TelNo = mskdTelNo.Text;
            t.Mail = txtMail.Text;
            t.Adres =Tools.ToTitleCase(txtAdres.Text);

            bool sonuc = tOrm.Insert(t);
            if (sonuc)
            {
                MessageBox.Show("Tedarikçi Eklendi", "Tedarikçi Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = tOrm.Select();
                Tools.Temizle(this);
                txtAdi.Focus();
            }
            else
            {
                MessageBox.Show("Tedarikçi eklenemedi\n -Aynı şirket isminde tedarikçi zaten vardır", "Tedarikçi Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            if (id <= 0)
            {
                MessageBox.Show("Silinecek tedarikçi yoktur");
            }
            else
            {
                Tedarikciler t = new Tedarikciler();
                t.Id = id;
                bool sonuc = tOrm.Delete(t);
                if (sonuc)
                {
                    MessageBox.Show("Tedarikçi Silindi", "Tedarikçi Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = tOrm.Select();
                    dataGridView1.Focus();
                }
                else
                {
                    MessageBox.Show("Tedarikçi Silinmedi\n", "Tedarikçi Silme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
            if ((txtAdi.Text == null || txtAdi.Text == "")
                || (txtSoyadi.Text == null || txtSoyadi.Text == "")
                || (txtSirketAdi.Text == null || txtSirketAdi.Text == ""))
            {
                MessageBox.Show("Adı,Soyadı,Şirket Adı alanları boş geçilemez", "Gerekli Alanlar", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtAdi.Focus();
                return;
            }
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            if (id <= 0)
            {
                MessageBox.Show("Güncellenecek Tedarikçi yoktur", "Tedarikçi Yok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Tedarikciler t = new Tedarikciler();
                t.Id = id;
                t.Adi = Tools.ToTitleCase(txtAdi.Text);
                t.Soyadi = Tools.ToTitleCase(txtSoyadi.Text);
                t.SirketAdi = Tools.ToTitleCase(txtSirketAdi.Text);
                t.TelNo = mskdTelNo.Text;
                t.Adres= Tools.ToTitleCase(txtAdres.Text);
                t.Mail = txtMail.Text;

                bool sonuc = tOrm.Updated(t);
                if (sonuc)
                {
                    MessageBox.Show("Tedarikçi Güncellendi", "Tedarikçi Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tedarikçi Güncellenmedi\n", "Tedarikçi Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                dataGridView1.DataSource = tOrm.Select();
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
                txtAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtSoyadi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtSirketAdi.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                mskdTelNo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtAdres.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtMail.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

                btnEkle.Visible = false;
                dataGridView1.Enabled = false;
                btnGuncelle.Visible = true;
                btnIptal.Visible = true;
            }
        }
    }
}
