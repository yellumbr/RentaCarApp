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
    public class OdemeRepository : IRepository<Odeme>,IDisposable
    {
        private string _connectionString;
        private string _dbProviderName;
        private DbProviderFactory _dbProviderFactory;
        private int _rowsAffected;
        private bool _bDisposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool bDisposing)
        {
            // Check the Dispose method called before.
            if (!_bDisposed)
            {
                if (bDisposing)
                {
                    // Clean the resources used.
                    _dbProviderFactory = null;
                }

                _bDisposed = true;
            }
        }
        public OdemeRepository()
        {
            _connectionString = DBHelper.GetConnectionString();
            _dbProviderName = DBHelper.GetConnectionProvider();
            _dbProviderFactory = DbProviderFactories.GetFactory(_dbProviderName);
        }


        public bool Ekle(Odeme entity)
        {
            _rowsAffected = 0;
          

            try
            {
                var query = new StringBuilder();
                query.Append("INSERT [dbo.tblOdeme] ");
                query.Append("( [OdemeMiktari], [Tarih], [Basarili],[MusteriID] ) ");
                query.Append("VALUES ");
                query.Append(
                    "( @OdemeMiktari, @Tarih, @Basarili,@MusteriId ) ");
                
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
                        DBHelper.AddParameter(dbCommand, "@OdemeTarihi",  entity.OdemeTarihi.Date);
                        DBHelper.AddParameter(dbCommand, "@OdemeBasarili", entity.OdemeBasarili);
                        DBHelper.AddParameter(dbCommand, "@MusteriId", entity.MusteriId);

                        

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
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

        public bool Guncelle(Odeme entity)
        {
            _rowsAffected = 0;
            

            try
            {
                var query = new StringBuilder();
                query.Append(" UPDATE [dbo].[tblOdeme] ");
                query.Append(" SET [OdemeID] = @OdemeID, [OdemeMiktari] = @OdemeMiktari, [OdemeBasarili] =  @OdemeBasarili, [OdemeTarihi] = @OdemeTarihi,[MusteriID] = @MusteriId ");
                query.Append(" WHERE ");
                query.Append(" [OdemeID] = @OdemeID ");

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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [tbl_Customers] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@OdemeID", entity.OdemeID);
                        DBHelper.AddParameter(dbCommand, "@OdemeMiktari",  entity.OdemeMiktari);
                        DBHelper.AddParameter(dbCommand, "@OdemeBasarili", entity.OdemeBasarili);
                        DBHelper.AddParameter(dbCommand, "@OdemeTarihi", entity.OdemeTarihi.Date);
                        DBHelper.AddParameter(dbCommand, "@MusteriId", entity.MusteriId);




                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                       }
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
              
                throw new Exception("CustomersRepository::Update:Error occured.", ex);
            }
        }
    

        public IList<Odeme> HepsiniSec()
        {
            
            _rowsAffected = 0;

            IList<Odeme> odemeler = new List<Odeme>();

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append(
                    "[OdemeID], [OdemeMiktari], [OdemeBasarili], [OdemeTarihi],[MusteriID]");
                query.Append("FROM [dbo].[tblOdeme] ");
                

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
                            throw new ArgumentNullException(
                                "dbCommand" + " The db SelectById command for entity [tblOdeme] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters - None

                        
                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query.
                        using (var reader = dbCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var entity = new Odeme();
                                    entity.OdemeID = reader.GetInt32(0);
                                    entity.OdemeMiktari = reader.GetDecimal(1);
                                    entity.OdemeBasarili = reader.GetBoolean(2);
                                    entity.OdemeTarihi = reader.GetDateTime(3).Date;
                                    entity.MusteriId = reader.GetInt32(4);
                                    odemeler.Add(entity);
                                }
                            }

                        }

                        
                    }
                }
                // Return list
                return odemeler;
            }
            catch (Exception ex)
            {
                throw new Exception("CustomersRepository::SelectAll:Error occured.", ex);
            }
        }

        public Odeme IdSec(int id)
        {
            
            _rowsAffected = 0;

            Odeme odemeler = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append(
                    "[OdemeID], [OdemeMiktari], [OdemeBasarili], [OdemeTarihi],[MusteriID] ");
                query.Append("FROM [dbo].[tblOdeme] ");
                query.Append("WHERE ");
                query.Append("[OdemeID] = @id ");
             

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
                            throw new ArgumentNullException(
                                "dbCommand" + " The db SelectById command for entity [tblOdeme] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        DBHelper.AddParameter(dbCommand, "@id", id);

                       
                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query.
                        using (var reader = dbCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var entity = new Odeme();
                                    entity.OdemeID = reader.GetInt32(0);
                                    entity.OdemeMiktari = reader.GetDecimal(1);
                                    entity.OdemeBasarili = reader.GetBoolean(2);
                                    entity.OdemeTarihi = reader.GetDateTime(3).Date;
                                    entity.MusteriId = reader.GetInt32(4);
                                    odemeler = entity;
                                    break;
                                }
                            }
                        }

                       
                    }
                }

                return odemeler;
            }
            catch (Exception ex)
            {
                throw new Exception("CustomersRepository::SelectById:Error occured.", ex);
            }
        }


        public bool IdSil(int id)
        {
            
            _rowsAffected = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("DELETE ");
                query.Append("FROM [dbo].[tblOdeme] ");
                query.Append("WHERE ");
                query.Append("[OdemeID] = @OdemeID ");
                

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
                            throw new ArgumentNullException(
                                "dbCommand" + " The db SelectById command for entity [tblOdeme] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        DBHelper.AddParameter(dbCommand, "@id", id);

                        
                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();
                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        
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
    }
}
