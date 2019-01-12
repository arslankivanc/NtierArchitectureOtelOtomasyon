using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyonu.ORM.Entity
{
    public class Personeller
    {
        private decimal _maas;

        public Personeller()
        {
            Aktif = true;
        }
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Tckn { get; set; }
        public string TelNo { get; set; }
        public string Adres { get; set; }
        public DateTime DogumTarihi { get; set; }
        public DateTime IseGirisTarihi { get; set; }
        public decimal Maas {
            get { return _maas; }
            set
            {
                if (value < 2020m)
                {
                    _maas = 2020m;
                }
                else
                {
                    _maas = value;
                }
            }
        }
        public string KullaniciAdi { get; set; }
        public string Parola { get; set; }
        public bool Aktif { get; set; }
        public int YetkiID { get; set; }


    }
}
