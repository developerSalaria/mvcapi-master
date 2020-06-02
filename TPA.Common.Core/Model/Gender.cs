using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class Gender : BaseModel
    {
        public int GenderId { get; set; }
        public string GenderNameA { get; set; }
        public string GenderNameE { get; set; }
        public string GenderName
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return GenderNameE;
                }
                else
                {
                    return GenderNameA;
                }
            }
        }
    }
}
