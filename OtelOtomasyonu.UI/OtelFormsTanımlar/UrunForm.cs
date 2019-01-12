using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OtelOtomasyonu.ORM;
using OtelOtomasyonu.ORM.Entity;
using OtelOtomasyonu.ORM.Facade;


namespace OtelOtomasyonu.UI
{
    public partial class UrunForm : Form
    {
        public UrunForm()
        {
            InitializeComponent();
        }
        UrunORM uOrm = new UrunORM();
        private void UrunForm_Load(object sender, EventArgs e)
        {
            Text = "Tanımlar - Ürünler";

            btnGuncelle.Visible = false;
            btnIptal.Visible = false;

            KategoriORM kOrm = new KategoriORM();
            BirimTipORM btOrm = new BirimTipORM();

            cmbBirim.DataSource = btOrm.Select();
            cmbBirim.DisplayMember = "Adi";
            cmbBirim.ValueMember = "Id";

            cmbKategori.DataSource = kOrm.Select();
            cmbKategori.DisplayMember = "Adi";
            cmbKategori.ValueMember = "Id";

            dataGridView1.DataSource = uOrm.Select();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            
        }

        private void btnEkle_Click_1(object sender, EventArgs e)
        {
            if (txtAdi.Text == null || txtAdi.Text == "")
            {
                MessageBox.Show("Ürün adını giriniz ", "Ürün Adı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAdi.Focus();
                return;
            }
            if (cmbKategori.Items.Count==0 || cmbBirim.Items.Count==0)
            {
                MessageBox.Show("Ürün eklemek için Kategori ve Birim Tipini belirlemelisiniz.\n -Tanımlar/Kategoriler \n -Tanımlar/Birim Tip", "Ürün Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            Urunler u = new Urunler();
            u.Adi =Tools.ToTitleCase(txtAdi.Text);
            u.Fiyat = nudFiyat.Value;
            u.Miktar = Convert.ToDouble(nudMiktar.Value);

            u.KategoriID = Convert.ToInt32(cmbKategori.SelectedValue);
            u.BirimTipID = Convert.ToInt32(cmbBirim.SelectedValue);

            
            bool sonuc = uOrm.Insert(u);
            if (sonuc)
            {
                MessageBox.Show("Ürün eklendi", "Ürün Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = uOrm.Select();
                Tools.Temizle(this);
                txtAdi.Focus();
            }
            else
            {
                MessageBox.Show("Ürün eklenmedi\n -Aynı isimde ürün eklenemez\n -Ürün adı boş geçilemez", "Ürün Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void contextMenuStrip1_MouseLeave(object sender, EventArgs e)
        {
            contextMenuStrip1.Visible = false;

        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            if (id <= 0)
            {
                MessageBox.Show("Silinecek ürün yoktur", "Ürün Silme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                Urunler u = new Urunler();
                u.Id = id;
                bool sonuc = uOrm.Delete(u);
                if (sonuc)
                {
                    MessageBox.Show("Ürün Silindi", "Ürün Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = uOrm.Select();
                    dataGridView1.Focus();
                }
                else
                {
                    MessageBox.Show("Ürün Silinmedi\n", "Ürün Silme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
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
                nudFiyat.Value =Convert.ToDecimal(dataGridView1.CurrentRow.Cells[2].Value);
                nudMiktar.Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[3].Value);

                btnEkle.Visible = false;
                dataGridView1.Enabled = false;
                btnGuncelle.Visible = true;
                btnIptal.Visible = true;
                cmbKategori.Enabled = false;
                cmbBirim.Enabled = false;
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtAdi.Text == null || txtAdi.Text == "")
            {
                MessageBox.Show("Ürün adını giriniz ", "Ürün Adı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAdi.Focus();
                return;
            }
            if (cmbKategori.Items.Count == 0 || cmbBirim.Items.Count == 0)
            {
                MessageBox.Show("Ürün eklemek için Kategori ve Birim Tipini belirlemelisiniz.\n -Tanımlar/Kategoriler \n -Tanımlar/Birim Tip", "Ürün Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            if (id <= 0)
            {
                MessageBox.Show("Güncellenecek Ürün yoktur", "Ürün Yok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Urunler u = new Urunler();
                u.Id = id;
                u.Adi = Tools.ToTitleCase(txtAdi.Text);
                u.Fiyat = nudFiyat.Value;
                u.Miktar = Convert.ToDouble(nudMiktar.Value);

                bool sonuc = uOrm.Updated(u);
                if (sonuc)
                {
                    MessageBox.Show("Ürün Güncellendi", "Ürün Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ürün Güncellenmedi\n", "Ürün Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                dataGridView1.DataSource = uOrm.Select();
                Tools.ButtonVisibleControl(this.dataGridView1, this.btnEkle, this.btnGuncelle, this.btnIptal);
                Tools.Temizle(this);
                cmbKategori.Enabled = true;
                cmbBirim.Enabled = true;
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
