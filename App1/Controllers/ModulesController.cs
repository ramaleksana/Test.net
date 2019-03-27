using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace App1.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ModulesController : Controller
    {
        // GET: Modules
        public ActionResult Index()
        {
            return View();
        }

        // GET: Modules/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Modules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Modules/Create
        [HttpPost]
        public ActionResult Create(DataModel.Module module)
        {
            try
            {
                // TODO: Add insert logic here
                //var module = new DataModel.Module { Id = "satu", Name = "UserManagement" };
                if (ModelState.IsValid)
                {
                    BusinessProcess.ModuleManager mm = new BusinessProcess.ModuleManager();
                    mm.Add(module);
                }
                else
                {

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Modules/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Modules/Edit/5
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

        // GET: Modules/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Modules/Delete/5
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
