using TPA.Common.Core.Model;
using TPA.Data.DAL.Repositories;
using System.Collections.Generic;

namespace TPA.Services.BusinessLogic
{
    public class CountryBL
    {
        private CountryRepository _countryRepo;
        public CountryBL()
        {
            _countryRepo = new CountryRepository();
        }

        public List<Country> Get()
        {
            return _countryRepo.Get();
        }

        public Country GetById(int countryId)
        {
            return _countryRepo.GetById(countryId);
        }

        public int DeleteById(int countryId)
        {
            return _countryRepo.DeleteById(countryId);
        }

        public int Insert(Country obj)
        {
            return _countryRepo.Insert(obj);
        }

        public int Update(Country obj)
        {
            return _countryRepo.Update(obj);
        }
    }
}
