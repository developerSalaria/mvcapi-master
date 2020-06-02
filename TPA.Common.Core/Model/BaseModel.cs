using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class BaseModel
    {
        public BaseModel()
        {
            ValidationMessage = new ValidationMessage();
            SearchModel = new JqueryDatatableParam();
        }
        //public int Id { get; set; }
        public int SelectLanguageId { get; set; }
        public string SelectLanguage { get; set; }
        public int SelectCountry { get; set; }
        public ValidationMessage ValidationMessage { get; set; }
        public JqueryDatatableParam SearchModel { get; set; }
        public int TotalRecords { get; set; }
        public int TotalDisplayRecords { get; set; }

        [Display(Name = nameof(Resources.Common.CreatedBy), ResourceType = typeof(Resources.Common))]
        public string CreatedBy { get; set; }

        [Display(Name = nameof(Resources.Common.ModifiedBy), ResourceType = typeof(Resources.Common))]
        public string UpdatedBy { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }

    public class ValidationMessage
    {
        public bool IsSuccess
        {
            get
            {
                if (Message == null || string.IsNullOrEmpty(Message.Trim()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public string Message { get; set; }
        public HttpStatusCode ErrorCode { get; set; }
    }
}
