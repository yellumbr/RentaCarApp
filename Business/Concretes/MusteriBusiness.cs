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
        public bool MusteriEkle(Musteri musteri, Kullanici kullanici)
        {
            try
            {
                bool musteriBasarilimi, kullaniciBasarilimi;
                using (var kullaniciRepo = new KullaniciRepository())
                {
                    kullaniciBasarilimi = kullaniciRepo.Ekle(kullanici);
                    using (var musteriRepo = new MusteriRepository())
                    {
                        musteriBasarilimi = musteriRepo.Ekle(musteri);
                    }
                }
                
                return (kullaniciBasarilimi && musteriBasarilimi);
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriBusiness:KullaniciRepo||MusteriRepo:Ekleme Hatası", ex);
            }
        }

        public bool MusteriGuncelle(Musteri musteri,Kullanici kullanici)
        {
            try
            {
                bool musteriBasarilimi, kullaniciBasarilimi;
                using (var kullaniciRepo = new KullaniciRepository())
                {
                    kullaniciBasarilimi = kullaniciRepo.Guncelle(kullanici);
                    using (var musteriRepo = new MusteriRepository())
                    {
                        musteriBasarilimi = musteriRepo.Guncelle(musteri);
                    }
                }

                return (kullaniciBasarilimi && musteriBasarilimi);
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriBusiness:KullaniciRepo||MusteriRepo:Güncelleme Hatası", ex);
            }
        }

        //TODO
        public bool MusteriIdSil(int ID)
        {
            try
            {
                bool musteriBasarilimi;
                using (var musteriRepo = new MusteriRepository())
                {  
                        musteriBasarilimi = musteriRepo.IdSil(ID);          
                }

                return (musteriBasarilimi);
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriBusiness:MusteriRepo:IDSil Hatası", ex);
            }
        }

        public Musteri MusteriIdSec(int MusteriId)
        {
            try
            {
                Musteri responseEntitiy;
                using (var repo = new MusteriRepository())
                {
                    responseEntitiy = repo.IdSec(MusteriId);
                    if (responseEntitiy == null)
                        throw new NullReferenceException("Böyle Bir Müşteri Yok!");
                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriBusiness:MusteriRepo:IDSec Hatası", ex);
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
                throw new Exception("MusteriBusiness:MusteriRepo:MusteriHepsiniSec Hatası", ex);
            }
        }
    }
}