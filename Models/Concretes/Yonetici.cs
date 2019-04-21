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
            Kisi = new KisiDetay();
        }

        public int YoneticiId { get; set; }
        public string Sifre { get; set; }
        public KisiDetay Kisi { get; set; }

    }
}
