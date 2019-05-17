using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concretes
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }

        [Required(ErrorMessage = "Kimlik numarası girmelisiniz.")]
        [StringLength(11, MinimumLength = 11)]
        public string TcKimlik { get; set; }

        [Required(ErrorMessage = "İsim girmelisiniz.")]
        [StringLength(50, MinimumLength = 3)]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyisim girmelisiniz.")]
        [StringLength(50, MinimumLength = 3)]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Doğum tarihi girmelisiniz.")]
        public DateTime DogumTarihi { get; set; }

        [Required(ErrorMessage = "Adres girmelisiniz.")]
        
        public string Adres { get; set; }

        [Required(ErrorMessage = "Telefon girmelisiniz.")]
        [StringLength(15, MinimumLength = 11)]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Email girmelisiniz.")]
        [StringLength(50, MinimumLength = 3)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı girmelisiniz.")]
        [StringLength(50, MinimumLength = 3)]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Parola girmelisiniz.")]
        [StringLength(50, MinimumLength = 6)]
        public string Parola { get; set; }

        public bool Durum { get; set; }
        public string KullaniciTipi { get; set; }
        public Guid Anahtar { get; set; }
    }
}
