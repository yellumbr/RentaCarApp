using System;
using System.ComponentModel.DataAnnotations;
namespace Models.Concretes
{
    public class Yonetici
    {
        public Yonetici()
        {
            Kullanici = new Kullanici();
        }
        public int YoneticiID { get; set; }
        public int SirketID { get; set; }
        public int KullaniciID { get; set; }
        public Kullanici Kullanici { get; set; }

    }
}
