using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Abstractions;
using Models.Concretes;
using System.Data.Common;
using System.Data;
using Commons.Concretes;

namespace DataAccesLayer.Concretes
{
    public class KullaniciRepository : IRepository<Kullanici>, IDisposable
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
        public KullaniciRepository()
        {
            _connectionString = DBHelper.GetConnectionString();
            _dbProviderName = DBHelper.GetConnectionProvider();
            _dbProviderFactory = DbProviderFactories.GetFactory(_dbProviderName);
        }

        public bool Ekle(Kullanici entity)
        {
            _rowsAffected = 0;


            try
            {
                var query = new StringBuilder();
                query.Append("INSERT INTO [dbo].[tblKullanici] ");
                query.Append(" ([TCKimlik],[Ad] ,[Soyad],[DogumTarihi],[Adres],[Telefon],[Email],[KullaniciAdi],[Parola],[KullaniciTipi])");
                query.Append("VALUES ");
                query.Append(
                    "( @TCKimlik, @Ad, @Soyad, @DogumTarihi, @Adres, @Telefon,@Email,@KullaniciAdi,@Parola,@KullaniciTipi ) ");


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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [tblKullanici] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@TCKimlik", entity.TcKimlik);
                        DBHelper.AddParameter(dbCommand, "@Ad", entity.Ad);
                        DBHelper.AddParameter(dbCommand, "@Soyad", entity.Soyad);
                        DBHelper.AddParameter(dbCommand, "@DogumTarihi", entity.DogumTarihi.Date);
                        DBHelper.AddParameter(dbCommand, "@Adres", entity.Adres);
                        DBHelper.AddParameter(dbCommand, "@Telefon", entity.Telefon);
                        DBHelper.AddParameter(dbCommand, "@Email", entity.Email);
                        DBHelper.AddParameter(dbCommand, "@KullaniciAdi", entity.KullaniciAdi);
                        DBHelper.AddParameter(dbCommand, "@Parola", entity.Parola);
                        DBHelper.AddParameter(dbCommand, "@KullaniciTipi", entity.KullaniciTipi);

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
                throw new Exception("KullaniciRepository:Ekleme Hatası", ex);
            }
        }


        public bool Guncelle(Kullanici entity)
        {
            _rowsAffected = 0;


            try
            {
                var query = new StringBuilder();
                query.Append("UPDATE [dbo].[tblKullanici] ");
                query.Append("SET [TCKimlik] = @TCKimlik ,[Ad] = @Ad ,[Soyad]=@Soyad,[DogumTarihi]=@DogumTarihi,[Adres]=@Adres,[Telefon]=@Telefon,[Email]=@Email,[KullaniciAdi]=@KullaniciAdi,[Parola]=@Parola ");
                query.Append("WHERE ");
                query.Append(" [KullaniciID] = @KullaniciID ");


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
                        DBHelper.AddParameter(dbCommand, "@TCKimlik", entity.TcKimlik);
                        DBHelper.AddParameter(dbCommand, "@Ad", entity.Ad);
                        DBHelper.AddParameter(dbCommand, "@Soyad", entity.Soyad);
                        DBHelper.AddParameter(dbCommand, "@DogumTarihi", entity.DogumTarihi.Date);
                        DBHelper.AddParameter(dbCommand, "@Adres", entity.Adres);
                        DBHelper.AddParameter(dbCommand, "@Telefon", entity.Telefon);
                        DBHelper.AddParameter(dbCommand, "@Email", entity.Email);
                        DBHelper.AddParameter(dbCommand, "@KullaniciAdi", entity.KullaniciAdi);
                        DBHelper.AddParameter(dbCommand, "@Parola", entity.Parola);
                        DBHelper.AddParameter(dbCommand, "@KullaniciTipi", entity.KullaniciTipi);

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
                throw new Exception("KullaniciRepository:Güncelleme Hatası", ex);
            }
        }

        public IList<Kullanici> HepsiniSec()
        {

            _rowsAffected = 0;

            IList<Kullanici> Kullanicilar = new List<Kullanici>();

           // try
           // {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[KullaniciID],[TCKimlik],[Ad] ,[Soyad],[DogumTarihi],[Adres],[Telefon],[Email],[KullaniciAdi],[Parola],[KullaniciTipi],[Anahtar]");
                query.Append("FROM [dbo].[tblKullanici] ");


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
                                "dbCommand" + " The db SelectById command for entity [tblKullanici] can't be null. ");

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
                                    var entity = new Kullanici();
                                    entity.KullaniciID=reader.GetInt32(0);
                                    entity.TcKimlik = reader.GetString(1);
                                    entity.Ad = reader.GetString(2);
                                    entity.Soyad = reader.GetString(3);
                                    entity.DogumTarihi = reader.GetDateTime(4).Date;
                                    entity.Adres = reader.GetString(5);
                                    entity.Telefon = reader.GetString(6);
                                    entity.Email = reader.GetString(7);
                                    entity.KullaniciAdi = reader.GetString(8);
                                    entity.Parola = reader.GetString(9);
                                    entity.KullaniciTipi = reader.GetString(10);
                                    entity.Anahtar = reader.GetGuid(11);
                              
