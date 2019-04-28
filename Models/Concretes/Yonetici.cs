using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concretes
{
    public class Yonetici
    {
        public Yonetici()
        {
            
        }
        public string TcKimlik { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public DateTime DogumTarihi { get; set; }
        public int YoneticiId { get; set; }
        public int SirketId { get; set; }
        public string Sifre { get; set; }
       

    }
}
