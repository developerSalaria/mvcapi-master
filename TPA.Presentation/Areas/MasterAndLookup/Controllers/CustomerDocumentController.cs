using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPA.Presentation.Areas.MasterAndLookup.Controllers
{
    public class CustomerDocumentController : Controller
    {
        // GET: MasterAndLookup/CustomerDocument
        public ActionResult Index()
        {
            return View();
        }

        // GET: MasterAndLookup/CustomerDocument/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterAndLookup/CustomerDocument/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterAndLookup/CustomerDocument/Create
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

        // GET: MasterAndLookup/CustomerDocument/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MasterAndLookup/CustomerDocument/Edit/5
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

        // GET: MasterAndLookup/CustomerDocument/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterAndLookup/CustomerDocument/Delete/5
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
