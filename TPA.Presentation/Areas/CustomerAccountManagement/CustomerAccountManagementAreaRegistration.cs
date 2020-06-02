using System.Web.Mvc;

namespace TPA.Presentation.Areas.CustomerAccountManagement
{
    public class CustomerAccountManagementAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CustomerAccountManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CustomerAccountManagement_default",
                "CustomerAccountManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}