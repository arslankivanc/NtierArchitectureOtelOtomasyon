using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyonu.ORM.Entity
{
    public class OdaTurleri
    {
        //Bu constructer odaturleriform  btnEkle de çalışmaz.
        //btnEkle de instance scope lar arasında tanımlandığından consructer ezildi.
        public OdaTurleri()
        {
            Aktif = true;
        }
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public bool Aktif { get; set; }


    }
}
