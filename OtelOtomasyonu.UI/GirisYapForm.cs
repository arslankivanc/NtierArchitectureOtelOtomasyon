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
    public partial class GirisYapForm : Form
    {
        public GirisYapForm()
        {
            InitializeComponent();
        }
        private void btnGiris_Click(object sender, EventArgs e)
        {
            PersonellerORM pOrm = new PersonellerORM();
            Personeller p = new Personeller();
            p.KullaniciAdi = txtKullaniciAdi.Text;
            p.Parola = txtParola.Text;
            Personeller aktif = pOrm.GirisYap(p);
            if (aktif==null)
            {
                MessageBox.Show("Kullanıcı adı veya parola yanlış");
            }
            else
            {
                PersonellerORM.AktifKullanici = aktif;
                Form1 f = new Form1();
                this.Hide();
                f.ShowDialog();
            }
        }

        private void GirisYapForm_Load(object sender, EventArgs e)
        {

        }
    }
}
