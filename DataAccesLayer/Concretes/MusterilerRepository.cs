using System;
using System.Data;
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
    public class MusterilerRepository : IRepository<Musteriler>,IDisposable
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
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("INSERT INTO tblMusteri(KaraListe,KullaniciAdi,Sifre,EhliyetTarih,EhliyetTipi) ");
                query.Append("VALUES( @KaraListe, @KullaniciAdi, @Sifre,@EhliyetTarih,@EhliyetTipi )");
                query.Append("declare @sonID int");
                query.Append("set @sonID = SCOPE_IDENTITY()");
                query.Append("INSERT INTO tblKisiDetay(TCKimlik,Ad,Soyad,Adres,Telefon,Email,DogumTarihi,MusteriID)");
                query.Append("Values(@TCKimlik,@Ad,@Soyad,@Adres,@Telefon,@Email,@DogumTarihi,@sonID)");
                  
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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [tblMusteriler] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@KaraLise", entity.KaraListe);
                        DBHelper.AddParameter(dbCommand, "@KullaniciAdi", entity.KullaniciAdi);
                        DBHelper.AddParameter(dbCommand, "@Sifre", entity.Sifre);
                        DBHelper.AddParameter(dbCommand, "@EhliyetTarih", entity.EhliyetYil);
                        DBHelper.AddParameter(dbCommand, "@EhliyetTipi", entity.EhliyetTipi);
                        DBHelper.AddParameter(dbCommand, "@Ad", entity.Kisi.Ad);
                        DBHelper.AddParameter(dbCommand, "@Soyad", entity.Kisi.Soyad);
                        DBHelper.AddParameter(dbCommand, "@Adres", entity.Kisi.Adres);
                        DBHelper.AddParameter(dbCommand, "@Telefon", entity.Kisi.Telefon);
                        DBHelper.AddParameter(dbCommand, "@Email", entity.Kisi.Email);
                        DBHelper.AddParameter(dbCommand, "@DogumTarihi", entity.Kisi.DogumTarihi);
                      

                        //Output Params
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception("Inserting Error for entity [tblMusteri] reported the Database ErrorCode: " + _errorCode);
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
                query.Append(" SET [KaraListe] = @KaraListe, [KullaniciAdi] = @KullaniciAdi, [Sifre] =  @Sifre, [EhliyetTarih] = @EhliyetTarih, [EhliyetTipi] = @EhliyetTipi ");
                query.Append(" WHERE ");
                query.Append(" [MusteriID] = @MusteriID ");

                query.Append(" UPDATE [dbo].[tblKisiDetay] ");
                query.Append(" SET [TCKimlik] = @TCKimlik, [Ad] = @Ad, [Soyad] =  @Soyad, [Adres] = @Adres, [Telefon] = @Telefon, [Email] = @Email, [DogumTarihi] =  @DogumTarihi");
                query.Append(" WHERE ");
                query.Append(" [MusteriID] = @MusteriID ");
                query.Append(" SELECT @intErrorCode = @@ERROR; ");

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
                        DBHelper.AddParameter(dbCommand, "@KaraLise", entity.KaraListe);
                        DBHelper.AddParameter(dbCommand, "@KullaniciAdi", entity.KullaniciAdi);
                        DBHelper.AddParameter(dbCommand, "@Sifre", entity.Sifre);
                        DBHelper.AddParameter(dbCommand, "@EhliyetTarih", entity.EhliyetYil);
                        DBHelper.AddParameter(dbCommand, "@EhliyetTipi", entity.EhliyetTipi);
                        DBHelper.AddParameter(dbCommand, "@Ad", entity.Kisi.Ad);
                        DBHelper.AddParameter(dbCommand, "@Soyad", entity.Kisi.Soyad);
                        DBHelper.AddParameter(dbCommand, "@Adres", entity.Kisi.Adres);
                        DBHelper.AddParameter(dbCommand, "@Telefon", entity.Kisi.Telefon);
                        DBHelper.AddParameter(dbCommand, "@Email", entity.Kisi.Email);
                        DBHelper.AddParameter(dbCommand, "@DogumTarihi", entity.Kisi.DogumTarihi);

                        //Output Params
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception("Updating Error for entity [tblMusteri] reported the Database ErrorCode: " + _errorCode);
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
            _errorCode = 0;
            _rowsAffected = 0;

            IList<Musteriler> musteriler = new List<Musteriler>();

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append(
                    "[MusteriID], [KullaniciAdi], [Sifre], [EhliyetTipi], [EhliyetYil],[Ad],[Soyad],[TCKimlik],[Telefon],[Email],[DogumTarihi],[Adres] ");
                query.Append("FROM [dbo].[tblMusteri], [dbo].[tblKisiDetay] ");
                query.Append("SELECT @intErrorCode=@@ERROR; ");

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

                        //Input Parameters - None

                        //Output Parameters
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", null);

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
                                    entity.KaraListe = reader.GetBoolean(1);
                                    entity.Sifre = reader.GetString(2);
                                    entity.EhliyetTipi = reader.GetString(3);
                                    entity.EhliyetYil = reader.GetDateTime(4);
                                    entity.Kisi.Ad = reader.GetString(5);
                                    entity.Kisi.Soyad = reader.GetString(6);
                                    entity.Kisi.TcKimlik = reader.GetString(7);
                                    entity.Kisi.Telefon = reader.GetString(8);
                                    entity.Kisi.Email = reader.GetString(9);
                                    entity.Kisi.DogumTarihi = reader.GetDateTime(10);
                                    entity.Kisi.Adres = reader.GetString(11);
                                    musteriler.Add(entity);
                                }
                            }

                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting All Error for entity [tblMusteri] reported the Database ErrorCode: " + _errorCode);

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
            _errorCode = 0;
            _rowsAffected = 0;

            Musteriler musteri = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append(
                    "[MusteriID], [KullaniciAdi], [Sifre], [EhliyetTipi], [EhliyetYil],[Ad],[Soyad],[TCKimlik],[Telefon],[Email],[DogumTarihi],[Adres] ");
                query.Append("FROM [dbo].[tblMusteri], [dbo].[tblKisiDetay] ");
                query.Append("WHERE ");
                query.Append("[MusteriID] = @id ");
                query.Append("SELECT @intErrorCode=@@ERROR; ");

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

                        //Output Parameters
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", null);

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
                                    entity.KaraListe = reader.GetBoolean(1);
                                    entity.Sifre = reader.GetString(2);
                                    entity.EhliyetTipi = reader.GetString(3);
                                    entity.EhliyetYil = reader.GetDateTime(4);
                                    entity.Kisi.Ad = reader.GetString(5);
                                    entity.Kisi.Soyad = reader.GetString(6);
                                    entity.Kisi.TcKimlik = reader.GetString(7);
                                    entity.Kisi.Telefon = reader.GetString(8);
                                    entity.Kisi.Email = reader.GetString(9);
                                    entity.Kisi.DogumTarihi = reader.GetDateTime(10);
                                    entity.Kisi.Adres = reader.GetString(11);
                                    musteri = entity;
                                    break;
                                }
                            }
                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting Error for entity [tblMusteri] reported the Database ErrorCode: " + _errorCode);
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
            _errorCode = 0;
            _rowsAffected = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("DELETE ");
                query.Append("FROM [dbo].[tblMusteri] ");
                query.Append("WHERE ");
                query.Append("[tblMusteri] = @id ");
                query.Append("SELECT @intErrorCode=@@ERROR; ");

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
                        DBHelper.AddParameter(dbCommand, "@id",  id);

                        //Output Parameters
                        DBHelper.AddParameter(dbCommand, "@intErrorCode",  null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();
                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception(
                                "Deleting Error for entity [tblMusteri] reported the Database ErrorCode: " +
                                _errorCode);
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
