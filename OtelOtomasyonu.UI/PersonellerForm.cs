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
    public partial class PersonellerForm : Form
    {
        public PersonellerForm()
        {
            InitializeComponent();
        }
        PersonellerORM perOrm = new PersonellerORM();
        private void PersonellerForm_Load(object sender, EventArgs e)
        {
            Text = "Personeller";
            #region YetkiControl
            YetkiORM yOrm = new YetkiORM();
            SuperORM sOrm = new SuperORM();
            AdminORM aOrm = new AdminORM();
            if (PersonellerORM.AktifKullanici.YetkiID == 3)
            {
                cmbYetki.DataSource = yOrm.Select();
                cmbYetki.DisplayMember = "YetkiAdi";
                cmbYetki.ValueMember = "Id";
            }else if(PersonellerORM.AktifKullanici.YetkiID == 1)
            {
                cmbYetki.DataSource = sOrm.Select();
                cmbYetki.DisplayMember = "YetkiAdi";
                cmbYetki.ValueMember = "Id";
            }
            else
            {
                cmbYetki.DataSource = aOrm.Select();
                cmbYetki.DisplayMember = "YetkiAdi";
                cmbYetki.ValueMember = "Id";
            }
            #endregion
            dataGridView1.DataSource = perOrm.Select();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            btnGuncelle.Visible = false;
            btnIptal.Visible = false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (dtpDogumTarihi.Value.Year > DateTime.Now.Year || (dtpDogumTarihi.Value.Year + 18) > DateTime.Now.Year)
            {
                MessageBox.Show("18 yaşından küçükler işe alınamaz", "Reşit Değil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((txtAdi.Text == null || txtAdi.Text == "")
               || (txtSoyad.Text == null || txtSoyad.Text == "")
               || (txtKullaniciAdi.Text == null || txtKullaniciAdi.Text == "")
               || (txtParola.Text == null || txtParola.Text == "")
               || (cmbYetki.SelectedValue == null))
            {
                MessageBox.Show("-Adı\n-Soyadı\n-Kullanıcı Adı\n-Parola\n-Yetki alanları boş geçilemez", "Gerekli Alanlar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Personeller p = new Personeller();
            bool mskdSonuc;
            p.Adi =Tools.ToTitleCase(txtAdi.Text);
            p.Soyadi = Tools.ToTitleCase(txtSoyad.Text);
            #region p.TcknController
            if (!mskdTckn.MaskFull)
            {
                MessageBox.Show("TCKN 11 haneli olmalıdır", "TC Kimlik No", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                mskdSonuc = Tools.TcknControl(mskdTckn.Text);
                if (mskdSonuc)
                    p.Tckn = mskdTckn.Text;
                else return;
            }
            #endregion
            p.TelNo = mskdTelNo.Text;
            p.Adres = Tools.ToTitleCase(txtAdres.Text);
            p.DogumTarihi = dtpDogumTarihi.Value;
            p.IseGirisTarihi = dtpİseGiris.Value;
            p.Maas =Convert.ToDecimal(nudMaas.Value);
            p.KullaniciAdi = Tools.ToTitleCase(txtKullaniciAdi.Text);
            p.Parola = Tools.ToTitleCase(txtParola.Text);
            p.YetkiID =Convert.ToInt32(cmbYetki.SelectedValue);

            bool sonuc = perOrm.Insert(p);
            if (sonuc)
            {
                MessageBox.Show("Personel Eklendi", "Personel Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = perOrm.Select();
                Tools.Temizle(this);
                txtAdi.Focus();
            }
            else
            {
                MessageBox.Show("Personel eklenemedi\n -Girdiğiniz TC kimlik no zaten sizin personeliniz.", "Personel Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            if (id <= 0)
            {
                MessageBox.Show("Silinecek Personel yoktur");
            }
            else
            {
                Personeller p = new Personeller();
                p.Id = id;
                bool sonuc = perOrm.Delete(p);
                if (sonuc)
                {
                    MessageBox.Show("Personel Silindi", "Personel Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = perOrm.Select();
                    dataGridView1.Focus();
                }
                else
                {
                    MessageBox.Show("Personel Silinmedi\n", "Personel Silme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
            if (dtpDogumTarihi.Value.Year > DateTime.Now.Year || (dtpDogumTarihi.Value.Year + 18) > DateTime.Now.Year)
            {
                MessageBox.Show("18 yaşından küçükler işe alınamaz", "Reşit Değil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((txtAdi.Text == null || txtAdi.Text == "")
               || (txtSoyad.Text == null || txtSoyad.Text == "")
               || (txtKullaniciAdi.Text == null || txtKullaniciAdi.Text == "")
               || (txtParola.Text == null || txtParola.Text == "")
               || (cmbYetki.SelectedValue == null))
            {
                MessageBox.Show("-Adı\n-Soyadı\n-Kullanıcı Adı\n-Parola\n-Yetki alanları boş geçilemez", "Gerekli Alanlar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            if (id <= 0)
            {
                MessageBox.Show("Güncellenecek Personel yoktur", "Personel Yok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                bool mskdSonuc;
                Personeller p = new Personeller();
                p.Id = id;
                p.Adi = Tools.ToTitleCase(txtAdi.Text);
                p.Soyadi = Tools.ToTitleCase(txtSoyad.Text);
                if (!mskdTckn.MaskFull)
                {
                    MessageBox.Show("TCKN 11 haneli olmalıdır", "TC Kimlik No", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    mskdSonuc = Tools.TcknControl(mskdTckn.Text);
                    if (mskdSonuc)
                        p.Tckn = mskdTckn.Text;
                    else return;
                }
                p.TelNo = Tools.ToTitleCase(mskdTelNo.Text);
                p.Adres = Tools.ToTitleCase(txtAdres.Text);
                p.DogumTarihi = dtpDogumTarihi.Value;
                p.IseGirisTarihi = dtpİseGiris.Value;
                p.Maas = Convert.ToDecimal(nudMaas.Value);
                p.KullaniciAdi = Tools.ToTitleCase(txtKullaniciAdi.Text);
                p.Parola = Tools.ToTitleCase(txtParola.Text);
                p.YetkiID = Convert.ToInt32(cmbYetki.SelectedValue);

                bool sonuc = perOrm.Updated(p);
                if (sonuc)
                {
                    MessageBox.Show("Personel Güncellendi", "Personel Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Personel Güncellenmedi\n", "Personel Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                dataGridView1.DataSource = perOrm.Select();
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
                txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                mskdTckn.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                mskdTelNo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtAdres.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                dtpDogumTarihi.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                dtpİseGiris.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                nudMaas.Value =Convert.ToDecimal(dataGridView1.CurrentRow.Cells[8].Value);
                txtKullaniciAdi.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                txtParola.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                cmbYetki.SelectedValue = dataGridView1.CurrentRow.Cells[12].Value;

                btnEkle.Visible = false;
                dataGridView1.Enabled = false;
                btnGuncelle.Visible = true;
                btnIptal.Visible = true;
            }
        }
    }
}
