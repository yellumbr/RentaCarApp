﻿using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Abstractions;
using Models.Concretes;
using System.Data;
using System.Data.Common;
using Commons.Concretes;

namespace DataAccesLayer.Concretes
{
    public class AracRepository : IRepository<Arac>,IDisposable
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
        public AracRepository()
        {
            _connectionString = DBHelper.GetConnectionString();
            _dbProviderName = DBHelper.GetConnectionProvider();
            _dbProviderFactory = DbProviderFactories.GetFactory(_dbProviderName);
        }
        public bool Ekle(Arac entity)
        {
            _rowsAffected = 0;
            

            try
            {
                var query = new StringBuilder();
                query.Append("INSERT INTO tblArac ");
                query.Append("( AracAdi, AracModel, GerekenEhliyetYasi,MinimumYasSiniri,GunlukKmSiniri,AracKm,HavaYastigi,BagajHacmi,KoltukSayisi,GunlukKiraBedeli,Rezerv,Kirada,YakitTipi,VitesTipi,Plaka,AracResmi,SirketID,MusteriID,AracGider ) ");//
                query.Append("VALUES ");
                query.Append(
                    "( @AracAdi, @AracModeli, @GerekenEhliyetYasi,@MinimumYasSiniri,@GunlukKmSiniri,@AracKm,@HavaYastigi,@BagajHacmi,@KoltukSayisi,@GunlukKiraBedeli,@Rezerv,@Kirada,@YakitTipi,@VitesTipi,@Plaka,@AracResmi,@SirketID,@MusteriID,@AracGider ) ");//

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
                        DBHelper.AddParameter(dbCommand, "@AracGider", entity.AracGider);
                        DBHelper.AddParameter(dbCommand, "@SirketID",entity.SirketID );
                        DBHelper.AddParameter(dbCommand, "@MusteriID", entity.MusteriID);

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

                throw new Exception("AracRepository:Ekleme Hatası", ex);
            }
        }

        public bool Guncelle(Arac entity)
        {
            _rowsAffected = 0;
           

            try
            {
                var query = new StringBuilder();
                query.Append("UPDATE [dbo].[tblArac] ");
                query.Append("SET [Plaka] = @Plaka, [AracAdi] =  @AracAdi, [AracModel] = @AracModeli, [GerekenEhliyetYasi] = @GerekenEhliyetYasi, [MinimumYasSiniri] = @MinimumYasSiniri, [GunlukKmSiniri] = @GunlukKmSiniri," +
                    "[AracKm] = @AracKm, [HavaYastigi] = @HavaYastigi, [BagajHacmi] = @BagajHacmi, [KoltukSayisi] = @KoltukSayisi, [GunlukKiraBedeli] = @GunlukKiraBedeli, " +
                    "[Rezerv] = @Rezerv, [Kirada] = @Kirada, [YakitTipi] = @YakitTipi, [VitesTipi] = @VitesTipi, [AracResmi] = @AracResmi,[KiralanmaTarihi] =@KiralanmaTarihi," +
                    "[KiradanDonusTarihi]=@KiradanDonusTarihi,[SirketID]=@SirketID,[MusteriID]=@MusteriID,[AracGider]=@AracGider ");
                query.Append("WHERE ");
                query.Append(" [AracID] = @AracId ");

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
                        DBHelper.AddParameter(dbCommand, "@AracId", entity.AracID);
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
                        DBHelper.AddParameter(dbCommand, "@KiralanmaTarihi", entity.KiralanmaTarihi.Date);
                        DBHelper.AddParameter(dbCommand, "@KiradanDonusTarihi", entity.KiradanDonusTarihi.Date);
                        DBHelper.AddParameter(dbCommand, "@SirketID", entity.SirketID);
                        DBHelper.AddParameter(dbCommand, "@MusteriID", entity.MusteriID);
                        DBHelper.AddParameter(dbCommand, "@AracGider", entity.AracGider);

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
                throw new Exception("AracRepository:Güncelleme Hatası", ex);
            }
        }
        public bool Kirala(Arac entity)
        {
            _rowsAffected = 0;


            try
            {
                var query = new StringBuilder();
                query.Append("UPDATE [dbo].[tblArac] ");
                query.Append("SET Kirada = @Kirada,KiralanmaTarihi=@KiralanmaTarihi," +
                    "KiradanDonusTarihi=@KiradanDonusTarihi,MusteriID=@MusteriID ");
                query.Append("WHERE ");
                query.Append(" [Plaka] = @Plaka ");

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
                        DBHelper.AddParameter(dbCommand, "@Kirada", entity.Kirada);
                        DBHelper.AddParameter(dbCommand, "@Plaka", entity.Plaka);
                        DBHelper.AddParameter(dbCommand, "@KiralanmaTarihi", entity.KiralanmaTarihi.Date);
                        DBHelper.AddParameter(dbCommand, "@KiradanDonusTarihi", entity.KiradanDonusTarihi.Date);
                        DBHelper.AddParameter(dbCommand, "@MusteriID", entity.MusteriID);
                     

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
                throw new Exception("AracRepository:Kiralama Hatası", ex);
            }
        }

