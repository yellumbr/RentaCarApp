using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Concretes;
using DataAccesLayer.Concretes;

namespace Business.Concretes
{
    public class AracBusiness:IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
        public AracBusiness()
        {

        }
        public Arac AracEkle(Arac entity)
        {
            try
            {
                using (var repo = new AracRepository())
                {
                    if (repo.Ekle(entity))
                        return entity;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("AracBusiness:AracRepository:Ekleme Hatası", ex);
            }
        }

        public Arac AracGuncelle(Arac entity)
        {
            try
            {
                using (var repo = new AracRepository())
                {
                    if (repo.Guncelle(entity))
                        return entity;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("AracBusiness:AracRepository:Güncelleme Hatası", ex);
            }
        }

        public Arac AracKirala(Arac entity)
        {
            try
            {
                using (var repo = new AracRepository())
                {
                    //var entity = repo.IdSec(arac.AracID);
                    if (repo.Kirala(entity))
                        return entity;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("AracBusiness:AracRepository:Kiralama Hatası", ex);
            }
        }

        public Arac AracIdSil(int AracId)
        {
            try
            {
                using (var repo = new AracRepository())
                {
                    if (repo.IdSil(AracId))
                        return repo.IdSec(AracId);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("AracBusiness:AracRepository:Silme Hatası", ex);
            }
        }

        public Arac AracIdSec(int AracId)
        {
            try
            {
                Arac responseEntitiy = null;
                using (var repo = new AracRepository())
                {
                    responseEntitiy = repo.IdSec(AracId);

                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("AracBusiness:AracRepository:Seçme Hatası", ex);
            }
        }

        public Arac AracPlakaSec(string plaka)
        {
            try
            {
                Arac responseEntitiy = null;
                using (var repo = new AracRepository())
                {
                    responseEntitiy = repo.PlakaSec(plaka);

                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("AracBusiness:AracRepository:Seçme Hatası", ex);
            }
        }
        public List<Arac> AracHepsiniSec()
        {
            var responseEntities = new List<Arac>();

            try
            {
                using (var repo = new AracRepository())
                {
                    foreach (var entity in repo.HepsiniSec())
                    {
                        responseEntities.Add(entity);
                    }
                }
                if (responseEntities == null)
                    return responseEntities;
                return responseEntities;
            }
            catch (Exception ex)
            {
                throw new Exception("AracBusiness:AracRepository:Hepsini Seçme Hatası", ex);
            }
        }


    }
}
