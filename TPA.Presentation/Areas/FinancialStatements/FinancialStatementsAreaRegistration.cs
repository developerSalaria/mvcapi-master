using System.Web.Mvc;

namespace TPA.Presentation.Areas.FinancialStatements
{
    public class FinancialStatementsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "FinancialStatements";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "FinancialStatements_default",
                "FinancialStatements/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}