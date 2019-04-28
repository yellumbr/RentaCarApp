using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Concretes;
using DataAccesLayer.Concretes;

namespace Business.Concretes
{
    public class YoneticiBusiness:IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
        public YoneticiBusiness()
        {

        }
        public bool YoneticiEkle(Yonetici entity)
        {
            try
            {
                bool basarilimi;
                using (var repo = new YoneticiRepository())
                {
                    basarilimi = repo.Ekle(entity);
                }
                return basarilimi;
            }
            catch (Exception ex)
            {
                throw new Exception("BusinessLogic:CustomerBusiness::InsertCustomer::Error occured.", ex);
            }
        }

        public bool YoneticiGuncelle(Yonetici entity)
        {
            try
            {
                bool basarilimi;
                using (var repo = new YoneticiRepository())
                {
                    basarilimi = repo.Guncelle(entity);
                }
                return basarilimi;
            }
            catch (Exception ex)
            {
                throw new Exception("BusinessLogic:CustomerBusiness::UpdateCustomer::Error occured.", ex);
            }
        }

        public bool YoneticiIdSil(int ID)
        {
            try
            {
                bool basarilimi;
                using (var repo = new YoneticiRepository())
                {
                    basarilimi = repo.IdSil(ID);
                }
                return basarilimi;
            }
            catch (Exception ex)
            {
                throw new Exception("BusinessLogic:CustomerBusiness::DeleteCustomer::Error occured.", ex);
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
                        throw new NullReferenceException("Böyle Bir Yönetici Yok!");
                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("BusinessLogic:CustomerBusiness::SelectCustomerById::Error occured.", ex);
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
                throw new Exception("BusinessLogic:CustomerBusiness::SelectAllCustomers::Error occured.", ex);
            }
        }
    }
}
