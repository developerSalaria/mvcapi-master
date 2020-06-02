using TPA.Common.Core.Model;
using TPA.Data.DAL.Repositories;
using System.Collections.Generic;

namespace TPA.Services.BusinessLogic
{
    public class GenderBL
    {
        private GenderRepository _genderRepo;
        public GenderBL()
        {
            _genderRepo = new GenderRepository();
        }

        public List<Gender> Get()
        {
            return _genderRepo.Get();
        }

        public Gender GetById(int genderId)
        {
            return _genderRepo.GetById(genderId);
        }

        public int DeleteById(int genderId)
        {
            return _genderRepo.DeleteById(genderId);
        }

        public int Insert(Gender obj)
        {
            return _genderRepo.Insert(obj);
        }

        public int Update(Gender obj)
        {
            return _genderRepo.Update(obj);
        }
    }
}
