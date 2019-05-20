using Commons.Concretes;
using DataAccesLayer.Abstractions;
using Models.Concretes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
namespace DataAccesLayer.Concretes
{
    public class YoneticiRepository : IRepository<Yonetici>, IDisposable
    {
        private string _connectionString;
        private string _dbProviderName;
        private DbProviderFactory _dbProviderFactory;
        private int _rowsAffected, _errorCode;
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
        public YoneticiRepository()
        {
            _connectionString = DBHelper.GetConnectionString();
            _dbProviderName = DBHelper.GetConnectionProvider();
            _dbProviderFactory = DbProviderFactories.GetFactory(_dbProviderName);
        }

        public bool Ekle(Yonetici entity)
        {
            _rowsAffected = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("INSERT INTO tblYonetici(SirketID,KullaniciID)");
                query.Append("VALUES(@SirketID,(SELECT IDENT_CURRENT('tblKullanici') WHERE KullaniciTipi = 'Y'))");

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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [tblYonetici] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@SirketID", entity.SirketID);
                        DBHelper.AddParameter(dbCommand, "@KullaniciID", entity.KullaniciID);
                     



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

                throw new Exception("YoneticiRepository:Ekleme Hatası", ex);
            }
        }

        public bool Guncelle(Yonetici entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append(" UPDATE [dbo].[tblYonetici] ");
                query.Append(" SET [SirketID] = @SirketID,[KullaniciID]=@KullaniciID ");
                query.Append(" WHERE ");
                query.Append(" [YoneticiID] = @YoneticiID ");


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
                        DBHelper.AddParameter(dbCommand, "@YoneticiID", entity.YoneticiID);
                        DBHelper.AddParameter(dbCommand, "@SirketID", entity.SirketID);
                        DBHelper.AddParameter(dbCommand, "@KullaniciID", entity.KullaniciID);
              
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
                throw new Exception("YoneticiRepository:Güncelleme Hatası", ex);
            }
        }

        public IList<Yonetici> HepsiniSec()
        {
            _rowsAffected = 0;

            IList<Yonetici> Yonetici = new List<Yonetici>();

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("YoneticiID,SirketID,KullaniciID");
                query.Append("FROM [dbo].[tblYonetici]");

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
                                "dbCommand" + " The db SelectById command for entity [tblYonetici] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;


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
                                    var entity = new Yonetici();
                                    entity.YoneticiID = reader.GetInt32(0);
                                    entity.SirketID = reader.GetInt32(1);
                                    entity.KullaniciID = reader.GetInt32(2);
                    
                                    Yonetici.Add(entity);
                                }
                            }

                        }
                    }
                }
                // Return list
                return Yonetici;
            }
            catch (Exception ex)
            {
                throw new Exception("YoneticiRepository:Hepsini Seçme Hatası", ex);
            }
        }

        public Yonetici IdSec(int id)
        {

            _rowsAffected = 0;

            Yonetici Yonetici = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("YoneticiID,SirketID,KullaniciID");
                query.Append("FROM [dbo].[tblYonetici]");
                query.Append("WHERE ");
                query.Append("[YoneticiID] = @id ");

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
                                "dbCommand" + " The db SelectById command for entity [tbl_Transactions] can't be null. ");

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
                                    var entity = new Yonetici();
                                    entity.YoneticiID = reader.GetInt32(0);
                                    entity.SirketID = reader.GetInt32(1);
                                    entity.KullaniciID = reader.GetInt32(2);
                                    Yonetici = entity;
                                    break;
                                }
                            }
                        }


                    }
                }

                return Yonetici;
            }
            catch (Exception ex)
            {
                throw new Exception("YoneticiRepository:ID ile Seçme Hatası", ex);
            }
        }

        public bool IdSil(int id)
        {

            _rowsAffected = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("DELETE ");
                query.Append("FROM [dbo].[tblYonetici] ");
                query.Append("WHERE ");
                query.Append("[YoneticiID] = @id ");


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
                                "dbCommand" + " The db SelectById command for entity [tblYonetici] can't be null. ");

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
                throw new Exception("YoneticiRepository:Silme Hatası", ex);
            }
        }
    }
}
