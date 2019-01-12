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
    public partial class BirimTipForm : Form
    {
        public BirimTipForm()
        {
            InitializeComponent();
        }
        BirimTipORM btOrm = new BirimTipORM();
        private void btnEkle_Click(object sender, EventArgs e)
        {
            BirimTipleri bt = new BirimTipleri();
            if (txtAdi.Text == null || txtAdi.Text == "")
            {
                MessageBox.Show("Birim Tip Adını giriniz");
                txtAdi.Focus();
                return;
            }
            bt.Adi = Tools.ToTitleCase(txtAdi.Text);
            bool sonuc = btOrm.Insert(bt);
            if (sonuc)
            {
                MessageBox.Show("Birim Tip Eklendi", "Birim Tip Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = btOrm.Select();
                Tools.Temizle(this);
                txtAdi.Focus();
            }
            else
            {
                MessageBox.Show("Birim tip ekleme başarısız.\n -Aynı birim tipten ekleyemezsiniz", "Birim Tip Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }
        
        private void BirimTipForm_Load(object sender, EventArgs e)
        {
            Text = "Tanımlar-Birim Tip";
            btnGuncelle.Visible = false;
            btnIptal.Visible = false;
            dataGridView1.DataSource = btOrm.Select();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtAdi.Text == null || txtAdi.Text == "")
            {
                MessageBox.Show("Birim Tip Adını giriniz");
                txtAdi.Focus();
                return;
            }
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

            if (id <= 0)
            {
                MessageBox.Show("Silinecek eleman yoktur");
            }
            else
            {
                BirimTipleri bt = new BirimTipleri();
                bt.Id = id;
                bool sonuc = btOrm.Delete(bt);
                if (sonuc)
                {
                    MessageBox.Show("Birim Tipi Silindi", "Birim Tipi Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = btOrm.Select();
                    dataGridView1.Focus();
                }
                else
                {
                    MessageBox.Show("Birim Tipi Silinmedi\n", "Birim Tipi Silme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            if (id <= 0)
            {
                MessageBox.Show("Güncellenecek birim tipi yoktur", "Birim Tip Yok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                BirimTipleri bt = new BirimTipleri();
                bt.Id = id;
                bt.Adi =Tools.ToTitleCase(txtAdi.Text);
                bool sonuc = btOrm.Updated(bt);
                if (sonuc)
                {
                    MessageBox.Show("Birim Tipi Güncellendi", "Birim Tipi Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }
                else
                {
                    MessageBox.Show("Birim Tipi Güncellenmedi\n", "Birim Tipi Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                dataGridView1.DataSource = btOrm.Select();
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
                txtAdi.Text = dataGridView1.CurrentRow.Cells["Adi"].Value.ToString();
                btnEkle.Visible = false;
                dataGridView1.Enabled = false;
                btnGuncelle.Visible = true;
                btnIptal.Visible = true;
            }
        }
    }
}
