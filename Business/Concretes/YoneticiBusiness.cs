﻿using System;
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
        public bool YoneticiEkle(Yonetici Yonetici, Kullanici kullanici)
        {
            try
            {
                bool YoneticiBasarilimi, kullaniciBasarilimi;
                using (var kullaniciRepo = new KullaniciRepository())
                {
                    kullaniciBasarilimi = kullaniciRepo.Ekle(kullanici);
                    using (var YoneticiRepo = new YoneticiRepository())
                    {
                        YoneticiBasarilimi = YoneticiRepo.Ekle(Yonetici);
                    }
                }

                return (kullaniciBasarilimi && YoneticiBasarilimi);
            }
            catch (Exception ex)
            {
                throw new Exception("YoneticiBusiness:KullaniciRepo||YoneticiRepo:Ekleme Hatası", ex);
            }
        }

        public bool YoneticiGuncelle(Yonetici Yonetici, Kullanici kullanici)
        {
            try
            {
                bool YoneticiBasarilimi, kullaniciBasarilimi;
                using (var kullaniciRepo = new KullaniciRepository())
                {
                    kullaniciBasarilimi = kullaniciRepo.Guncelle(kullanici);
                    using (var YoneticiRepo = new YoneticiRepository())
                    {
                        YoneticiBasarilimi = YoneticiRepo.Guncelle(Yonetici);
                    }
                }

                return (kullaniciBasarilimi && YoneticiBasarilimi);
            }
            catch (Exception ex)
            {
                throw new Exception("YoneticiBusiness:KullaniciRepo||YoneticiRepo:Güncelleme Hatası", ex);
            }
        }

        //TODO
        public bool YoneticiIdSil(int ID)
        {
            try
            {
                bool YoneticiBasarilimi;
                using (var YoneticiRepo = new YoneticiRepository())
                {
                    YoneticiBasarilimi = YoneticiRepo.IdSil(ID);
                }

                return (YoneticiBasarilimi);
            }
            catch (Exception ex)
            {
                throw new Exception("YoneticiBusiness:YoneticiRepo:IDSil Hatası", ex);
            }
        }

        public Yonetici YoneticiIdSec(int YoneticiId)
        {
            try
            {
                Yonetici responseEntitiy;
                using (var repo = new YoneticiRepository())
                {
                    responseEntitiy = repo.IdSec(YoneticiId);
                    if (responseEntitiy == null)
                        throw new NullReferenceException("Böyle Bir Müşteri Yok!");
                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("YoneticiBusiness:YoneticiRepo:IDSec Hatası", ex);
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
                throw new Exception("YoneticiBusiness:YoneticiRepo:YoneticiHepsiniSec Hatası", ex);
            }
        }
    }
}