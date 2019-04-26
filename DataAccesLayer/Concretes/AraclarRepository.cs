using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Abstractions;
using Models.Concretes;
using System.Data;
using System.Data.Common;
using Commons.Concretes;

namespace DataAccesLayer.Concretes
{
    public class AraclarRepository : IRepository<Araclar>,IDisposable
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
        public AraclarRepository()
        {
            _connectionString = DBHelper.GetConnectionString();
            _dbProviderName = DBHelper.GetConnectionProvider();
            _dbProviderFactory = DbProviderFactories.GetFactory(_dbProviderName);
        }
        public bool Ekle(Araclar entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("INSERT [dbo.tblArac] ");
                query.Append("( [AracAdi], [AracModel], [GerekenEhliyetYasi],[MinimumYasSiniri],[GunlukKmSiniri],[AracKm],[HavaYastigi],[BagajHacmi],[KoltukSayisi],[GunlukKiraBedeli],[Rezerv],[Kirada],[YakitTipi],[VitesTipi],[Plaka],[AracResmi] ) ");
                query.Append("VALUES ");
                query.Append(
                    "( @AracAdi, @AracModel, @GerekenEhliyetYasi,@MinimumYasSiniri,@GunlukKmSiniri,@AracKm,@HavaYastigi,@BagajHacmi,@KoltukSayisi,@GunlukKiraBedeli,@Rezerv,@Kirada,@YakitTipi,@VitesTipi,@Plaka,@AracResmi ) ");
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
                        DBHelper.AddParameter(dbCommand, "@AracAdi", entity.AracAdi);
                        DBHelper.AddParameter(dbCommand, "@AracKm", entity.AracKm);
                        DBHelper.AddParameter(dbCommand, "@AracModeli", entity.AracModeli);
                        DBHelper.AddParameter(dbCommand, "@AracResmi", entity.AracResmi);
                        DBHelper.AddParameter(dbCommand, "@BagajHacmi", entity.BagajHacmi);
                        DBHelper.AddParameter(dbCommand, "@GerekenEhliyetYasi", entity.GerekenEhliyetYasi);
                        DBHelper.AddParameter(dbCommand, "@GunlukKiraBedeli", entity.GunlukKiraBedeli);
                        DBHelper.AddParameter(dbCommand, "@GunlukKmSiniri", entity.GunlukKmSiniri);
                        DBHelper.AddParameter(dbCommand, "@HavaYastigi", entity.HavaYastigi);
                        DBHelper.AddParameter(dbCommand, "@Kirada", entity.Kirada);
                        DBHelper.AddParameter(dbCommand, "@KoltukSayisi", entity.KoltukSayisi);
                        DBHelper.AddParameter(dbCommand, "@MinimumYasSiniri", entity.MinimumYasSiniri);
                        DBHelper.AddParameter(dbCommand, "@Plaka", entity.Plaka);
                        DBHelper.AddParameter(dbCommand, "@Rezerv", entity.Rezerv);
                        DBHelper.AddParameter(dbCommand, "@VitesTipi", entity.VitesTipi);
                        DBHelper.AddParameter(dbCommand, "@YakitTipi", entity.YakitTipi);

                        //Output Params
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception("Inserting Error for entity [tblArac] reported the Database ErrorCode: " + _errorCode);
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

        public bool Guncelle(Araclar entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("UPDATE [dbo].[tblArac] ");
                query.Append("SET [AracID] = @AracId, [Plaka] = @Plaka, [AracAdi] =  @AracAdi, [AracModeli] = @AracModeli, [GerekenEhliyetYasi] = @GerekenEhliyetYasi, [MinimumYasSiniri] = @MinimumYasSiniri, [GunlukKmSiniri] = @GunlukKmSiniri," +
                    "[AracKm] = @AracKm, [HavaYastigi] = @HavaYastigi, [BagajHacmi] = @BagajHacmi, [KoltukSayisi] = @KoltukSayisi, [GunlukKiraBedeli] = @GunlukKiraBedeli, [Rezerv] = @Rezerv, [Kirada] = @Kirada, [YakitTipi] = @YakitTipi, [VitesTipi] = @VitesTipi, [AracResmi] = @AracResmi, ");
                query.Append("WHERE ");
                query.Append(" [AracId] = @AracId ");
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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [tblArac] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@AracId", entity.AracId);
                        DBHelper.AddParameter(dbCommand, "@AracAdi", entity.AracAdi);
                        DBHelper.AddParameter(dbCommand, "@AracKm", entity.AracKm);
                        DBHelper.AddParameter(dbCommand, "@AracModeli", entity.AracModeli);
                        DBHelper.AddParameter(dbCommand, "@AracResmi", entity.AracResmi);
                        DBHelper.AddParameter(dbCommand, "@BagajHacmi", entity.BagajHacmi);
                        DBHelper.AddParameter(dbCommand, "@GerekenEhliyetYasi", entity.GerekenEhliyetYasi);
                        DBHelper.AddParameter(dbCommand, "@GunlukKiraBedeli", entity.GunlukKiraBedeli);
                        DBHelper.AddParameter(dbCommand, "@GunlukKmSiniri", entity.GunlukKmSiniri);
                        DBHelper.AddParameter(dbCommand, "@HavaYastigi", entity.HavaYastigi);
                        DBHelper.AddParameter(dbCommand, "@Kirada", entity.Kirada);
                        DBHelper.AddParameter(dbCommand, "@KoltukSayisi", entity.KoltukSayisi);
                        DBHelper.AddParameter(dbCommand, "@MinimumYasSiniri", entity.MinimumYasSiniri);
                        DBHelper.AddParameter(dbCommand, "@Plaka", entity.Plaka);
                        DBHelper.AddParameter(dbCommand, "@Rezerv", entity.Rezerv);
                        DBHelper.AddParameter(dbCommand, "@VitesTipi", entity.VitesTipi);
                        DBHelper.AddParameter(dbCommand, "@YakitTipi", entity.YakitTipi);

                        //Output Params
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception("Updating Error for entity [tblArac] reported the Database ErrorCode: " + _errorCode);
                    }
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("TransactionsRepository::Update:Error occured.", ex);
            }
        }

        public IList<Araclar> HepsiniSec()
        {
            _errorCode = 0;
            _rowsAffected = 0;

            IList<Araclar> araclar = new List<Araclar>();

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append(
                    "[AracId], [Plaka], [AracAdi], [AracModeli], [GerekenEhliyetYasi], [MinimumYasSiniri], [GunlukKmSiniri], [AracKm], [HavaYastigi], [BagajHacmi], [KoltukSayisi], [GunlukKiraBedeli], [Rezerv], [Kirada], [YakitTipi], [VitesTipi], [AracResmi] ");
                query.Append("FROM [dbo].[tblArac] ");
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
                                "dbCommand" + " The db SelectById command for entity [tblArac] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters - None

                        //Output Parameters
                        DBHelper.AddParameter(dbCommand, "@intErrorCode"
                            , null);

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
                                    var entity = new Araclar();
                                    entity.AracId = reader.GetInt32(0);
                                    entity.Plaka = reader.GetString(1);
                                    entity.AracAdi = reader.GetString(2);
                                    entity.AracModeli = reader.GetString(3);
                                    entity.GerekenEhliyetYasi = reader.GetInt32(4);
                                    entity.MinimumYasSiniri = reader.GetInt32(5);
                                    entity.GunlukKmSiniri = reader.GetInt32(6);
                                    entity.AracKm = reader.GetInt32(7);
                                    entity.HavaYastigi = reader.GetBoolean(8);
                                    entity.BagajHacmi = reader.GetInt32(9);
                                    entity.KoltukSayisi = reader.GetInt32(10);
                                    entity.GunlukKiraBedeli = reader.GetInt32(11);
                                    entity.Rezerv = reader.GetBoolean(12);
                                    entity.Kirada = reader.GetBoolean(13);
                                    entity.YakitTipi = reader.GetByte(14);
                                    entity.VitesTipi = reader.GetBoolean(15);
                                    entity.AracResmi = reader.GetString(16);
                                    araclar.Add(entity);
                                }
                            }

                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting All Error for entity [tblArac] reported the Database ErrorCode: " + _errorCode);

                        }
                    }
                }
                // Return list
                return araclar;
            }
            catch (Exception ex)
            {
                throw new Exception("TransactionsRepository::SelectAll:Error occured.", ex);
            }
        }

        public Araclar IdSec(int id)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            Araclar arac = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append(
                    "[AracId], [Plaka], [AracAdi], [AracModeli], [GerekenEhliyetYasi], [MinimumYasSiniri], [GunlukKmSiniri], [AracKm], [HavaYastigi], [BagajHacmi], [KoltukSayisi], [GunlukKiraBedeli], [Rezerv], [Kirada], [YakitTipi], [VitesTipi], [AracResmi] ");
                query.Append("FROM [dbo].[tblArac] ");
                query.Append("WHERE ");
                query.Append("[AracId] = @id ");
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
                                "dbCommand" + " The db SelectById command for entity [tblArac] can't be null. ");

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
                                    var entity = new Araclar();
                                    entity.AracId = reader.GetInt32(0);
                                    entity.Plaka = reader.GetString(1);
                                    entity.AracAdi = reader.GetString(2);
                                    entity.AracModeli = reader.GetString(3);
                                    entity.GerekenEhliyetYasi = reader.GetInt32(4);
                                    entity.MinimumYasSiniri = reader.GetInt32(5);
                                    entity.GunlukKmSiniri = reader.GetInt32(6);
                                    entity.AracKm = reader.GetInt32(7);
                                    entity.HavaYastigi = reader.GetBoolean(8);
                                    entity.BagajHacmi = reader.GetInt32(9);
                                    entity.KoltukSayisi = reader.GetInt32(10);
                                    entity.GunlukKiraBedeli = reader.GetInt32(11);
                                    entity.Rezerv = reader.GetBoolean(12);
                                    entity.Kirada = reader.GetBoolean(13);
                                    entity.YakitTipi = reader.GetByte(14);
                                    entity.VitesTipi = reader.GetBoolean(15);
                                    entity.AracResmi = reader.GetString(16);
                                    arac= entity;
                                    break;
                                }
                            }
                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting Error for entity [tblArac] reported the Database ErrorCode: " + _errorCode);
                        }
                    }
                }

                return arac;
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
                query.Append("FROM [dbo].[tblArac] ");
                query.Append("WHERE ");
                query.Append("[tblArac] = @id ");
                //TODO: SAÇMA
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
                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception(
                                "Deleting Error for entity [tblArac] reported the Database ErrorCode: " +
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
