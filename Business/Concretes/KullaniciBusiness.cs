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
        public Kullanici Giris(string kullaniciAdi,string parola)
        {
            Kullanici kullanici = null;
            try
            {
                using (var repo = new KullaniciRepository())
                {
                    kullanici = repo.Giris(kullaniciAdi,parola);
                }
                return kullanici;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Kullanici KullaniciAnahtarSec(string Anahtar)
        {

            try
            {
                Kullanici responseEntitiy = null;
                using (var repo = new KullaniciRepository())
                {
                    responseEntitiy = repo.KeySec(Anahtar);

                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("KullaniciBusiness:KullaniciRepository:Key Seçme Hatası", ex);
            }
        }
        public Kullanici KullaniciEkle(Kullanici entity)
        {
            try
            {
                using (var repo = new KullaniciRepository())
                {
                    if (repo.Ekle(entity))
                        return entity;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("KullaniciBusiness:KullaniciRepository:Ekleme Hatası", ex);
            }
        }

        public Kullanici KullaniciGuncelle(Kullanici entity)
        {
            try
            {
                using (var repo = new KullaniciRepository())
                {
                    if (repo.Guncelle(entity))
                        return entity;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("KullaniciBusiness:KullaniciRepository:Güncelleme Hatası", ex);
            }
        }

        public Kullanici KullaniciIdSil(int KullaniciId)
        {
            try
            {
                using (var repo = new KullaniciRepository())
                {
                    if (repo.IdSil(KullaniciId))
                        return repo.IdSec(KullaniciId);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("KullaniciBusiness:KullaniciRepository:Silme Hatası", ex);
            }
        }

        public Kullanici KullaniciIdSec(int KullaniciId)
        {
            try
            {
                Kullanici responseEntitiy = null;
                using (var repo = new KullaniciRepository())
                {
                    responseEntitiy = repo.IdSec(KullaniciId);

                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("KullaniciBusiness:KullaniciRepository:Seçme Hatası", ex);
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
                throw new Exception("KullaniciBusiness:KullaniciRepository:Hepsini Seçme Hatası", ex);
            }
        }
    }
}