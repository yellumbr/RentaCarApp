using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Concretes;
using DataAccesLayer.Concretes;


namespace Business.Concretes
{
    public class SirketBusiness:IDisposable
    {
        private YoneticiBusiness _yoneticiBusiness = new YoneticiBusiness();
        private bool _bDisposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected virtual void Dispose(bool bDisposing)
        {
            // Check the Dispose method called before.
            if (!_bDisposed)
            {
                if (bDisposing)
                {
                    // Clean the resources used.
                    _yoneticiBusiness = null;
                }

                _bDisposed = true;
            }
        }
        public SirketBusiness()
        {
            _yoneticiBusiness = new YoneticiBusiness();
        }

        public bool SirketEkle(Sirket entity)
        {
            try
            {
                bool basarilimi;
                using (var repo = new SirketRepository())
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

        public bool SirketGuncelle(Sirket entity)
        {
            try
            {
                bool basarilimi;
                using (var repo = new SirketRepository())
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

        public bool SirketIdSil(int ID)
        {
            try
            {
                bool basarilimi;
                using (var repo = new SirketRepository())
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

        public Sirket SirketIdSec(int sirketId)
        {
            try
            {
                Sirket responseEntitiy;
                using (var repo = new SirketRepository())
                {
                    responseEntitiy = repo.IdSec(sirketId);
                    if (responseEntitiy == null)
                        throw new NullReferenceException("Böyle Bir Şirket Yok!");
                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("BusinessLogic:CustomerBusiness::SelectCustomerById::Error occured.", ex);
            }
        }

        public List<Sirket> SirketHepsiniSec()
        {
            var responseEntities = new List<Sirket>();

            try
            {
                using (var repo = new SirketRepository())
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
