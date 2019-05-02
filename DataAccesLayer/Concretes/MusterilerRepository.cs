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
    public class MusterilerRepository : IRepository<Musteriler>, IDisposable
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
        public MusterilerRepository()
        {
            _connectionString = DBHelper.GetConnectionString();
            _dbProviderName = DBHelper.GetConnectionProvider();
            _dbProviderFactory = DbProviderFactories.GetFactory(_dbProviderName);
        }

        public bool Ekle(Musteriler entity)
        {
            _rowsAffected = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("INSERT INTO tblMusteri(TCKimlik,Ad,Soyad,Adres,Telefon,Email,KaraListe,KullaniciAdi,Sifre,EhliyetTipi,EhliyetTarih,DogumTarihi)");//
                query.Append("VALUES(@TCKimlik,@Ad,@Soyad,@Adres,@Telefon,@Email,@KaraListe,@KullaniciAdi,@Sifre,@EhliyetTipi,@EhliyetTarih,@DogumTarihi)");//

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
                        DBHelper.AddParameter(dbCommand, "@KaraListe", entity.KaraListe);
                        DBHelper.AddParameter(dbCommand, "@KullaniciAdi", entity.KullaniciAdi);
                        DBHelper.AddParameter(dbCommand, "@Sifre", entity.Sifre);
                        DBHelper.AddParameter(dbCommand, "@EhliyetTarih", entity.EhliyetYil.Date);
                        DBHelper.AddParameter(dbCommand, "@EhliyetTipi", entity.EhliyetTipi);
                        DBHelper.AddParameter(dbCommand, "@TCKimlik", entity.TcKimlik);
                        DBHelper.AddParameter(dbCommand, "@Ad", entity.Ad);
                        DBHelper.AddParameter(dbCommand, "@Soyad", entity.Soyad);
                        DBHelper.AddParameter(dbCommand, "@Adres", entity.Adres);
                        DBHelper.AddParameter(dbCommand, "@Telefon", entity.Telefon);
                        DBHelper.AddParameter(dbCommand, "@Email", entity.Email);
                        DBHelper.AddParameter(dbCommand, "@DogumTarihi", entity.DogumTarihi.Date);



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

        public bool Guncelle(Musteriler entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append(" UPDATE [dbo].[tblMusteri] ");
                //KaraListe,KullaniciAdi,Sifre,EhliyetTarih,EhliyetTipi
                query.Append(" SET [TCKimlik] = @TCKimlik, [Ad] = @Ad, [Soyad] =  @Soyad, [Adres] = @Adres, [Telefon] = @Telefon, [Email] = @Email,  [KaraListe] = @KaraListe, [KullaniciAdi] = @KullaniciAdi, [Sifre] =  @Sifre, [EhliyetTipi] = @EhliyetTipi,[EhliyetTarih]=@EhliyetTarih,[DogumTarihi]=@DogumTarihi ");
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
                        DBHelper.AddParameter(dbCommand, "@MusteriID", entity.MusteriId);
                        DBHelper.AddParameter(dbCommand, "@KaraListe", entity.KaraListe);
                        DBHelper.AddParameter(dbCommand, "@KullaniciAdi", entity.KullaniciAdi);
                        DBHelper.AddParameter(dbCommand, "@Sifre", entity.Sifre);
                        DBHelper.AddParameter(dbCommand, "@EhliyetTarih", entity.EhliyetYil.Date);
                        DBHelper.AddParameter(dbCommand, "@EhliyetTipi", entity.EhliyetTipi);
                        DBHelper.AddParameter(dbCommand, "@TCKimlik", entity.TcKimlik);
                        DBHelper.AddParameter(dbCommand, "@Ad", entity.Ad);
                        DBHelper.AddParameter(dbCommand, "@Soyad", entity.Soyad);
                        DBHelper.AddParameter(dbCommand, "@Adres", entity.Adres);
                        DBHelper.AddParameter(dbCommand, "@Telefon", entity.Telefon);
                        DBHelper.AddParameter(dbCommand, "@Email", entity.Email);
                        DBHelper.AddParameter(dbCommand, "@DogumTarihi", entity.DogumTarihi.Date);


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

        public IList<Musteriler> HepsiniSec()
        {
            _rowsAffected = 0;

            IList<Musteriler> musteriler = new List<Musteriler>();

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append(
                    "[MusteriID], [TCKimlik], [Ad], [Soyad],[DogumTarihi],[Adres],[Telefon],[Email],[KullaniciAdi],[Sifre],[EhliyetTipi],[EhliyetTarih],[KaraListe] ");
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
                                    var entity = new Musteriler();
                                    entity.MusteriId = reader.GetInt32(0);
                                    entity.TcKimlik = reader.GetString(1);
                                    entity.Ad = reader.GetString(2);
                                    entity.Soyad = reader.GetString(3);
                                    entity.DogumTarihi = reader.GetDateTime(4).Date;
                                    entity.Adres = reader.GetString(5);
                                    entity.Telefon = reader.GetString(6);
                                    entity.Email = reader.GetString(7);
                                    entity.KullaniciAdi = reader.GetString(8);
                                    entity.Sifre = reader.GetString(9);
                                    entity.EhliyetTipi = reader.GetString(10);
                                    entity.EhliyetYil = reader.GetDateTime(11).Date;
                                    entity.KaraListe = reader.GetBoolean(12);
                                    musteriler.Add(entity);
                                }
                            }

                        }
                    }
                }
                // Return list
                return musteriler;
            }
            catch (Exception ex)
            {
                throw new Exception("CustomersRepository::SelectAll:Error occured.", ex);
            }
        }

        public Musteriler IdSec(int id)
        {

            _rowsAffected = 0;

            Musteriler musteri = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append(
                    "[MusteriID], [TCKimlik], [Ad], [Soyad],[DogumTarihi],[Adres],[Telefon],[Email],[KullaniciAdi],[Sifre],[EhliyetTipi],[EhliyetTarih],[KaraListe] ");
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
                                    var entity = new Musteriler();
                                    entity.MusteriId = reader.GetInt32(0);
                                    entity.TcKimlik = reader.GetString(1);
                                    entity.Ad = reader.GetString(2);
                                    entity.Soyad = reader.GetString(3);
                                    entity.DogumTarihi = reader.GetDateTime(4).Date;
                                    entity.Adres = reader.GetString(5);
                                    entity.Telefon = reader.GetString(6);
                                    entity.Email = reader.GetString(7);
                                    entity.KullaniciAdi = reader.GetString(8);
                                    entity.Sifre = reader.GetString(9);
                                    entity.EhliyetTipi = reader.GetString(10);
                                    entity.EhliyetYil = reader.GetDateTime(11).Date;
                                    entity.KaraListe = reader.GetBoolean(12);
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
                throw new Exception("TransactionsRepository::SelectById:Error occured.", ex);
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
                throw new Exception("TransactionsRepository::Insert:Error occured.", ex);
            }
        }
    }
}