                                    Kullanicilar.Add(entity);
                                }
                            }
                        }


                    }
                }
                // Return list
                return Kullanicilar;
          //  }
            //catch (Exception ex)
            //{
          //      throw new Exception("KullaniciRepository:Hepsini Seçim Hatası", ex);
            //}
        }

        public Kullanici IdSec(int id)
        {

            _rowsAffected = 0;

            Kullanici Kullanici = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[KullaniciID],[TCKimlik],[Ad] ,[Soyad],[DogumTarihi],[Adres],[Telefon],[Email],[KullaniciAdi],[Parola],[KullaniciTipi],[Anahtar]");
                query.Append("FROM [dbo].[tblKullanici] ");
                query.Append("WHERE ");
                query.Append("[KullaniciID] = @id ");


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
                                "dbCommand" + " The db SelectById command for entity [tblKullanici] can't be null. ");

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
                                    var entity = new Kullanici();
                                    entity.KullaniciID = reader.GetInt32(0);
                                    entity.TcKimlik = reader.GetString(1);
                                    entity.Ad = reader.GetString(2);
                                    entity.Soyad = reader.GetString(3);
                                    entity.DogumTarihi = reader.GetDateTime(4).Date;
                                    entity.Adres = reader.GetString(5);
                                    entity.Telefon = reader.GetString(6);
                                    entity.Email = reader.GetString(7);
                                    entity.KullaniciAdi = reader.GetString(8);
                                    entity.Parola = reader.GetString(9);
                                    entity.KullaniciTipi = reader.GetString(10);
                                    entity.Anahtar = reader.GetGuid(11);
                                    Kullanici = entity;
                                    break;
                                }
                            }
                        }


                    }
                }

                return Kullanici;
            }
            catch (Exception ex)
            {

                throw new Exception("KullaniciRepository:ID ile Seçim Hatası", ex);
            }
        }

        public Kullanici KullaniciAdSec(string kullaniciAdi)
        {

            _rowsAffected = 0;

            Kullanici Kullanici = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[KullaniciID],[TCKimlik],[Ad] ,[Soyad],[DogumTarihi],[Adres],[Telefon],[Email],[KullaniciAdi],[Parola],[KullaniciTipi],[Anahtar]");
                query.Append("FROM [dbo].[tblKullanici] ");
                query.Append("WHERE ");
                query.Append("[KullaniciAdi] = @kullaniciAdi ");


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
                                "dbCommand" + " The db SelectById command for entity [tblKullanici] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        DBHelper.AddParameter(dbCommand, "@kullaniciAdi", kullaniciAdi);

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
                                    var entity = new Kullanici();
                                    entity.KullaniciID = reader.GetInt32(0);
                                    entity.TcKimlik = reader.GetString(1);
                                    entity.Ad = reader.GetString(2);
                                    entity.Soyad = reader.GetString(3);
                                    entity.DogumTarihi = reader.GetDateTime(4).Date;
                                    entity.Adres = reader.GetString(5);
                                    entity.Telefon = reader.GetString(6);
                                    entity.Email = reader.GetString(7);
                                    entity.KullaniciAdi = reader.GetString(8);
                                    entity.Parola = reader.GetString(9);
                                    entity.KullaniciTipi = reader.GetString(10);
                                    entity.Anahtar = reader.GetGuid(11);
                                    Kullanici = entity;
                                    break;
                                }
                            }
                        }


                    }
                }

                return Kullanici;
            }
            catch (Exception ex)
            {

                throw new Exception("KullaniciRepository:KullaniciAdi ile Seçim Hatası", ex);
            }
        }

        public bool IdSil(int id)
        {

            _rowsAffected = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("DELETE ");
                query.Append("FROM [dbo].[tblKullanici] ");
                query.Append("WHERE ");
                query.Append("[tblKullanici] = @id ");


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
                                "dbCommand" + " The db SelectById command for entity [tblKullanici] can't be null. ");

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
                throw new Exception("KullaniciRepository:Silme Hatası", ex);
            }
        }

        public Kullanici Giris(string kullaniciadi, string parola)
        {
            _rowsAffected = 0;
            Kullanici Kullanici = null;
            
            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[KullaniciID],[TCKimlik],[Ad] ,[Soyad],[DogumTarihi],[Adres],[Telefon],[Email],[KullaniciAdi],[Parola],[KullaniciTipi],[Anahtar]");
                query.Append("FROM [dbo].[tblKullanici]");
                query.Append("WHERE ");
                query.Append("[KullaniciAdi] = @KullaniciAdi AND [Parola]=@Parola ");

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
                        DBHelper.AddParameter(dbCommand, "@KullaniciAdi", kullaniciadi);
                        DBHelper.AddParameter(dbCommand, "@Parola", parola);

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
                                    var entity = new Kullanici();
                                    entity.KullaniciID = reader.GetInt32(0);
                                    entity.TcKimlik = reader.GetString(1);
                                    entity.Ad = reader.GetString(2);
                                    entity.Soyad = reader.GetString(3);
                                    entity.DogumTarihi = reader.GetDateTime(4).Date;
                                    entity.Adres = reader.GetString(5);
                                    entity.Telefon = reader.GetString(6);
                                    entity.Email = reader.GetString(7);
                                    entity.KullaniciAdi = reader.GetString(8);
                                    entity.Parola = reader.GetString(9);
                                    entity.KullaniciTipi = reader.GetString(10);
                                    entity.Anahtar = reader.GetGuid(11);
                                    Kullanici = entity;
                                    break;
                                }
                            }

                        }
                    }

                }

                return Kullanici;
            }
            catch (Exception ex)
            {
                throw new Exception("KullaniciRepository:Giriş Hatası", ex);
            }
        }

        public Kullanici KeySec(string anahtar)
        {

            _rowsAffected = 0;

            Kullanici Kullanici = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[KullaniciID],[TCKimlik],[Ad] ,[Soyad],[DogumTarihi],[Adres],[Telefon],[Email],[KullaniciAdi],[Parola],[KullaniciTipi],[Anahtar]");
                query.Append("FROM [dbo].[tblKullanici] ");
                query.Append("WHERE ");
                query.Append("[Anahtar] = @anahtar ");


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
                                "dbCommand" + " The db SelectById command for entity [tblKullanici] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        DBHelper.AddParameter(dbCommand, "@anahtar", anahtar);

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
                                    var entity = new Kullanici();
                                    entity.KullaniciID = reader.GetInt32(0);
                                    entity.TcKimlik = reader.GetString(1);
                                    entity.Ad = reader.GetString(2);
                                    entity.Soyad = reader.GetString(3);
                                    entity.DogumTarihi = reader.GetDateTime(4).Date;
                                    entity.Adres = reader.GetString(5);
                                    entity.Telefon = reader.GetString(6);
                                    entity.Email = reader.GetString(7);
                                    entity.KullaniciAdi = reader.GetString(8);
                                    entity.Parola = reader.GetString(9);
                                    entity.KullaniciTipi = reader.GetString(10);
                                    entity.Anahtar = reader.GetGuid(11);
                                    Kullanici = entity;
                                    break;
                                }
                            }
                        }


                    }
                }

                return Kullanici;
            }
            catch (Exception ex)
            {

                throw new Exception("KullaniciRepository:ID ile Seçim Hatası", ex);
            }
        }
        //public string Giris(string kullaniciadi, string parola)
        //{
        //    _rowsAffected = 0;

        //    string tip = "tipsiz";
        //    try
        //    {
        //        var query = new StringBuilder();
        //        query.Append("SELECT ");
        //        query.Append("*");
        //        query.Append("FROM [dbo].[tblKullanici]");
        //        query.Append("WHERE ");
        //        query.Append("[KullaniciAdi] = @KullaniciAdi AND [Parola]=@Parola ");

        //        var commandText = query.ToString();
        //        query.Clear();

        //        using (var dbConnection = _dbProviderFactory.CreateConnection())
        //        {
        //            if (dbConnection == null)
        //                throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

        //            dbConnection.ConnectionString = _connectionString;

        //            using (var dbCommand = _dbProviderFactory.CreateCommand())
        //            {
        //                if (dbCommand == null)
        //                    throw new ArgumentNullException(
        //                        "dbCommand" + " The db SelectById command for entity [tbl_Transactions] can't be null. ");

        //                dbCommand.Connection = dbConnection;
        //                dbCommand.CommandText = commandText;

        //                //Input Parameters
        //                DBHelper.AddParameter(dbCommand, "@KullaniciAdi", kullaniciadi);
        //                DBHelper.AddParameter(dbCommand, "@Parola", parola);

        //                //Open Connection
        //                if (dbConnection.State != ConnectionState.Open)
        //                    dbConnection.Open();

        //                //Execute query.
        //                using (var reader = dbCommand.ExecuteReader())
        //                {
        //                    if (reader.HasRows)
        //                    {
        //                        while (reader.Read())
        //                        {
        //                            if (reader["KullaniciTipi"] == "Müşteri")
        //                                tip = "true";
        //                            else
        //                                tip = "false";
        //                        }
        //                    }
        //                    else
        //                    {
        //                        tip = "yanlış";
        //                    }
        //                }
        //            }

        //        }
        //        return tip;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("KullaniciRepository:Giriş Hatası", ex);
        //    }
        //}
    }
}
