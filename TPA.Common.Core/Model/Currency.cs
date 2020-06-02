using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class Currency : BaseModel
    {
        public int CurrencyId { get; set; }
        public string CurrencyNameA { get; set; }
        public string CurrencyNameE { get; set; }
        public string CurrencyName
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return CurrencyNameE;
                }
                else
                {
                    return CurrencyNameA;
                }
            }
        }
        public string CurrencyCode { get; set; }
        public bool FavouriteCurrency { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
