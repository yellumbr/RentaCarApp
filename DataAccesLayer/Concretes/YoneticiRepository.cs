﻿using System;
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
                query.Append("INSERT INTO tblYonetici(Sifre,SirketID) ");
                query.Append("VALUES( @Sifre, @SirketID)");
                query.Append("declare @sonID int");
                query.Append("set @sonID = SCOPE_IDENTITY()");
                query.Append("INSERT INTO tblKisiDetay(TCKimlik,Ad,Soyad,Adres,Telefon,Email,DogumTarihi,YoneticiID)");
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
                        
                        DBHelper.AddParameter(dbCommand, "@Sifre", entity.Sifre);
                        DBHelper.AddParameter(dbCommand, "@SirketID", entity.SirketId);
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
                            throw new Exception("Inserting Error for entity [tblYonetici] reported the Database ErrorCode: " + _errorCode);
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
                query.Append(" SET [Sifre] =  @Sifre, [SirketID] = @SirketID ");
                query.Append(" WHERE ");
                query.Append(" [YoneticiID] = @YoneticiID ");

                query.Append(" UPDATE [dbo].[tblKisiDetay] ");
                query.Append(" SET [TCKimlik] = @TCKimlik, [Ad] = @Ad, [Soyad] =  @Soyad, [Adres] = @Adres, [Telefon] = @Telefon, [Email] = @Email, [DogumTarihi] =  @DogumTarihi");
                query.Append(" WHERE ");
                query.Append(" [YoneticiID] = @YoneticiID ");
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

                        DBHelper.AddParameter(dbCommand, "@Sifre", entity.Sifre);
                        DBHelper.AddParameter(dbCommand, "@SirketID", entity.SirketId);
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
                            throw new Exception("Updating Error for entity [tblYonetici] reported the Database ErrorCode: " + _errorCode);
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
                query.Append("FROM [dbo].[tblYonetici], [dbo].[tblKisiDetay] ");
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
                                "dbCommand" + " The db SelectById command for entity [tblYonetici] can't be null. ");

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
                                    var entity = new Yonetici();
                                    entity.YoneticiId = reader.GetInt32(0);
                                    entity.SirketId = reader.GetInt32(1);
                                    entity.Sifre = reader.GetString(2);
                                    entity.Kisi.Ad = reader.GetString(3);
                                    entity.Kisi.Soyad = reader.GetString(4);
                                    entity.Kisi.TcKimlik = reader.GetString(5);
                                    entity.Kisi.Telefon = reader.GetString(6);
                                    entity.Kisi.Email = reader.GetString(7);
                                    entity.Kisi.DogumTarihi = reader.GetDateTime(8);
                                    entity.Kisi.Adres = reader.GetString(9);
                                    yoneticiler.Add(entity);
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
                query.Append("FROM [dbo].[tblYonetici], [dbo].[tblKisiDetay] ");
                query.Append("WHERE ");
                query.Append("[YoneticiID] = @id ");
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
                                "dbCommand" + " The db SelectById command for entity [tblYonetici] can't be null. ");

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
                                    var entity = new Yonetici();
                                    entity.YoneticiId = reader.GetInt32(0);
                                    entity.SirketId = reader.GetInt32(1);
                                    entity.Sifre = reader.GetString(2);
                                    entity.Kisi.Ad = reader.GetString(3);
                                    entity.Kisi.Soyad = reader.GetString(4);
                                    entity.Kisi.TcKimlik = reader.GetString(5);
                                    entity.Kisi.Telefon = reader.GetString(6);
                                    entity.Kisi.Email = reader.GetString(7);
                                    entity.Kisi.DogumTarihi = reader.GetDateTime(8);
                                    entity.Kisi.Adres = reader.GetString(9);
                                    yonetici = entity;
                                    break;
                                }
                            }
                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting Error for entity [tblYonetici] reported the Database ErrorCode: " + _errorCode);
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
                                "dbCommand" + " The db SelectById command for entity [tblYonetici] can't be null. ");

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
                                "Deleting Error for entity [tblYonetici] reported the Database ErrorCode: " +
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
