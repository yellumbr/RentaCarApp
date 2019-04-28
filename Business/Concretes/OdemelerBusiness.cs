using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Concretes;
using DataAccesLayer.Concretes;

namespace Business.Concretes
{
    public class OdemelerBusiness:IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
        public OdemelerBusiness()
        {

        }
        public bool OdemeEkle(Odemeler entity)
        {
            try
            {
                bool basarilimi;
                using (var repo = new OdemelerRepository())
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

        public bool OdemeGuncelle(Odemeler entity)
        {
            try
            {
                bool basarilimi;
                using (var repo = new OdemelerRepository())
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

        public bool OdemeIdSil(int ID)
        {
            try
            {
                bool basarilimi;
                using (var repo = new OdemelerRepository())
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

        public Odemeler OdemeIdSec(int OdemeId)
        {
            try
            {
                Odemeler responseEntitiy;
                using (var repo = new OdemelerRepository())
                {
                    responseEntitiy = repo.IdSec(OdemeId);
                    if (responseEntitiy == null)
                        throw new NullReferenceException("Böyle Bir Ödeme Yok!");
                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("BusinessLogic:CustomerBusiness::SelectCustomerById::Error occured.", ex);
            }
        }

        public List<Odemeler> OdemeHepsiniSec()
        {
            var responseEntities = new List<Odemeler>();

            try
            {
                using (var repo = new OdemelerRepository())
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

