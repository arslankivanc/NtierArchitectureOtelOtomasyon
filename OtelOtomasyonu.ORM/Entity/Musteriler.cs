using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyonu.ORM.Entity
{
    public class Musteriler
    {
        public Musteriler()
        {
            Aktif = true;
        }
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string SirketAdi { get; set; }
        public string Tckn { get; set; }
        public string TelNo { get; set; }
        private DateTime _dogumTarihi;

        public DateTime DogumTarihi
        {
            get { return _dogumTarihi; }
            set
            {
                if(_dogumTarihi.Year<DateTime.Now.Year)
                _dogumTarihi = value;
            }
        }
        public MedeniDurumTip MedeniDurum { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
        public bool Aktif { get; set; }
    }
    public enum MedeniDurumTip
    {
        Bekar=1,
        Evli=2
    }
    public enum Cinsiyet
    {
        Kadın=1,
        Erkek=2
    }
}
