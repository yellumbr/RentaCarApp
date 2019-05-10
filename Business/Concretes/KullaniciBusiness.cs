using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Concretes;
using DataAccesLayer.Concretes;

namespace Business.Concretes
{
    public class KullaniciBusiness : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
        public KullaniciBusiness()
        {

        }
        public bool KullaniciEkle(Kullanici Kullanici)
        {
            try
            {
                bool KullaniciBasarilimi;
               
                    using (var KullaniciRepo = new KullaniciRepository())
                    {
                        KullaniciBasarilimi = KullaniciRepo.Ekle(Kullanici);
                    }
                

                return (KullaniciBasarilimi);
            }
            catch (Exception ex)
            {
                throw new Exception("KullaniciBusiness:KullaniciRepo:Ekleme Hatası", ex);
            }
        }

        public bool KullaniciGuncelle(Kullanici Kullanici)
        {
            try
            {
                bool KullaniciBasarilimi;
                using (var KullaniciRepo = new KullaniciRepository())
                {
                    
                
                        KullaniciBasarilimi = KullaniciRepo.Guncelle(Kullanici);
                    
                }

                return ( KullaniciBasarilimi);
            }
            catch (Exception ex)
            {
                throw new Exception("KullaniciBusiness:KullaniciRepo||KullaniciRepo:Güncelleme Hatası", ex);
            }
        }

        //TODO
        public bool KullaniciIdSil(int ID)
        {
            try
            {
                bool KullaniciBasarilimi;
                using (var KullaniciRepo = new KullaniciRepository())
                {
                    KullaniciBasarilimi = KullaniciRepo.IdSil(ID);
                }

                return (KullaniciBasarilimi);
            }
            catch (Exception ex)
            {
                throw new Exception("KullaniciBusiness:KullaniciRepo:IDSil Hatası", ex);
            }
        }

        public Kullanici KullaniciIdSec(int KullaniciId)
        {
            try
            {
                Kullanici responseEntitiy;
                using (var repo = new KullaniciRepository())
                {
                    responseEntitiy = repo.IdSec(KullaniciId);
                    if (responseEntitiy == null)
                        throw new NullReferenceException("Böyle Bir Müşteri Yok!");
                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("KullaniciBusiness:KullaniciRepo:IDSec Hatası", ex);
            }
        }

        public List<Kullanici> KullaniciHepsiniSec()
        {
            var responseEntities = new List<Kullanici>();

            try
            {
                using (var repo = new KullaniciRepository())
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
                throw new Exception("KullaniciBusiness:KullaniciRepo:KullaniciHepsiniSec Hatası", ex);
            }
        }
    }
}