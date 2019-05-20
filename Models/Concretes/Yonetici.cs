using System;
using System.ComponentModel.DataAnnotations;
namespace Models.Concretes
{
    public class Yonetici
    {
        public Yonetici()
        {
        }
        public int YoneticiID { get; set; }
        public int SirketID { get; set; }
        public int KullaniciID { get; set; }

    }
}
