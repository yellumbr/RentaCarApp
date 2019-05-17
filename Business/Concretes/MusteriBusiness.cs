using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Concretes;
using DataAccesLayer.Concretes;

namespace Business.Concretes
{
    public class MusteriBusiness:IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
        public MusteriBusiness()
        {

        }
        public Musteri MusteriEkle(Musteri entity)
        {
            try
            {
                using (var repo = new MusteriRepository())
                {
                    if (repo.Ekle(entity))
                        return entity;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriBusiness:MusteriRepository:Ekleme Hatası", ex);
            }
        }

        public Musteri MusteriGuncelle(Musteri entity)
        {
            try
            {
                using (var repo = new MusteriRepository())
                {
                    if (repo.Guncelle(entity))
                        return entity;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriBusiness:MusteriRepository:Güncelleme Hatası", ex);
            }
        }

        public Musteri MusteriIdSil(int MusteriId)
        {
            try
            {
                using (var repo = new MusteriRepository())
                {
                    if (repo.IdSil(MusteriId))
                        return repo.IdSec(MusteriId);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriBusiness:MusteriRepository:Silme Hatası", ex);
            }
        }

        public Musteri MusteriIdSec(int MusteriId)
        {
            try
            {
                Musteri responseEntitiy = null;
                using (var repo = new MusteriRepository())
                {
                    responseEntitiy = repo.IdSec(MusteriId);

                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriBusiness:MusteriRepository:Seçme Hatası", ex);
            }
        }

        public List<Musteri> MusteriHepsiniSec()
        {
            var responseEntities = new List<Musteri>();

            try
            {
                using (var repo = new MusteriRepository())
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
                throw new Exception("MusteriBusiness:MusteriRepository:Hepsini Seçme Hatası", ex);
            }
        }
    }
}