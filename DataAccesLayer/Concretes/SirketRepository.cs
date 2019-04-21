using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Abstractions;
using Models.Concretes;
using System.Data.Common;

namespace DataAccesLayer.Concretes
{
    public class SirketRepository : IRepository<Sirket>
    {
        public bool Ekle(Sirket entity)
        {
            throw new NotImplementedException();
        }

        public bool Guncelle(Sirket entity)
        {
            throw new NotImplementedException();
        }

        public IList<Sirket> HepsiniSec()
        {
            throw new NotImplementedException();
        }

        public Sirket IdSec(int id)
        {
            throw new NotImplementedException();
        }

        public bool IdSil(int id)
        {
            throw new NotImplementedException();
        }
    }
}
