using TPA.Presentation.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPA.Presentation.Areas.CustomerAccountManagement.Controllers
{
    public class CustomerAccountController : BaseController
    {
        // GET: CustomerAccountManagement/CustomerAccount
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerAccountManagement/CustomerAccount/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerAccountManagement/CustomerAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerAccountManagement/CustomerAccount/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerAccountManagement/CustomerAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerAccountManagement/CustomerAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerAccountManagement/CustomerAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerAccountManagement/CustomerAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
