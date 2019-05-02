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
        public int MusteriId { get; set; }
        public string TcKimlik { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string EhliyetTipi { get; set; }
        public DateTime EhliyetYil { get; set; }
        public bool KaraListe { get; set; }
        public List<Araclar> Araclar { get; set; }

    }
}
