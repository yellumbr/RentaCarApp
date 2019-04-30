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
    public class YoneticiRepository : IRepository<Yonetici>,IDisposable
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
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("INSERT INTO tblYonetici(TCKimlik,Ad,Soyad,Adres,Telefon,Email,DogumTarihi,Sifre,SirketID) ");
                query.Append("VALUES( @TCKimlik,@Ad,@Soyad,@Adres,@Telefon,@Email,@DogumTarihi,@Sifre, @SirketID)");

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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [tblMusteriler] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        
                        DBHelper.AddParameter(dbCommand, "@Sifre", entity.Sifre);
                        DBHelper.AddParameter(dbCommand, "@SirketID", entity.SirketId);
                        DBHelper.AddParameter(dbCommand, "@TCKimlik", entity.TcKimlik);
                        DBHelper.AddParameter(dbCommand, "@Ad", entity.Ad);
                        DBHelper.AddParameter(dbCommand, "@Soyad", entity.Soyad);
                        DBHelper.AddParameter(dbCommand, "@Adres", entity.Adres);
                        DBHelper.AddParameter(dbCommand, "@Telefon", entity.Telefon);
                        DBHelper.AddParameter(dbCommand, "@Email", entity.Email);
                        DBHelper.AddParameter(dbCommand, "@DogumTarihi", entity.DogumTarihi);


                       
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

        public bool Guncelle(Yonetici entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append(" UPDATE [dbo].[tblMusteri] ");
                //KaraListe,KullaniciAdi,Sifre,EhliyetTarih,EhliyetTipi
                query.Append(" SET [TCKimlik] = @TCKimlik, [Ad] = @Ad, [Soyad] =  @Soyad, [Adres] = @Adres, [Telefon] = @Telefon, [Email] = @Email, [DogumTarihi] =  @DogumTarihi, [Sifre] =  @Sifre, [SirketID] = @SirketID ");
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

                        DBHelper.AddParameter(dbCommand, "@Sifre", entity.Sifre);
                        DBHelper.AddParameter(dbCommand, "@SirketID", entity.SirketId);
                        DBHelper.AddParameter(dbCommand, "@TCKimlik", entity.TcKimlik);
                        DBHelper.AddParameter(dbCommand, "@Ad", entity.Ad);
                        DBHelper.AddParameter(dbCommand, "@Soyad", entity.Soyad);
                        DBHelper.AddParameter(dbCommand, "@Adres", entity.Adres);
                        DBHelper.AddParameter(dbCommand, "@Telefon", entity.Telefon);
                        DBHelper.AddParameter(dbCommand, "@Email", entity.Email);
                        DBHelper.AddParameter(dbCommand, "@DogumTarihi", entity.DogumTarihi);

                       

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

        public IList<Yonetici> HepsiniSec()
        {
            _errorCode = 0;
            _rowsAffected = 0;

            IList<Yonetici> yoneticiler = new List<Yonetici>();

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append(
                    "[YoneticiID], [Sifre],[Ad],[Soyad],[TCKimlik],[Telefon],[Email],[DogumTarihi],[Adres],[SirketID] ");
                query.Append("FROM [dbo].[tblYonetici] ");
                

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
                                    entity.YoneticiId = reader.GetInt32(0);
                                    entity.SirketId = reader.GetInt32(1);
                                    entity.Sifre = reader.GetString(2);
                                    entity.Ad = reader.GetString(3);
                                    entity.Soyad = reader.GetString(4);
                                    entity.TcKimlik = reader.GetString(5);
                                    entity.Telefon = reader.GetString(6);
                                    entity.Email = reader.GetString(7);
                                    entity.DogumTarihi = reader.GetDateTime(8);
                                    entity.Adres = reader.GetString(9);
                                    yoneticiler.Add(entity);
                                }
                            }

                        }

                        
                    }
                }
                // Return list
                return yoneticiler;
            }
            catch (Exception ex)
            {
                throw new Exception("CustomersRepository::SelectAll:Error occured.", ex);
            }
        }

        public Yonetici IdSec(int id)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            Yonetici yonetici = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append(
                    "[YoneticiID], [SirketID], [Sifre], [Ad],[Soyad],[TCKimlik],[Telefon],[Email],[DogumTarihi],[Adres] ");
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

                        //Execute query.
                        using (var reader = dbCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var entity = new Yonetici();
                                    entity.YoneticiId = reader.GetInt32(0);
                                    entity.SirketId = reader.GetInt32(1);
                                    entity.Sifre = reader.GetString(2);
                                    entity.Ad = reader.GetString(3);
                                    entity.Soyad = reader.GetString(4);
                                    entity.TcKimlik = reader.GetString(5);
                                    entity.Telefon = reader.GetString(6);
                                    entity.Email = reader.GetString(7);
                                    entity.DogumTarihi = reader.GetDateTime(8);
                                    entity.Adres = reader.GetString(9);
                                    yonetici = entity;
                                    break;
                                }
                            }
                        }

                      
                    }
                }

                return yonetici;
            }
            catch (Exception ex)
            {
                throw new Exception("TransactionsRepository::SelectById:Error occured.", ex);
            }
        }

        public bool IdSil(int id)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("DELETE ");
                query.Append("FROM [dbo].[tblYonetici] ");
                query.Append("WHERE ");
                query.Append("[tblYonetici] = @id ");
               

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
                throw new Exception("TransactionsRepository::Insert:Error occured.", ex);
            }
        }
    }
}
