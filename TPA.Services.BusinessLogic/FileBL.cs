using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.Model;
using TPA.Data.DAL.Repositories;

namespace TPA.Services.BusinessLogic
{
    public class FileBL
    {
        private FileRepository _repo;
        public FileBL()
        {
            _repo = new FileRepository();
        }

        public int SaveFile(FileData fileData)
        {
            return _repo.SaveFile(fileData);
        }

        public FileData GetFile(int fileId)
        {
            return _repo.GetFile(fileId);
        }
    }
}
