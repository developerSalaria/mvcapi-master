using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class CustomerInsured : BaseModel
    {
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
        public string Location { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
