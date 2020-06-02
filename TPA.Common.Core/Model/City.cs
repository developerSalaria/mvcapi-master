using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class City : BaseModel
    {
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string CityNameA { get; set; }
        public string CityNameE { get; set; }
        public string CityName
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return CityNameE;
                }
                else
                {
                    return CityNameA;
                }
            }
        }
        public string CountryName { get; set; }
        public string CityCode { get; set; }
        public bool FavouriteCity { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
