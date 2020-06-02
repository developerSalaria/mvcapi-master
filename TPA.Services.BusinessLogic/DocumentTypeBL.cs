using TPA.Common.Core.Model;
using TPA.Data.DAL.Repositories;
using System.Collections.Generic;

namespace TPA.Services.BusinessLogic
{
    public class DocumentTypeBL
    {
        private DocumentTypeRepository _DocumentTypeRepo;
        public DocumentTypeBL()
        {
            _DocumentTypeRepo = new DocumentTypeRepository();
        }

        public List<DocumentType> Get()
        {
            return _DocumentTypeRepo.Get();
        }

        public DocumentType GetById(int DocumentTypeId)
        {
            return _DocumentTypeRepo.GetById(DocumentTypeId);
        }

        public int DeleteById(int DocumentTypeId)
        {
            return _DocumentTypeRepo.DeleteById(DocumentTypeId);
        }

        public int Insert(DocumentType obj)
        {
            return _DocumentTypeRepo.Insert(obj);
        }

        public int Update(DocumentType obj)
        {
            return _DocumentTypeRepo.Update(obj);
        }
    }
}
