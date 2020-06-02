using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class Symptoms : BaseModel
    {
        public int ID { get; set; }
        public string EName { get; set; }
        public string AName { get; set; }
        public int StatusID { get; set; }
    }
}
