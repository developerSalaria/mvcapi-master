using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPA.Common.Core.Model;
using TPA.Presentation.ApiServices;

namespace TPA.Presentation.Controllers
{
    public class ProviderController : Controller
    {
        // GET: Provider
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get All Providers List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetProviders()
        {
            var providers = ProviderService.Instance.Get();

            return Json(new
            {
                draw = "1",
                data = providers,
                recordsFiltered = providers.Count,
                recordsTotal = providers.Count,
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get Provider For Edit
        /// </summary>
        /// <param name="providerId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditProvider(int providerId = 0)
        {
            Provider provider = new Provider();
            try
            {
                if (providerId > 0)
                {
                    //Get provider By
                    ViewBag.headerTitle = "Edit Provider";
                    provider = ApiServices.ProviderService.Instance.GetById(providerId);
                }
                else
                {
                    ViewBag.headerTitle = "Add Provider";
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return View(provider);
        }

        /// <summary>
        /// Add Edit Provider POST data
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditProvider(Provider provider)
        {
            try
            {
                int providerId = ApiServices.ProviderService.Instance.AddOrUpdateProvider(provider);
            }
            catch (Exception ex)
            {
                return null;
            }
            return View(provider);
        }

        /// <summary>
        /// Get Provider Services List
        /// </summary>
        /// <param name="providerId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetProviderServices(int providerId = 0)
        {
            List<ServiceType> services = ServiceTypeService.Instance.GetProviderServices(providerId);

            return Json(new
            {
                draw = "1",
                data = services,
                recordsFiltered = services.Count,
                recordsTotal = services.Count,
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
