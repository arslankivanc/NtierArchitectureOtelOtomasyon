using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyonu.ORM.Entity
{
    public class KasaHareket
    {
        public int Id { get; set; }
        public int KasaID { get; set; }
        public int KasaHareketTipID { get; set; }
        public decimal Tutar { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Kdvsiz { get; set; }

    }
}
