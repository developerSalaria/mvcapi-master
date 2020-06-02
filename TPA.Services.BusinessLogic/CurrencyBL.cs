using TPA.Common.Core.Model;
using TPA.Data.DAL.Repositories;
using System.Collections.Generic;

namespace TPA.Services.BusinessLogic
{
    public class CurrencyBL
    {
        private CurrencyRepository _currencyRepo;
        public CurrencyBL()
        {
            _currencyRepo = new CurrencyRepository();
        }

        public List<Currency> Get()
        {
            return _currencyRepo.Get();
        }

        public Currency GetById(int currencyId)
        {
            return _currencyRepo.GetById(currencyId);
        }

        public int DeleteById(int currencyId)
        {
            return _currencyRepo.DeleteById(currencyId);
        }

        public int Insert(Currency obj)
        {
            return _currencyRepo.Insert(obj);
        }

        public int Update(Currency obj)
        {
            return _currencyRepo.Update(obj);
        }
    }
}
