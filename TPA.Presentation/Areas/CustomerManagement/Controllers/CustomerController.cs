using TPA.Common.Core.Model;
using TPA.Presentation.ApiServices;
using TPA.Presentation.Controllers;
using TPA.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace TPA.Presentation.Areas.CustomerManagement.Controllers
{
    public class CustomerController : BaseController
    {
        private CustomerService _custService;
        public CustomerController()
        {
            _custService = new CustomerService();
        }

        public ActionResult CustomerDetail(int id=0)
        {
            var Model = new Customer();
            if (id != 0)
            {
                Model = _custService.GetById(id);
            }
            return View(Model);
        }

        public ActionResult AllCustomers()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AllCustomersSearch(JqueryDatatableParam param)
        {
            var customer = new Customer();
            customer.SearchModel = param;
            var Model = _custService.CustomerDataTable(customer);
            var result = new
            {
                iTotalRecords = Model.TotalRecords,
                iTotalDisplayRecords = Model.TotalDisplayRecords,
                aaData = Model.CustomerList
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create(int id=0)
        {
            var Model = new Customer();
            Model.CustomerDocument = new CustomerDocument();
            if (id != 0)
            {
                Model = _custService.GetById(Convert.ToInt32(id));
            }
            return View(Model);
        }

        [HttpPost]
        public ActionResult Create(Customer obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = new ValidationMessage();
                    if (obj.CustomerId == 0)
                    {
                        result = _custService.Insert(obj);
                    }
                    else
                    {
                        result = _custService.Update(obj);
                    }

                    if (result.IsSuccess)
                    {
                        UrlHelper u = new UrlHelper(this.ControllerContext.RequestContext);
                        ajaxResponse.URL = u.Action("AllCustomers", "Customer", new { area = "CustomerManagement" });
                        return Json(ajaxResponse, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        ajaxResponse.ErrorMessage = result.Message;
                        return Json(ajaxResponse, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                   ajaxResponse.ErrorMessage =  string.Join(",",
                    ModelState.Values.Where(E => E.Errors.Count > 0)
                    .SelectMany(E => E.Errors)
                    .Select(E => E.ErrorMessage)
                    .ToArray());

                    return Json(ajaxResponse, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return View();
            }
        }
        
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                var response =_custService.Delete(id);
                if (response.IsSuccess)
                {
                    ajaxResponse.Message = Common.Core.Resources.Common.RecordDeleted;
                    return Json(ajaxResponse, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    ajaxResponse.ErrorMessage = Common.Core.Resources.Common.ErrorOccurred;
                    return Json(ajaxResponse, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                ajaxResponse.ErrorMessage = Common.Core.Resources.Common.ErrorOccurred;
                return Json(ajaxResponse, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CreateCustomerAccount(int id = 0)
        {
            var Model = new Customer();
            Model.CustomerDocument = new CustomerDocument();
            if (id != 0)
            {
                Model = _custService.GetById(Convert.ToInt32(id));
            }
            return View(Model);
        }

        [HttpPost]
        public ActionResult CreateCustomerAccount(Customer obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = new ValidationMessage();
                    if (obj.CustomerId == 0)
                    {
                        result = _custService.Insert(obj);
                    }
                    else
                    {
                        result = _custService.Update(obj);
                    }

                    if (result.IsSuccess)
                    {
                        UrlHelper u = new UrlHelper(this.ControllerContext.RequestContext);
                        ajaxResponse.URL = u.Action("AllCustomers", "Customer", new { area = "CustomerManagement" });
                        return Json(ajaxResponse, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        ajaxResponse.ErrorMessage = result.Message;
                        return Json(ajaxResponse, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    ajaxResponse.ErrorMessage = string.Join(",",
                     ModelState.Values.Where(E => E.Errors.Count > 0)
                     .SelectMany(E => E.Errors)
                     .Select(E => E.ErrorMessage)
                     .ToArray());

                    return Json(ajaxResponse, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
