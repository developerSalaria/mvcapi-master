using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class Nationalty : BaseModel
    {
        public int NationalityId { get; set; }
        public string NationalityNameA { get; set; }
        public string NationalityNameE { get; set; }
        public string NationalityName
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return NationalityNameE;
                }
                else
                {
                    return NationalityNameA;
                }
            }
        }
        public string NationalityCode { get; set; }
        public bool FavouriteNationality { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
