using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doque.Models;

namespace Doque.Controllers
{
    public class InputTypesController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /InputTypes/

        public ActionResult Index()
        {
            return View(db.InputTypes.ToList());
        }

        //
        // GET: /InputTypes/Details/5

        public ActionResult Details(int id = 0)
        {
            InputTypes inputtypes = db.InputTypes.Find(id);
            if (inputtypes == null)
            {
                return HttpNotFound();
            }
            return View(inputtypes);
        }

        //
        // GET: /InputTypes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /InputTypes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InputTypes inputtypes)
        {
            if (ModelState.IsValid)
            {
                db.InputTypes.Add(inputtypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inputtypes);
        }

        //
        // GET: /InputTypes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            InputTypes inputtypes = db.InputTypes.Find(id);
            if (inputtypes == null)
            {
                return HttpNotFound();
            }
            return View(inputtypes);
        }

        //
        // POST: /InputTypes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InputTypes inputtypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inputtypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inputtypes);
        }

        //
        // GET: /InputTypes/Delete/5

        public ActionResult Delete(int id = 0)
        {
            InputTypes inputtypes = db.InputTypes.Find(id);
            if (inputtypes == null)
            {
                return HttpNotFound();
            }
            return View(inputtypes);
        }

        //
        // POST: /InputTypes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InputTypes inputtypes = db.InputTypes.Find(id);
            db.InputTypes.Remove(inputtypes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}