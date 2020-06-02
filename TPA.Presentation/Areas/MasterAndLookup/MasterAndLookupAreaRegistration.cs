using System.Web.Mvc;

namespace TPA.Presentation.Areas.MasterAndLookup
{
    public class MasterAndLookupAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MasterAndLookup";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MasterAndLookup_default",
                "MasterAndLookup/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}