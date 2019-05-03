using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concretes
{
    public class Rezervasyon
    {
        public int MusteriId { get; set; }
        public int AracId { get; set; }
        public int SirketId { get; set; }
        public string AracAdi { get; set; }
        public string AracModeli { get; set; }
        public string MusteriAdi { get; set; }
        public decimal GunlukKiraBedeli { get; set; }
        public string MusteriSoyad { get; set; }
        public DateTime TeslimAlmaTarihi { get; set; }
        public DateTime KiralanmaTarihi { get; set; }

    }
}
