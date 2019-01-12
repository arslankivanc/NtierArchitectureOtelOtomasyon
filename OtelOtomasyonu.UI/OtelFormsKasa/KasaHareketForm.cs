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
    public partial class KasaHareketForm : Form
    {
        public KasaHareketForm()
        {
            InitializeComponent();
        }

        private void KasaHareketForm_Load(object sender, EventArgs e)
        {
            Text = "Kasalar - Kasa Hareket";

            dataGridView1.DataSource = kHarOrm.Select();
            dataGridView1.Columns[0].Visible = false;

            KasaORM kasaOrm = new KasaORM();
            cmbKasaTip.DataSource = kasaOrm.Select();
            cmbKasaTip.DisplayMember = "Adi";
            cmbKasaTip.ValueMember = "Id";
            KasaHareketTipORM khTipOrm = new KasaHareketTipORM();
            cmbKasaHareket.DataSource = khTipOrm.Select();
            cmbKasaHareket.DisplayMember = "Adi";
            cmbKasaHareket.ValueMember = "Id";
        }
        KasaHareketORM kHarOrm = new KasaHareketORM();
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmbKasaTip.Items.Count == 0 || cmbKasaHareket.Items.Count==0)
            {
                MessageBox.Show("-Kasa Tipi\n-Kasa Hareketi\n tanımlamalısınız ", "Kasa Tip-Kasa Hareket", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            KasaHareket kh = new KasaHareket();
            kh.KasaID = Convert.ToInt32(cmbKasaTip.SelectedValue);
            kh.KasaHareketTipID = Convert.ToInt32(cmbKasaHareket.SelectedValue);
            kh.Tutar = nudTutar.Value;
            kh.Tarih = DateTime.Now;
            
            DialogResult result = MessageBox.Show("Kasa hareketi onaylansın mı ?", "Kasa Hareketleri", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result==DialogResult.Yes)
            {
                bool sonuc = kHarOrm.Insert(kh);
                if (sonuc)
                {
                    MessageBox.Show("Kasa hareketi onaylandı", "Kasa Hareketleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = kHarOrm.Select();
                    Tools.Temizle(this);
                    cmbKasaTip.Focus();
                }
                else
                {
                    MessageBox.Show("Kasa hareketi onaylanmadı\n", "Kasa Hareketleri", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else if (result == DialogResult.No)
            {
                dataGridView1.Focus();
            }

        }
    }
}
