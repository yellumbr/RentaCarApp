using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concretes
{
    public class Musteriler
    {
        public Musteriler()
        {
            Kisi = new KisiDetay();
            Araclar = new List<Araclar>();
        }
        public int MusteriId { get; set; }
        public bool KaraListe { get; set; }
        public List<Araclar> Araclar { get; set; }
        public KisiDetay Kisi { get; set; }
        public string Sifre { get; set; }
        public string KullaniciAdi { get; set; }
        public DateTime EhliyetYil { get; set; }
        public string EhliyetTipi { get; set; }
    }
}
