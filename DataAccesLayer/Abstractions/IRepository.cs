using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        bool Ekle(TEntity entity);
        bool Guncelle(TEntity entity);
        bool IdSil(int id);
        TEntity IdSec(int id);
        IList<TEntity> HepsiniSec();
    }
}
