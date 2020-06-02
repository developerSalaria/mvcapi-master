using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class Employee : BaseModel
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
    }
}
