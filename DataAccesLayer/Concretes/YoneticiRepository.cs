using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Abstractions;
using Models.Concretes;
using System.Data;
using System.Data.Common;
using Commons.Concretes;

namespace DataAccesLayer.Concretes
{
    public class YoneticiRepository : IRepository<Yonetici>
    {
        private string _connectionString;
        private string _dbProviderName;
        private DbProviderFactory _dbProviderFactory;
        private int _rowsAffected, _errorCode;
        private bool _bDisposed;

        public YoneticiRepository()
        {
            _connectionString = DBHelper.GetConnectionString();
            _dbProviderName = DBHelper.GetConnectionProvider();
            _dbProviderFactory = DbProviderFactories.GetFactory(_dbProviderName);
        }
        public bool Ekle(Yonetici entity)
        {
            throw new NotImplementedException();


        }

        public bool Guncelle(Yonetici entity)
        {
            throw new NotImplementedException();
        }

        public IList<Yonetici> HepsiniSec()
        {
            throw new NotImplementedException();
        }

        public Yonetici IdSec(int id)
        {
            throw new NotImplementedException();
        }

        public bool IdSil(int id)
        {
            throw new NotImplementedException();
        }
    }
}
