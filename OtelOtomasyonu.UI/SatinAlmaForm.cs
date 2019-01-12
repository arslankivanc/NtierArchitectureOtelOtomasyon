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
    public partial class SatinAlmaForm : Form
    {
        public SatinAlmaForm()
        {
            InitializeComponent();
        }

        private void SatinAlmaForm_Load(object sender, EventArgs e)
        {
            Text = "Satın Alma";

            TedarikciORM tedOrm = new TedarikciORM();
            cmbTedarikci.DataSource = tedOrm.Select();
            cmbTedarikci.DisplayMember = "SirketAdi";
            cmbTedarikci.ValueMember = "Id";

            UrunORM uOrm = new UrunORM();
            dataGridView1.DataSource = uOrm.Select();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
        }

        private void btnListeyeEkle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.Rows.Count==0)
            {
                MessageBox.Show("Listeye sipariş eklemek için ürün seçmelisiniz", "Ürün Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (nudMiktar.Value <= 0)
            {
                MessageBox.Show("Ürünün miktarını belirtiniz(En az 1 olmalı) ", "Ürün Miktar Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ListViewItem lvi = new ListViewItem();
            lvi.Text= (listView1.Items.Count + 1).ToString();
            lvi.SubItems.Add(dataGridView1.CurrentRow.Cells["Adi"].Value.ToString());
            lvi.SubItems.Add(nudMiktar.Value.ToString());
            lvi.SubItems.Add(nudAlisFiyati.Value.ToString());

            lvi.Tag = dataGridView1.CurrentRow.Cells["Id"].Value;
            if (listView1.Items.Count==0)
            {
                listView1.Items.Add(lvi);
            }
            else
            {
                foreach (ListViewItem item in this.listView1.Items)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if ((int)lvi.Tag == (int)item.Tag)
                        {
                            MessageBox.Show("Bu üründen sipariş verilmiştir", "Ürün Bilgisi", MessageBoxButtons.OK,MessageBoxIcon.Information);
                            return;
                        }
                        
                    }
                }
                listView1.Items.Add(lvi);
            }
            decimal toplam=0;
            foreach (ListViewItem item in listView1.Items)
            {
                decimal a = Convert.ToDecimal(item.SubItems[2].Text);
                decimal b = Convert.ToDecimal(item.SubItems[3].Text);
                toplam += a * b;
                lblTotal.Text = toplam.ToString()+" TL";
            }

        }

        private void btnOnay_Click(object sender, EventArgs e)
        {
            if (cmbTedarikci.Items.Count == 0)
            {
                MessageBox.Show("Tedarikçi tanımlanmalı", "Tedarikçi Bulunmadı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            SatinAlmaORM sAlmaOrm = new SatinAlmaORM();
            SatinAlma sa = new SatinAlma();
            sa.TedarikciID =Convert.ToInt32(cmbTedarikci.SelectedValue);
            sa.SatinAlmaTarihi = DateTime.Now;
            sa.PersonelID = PersonellerORM.AktifKullanici.Id;

            int saId = Convert.ToInt32(sAlmaOrm.InsertScalar(sa));
            try
            {
                DialogResult result = MessageBox.Show("Seçilen ürünü sipariş vermek\n istediğinize emin misiniz?", "Satın Alma Onay", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    if (saId > 0)
                    {
                        SatinAlmaDetayORM sDetayOrm = new SatinAlmaDetayORM();
                        UrunORM uOrm = new UrunORM();
                        KasaHareketORM khOrm = new KasaHareketORM();
                        foreach (ListViewItem lvi in listView1.Items)
                        {
                            
                            SatinAlmaDetay sad = new SatinAlmaDetay();
                            sad.SatinAlmaID = saId;
                            sad.UrunID = (int)lvi.Tag;
                            sad.Miktar = Convert.ToDouble(lvi.SubItems[2].Text);
                            sad.AlisFiyati = Convert.ToDecimal(lvi.SubItems[3].Text);
                            sDetayOrm.Insert(sad);
                            Urunler u = new Urunler();
                            u.Id = Convert.ToInt32(lvi.Tag);
                            u.Miktar = Convert.ToDouble(lvi.SubItems[2].Text);

                            decimal tutar = ((decimal)sad.Miktar * sad.AlisFiyati);
                            //object initializer
                            KasaHareket kh = new KasaHareket
                            {
                                KasaID = 2,
                                KasaHareketTipID = 2,
                                Tutar = tutar,
                                Tarih = DateTime.Now,
                                Kdvsiz = tutar - (tutar * 0.18m)
                            };
                            try
                            {
                                uOrm.Update(u);
                                khOrm.Insert(kh);
                            }
                            catch (Exception ex)
                            {
                                 MessageBox.Show(ex.Message,"Satın Alma Onay",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                 return;
                            }

                        }
                        MessageBox.Show("Satın alma onaylandı","Satın Alma Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        dataGridView1.DataSource = uOrm.Select();
                        Tools.Temizle(this);
                        lblTotal.Text = "";
                        dataGridView1.Focus();
                    }
                }
                else if (result == DialogResult.No)
                {
                    listView1.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Satın alma onay hatası","Satın Alma Onay",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count!=0)
            {
                decimal fiyat = Convert.ToDecimal(this.dataGridView1.CurrentRow.Cells["Fiyat"].Value);
                nudAlisFiyati.Value = fiyat;
            }
        }

        private void btnListviewTemizle_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            lblTotal.Text = "";
        }
    }
}
