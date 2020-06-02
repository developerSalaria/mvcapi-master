using System.Web;
using System.Web.Optimization;

namespace TPA.Presentation
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/login").Include(
                      "~/Content/assests/js/pages/login/login-general.min.js",
                      "~/Content/assets/js/scripts.bundle.js",
                      "~/Content/assets/plugins/global/plugins.bundle.js",
                      "~/Scripts/commonProject.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/common").Include(
                      "~/Content/common-styles.css"));

            bundles.Add(new StyleBundle("~/Content/login").Include(
                      "~/Content/assets/css/pages/login/login-3.css",
                      "~/Content/custom-login.css",
                      "~/Content/style.bundle.css", "~/Content/assets/plugins/global/plugins.bundle.css"));
        }
    }
}
