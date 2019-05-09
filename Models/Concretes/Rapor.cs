using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concretes
{
    public class Rapor
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string AracPlaka { get; set; }
        public DateTime AracTeslimEtmeTarih { get; set; }
        public DateTime AracTeslimAlmaTarih { get; set; }
        public decimal OdenecekCeza { get; set; }
        public decimal ToplamMiktar { get; set; }
    }
}