        public IList<Arac> HepsiniSec()
        {
           
            _rowsAffected = 0;

            IList<Arac> araclar = new List<Arac>();

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append(
                    "[AracID], [AracAdi], [AracModel],[Plaka],  " +
                    "[GerekenEhliyetYasi], [MinimumYasSiniri], [GunlukKmSiniri], [AracKm], [HavaYastigi], " +
                    "[BagajHacmi], [KoltukSayisi], [GunlukKiraBedeli], [Rezerv], [Kirada], [YakitTipi], " +
                    "[VitesTipi], [AracResmi],[KiralanmaTarihi],[KiradanDonusTarihi],[SirketID],[MusteriID],[AracGider] ");
                query.Append("FROM [dbo].[tblArac] ");

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
                                    var entity = new Arac();
                                    entity.AracID = reader.GetInt32(0);
                                    entity.AracAdi = reader.GetString(1);
                                    entity.AracModeli = reader.GetString(2);
                                    entity.Plaka = reader.GetString(3);
                                    entity.GerekenEhliyetYasi = reader.GetInt32(4);
                                    entity.MinimumYasSiniri = reader.GetInt32(5);
                                    entity.GunlukKmSiniri = reader.GetInt32(6);
                                    entity.AracKm = reader.GetInt32(7);
                                    entity.HavaYastigi = reader.GetString(8);
                                    entity.BagajHacmi = reader.GetInt32(9);
                                    entity.KoltukSayisi = reader.GetInt32(10);
                                    entity.GunlukKiraBedeli = reader.GetDecimal(11);
                                    if (!reader.IsDBNull(12))
                                        entity.Rezerv = reader.GetBoolean(12);
                                    if (!reader.IsDBNull(13))
                                        entity.Kirada = reader.GetBoolean(13);
                                    if (!reader.IsDBNull(14))
                                        entity.YakitTipi = reader.GetString(14);
                                    if (!reader.IsDBNull(15))
                                        entity.VitesTipi = reader.GetString(15);
                                    if (!reader.IsDBNull(16))
                                        entity.AracResmi = reader.GetString(16);
                                    if (!reader.IsDBNull(17))
                                        entity.KiralanmaTarihi = reader.GetDateTime(17).Date;
                                    if (!reader.IsDBNull(18))
                                        entity.KiradanDonusTarihi = reader.GetDateTime(18).Date;
                                    if (!reader.IsDBNull(19))
                                        entity.SirketID = reader.GetInt32(19);
                                    if (!reader.IsDBNull(20))
                                        entity.MusteriID = reader.GetInt32(20);
                                    if (!reader.IsDBNull(21))
                                        entity.AracGider = reader.GetDecimal(21);


                                    araclar.Add(entity);
                                }
                            }

                        }

                    }
                }
                // Return list
                return araclar;
            }
            catch (Exception ex)
            {
                throw new Exception("AracRepository:Hepsini Seçme Hatası", ex);
            }
        }

        public Arac IdSec(int id)
        {
            
            _rowsAffected = 0;

            Arac arac = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append(
                    "[AracID], [Plaka], [AracAdi], [AracModel], [GerekenEhliyetYasi]," +
                    " [MinimumYasSiniri], [GunlukKmSiniri], [AracKm], [HavaYastigi], " +
                    "[BagajHacmi], [KoltukSayisi], [GunlukKiraBedeli], [Rezerv], [Kirada], " +
                    "[YakitTipi], [VitesTipi], [AracResmi],[KiralanmaTarihi],[KiradanDonusTarihi],[SirketID],[MusteriID],[AracGider] ");
                query.Append("FROM [dbo].[tblArac] ");
                query.Append("WHERE ");
                query.Append("[AracID] = @id ");

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
                                    var entity = new Arac();
                                    entity.AracID = reader.GetInt32(0);
                                    entity.AracAdi = reader.GetString(1);
                                    entity.AracModeli = reader.GetString(2);
                                    entity.Plaka = reader.GetString(3);
                                    entity.GerekenEhliyetYasi = reader.GetInt32(4);
                                    entity.MinimumYasSiniri = reader.GetInt32(5);
                                    entity.GunlukKmSiniri = reader.GetInt32(6);
                                    entity.AracKm = reader.GetInt32(7);
                                    entity.HavaYastigi = reader.GetString(8);
                                    entity.BagajHacmi = reader.GetInt32(9);
                                    entity.KoltukSayisi = reader.GetInt32(10);
                                    entity.GunlukKiraBedeli = reader.GetDecimal(11);
                                    entity.Rezerv = reader.GetBoolean(12);
                                    entity.Kirada = reader.GetBoolean(13);
                                    entity.YakitTipi = reader.GetString(14);
                                    entity.VitesTipi = reader.GetString(15);
                                    if (!reader.IsDBNull(16))
                                        entity.AracResmi = reader.GetString(16);
                                    if (!reader.IsDBNull(17))
                                        entity.KiralanmaTarihi = reader.GetDateTime(17).Date;
                                    if (!reader.IsDBNull(18))
                                        entity.KiradanDonusTarihi = reader.GetDateTime(18).Date;
                                    if (!reader.IsDBNull(19))
                                        entity.SirketID = reader.GetInt32(19);
                                    if (!reader.IsDBNull(20))
                                        entity.MusteriID = reader.GetInt32(20);
                                    if (!reader.IsDBNull(21))
                                        entity.AracGider = reader.GetDecimal(21);
                                    arac = entity;
                                    break;
                                }
                            }
                        }

                        
                    }
                }

                return arac;
            }
            catch (Exception ex)
            {
                throw new Exception("AracRepository:Id ile Seçme Hatası", ex);
            }
        }

        public Arac PlakaSec(string plaka)
        {

            _rowsAffected = 0;

            Arac arac = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append(
                    "[AracID], [Plaka], [AracAdi], [AracModel], [GerekenEhliyetYasi]," +
                    " [MinimumYasSiniri], [GunlukKmSiniri], [AracKm], [HavaYastigi], " +
                    "[BagajHacmi], [KoltukSayisi], [GunlukKiraBedeli], [Rezerv], [Kirada], " +
                    "[YakitTipi], [VitesTipi], [AracResmi],[KiralanmaTarihi],[KiradanDonusTarihi],[SirketID],[MusteriID],[AracGider] ");
                query.Append("FROM [dbo].[tblArac] ");
                query.Append("WHERE ");
                query.Append("[Plaka] = @plaka ");

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
                        DBHelper.AddParameter(dbCommand, "@plaka", plaka);



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
                                    var entity = new Arac();
                                    entity.AracID = reader.GetInt32(0);
                                    entity.AracAdi = reader.GetString(1);
                                    entity.AracModeli = reader.GetString(2);
                                    entity.Plaka = reader.GetString(3);
                                    entity.GerekenEhliyetYasi = reader.GetInt32(4);
                                    entity.MinimumYasSiniri = reader.GetInt32(5);
                                    entity.GunlukKmSiniri = reader.GetInt32(6);
                                    entity.AracKm = reader.GetInt32(7);
                                    entity.HavaYastigi = reader.GetString(8);
                                    entity.BagajHacmi = reader.GetInt32(9);
                                    entity.KoltukSayisi = reader.GetInt32(10);
                                    entity.GunlukKiraBedeli = reader.GetDecimal(11);
                                    entity.Rezerv = reader.GetBoolean(12);
                                    entity.Kirada = reader.GetBoolean(13);
                                    entity.YakitTipi = reader.GetString(14);
                                    entity.VitesTipi = reader.GetString(15);
                                    if (!reader.IsDBNull(16))
                                        entity.AracResmi = reader.GetString(16);
                                    if (!reader.IsDBNull(17))
                                        entity.KiralanmaTarihi = reader.GetDateTime(17).Date;
                                    if (!reader.IsDBNull(18))
                                        entity.KiradanDonusTarihi = reader.GetDateTime(18).Date;
                                    if (!reader.IsDBNull(19))
                                        entity.SirketID = reader.GetInt32(19);
                                    if (!reader.IsDBNull(20))
                                        entity.MusteriID = reader.GetInt32(20);
                                    if (!reader.IsDBNull(21))
                                        entity.AracGider = reader.GetDecimal(21);
                                    arac = entity;
                                    break;
                                }
                            }
                        }


                    }
                }

                return arac;
            }
            catch (Exception ex)
            {
                throw new Exception("AracRepository:Id ile Seçme Hatası", ex);
            }
        }

        public bool IdSil(int id)
        {
            
            _rowsAffected = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("DELETE ");
                query.Append("FROM [dbo].[tblArac] ");
                query.Append("WHERE ");
                query.Append("[AracID] = @id ");

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

                throw new Exception("AracRepository:Silme Hatası", ex);
            }
        }
    }
}
