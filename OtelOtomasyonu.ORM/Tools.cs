using OtelOtomasyonu.ORM.Facade;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelOtomasyonu.ORM
{
    public class Tools
    {
        //Singleton pattern
        private static SqlConnection con;

        public static SqlConnection Con
        {
            get
            {
                if (con == null)
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);
                return con;
            }
        }
        public static bool ExecCommand(SqlCommand cmd)
        {
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                int sonuc = cmd.ExecuteNonQuery();
                return sonuc > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
        }
        public static object ExecScalar(SqlCommand cmd)
        {
            try
            {
                if (cmd.Connection.State!=ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }
                object deger = cmd.ExecuteScalar();
                return deger;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
        }
        public static void ParametreOlustur<T>(SqlCommand cmd,KomutTip kt,T ent)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo item in properties)
            {
                string name = item.Name;
                switch (kt)
                {
                    case KomutTip.Select:
                        break;
                    case KomutTip.Insert:
                        if ((name.ToLower() == "ıd" || name.ToLower() == "id"))
                        {
                            continue;
                        }
                        break;
                    case KomutTip.Update:
                        if (name.ToLower()=="ıd" || name.ToLower() == "id" || name.ToLower() == "miktar")
                        {

                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case KomutTip.Updated:
                        break;
                    case KomutTip.Delete:
                        if ((name.ToLower() == "ıd") || (name.ToLower() == "id"))
                        {

                        }
                        else
                        {
                            continue;
                        }
                        break;
                    default:
                        break;
                }
                object value = item.GetValue(ent);
                cmd.Parameters.AddWithValue("@" + name, value);
            }
        }
        public static decimal KdvOrani(decimal miktar,decimal alisFiyati,decimal kdvOran)
        {
            decimal kdv= miktar * alisFiyati;
            return kdv -= kdv * kdvOran;
        }
        public static void Temizle(Control ctl)
        {
            foreach (Control item in ctl.Controls)
            {
                if (item is TextBox) ((TextBox)item).Text = String.Empty;
                if (item is NumericUpDown) ((NumericUpDown)item).Value = 0;
                if (item is MaskedTextBox) ((MaskedTextBox)item).Text = string.Empty;
                if (item is DateTimePicker) ((DateTimePicker)item).Value = DateTime.Now;
                if (item is ListBox) ((ListBox)item).SelectedIndex = 0;
                if (item is ListView) ((ListView)item).Items.Clear();
            }
        }
        public static string ToTitleCase(string kelime)
        {
            string ToTitleC = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(kelime).Trim();
            return ToTitleC;
        }
        public static bool TcknControl(string mskdTCKN)
        {
            MaskedTextBox mtb = new MaskedTextBox();
            mtb.Text = mskdTCKN.ToString();
            if (mskdTCKN.Length==11)
            {
                
                int sonNu = Convert.ToInt32(mtb.Text[10].ToString());
                if (sonNu % 2 != 0)
                {
                    MessageBox.Show("TCKN Hatalıdır","TC Kimlik No",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    int toplam = 0;
                    for (int i = 0; i < mtb.Text.Length - 1; i++)
                    {
                        string rkm = mtb.Text[i].ToString();
                        toplam += Convert.ToInt32(rkm);
                    }
                    if (toplam % 10 == sonNu)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("TCKN Hatalıdır", "TC Kimlik No", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            else
            {
                MessageBox.Show("11 haneli TCNo giriniz,Boş girmeyiniz.");
            }
            return false;
        }
        public static string KullaniciAdSoyad()
        {
            return PersonellerORM.AktifKullanici.Adi + " " + PersonellerORM.AktifKullanici.Soyadi;
        }
        public static void MouseDownControl(MouseEventArgs e ,DataGridView dg,ContextMenuStrip cms,ToolStripMenuItem tsm)
        {
            var hti = dg.HitTest(e.X, e.Y);
            if (hti.RowIndex == -1 || hti.ColumnIndex == -1)
            {
                cms.Items.Clear();
                return;
            }
            else
            {
                cms.Items.Add(tsm);
                dg.ClearSelection();
                dg.CurrentCell = dg.Rows[hti.RowIndex].Cells[hti.ColumnIndex];
                dg.Rows[hti.RowIndex].Selected = true;
            }
        }
        public static bool MouseDoubleClick(MouseEventArgs e,DataGridView dg)
        {
            var hti = dg.HitTest(e.X, e.Y);
            if (hti.RowIndex == -1 || hti.ColumnIndex == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void ButtonVisibleControl(DataGridView dg,Button ekle,Button guncelle,Button iptal)
        {
            dg.Enabled = true;
            ekle.Visible = true;
            guncelle.Visible = false;
            iptal.Visible = false;
        }
    }
}
