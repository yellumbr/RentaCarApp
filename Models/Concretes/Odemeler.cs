using System;
using System.ComponentModel.DataAnnotations;

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

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OdemeTarihi { get; set; }

        public Musteriler Musteri;
    }
}
