using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concretes
{
    public class Sirket
    {
        public Sirket()
        {
            Yoneticiler = new List<Yonetici>();
        }
        public int SirketID { get; set; }
        public string SirketAdi { get; set; }
        public string Sehir { get; set; }
        public string Adres { get; set; }
        public int AracSayisi { get; set; }
        public float SirketPuani { get; set; }
        public decimal SirketGelir { get; set; }
        public decimal SirketGider { get; set; }
        public List<Yonetici> Yoneticiler { get; set; }
    }
}
