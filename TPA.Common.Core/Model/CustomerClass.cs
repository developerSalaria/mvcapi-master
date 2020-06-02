using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class CustomerClass : BaseModel
    {
        public int CustomerClassId { get; set; }
        public string CustomerClassNameA { get; set; }
        public string CustomerClassNameE { get; set; }
        public string CustomerClassName {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return CustomerClassNameE;
                }
                else
                {
                    return CustomerClassNameA;
                }
            }
        }
    }
}
