using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Data.DAL
{
    public static class ListExtentions
    {
        public static DataTable ToDataTable(this List<object> d)
        {
            dynamic json = JsonConvert.SerializeObject(d);
            return JsonConvert.DeserializeObject<DataTable>(json);
        }

        public static DataTable ToDataTableSelect(this List<object> d)
        {
            dynamic json = JsonConvert.SerializeObject(d);
            if (json != null)
            {
                string text = json;
                text = text.Replace("\"\":", "\"status\":");
                json = text;
            }
            return JsonConvert.DeserializeObject<DataTable>(json);
        }
    }
}
