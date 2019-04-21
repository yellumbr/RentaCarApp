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
    public class OdemelerRepository : IRepository<Odemeler>
    {
        private string _connectionString;
        private string _dbProviderName;
        private DbProviderFactory _dbProviderFactory;
        private int _rowsAffected, _errorCode;
        private bool _bDisposed;
        
        public OdemelerRepository()
        {
            _connectionString = DBHelper.GetConnectionString();
            _dbProviderName = DBHelper.GetConnectionProvider();
            _dbProviderFactory = DbProviderFactories.GetFactory(_dbProviderName);
        }


        public bool Ekle(Odemeler entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("INSERT [dbo.tblOdeme] ");
                query.Append("( [OdemeMiktari], [Tarih], [Basarili] ) ");
                query.Append("VALUES ");
                query.Append(
                    "( @OdemeMiktari, @Tarih, @Basarili ) ");
                query.Append("SELECT @intErrorCode=@@ERROR;");

                var commandText = query.ToString();
                query.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [tbl_Transactions] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@OdemeMiktari", entity.OdemeMiktari);
                        DBHelper.AddParameter(dbCommand, "@OdemeTarihi",  entity.OdemeTarihi);
                        DBHelper.AddParameter(dbCommand, "@OdemeBasarili", entity.OdemeBasarili);

                        //Output Params
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception("Inserting Error for entity [tblOdeme] reported the Database ErrorCode: " + _errorCode);
                    }
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
               
                throw new Exception("TransactionsRepository::Insert:Error occured.", ex);
            }
        }

        public bool Guncelle(Odemeler entity)
        {
            throw new NotImplementedException();
        }

        public IList<Odemeler> HepsiniSec()
        {
            throw new NotImplementedException();
        }

        public Odemeler IdSec(int id)
        {
            throw new NotImplementedException();
        }


        public bool IdSil(int id)
        {
            throw new NotImplementedException();
        }
    }
}
