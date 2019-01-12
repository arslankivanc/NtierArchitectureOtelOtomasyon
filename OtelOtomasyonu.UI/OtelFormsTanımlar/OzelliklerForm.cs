using OtelOtomasyonu.ORM;
using OtelOtomasyonu.ORM.Entity;
using OtelOtomasyonu.ORM.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelOtomasyonu.UI
{
    public partial class OzelliklerForm : Form
    {
        public OzelliklerForm()
        {
            InitializeComponent();
        }
        OzelliklerORM ozellikOrm = new OzelliklerORM();
        private void OzelliklerForm_Load(object sender, EventArgs e)
        {
            Text = "Tanımlar - Özellikler";
            btnGuncelle.Visible = false;
            btnIptal.Visible = false;

            dataGridView1.DataSource = ozellikOrm.Select();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            //dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Ozellikler oze = new Ozellikler();
            if (txtAdi.Text == null || txtAdi.Text == "")
            {
                MessageBox.Show("Özellik adını giriniz");
                txtAdi.Focus();
                return;
            }
            oze.Adi = Tools.ToTitleCase(txtAdi.Text);
            oze.Aciklama = Tools.ToTitleCase(txtAciklama.Text);

            bool sonuc = ozellikOrm.Insert(oze);
            if (sonuc)
            {
                MessageBox.Show("Özellik Eklendi", "Özellik Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = ozellikOrm.Select();
                Tools.Temizle(this);
                txtAdi.Focus();
            }
            else
            {
                MessageBox.Show("Özellik eklenmedi\n -Var olan özellik eklenemez", "Özellik Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Error);              
            }
        }

        private void contextMenuStrip1_MouseLeave(object sender, EventArgs e)
        {
            this.contextMenuStrip1.Visible = false;
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            if (id <= 0)
            {
                MessageBox.Show("Silinecek özellik yoktur", "Özellik Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Ozellikler o = new Ozellikler();
                o.Id = id;
                bool sonuc = ozellikOrm.Delete(o);
                if (sonuc)
                {
                    MessageBox.Show("Özellik Silindi", "Özellik Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = ozellikOrm.Select();
                    dataGridView1.Focus();
                }
                else
                {
                    MessageBox.Show("Özellik Silinmedi\n", "Özellik Silme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                Tools.MouseDownControl(e, this.dataGridView1, this.contextMenuStrip1, this.silToolStripMenuItem);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtAdi.Text == null || txtAdi.Text == "")
            {
                MessageBox.Show("Özellik adını giriniz");
                txtAdi.Focus();
                return;
            }
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            if (id <= 0)
            {
                MessageBox.Show("Mevcut özellik yoktur", "Özellik Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Ozellikler o = new Ozellikler();
                o.Id = id;
                o.Adi = Tools.ToTitleCase(txtAdi.Text);
                o.Aciklama = Tools.ToTitleCase(txtAciklama.Text);

                bool sonuc = ozellikOrm.Updated(o);
                if (sonuc)
                {
                    MessageBox.Show("Özellikler Güncellendi", "Özellikler Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Özellikler Güncellenmedi\n", "Özellikler Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                dataGridView1.DataSource = ozellikOrm.Select();
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
                txtAciklama.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                btnEkle.Visible = false;
                dataGridView1.Enabled = false;
                btnGuncelle.Visible = true;
                btnIptal.Visible = true;
            }
        }
    }
}
