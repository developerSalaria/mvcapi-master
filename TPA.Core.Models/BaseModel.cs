using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlTaif.Core.Models
{
    public class BaseModel
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
        public string ErrorCode { get; set; }
        public int LanguageId { get; set; }
        public string Language { get; set; }
        public Credentials Credentials { get; set; }
    }

    public class Credentials
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
