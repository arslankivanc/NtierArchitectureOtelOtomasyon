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
    public partial class SatisForm : Form
    {
        public SatisForm()
        {
            InitializeComponent();
        }
        OdalarORM odaOrm = new OdalarORM();
        private void SatisForm_Load(object sender, EventArgs e)
        {
            Text = "Satis Formu";

            MusteriORM mOrm = new MusteriORM();
            cmbMusteri.DataSource = mOrm.Select();
            cmbMusteri.DisplayMember = "Adi";
            cmbMusteri.ValueMember = "Id";

            KasaORM kasaOrm = new KasaORM();
            cmbKasaOdemeTip.DataSource = kasaOrm.Select();
            cmbKasaOdemeTip.DisplayMember = "Adi";
            cmbKasaOdemeTip.ValueMember = "Id";

            
            cmbOda.DataSource = odaOrm.Select();
            cmbOda.DisplayMember = "Adi";
            cmbOda.ValueMember = "Id";

            UrunORM uOrm = new UrunORM();
            dataGridView1.DataSource = uOrm.Select();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;

        }

        private void btnSatisaEkle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow==null)
            {
                MessageBox.Show("Ürün seçiniz", "Ürün Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (nudUrunMiktarı.Value <= 0)
            {
                MessageBox.Show("Satılacak ürünün miktarını belirtiniz(En az 1 olmalı) ", "Ürün Miktar Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ListViewItem lvi = new ListViewItem();
            lvi.Text = (listView1.Items.Count + 1).ToString();
            lvi.SubItems.Add(dataGridView1.CurrentRow.Cells["Adi"].Value.ToString());
            lvi.SubItems.Add(nudUrunMiktarı.Value.ToString());
            lvi.SubItems.Add(nudUrunFiyati.Value.ToString());
            lvi.SubItems.Add(nudIndirim.Value.ToString());

            lvi.Tag = dataGridView1.CurrentRow.Cells["Id"].Value;
            if (listView1.Items.Count == 0)
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
                            MessageBox.Show("Bu üründen sipariş verilmiştir", "Ürün Bilgisi", MessageBoxButtons.OK);
                            return;
                        }

                    }
                }
                listView1.Items.Add(lvi);
            }
            decimal toplam = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                decimal a = Convert.ToDecimal(item.SubItems[2].Text);
                decimal b = Convert.ToDecimal(item.SubItems[3].Text);
                decimal c = Convert.ToDecimal(item.SubItems[4].Text);

                toplam += (a*b)-(a*b*c)/100;
                lblTutar.Text = toplam.ToString() + " TL";
            }
        }

        private void btnKatdet_Click(object sender, EventArgs e)
        {
            if (cmbMusteri.Items.Count == 0 || cmbOda.Items.Count == 0)
            {
                MessageBox.Show("Tanımlı müşteri veya Oda belirlemelisiniz.\n -Müşteriler \n -Tanımlar/Odalar", "Satış Onay", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            SatisORM sOrm = new SatisORM();
            Odalar o = new Odalar();
            o.Id = Convert.ToInt32(cmbOda.SelectedValue);
            Satis s = new Satis();
            s.MusteriID = Convert.ToInt32(cmbMusteri.SelectedValue);
            s.OdaID = Convert.ToInt32(cmbOda.SelectedValue);
            s.PersonelID = PersonellerORM.AktifKullanici.Id;
            s.OdaFiyati = nudOdaFiyati.Value;
            s.SatisTarihi = DateTime.Now;
            
            try
            {
                int satisId = Convert.ToInt32(sOrm.InsertScalar(s));
                DialogResult result = MessageBox.Show("Satışı onaylıyor musunuz?", "Satış Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        SatisDetayORM sdOrm = new SatisDetayORM();
                        UrunORM uOrm = new UrunORM();
                        KasaHareketORM khOrm = new KasaHareketORM();
                        KasaHareket kh;
                        decimal odaFiyati = nudOdaFiyati.Value;
                        if (listView1.Items.Count == 0)
                        {
                            kh = new KasaHareket
                            {
                                KasaID = 2,
                                KasaHareketTipID = 1,
                                Tutar = odaFiyati,
                                Tarih = DateTime.Now,
                                Kdvsiz = (odaFiyati - (odaFiyati * 0.18m))
                            };
                            khOrm.Insert(kh);
                        }
                        else
                        {
                            foreach (ListViewItem lvi in listView1.Items)
                            {

                                SatisDetay sd = new SatisDetay();
                                sd.SatisID = satisId;
                                sd.UrunID = (int)lvi.Tag;
                                sd.Fiyat = Convert.ToDecimal(lvi.SubItems[3].Text);
                                sd.Miktar = (Convert.ToDouble(lvi.SubItems[2].Text));
                                sd.Indirim = Convert.ToDouble(lvi.SubItems[4].Text);
                                sdOrm.Insert(sd);

                                Urunler u = new Urunler();
                                u.Id = Convert.ToInt32(lvi.Tag);
                                u.Miktar = -(Convert.ToDouble(lvi.SubItems[2].Text));

                                decimal miktar = ((decimal)sd.Miktar);
                                decimal indirim = (int)sd.Indirim;

                                decimal tutar = (miktar * sd.Fiyat) - (miktar * sd.Fiyat * (indirim / 100));
                                //object initializer
                                kh = new KasaHareket
                                {
                                    KasaID = 2,
                                    KasaHareketTipID = 1,
                                    Tutar = tutar,
                                    Tarih = DateTime.Now,
                                    Kdvsiz = (tutar - (tutar * 0.18m))
                                };
                                try
                                {
                                    if (uOrm.Update(u))
                                    {
                                        khOrm.Insert(kh);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Stokta yeteri kadar ürün kalmamıştır", "Satış Onay", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Satış Onay", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                            }
                        }
                        MessageBox.Show("Satış onaylandı", "Satış Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = uOrm.Select();
                        Tools.Temizle(this);
                        nudUrunFiyati.Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[2].Value);
                        nudUrunMiktarı.Value = 1;
                        lblTutar.Text = "";
                        dataGridView1.Focus();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Satış sırasında hata oluştu", "Satış Onay", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (result == DialogResult.No)
                {
                    listView1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Satış Onay", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnListviewTemizle_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            lblTutar.Text = "";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                decimal fiyat = Convert.ToDecimal(this.dataGridView1.CurrentRow.Cells["Fiyat"].Value);
                nudUrunFiyati.Value = fiyat;
            }
        }
    }
}
