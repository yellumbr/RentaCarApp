using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Concretes
{
    public class Musteriler
    {
        public Musteriler()
        {
            
            Araclar = new List<Araclar>();
        }
        public string TcKimlik { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

      //  [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
      //  public DateTime DogumTarihi { get; set; }
        public int MusteriId { get; set; }
        public bool KaraListe { get; set; }
        public List<Araclar> Araclar { get; set; }
        public string Sifre { get; set; }
        public string KullaniciAdi { get; set; }

       // [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
       // public DateTime EhliyetYil { get; set; }
        public string EhliyetTipi { get; set; }
    }
}
