using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TPA.Common.Core.MobileModel
{
    public class FileModel
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public int ClaimId { get; set; }

        public string Contents { get; set; }

        public string ContentType { get; set; }

        public int CreatedBy { get; set; }
    }
}
