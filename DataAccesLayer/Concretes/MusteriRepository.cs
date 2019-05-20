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
    public class MusteriRepository : IRepository<Musteri>, IDisposable
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
        public MusteriRepository()
        {
            _connectionString = DBHelper.GetConnectionString();
            _dbProviderName = DBHelper.GetConnectionProvider();
            _dbProviderFactory = DbProviderFactories.GetFactory(_dbProviderName);
        }

        public bool Ekle(Musteri entity)
        {
            _rowsAffected = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("INSERT INTO tblMusteri(KullaniciID,EhliyetTipi,EhliyetTarihi,KaraListe,Ceza)");
                query.Append("VALUES((SELECT IDENT_CURRENT('tblKullanici')),@EhliyetTipi,@EhliyetTarihi,@KaraListe,@Ceza)");

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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [tblMusteri] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@EhliyetTipi", entity.EhliyetTipi);
                        DBHelper.AddParameter(dbCommand, "@EhliyetTarihi", entity.EhliyetTarihi.Date);
                        DBHelper.AddParameter(dbCommand, "@KaraListe", entity.KaraListe);
                        DBHelper.AddParameter(dbCommand, "@Ceza", entity.Ceza);
                       


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

                throw new Exception("MusteriRepository:Ekleme Hatası", ex);
            }
        }
        
        public bool Guncelle(Musteri entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append(" UPDATE [dbo].[tblMusteri] ");
                query.Append(" SET [EhliyetTipi] = @EhliyetTipi,[EhliyetTarih]=@EhliyetTarih, [KaraListe] = @KaraListe,[Ceza] = @Ceza ");
                query.Append(" WHERE ");
                query.Append(" [MusteriID] = @MusteriID ");


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
                        DBHelper.AddParameter(dbCommand, "@MusteriID", entity.MusteriID);
                        DBHelper.AddParameter(dbCommand, "@KaraListe", entity.KaraListe);
                        DBHelper.AddParameter(dbCommand, "@EhliyetTarih", entity.EhliyetTarihi.Date);
                        DBHelper.AddParameter(dbCommand, "@EhliyetTipi", entity.EhliyetTipi);
                       


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
                throw new Exception("MusteriRepository:Güncelleme Hatası", ex);
            }
        }

        public IList<Musteri> HepsiniSec()
        {
            _rowsAffected = 0;

            IList<Musteri> Musteri = new List<Musteri>();

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("MusteriID,KullaniciID,EhliyetTipi,EhliyetTarihi,KaraListe,Ceza");
                query.Append("FROM [dbo].[tblMusteri]");

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
                                "dbCommand" + " The db SelectById command for entity [tblMusteri] can't be null. ");

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
                                    var entity = new Musteri();
                                    entity.MusteriID = reader.GetInt32(0);
                                    entity.KullaniciID = reader.GetInt32(1);
                                    entity.EhliyetTipi = reader.GetString(2);
                                    entity.EhliyetTarihi = reader.GetDateTime(3).Date;
                                    entity.KaraListe = reader.GetBoolean(4);
                                    Musteri.Add(entity);
                                }
                            }

                        }
                    }
                }
                // Return list
                return Musteri;
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriRepository:Hepsini Seçme Hatası", ex);
            }
        }

        public Musteri IdSec(int id)
        {

            _rowsAffected = 0;

            Musteri musteri = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("MusteriID,KullaniciID,EhliyetTipi,EhliyetTarihi,KaraListe,Ceza");
                query.Append("FROM [dbo].[tblMusteri]");
                query.Append("WHERE ");
                query.Append("[MusteriID] = @id ");

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
                                    var entity = new Musteri();
                                    entity.MusteriID = reader.GetInt32(0);
                                    entity.KullaniciID = reader.GetInt32(1);
                                    entity.EhliyetTipi = reader.GetString(2);
                                    entity.EhliyetTarihi = reader.GetDateTime(3).Date;
                                    entity.KaraListe = reader.GetBoolean(4);
                                    entity.Ceza = reader.GetDecimal(5);
                                    musteri = entity;
                                    break;
                                }
                            }
                        }


                    }
                }

                return musteri;
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriRepository:ID ile Seçme Hatası", ex);
            }
        }

        public bool IdSil(int id)
        {

            _rowsAffected = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("DELETE ");
                query.Append("FROM [dbo].[tblMusteri] ");
                query.Append("WHERE ");
                query.Append("[MusteriID] = @id ");


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
                                "dbCommand" + " The db SelectById command for entity [tblMusteri] can't be null. ");

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
                throw new Exception("MusteriRepository:Silme Hatası", ex);
            }
        }
    }
}
