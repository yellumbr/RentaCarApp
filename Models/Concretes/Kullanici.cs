using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concretes
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }
        public string TcKimlik { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string KullaniciAdi { get; set; }
        public string Parola { get; set; }
        public bool Durum { get; set; }
        public string KullaniciTipi { get; set; }
        public Guid Anahtar { get; set; }
    }
}
