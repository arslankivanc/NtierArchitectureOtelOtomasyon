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
    public partial class OdalarForm : Form
    {
        public OdalarForm()
        {
            InitializeComponent();
        }
        OdalarORM odaOrm = new OdalarORM();
        private void OdalarForm_Load(object sender, EventArgs e)
        {
            Text = "Tanımlar - Odalar";
            btnGuncelle.Visible = false;
            btnIptal.Visible = false;

            OdaTurleriORM oturOrm = new OdaTurleriORM();
            cmbOdaTuru.DataSource = oturOrm.Select();
            cmbOdaTuru.DisplayMember = "Adi";
            cmbOdaTuru.ValueMember = "Id";
            
            dataGridView1.DataSource = odaOrm.Select();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;


        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtOdaAdi.Text == null || txtOdaAdi.Text == "")
            {
                MessageBox.Show("Oda adını giriniz.", "Odalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOdaAdi.Focus();
                return;
            }
            if (cmbOdaTuru.Items.Count==0)
            {
                MessageBox.Show("Oda eklemek için öncelikle Oda türü tanımlamalısınız\n -Tanımlar/Oda Türleri ", "Odalar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            Odalar o = new Odalar();
            o.Aciklama = Tools.ToTitleCase(txtAciklama.Text);
            o.Adi = Tools.ToTitleCase(txtOdaAdi.Text);
            o.OdaTurID = (int)cmbOdaTuru.SelectedValue;
            
            bool sonuc = odaOrm.Insert(o);
            if (sonuc)
            {
                MessageBox.Show("Oda eklendi","Oda Ekleme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                dataGridView1.DataSource = odaOrm.Select();
                Tools.Temizle(this);
                txtOdaAdi.Focus();
            }
            else
            {
                MessageBox.Show("Oda eklenmedi\n -Aynı isimde oda eklenemez\n -Oda ismi boş geçilemez ","Oda Ekleme",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                Tools.MouseDownControl(e, this.dataGridView1, this.contextMenuStrip1, this.silToolStripMenuItem);
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            if (id <= 0)
            {
                MessageBox.Show("Silinecek oda yoktur");
            }
            else
            {
                Odalar o = new Odalar();
                o.Id = id;
                bool sonuc = odaOrm.Delete(o);
                if (sonuc)
                {
                    MessageBox.Show("Oda Silindi", "Oda Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = odaOrm.Select();
                    dataGridView1.Focus();
                }
                else
                {
                    MessageBox.Show("Oda Silinmedi\n", "Oda Silme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void contextMenuStrip1_MouseLeave(object sender, EventArgs e)
        {
            contextMenuStrip1.Visible = false;

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtOdaAdi.Text == null || txtOdaAdi.Text == "")
            {
                MessageBox.Show("Oda adını giriniz.", "Odalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOdaAdi.Focus();
                return;
            }
            if (cmbOdaTuru.Items.Count == 0)
            {
                MessageBox.Show("Oda eklemek için öncelikle Oda türü tanımlamalısınız\n -Tanımlar/Oda Türleri ", "Odalar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            if (id <= 0)
            {
                MessageBox.Show("Güncellenecek oda yoktur", "Oda Yok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Odalar o = new Odalar();
                o.Id = id;
                o.Adi = Tools.ToTitleCase(txtOdaAdi.Text);
                o.Aciklama = Tools.ToTitleCase(txtAciklama.Text);
                o.OdaTurID = (int)cmbOdaTuru.SelectedValue;

                bool sonuc = odaOrm.Updated(o);
                if (sonuc)
                {
                    MessageBox.Show("Oda Güncellendi", "Oda Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Oda Güncellenmedi\n", "Oda Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                dataGridView1.DataSource = odaOrm.Select();
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
            if (Tools.MouseDoubleClick(e,this.dataGridView1)==false)
            {
                return;
            }
            else
            {
                txtOdaAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtAciklama.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                cmbOdaTuru.SelectedValue= Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value);

                btnEkle.Visible = false;
                dataGridView1.Enabled = false;
                btnGuncelle.Visible = true;
                btnIptal.Visible = true;
            }
        }
    }
}
