using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Concretes;
using DataAccesLayer.Concretes;

namespace Business.Concretes
{
    public class AracBusiness:IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
        public AracBusiness()
        {

        }
        public bool AracEkle(Arac arac, Sirket sirket)
        {
            try
            {
                bool basarilimiArac,basarilimiSirket;
                using (var repo = new AracRepository())
                {
                    basarilimiArac = repo.Ekle(arac);

                    using (var repo2 = new SirketRepository())
                    {

                        basarilimiSirket = repo2.Guncelle(sirket);
                    }
                }
                return (basarilimiArac && basarilimiSirket);
            }
            catch (Exception ex)
            {
                throw new Exception("BusinessLogic:CustomerBusiness::InsertCustomer::Error occured.", ex);
            }
        }

        public bool AracGuncelle(Arac entity)
        {
            try
            {
                bool basarilimi;
                using (var repo = new AracRepository())
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

        public bool AracIdSil(int ID,Sirket sirket)
        {
            try
            {
                bool basarilimi,basarilimi2;
                using (var repo = new AracRepository())
                {
                    basarilimi = repo.IdSil(ID);

                    using (var repo2 = new SirketRepository())
                    {
                        basarilimi2 = repo2.Guncelle(sirket);
                    }
                }
                return (basarilimi&&basarilimi2);
            }
            catch (Exception ex)
            {
                throw new Exception("BusinessLogic:CustomerBusiness::DeleteCustomer::Error occured.", ex);
            }
        }

        public Arac AracIdSec(int AracId)
        {
            try
            {
                Arac responseEntitiy;
                using (var repo = new AracRepository())
                {
                    responseEntitiy = repo.IdSec(AracId);
                    if (responseEntitiy == null)
                        throw new NullReferenceException("Böyle Bir Araç Yok!");
                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("BusinessLogic:CustomerBusiness::SelectCustomerById::Error occured.", ex);
            }
        }

        public List<Arac> AracHepsiniSec()
        {
            var responseEntities = new List<Arac>();

            try
            {
                using (var repo = new AracRepository())
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
