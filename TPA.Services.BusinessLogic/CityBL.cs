using TPA.Common.Core.Model;
using TPA.Data.DAL.Repositories;
using System.Collections.Generic;

namespace TPA.Services.BusinessLogic
{
    public class CityBL
    {
        private CityRepository _cityRepo;
        public CityBL()
        {
            _cityRepo = new CityRepository();
        }

        public List<City> Get()
        {
            return _cityRepo.Get();
        }

        public City GetById(int cityId)
        {
            return _cityRepo.GetById(cityId);
        }

        public int DeleteById(int cityId)
        {
            return _cityRepo.DeleteById(cityId);
        }

        public int Insert(City obj)
        {
            return _cityRepo.Insert(obj);
        }

        public int Update(City obj)
        {
            return _cityRepo.Update(obj);
        }
    }
}
