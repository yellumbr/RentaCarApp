using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Concretes;
using DataAccesLayer.Concretes;

namespace Business.Concretes
{
    public class OdemeBusiness:IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
        public OdemeBusiness()
        {

        }
        public Odeme OdemeEkle(Odeme entity)
        {
            try
            {
                using (var repo = new OdemeRepository())
                {
                    if (repo.Ekle(entity))
                        return entity;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("OdemeBusiness:OdemeRepository:Ekleme Hatası", ex);
            }
        }

        public Odeme OdemeGuncelle(Odeme entity)
        {
            try
            {
                using (var repo = new OdemeRepository())
                {
                    if (repo.Guncelle(entity))
                        return entity;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("OdemeBusiness:OdemeRepository:Güncelleme Hatası", ex);
            }
        }

        public Odeme OdemeIdSil(int OdemeId)
        {
            try
            {
                using (var repo = new OdemeRepository())
                {
                    if (repo.IdSil(OdemeId))
                        return repo.IdSec(OdemeId);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("OdemeBusiness:OdemeRepository:Silme Hatası", ex);
            }
        }

        public Odeme OdemeIdSec(int OdemeId)
        {
            try
            {
                Odeme responseEntitiy = null;
                using (var repo = new OdemeRepository())
                {
                    responseEntitiy = repo.IdSec(OdemeId);

                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("OdemeBusiness:OdemeRepository:Seçme Hatası", ex);
            }
        }

        public List<Odeme> OdemeHepsiniSec()
        {
            var responseEntities = new List<Odeme>();

            try
            {
                using (var repo = new OdemeRepository())
                {
                    foreach (var entity in repo.HepsiniSec())
                    {
                        responseEntities.Add(entity);
                    }
                }
                return responseEntities;
            }
            catch (Exception ex)
            {
                throw new Exception("OdemeBusiness:OdemeRepository:Hepsini Seçme Hatası", ex);
            }
        }
    }
}

