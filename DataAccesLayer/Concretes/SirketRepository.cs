using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Abstractions;
using Models.Concretes;
using System.Data.Common;

namespace DataAccesLayer.Concretes
{
    public class SirketRepository : IRepository<Sirket>
    {
        private string _connectionString;
        private string _dbProviderName;
        private DbProviderFactory _dbProviderFactory;
        private int _rowsAffected, _errorCode;
        private bool _bDisposed;

        public SirketRepository()
        {
            _connectionString = DBHelper.GetConnectionString();
            _dbProviderName = DBHelper.GetConnectionProvider();
            _dbProviderFactory = DbProviderFactories.GetFactory(_dbProviderName);
        }

        public bool Ekle(Sirket entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("INSERT [dbo].[tblSirket] ");
                query.Append("( [SirketId], [SirketAdi], [Sehir], [Adres], [AracSayisi], [SirketPuani] ) ");
                query.Append("VALUES ");
                query.Append(
                    "( @SirketId, @SirketAdi, @Sehir, @Adres, @AracSayisi, @SirketPuani ) ");
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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [tblSirket] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@SirketId",  entity.SirketId);
                        DBHelper.AddParameter(dbCommand, "@SirketAdi", entity.SirketAdi);
                        DBHelper.AddParameter(dbCommand, "@Sehir", entity.Sehir);
                        DBHelper.AddParameter(dbCommand, "@Adres", entity.Adres);
                        DBHelper.AddParameter(dbCommand, "@AracSayisi", entity.AracSayisi);
                        DBHelper.AddParameter(dbCommand, "@SirketPuani", entity.SirketPuani);

                        //Output Params
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception("Inserting Error for entity [tblSirket] reported the Database ErrorCode: " + _errorCode);
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
    

        public bool Guncelle(Sirket entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("UPDATE [dbo].[tblSirket] ");
                query.Append("SET [SirketID] = @SirketId, [SirketAdi] = @SirketAdi, [Sehir] =  @Sehir, [Adres] = @Adres, [AracSayisi] = @AracSayisi, [SirketPuani] = @SirketPuani ");
                query.Append("WHERE ");
                query.Append(" [SirketID] = @SirketId ");
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
                        DBHelper.AddParameter(dbCommand, "@SirketId", entity.SirketId);
                        DBHelper.AddParameter(dbCommand, "@SirketAdi", entity.SirketAdi);
                        DBHelper.AddParameter(dbCommand, "@Sehir", entity.Sehir);
                        DBHelper.AddParameter(dbCommand, "@Adres", entity.Adres);
                        DBHelper.AddParameter(dbCommand, "@AracSayisi", entity.AracSayisi);
                        DBHelper.AddParameter(dbCommand, "@SirketPuani", entity.SirketPuani);
                        //Output Params
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception("Updating Error for entity [tblSirket] reported the Database ErrorCode: " + _errorCode);
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

        public IList<Sirket> HepsiniSec()
        {
            _errorCode = 0;
            _rowsAffected = 0;

            IList<Sirket> sirketler = new List<Sirket>();

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append(
                    "[SirketId], [SirketAdi], [Sehir], [Adres], [AracSayisi], [SirketPuani] ");
                query.Append("FROM [dbo].[tblSirket] ");
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
                                "dbCommand" + " The db SelectById command for entity [tblSirket] can't be null. ");

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
                                    var entity = new Sirket();
                                    entity.SirketId = reader.GetInt32(0);
                                    entity.SirketAdi = reader.GetString(1);
                                    entity.Sehir = reader.GetString(2);
                                    entity.Adres = reader.GetString(3);
                                    entity.AracSayisi = reader.GetInt32(4);
                                    entity.SirketPuani = reader.GetFloat(5);
                                    sirketler.Add(entity);
                                }
                            }

                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting All Error for entity [tblSirket] reported the Database ErrorCode: " + _errorCode);

                        }
                    }
                }
                // Return list
                return sirketler;
            }
            catch (Exception ex)
            {
                throw new Exception("TransactionsRepository::SelectAll:Error occured.", ex);
            }
        }

        public Sirket IdSec(int id)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            Sirket sirket= null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append(
                    "[SirketId], [SirketAdi], [Sehir], [Adres], [AracSayisi], [SirketPuani] ");
                query.Append("FROM [dbo].[tblSirket] ");
                query.Append("WHERE ");
                query.Append("[SirketID] = @id ");
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
                                "dbCommand" + " The db SelectById command for entity [tblSirket] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        DBHelper.AddParameter(dbCommand, "@id", id);

                        //Output Parameters
                        DBHelper.AddParameter(dbCommand, "@intErrorCode",null);

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
                                    var entity = new Sirket();
                                    entity.SirketId = reader.GetInt32(0);
                                    entity.SirketAdi = reader.GetString(1);
                                    entity.Sehir = reader.GetString(2);
                                    entity.Adres = reader.GetString(3);
                                    entity.AracSayisi = reader.GetInt32(4);
                                    entity.SirketPuani = reader.GetFloat(5);
                                    sirket = entity;
                                    break;
                                }
                            }
                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting Error for entity [tblSirket] reported the Database ErrorCode: " + _errorCode);
                        }
                    }
                }

                return sirket;
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
                query.Append("FROM [dbo].[tblSirket] ");
                query.Append("WHERE ");
                query.Append("[tblSirket] = @id ");
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
                                "dbCommand" + " The db SelectById command for entity [tblSirket] can't be null. ");

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
                                "Deleting Error for entity [tblSirket] reported the Database ErrorCode: " +
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
