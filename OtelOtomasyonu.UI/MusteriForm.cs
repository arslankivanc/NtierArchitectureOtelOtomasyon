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
    public partial class MusteriForm : Form
    {
        public MusteriForm()
        {
            InitializeComponent();
        }
        MusteriORM mOrm = new MusteriORM();
        private void MusteriForm_Load(object sender, EventArgs e)
        {
            Text = "Müşteriler";
            btnGuncelle.Visible = false;
            btnIptal.Visible = false;
            cmbMedeniDurum.DataSource = Enum.GetValues(typeof(MedeniDurumTip));
            cmbCinsiyet.DataSource = Enum.GetValues(typeof(Cinsiyet));
            dataGridView1.DataSource = mOrm.Select();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Musteriler m = new Musteriler();
            #region Controller
            if ( dtpDogumTarihi.Value.Year > DateTime.Now.Year || (dtpDogumTarihi.Value.Year+10)>DateTime.Now.Year)
            {
                MessageBox.Show("10 yaşından küçükler kayıt edilemez", "Reşit Değil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((txtAdi.Text == null || txtAdi.Text == "")
                || (txtSoyadi.Text == null || txtSoyadi.Text == "")
                || (txtSirketAdi.Text == null || txtSirketAdi.Text == ""))
            {
                MessageBox.Show("Adı,Soyadı,Şirket Adı alanları boş geçilemez", "Gerekli Alanlar", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtAdi.Focus();
                return;
            }
            #endregion
            bool mskdSonuc;
            m.Adi =Tools.ToTitleCase(txtAdi.Text);
            m.Soyadi =Tools.ToTitleCase(txtSoyadi.Text);
            m.SirketAdi = Tools.ToTitleCase(txtSirketAdi.Text);
            #region m.TcknController
            if (!mskdTCKN.MaskFull)
            {
                MessageBox.Show("TCKN 11 haneli olmalıdır", "TC Kimlik No", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                mskdSonuc = Tools.TcknControl(mskdTCKN.Text);
                if (mskdSonuc)
                    m.Tckn = mskdTCKN.Text;
                else return;
            }
            #endregion
            m.TelNo = mskdTelefon.Text;
            m.DogumTarihi = dtpDogumTarihi.Value;
            m.MedeniDurum = (MedeniDurumTip)Enum.Parse(typeof(MedeniDurumTip), cmbMedeniDurum.SelectedItem.ToString());
            m.Cinsiyet = (Cinsiyet)Enum.Parse(typeof(Cinsiyet), cmbCinsiyet.SelectedItem.ToString());

            
            bool sonuc = mOrm.Insert(m);
            if (sonuc)
            {
                MessageBox.Show("Müşteri Eklendi", "Müşteri Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = mOrm.Select();
                Tools.Temizle(this);
                txtAdi.Focus();
            }
            else
            {
                MessageBox.Show("Müşteri eklenemedi\n -Girdiğiniz TC kimlik no zaten sizin müşteriniz.", "Müşteri Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            if (id <= 0)
            {
                MessageBox.Show("Silinecek müşteri yoktur");
            }
            else
            {
                Musteriler m = new Musteriler();
                m.Id = id;
                bool sonuc = mOrm.Delete(m);
                if (sonuc)
                {
                    MessageBox.Show("Müşteri Silindi", "Müşteri Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = mOrm.Select();
                    dataGridView1.Focus();
                }
                else
                {
                    MessageBox.Show("Müşteri Silinmedi\n", "Müşteri Silme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
            if (dtpDogumTarihi.Value.Year > DateTime.Now.Year || (dtpDogumTarihi.Value.Year + 10) > DateTime.Now.Year)
            {
                MessageBox.Show("10 yaşından küçükler kayıt edilemez", "Reşit Değil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
                MessageBox.Show("Güncellenecek Müşteri yoktur", "Müşteri Yok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                bool mskdSonuc;
                Musteriler m = new Musteriler();
                m.Id = id;
                m.Adi = Tools.ToTitleCase(txtAdi.Text);
                m.Soyadi = Tools.ToTitleCase(txtSoyadi.Text);
                m.SirketAdi = Tools.ToTitleCase(txtSirketAdi.Text);
                if (!mskdTCKN.MaskFull)
                {
                    MessageBox.Show("TCKN 11 haneli olmalıdır", "TC Kimlik No", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    mskdSonuc = Tools.TcknControl(mskdTCKN.Text);
                    if (mskdSonuc)
                        m.Tckn = mskdTCKN.Text;
                    else return;
                }
                m.TelNo = mskdTelefon.Text;
                m.DogumTarihi = dtpDogumTarihi.Value;
                m.MedeniDurum = (MedeniDurumTip)Enum.Parse(typeof(MedeniDurumTip), cmbMedeniDurum.SelectedItem.ToString());
                m.Cinsiyet = (Cinsiyet)Enum.Parse(typeof(Cinsiyet), cmbCinsiyet.SelectedItem.ToString());

                bool sonuc = mOrm.Updated(m);
                if (sonuc)
                {
                    MessageBox.Show("Müşteri Güncellendi", "Müşteri Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Müşteri güncellenmedi\n-Aynı Tc kimlik Nosuna sahip müşteriniz olabilir.\n", "Müşteri Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                dataGridView1.DataSource = mOrm.Select();
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
                mskdTCKN.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                mskdTelefon.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                dtpDogumTarihi.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                if (dataGridView1.CurrentRow.Cells[7].Value.ToString() == "Evli")
                    cmbMedeniDurum.SelectedIndex = 1;
                else
                    cmbMedeniDurum.SelectedIndex = 0;
                if (dataGridView1.CurrentRow.Cells[8].Value.ToString() == "Erkek")
                    cmbCinsiyet.SelectedIndex = 1;
                else
                    cmbCinsiyet.SelectedIndex = 0;



                btnEkle.Visible = false;
                dataGridView1.Enabled = false;
                btnGuncelle.Visible = true;
                btnIptal.Visible = true;
            }
        }
    }
}
