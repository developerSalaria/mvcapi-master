using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class DocumentType : BaseModel
    {
        public int DocumentTypeId { get; set; }
        public string DocumentTypeA { get; set; }
        public string DocumentTypeE { get; set; }
        public string DocumentTypeName {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return DocumentTypeE;
                }
                else
                {
                    return DocumentTypeA;
                }
            }
        }
        public string Code { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
