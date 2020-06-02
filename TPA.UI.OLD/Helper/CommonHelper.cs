using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPA.Helper
{
    public static class CommonHelper
    {
        public static IEnumerable<SelectListItem> GetVisitTypes()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem()
            {
                Text = "Regular",
                Value = "Regular"
            });
            return items;
        }
    }
}