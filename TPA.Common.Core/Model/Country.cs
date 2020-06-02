using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class Country : BaseModel
    {
        public int Id { get; set; }
        public string AName { get; set; }
        public string EName { get; set; }
        public string PHCode { get; set; }
        public int StatusId { get; set; }
    }
}
