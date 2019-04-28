using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Concretes;
using DataAccesLayer.Concretes;

namespace Business.Concretes
{
    public class MusterilerBusiness:IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
        public MusterilerBusiness()
        {

        }
        public bool MusteriEkle(Musteriler entity)
        {
            try
            {
                bool basarilimi;
                using (var repo = new MusterilerRepository())
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

        public bool MusteriGuncelle(Musteriler entity)
        {
            try
            {
                bool basarilimi;
                using (var repo = new MusterilerRepository())
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

        public bool MusteriIdSil(int ID)
        {
            try
            {
                bool basarilimi;
                using (var repo = new MusterilerRepository())
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

        public Musteriler MusteriIdSec(int MusteriId)
        {
            try
            {
                Musteriler responseEntitiy;
                using (var repo = new MusterilerRepository())
                {
                    responseEntitiy = repo.IdSec(MusteriId);
                    if (responseEntitiy == null)
                        throw new NullReferenceException("Böyle Bir Müşteri Yok!");
                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("BusinessLogic:CustomerBusiness::SelectCustomerById::Error occured.", ex);
            }
        }

        public List<Musteriler> MusteriHepsiniSec()
        {
            var responseEntities = new List<Musteriler>();

            try
            {
                using (var repo = new MusterilerRepository())
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