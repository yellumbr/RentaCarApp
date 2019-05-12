using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Concretes;
using DataAccesLayer.Concretes;

namespace Business.Concretes
{
    public class YoneticiBusiness : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
        public YoneticiBusiness()
        {

        }
        public Yonetici YoneticiEkle(Yonetici entity)
        {
            try
            {
                using (var repo = new YoneticiRepository())
                {
                    if (repo.Ekle(entity))
                        return entity;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("YoneticiBusiness:YoneticiRepository:Ekleme Hatası", ex);
            }
        }

        public Yonetici YoneticiGuncelle(Yonetici entity)
        {
            try
            {
                using (var repo = new YoneticiRepository())
                {
                    if (repo.Guncelle(entity))
                        return entity;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("YoneticiBusiness:YoneticiRepository:Güncelleme Hatası", ex);
            }
        }

        public Yonetici YoneticiIdSil(int YoneticiId)
        {
            try
            {
                using (var repo = new YoneticiRepository())
                {
                    if (repo.IdSil(YoneticiId))
                        return repo.IdSec(YoneticiId);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("YoneticiBusiness:YoneticiRepository:Silme Hatası", ex);
            }
        }

        public Yonetici YoneticiIdSec(int YoneticiId)
        {
            try
            {
                Yonetici responseEntitiy = null;
                using (var repo = new YoneticiRepository())
                {
                    responseEntitiy = repo.IdSec(YoneticiId);

                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("YoneticiBusiness:YoneticiRepository:Seçme Hatası", ex);
            }
        }

        public List<Yonetici> YoneticiHepsiniSec()
        {
            var responseEntities = new List<Yonetici>();

            try
            {
                using (var repo = new YoneticiRepository())
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
                throw new Exception("YoneticiBusiness:YoneticiRepository:Hepsini Seçme Hatası", ex);
            }
        }
    }
}