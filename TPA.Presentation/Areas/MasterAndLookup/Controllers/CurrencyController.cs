using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPA.Presentation.Areas.MasterAndLookup.Controllers
{
    public class CurrencyController : Controller
    {
        // GET: MasterAndLookup/Currency
        public ActionResult Index()
        {
            return View();
        }

        // GET: MasterAndLookup/Currency/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterAndLookup/Currency/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterAndLookup/Currency/Create
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

        // GET: MasterAndLookup/Currency/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MasterAndLookup/Currency/Edit/5
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

        // GET: MasterAndLookup/Currency/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterAndLookup/Currency/Delete/5
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
