using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Models.Concretes
{
    public class Arac
    {
        public Arac()
        {
            Sirket = new Sirket();
        }
        public int AracID { get; set; }
        public string Plaka { get; set; }
        public string AracAdi { get; set; }
        public string AracModeli { get; set; }
        public int GerekenEhliyetYasi { get; set; }
        public int MinimumYasSiniri { get; set; }
        public int GunlukKmSiniri { get; set; }
        public int AracKm { get; set; }
        public string HavaYastigi { get; set; }
        public int BagajHacmi  { get; set; }
        public int KoltukSayisi { get; set; }
        public decimal GunlukKiraBedeli { get; set; }
        public bool Rezerv { get; set; }
        public bool Kirada { get; set; }
        public string YakitTipi { get; set; }
        public string VitesTipi { get; set; }
        public DateTime KiralanmaTarihi { get; set; }
        public DateTime KiradanDonusTarihi { get; set; }
        public string AracResmi { get; set; }
        public int MusteriID { get; set; }
        public int SirketID { get; set; }
        public Sirket Sirket { get; set; }
        public decimal AracGider { get; set; }


    }
}
