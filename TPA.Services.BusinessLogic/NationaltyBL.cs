using TPA.Common.Core.Model;
using TPA.Data.DAL.Repositories;
using System.Collections.Generic;

namespace TPA.Services.BusinessLogic
{
    public class NationaltyBL
    {
        private NationaltyRepository _nationaltyRepo;
        public NationaltyBL()
        {
            _nationaltyRepo = new NationaltyRepository();
        }

        public List<Nationalty> Get()
        {
            return _nationaltyRepo.Get();
        }

        public Nationalty GetById(int nationaltyId)
        {
            return _nationaltyRepo.GetById(nationaltyId);
        }

        public int DeleteById(int nationaltyId)
        {
            return _nationaltyRepo.DeleteById(nationaltyId);
        }

        public int Insert(Nationalty obj)
        {
            return _nationaltyRepo.Insert(obj);
        }

        public int Update(Nationalty obj)
        {
            return _nationaltyRepo.Update(obj);
        }
    }
}
