﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Models.Concretes
{
    public class Araclar
    {
        public Araclar()
        {
           Musteri = new Musteriler();
        }
        public int AracId { get; set; }
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
        public int GunlukKiraBedeli { get; set; }
        public bool Rezerv { get; set; }
        public bool Kirada { get; set; }
        public string YakitTipi { get; set; }
        public string VitesTipi { get; set; }
        public DateTime KiralanmaTarihi { get; set; }
        public DateTime KiradanDonusTarihi { get; set; }
        public string AracResmi { get; set; }
        public Musteriler Musteri { get; set; }


    }
}
