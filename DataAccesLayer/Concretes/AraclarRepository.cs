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
    public class AraclarRepository : IRepository<Araclar>
    {
        private string _connectionString;
        private string _dbProviderName;
        private DbProviderFactory _dbProviderFactory;
        private int _rowsAffected, _errorCode;
        private bool _bDisposed;

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
            throw new NotImplementedException();
        }

        public IList<Araclar> HepsiniSec()
        {
            throw new NotImplementedException();
        }

        public Araclar IdSec(int id)
        {
            throw new NotImplementedException();
        }

        public bool IdSil(int id)
        {
            throw new NotImplementedException();
        }
    }
}
