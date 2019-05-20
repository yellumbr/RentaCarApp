using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Concretes
{
    public class Musteri
    {
        public Musteri()
        {
        }
        public int MusteriID { get; set; }
        public int KullaniciID { get; set; }
        public string EhliyetTipi { get; set; }
        public DateTime EhliyetTarihi { get; set; }
        public bool KaraListe { get; set; }
        public decimal Ceza { get; set; }

    }
}
