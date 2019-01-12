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
    public partial class OdaOzelliklerForm : Form
    {
        public OdaOzelliklerForm()
        {
            InitializeComponent();
        }

        private void OdaOzelliklerForm_Load(object sender, EventArgs e)
        {
            Text = "Oda Özellikleri Ekle";
            OdalarORM odaOrm = new OdalarORM();
            cmbOdalar.DataSource = odaOrm.Select();
            cmbOdalar.DisplayMember = "Adi";
            cmbOdalar.ValueMember = "Id";

            OzelliklerORM ozeOrm = new OzelliklerORM();
            listOzellikler.DataSource = ozeOrm.Select();
            listOzellikler.DisplayMember = "Adi";
            listOzellikler.ValueMember = "Id";
            //BackgroundImage = Properties.Resources.OtelOdasi;
        }
        OdaOzellikleriORM odaOzeOrm = new OdaOzellikleriORM();
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmbOdalar.Items.Count==0)
            {
                MessageBox.Show("Özellik atamak için öncelikle oda tanımlamalısınız","Oda Bulunamadı",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            if (listOzellikler.Items.Count==0)
            {
                MessageBox.Show("Odaya özellik atamak için öncelikle Oda özelliği tanımlanmalı\n-Tanımlar/Oda Özellikleri", "Oda Özelliği Tanımlanmalı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            OdaOzellikleri odaOze = new OdaOzellikleri();
            odaOze.OdaID = (int)cmbOdalar.SelectedValue;
            odaOze.OzellikID = (int)listOzellikler.SelectedValue;
            short deger;
            //tryparse değeri pars ediyorsa true edemıyorsa false dondurur.
            if (short.TryParse(txtDeger.Text,out deger))
            {
                odaOze.Deger = deger;
            }

            bool sonuc = odaOzeOrm.Insert(odaOze);
            if (sonuc)
            {
                MessageBox.Show("Oda özelliği eklendi", "Oda Özellik Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Tools.Temizle(this);
                cmbOdalar.Focus();
            }
            else
            {
                MessageBox.Show("Oda özellik eklenmedi\n -Var olan oda özelliği eklenemez", "Odaya Özellik Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Error);               
            }
        }
    }
}
