using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Abstractions;
using Models.Concretes;
using Commons.Concretes;
namespace DataAccesLayer.Concretes
{
    public class MusterilerRepository : IRepository<Musteriler>
    {
        private string _connectionString;
        private string _dbProviderName;
        private DbProviderFactory _dbProviderFactory;
        private int _rowsAffected, _errorCode;
        private bool _bDisposed;

        public MusterilerRepository()
        {
            _connectionString = DBHelper.GetConnectionString();
            _dbProviderName = DBHelper.GetConnectionProvider();
            _dbProviderFactory = DbProviderFactories.GetFactory(_dbProviderName);
        }

        public bool Ekle(Musteriler entity)
        {
            throw new NotImplementedException();    
        }

        public bool Guncelle(Musteriler entity)
        {
            throw new NotImplementedException();
        }

        public IList<Musteriler> HepsiniSec()
        {
            throw new NotImplementedException();
        }

        public Musteriler IdSec(int id)
        {
            throw new NotImplementedException();
        }

        public bool IdSil(int id)
        {
            throw new NotImplementedException();
        }
    }
}
