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
    public class UnitOfMeasureController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /UnitOfMeasure/

        public ActionResult Index()
        {
            return View(db.UnitOfMeasures.ToList());
        }

        //
        // GET: /UnitOfMeasure/Details/5

        public ActionResult Details(int id = 0)
        {
            UnitOfMeasures unitofmeasures = db.UnitOfMeasures.Find(id);
            if (unitofmeasures == null)
            {
                return HttpNotFound();
            }
            return View(unitofmeasures);
        }

        //
        // GET: /UnitOfMeasure/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UnitOfMeasure/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UnitOfMeasures unitofmeasures)
        {
            if (ModelState.IsValid)
            {
                db.UnitOfMeasures.Add(unitofmeasures);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unitofmeasures);
        }

        //
        // GET: /UnitOfMeasure/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UnitOfMeasures unitofmeasures = db.UnitOfMeasures.Find(id);
            if (unitofmeasures == null)
            {
                return HttpNotFound();
            }
            return View(unitofmeasures);
        }

        //
        // POST: /UnitOfMeasure/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UnitOfMeasures unitofmeasures)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unitofmeasures).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unitofmeasures);
        }

        //
        // GET: /UnitOfMeasure/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UnitOfMeasures unitofmeasures = db.UnitOfMeasures.Find(id);
            if (unitofmeasures == null)
            {
                return HttpNotFound();
            }
            return View(unitofmeasures);
        }

        //
        // POST: /UnitOfMeasure/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UnitOfMeasures unitofmeasures = db.UnitOfMeasures.Find(id);
            db.UnitOfMeasures.Remove(unitofmeasures);
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