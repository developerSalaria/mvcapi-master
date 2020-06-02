using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPA.Common.Core.Model;
using TPA.Presentation.ApiServices;

namespace TPA.Presentation.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// return view of Policies
        /// </summary>
        /// <returns></returns>
        public ActionResult Policies()
        {
            return View();
        }

        /// <summary>
        /// Return view of Customers Insured
        /// </summary>
        /// <returns></returns>
        public ActionResult CustomersInsured()
        {
            return View();
        }

        /// <summary>
        /// use to get all Policies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPolicies()
        {
            var policies = CustomersService.Instance.GetPolicies();

            return Json(new
            {
                draw = "1",
                data = policies,
                recordsFiltered = policies.Count,
                recordsTotal = policies.Count,
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Edit Policy
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditPolicy(string policyNo)
        {
            Policy policy = new Policy();
            try
            {
                if (policyNo != "")
                {
                    //Get provider By
                    ViewBag.headerTitle = "Edit Policy";
                    policy = ApiServices.CustomersService.Instance.GetPolicyByPolicyNo(policyNo);
                }
                else
                {
                    ViewBag.headerTitle = "Add Policy";
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return View(policy);
        }

        /// <summary>
        /// Add Edit Provider
        /// </summary>
        /// <param name="policy"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditPolicy(Policy policy)
        {
            try
            {
                //Edit case 
                if (policy.Id > 0)
                {
                    int policyId = CustomersService.Instance.UpdatePolicy(policy);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return View(policy);
        }




        /// <summary>
        /// use to get all Customers Insured
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetCustomersInsured()
        {
            var customersInsured = CustomersService.Instance.GetCustomersInsured();

            return Json(new
            {
                draw = "1",
                data = customersInsured,
                recordsFiltered = customersInsured.Count,
                recordsTotal = customersInsured.Count,
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get Sub Policies List By PolicyNo
        /// </summary>
        /// <param name="policyNo"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetSubPoliciesByPolicyNo(string policyNo)
        {
            List<SubPolicy> subPolicy = CustomersService.Instance.GetSubPoliciesByPolicyNo(policyNo);
            return Json(new
            {
                draw = "1",
                data = subPolicy,
                recordsFiltered = subPolicy.Count,
                recordsTotal = subPolicy.Count,
            }, JsonRequestBehavior.AllowGet);
        }
    }
}