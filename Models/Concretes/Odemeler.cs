using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concretes
{
    public class Odemeler
    {
        public Odemeler()
        {
            Musteri = new Musteriler();
        }
        public int OdemeID { get; set; }
        public decimal OdemeMiktari { get; set; }
        public bool OdemeBasarili { get; set; }
        public DateTime OdemeTarihi { get; set; }

        public Musteriler Musteri;
    }
}
