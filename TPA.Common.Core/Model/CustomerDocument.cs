using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class CustomerDocument : BaseModel
    {
        public int DocumentId { get; set; }
        public int CustomerId { get; set; }

        [Display(Name = nameof(Resources.Common.DocumentType), ResourceType = typeof(Resources.Common))]
        public int DocumentTypeId { get; set; }

        [Display(Name = nameof(Resources.Common.DocumentNumber), ResourceType = typeof(Resources.Common))]
        public string DocumentNumber { get; set; }

        [Display(Name = nameof(Resources.Common.DocumentIssueBy), ResourceType = typeof(Resources.Common))]
        public string DocumentIssueBy { get; set; }

        [Display(Name = nameof(Resources.Common.DocumentIssueDate), ResourceType = typeof(Resources.Common))]
        [DataType(DataType.Date)]
        public DateTime? DocumentIssueDate { get; set; }

        [Display(Name = nameof(Resources.Common.DocumentExpiryDate), ResourceType = typeof(Resources.Common))]
        [DataType(DataType.Date)]
        public DateTime? DocumentExpiryDate { get; set; }

        public string DocumentTypeA { get; set; }
        public string DocumentTypeE { get; set; }
        public string DocumentTypeName
        {
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
    }
}
