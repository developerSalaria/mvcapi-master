using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class CustomerType : BaseModel
    {
        public int CustomerTypeId { get; set; }
        public string CustomerTypeNameA { get; set; }
        public string CustomerTypeNameE { get; set; }
        public string CustomerTypeName
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return CustomerTypeNameE;
                }
                else
                {
                    return CustomerTypeNameA;
                }
            }
        }
        public string CustomerTypeCode { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
