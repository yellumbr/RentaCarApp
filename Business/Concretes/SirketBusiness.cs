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

        public Sirket SirketEkle(Sirket entity)
        {
            try
            {
                using (var repo = new SirketRepository())
                {
                    if (repo.Ekle(entity))
                        return entity;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("SirketBusiness:SirketRepository:Ekleme Hatası", ex);
            }
        }

        public Sirket SirketGuncelle(Sirket entity)
        {
            try
            {
                using (var repo = new SirketRepository())
                {
                    if (repo.Guncelle(entity))
                        return entity;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("SirketBusiness:SirketRepository:Güncelleme Hatası", ex);
            }
        }

        public Sirket SirketIdSil(int sirketId)
        {
            try
            {
                using (var repo = new SirketRepository())
                {
                    if (repo.IdSil(sirketId))
                        return repo.IdSec(sirketId);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("SirketBusiness:SirketRepository:Silme Hatası", ex);
            }
        }

        public Sirket SirketIdSec(int sirketId)
        {
            try
            {
                Sirket responseEntitiy = null ;
                using (var repo = new SirketRepository())
                {
                    responseEntitiy = repo.IdSec(sirketId);
                    
                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("SirketBusiness:SirketRepository:Seçme Hatası", ex);
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
                throw new Exception("SirketBusiness:SirketRepository:Hepsini Seçme Hatası", ex);
            }
        }
    }
}
