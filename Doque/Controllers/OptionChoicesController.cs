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
    public class OptionChoicesController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /OptionChoices/

        public ActionResult Index()
        {
            var optionchoices = db.OptionChoices.Include(o => o.OptionGroups);
            return View(optionchoices.ToList());
        }

        //
        // GET: /OptionChoices/Details/5

        public ActionResult Details(int id = 0)
        {
            OptionChoices optionchoices = db.OptionChoices.Find(id);
            if (optionchoices == null)
            {
                return HttpNotFound();
            }
            return View(optionchoices);
        }

        //
        // GET: /OptionChoices/Create

        public ActionResult Create()
        {
            ViewBag.OptionGroupID = new SelectList(db.OptionGroups, "ID", "Name");
            return View();
        }

        //
        // POST: /OptionChoices/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OptionChoices optionchoices)
        {
            if (ModelState.IsValid)
            {
                db.OptionChoices.Add(optionchoices);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OptionGroupID = new SelectList(db.OptionGroups, "ID", "Name", optionchoices.OptionGroupID);
            return View(optionchoices);
        }

        //
        // GET: /OptionChoices/Edit/5

        public ActionResult Edit(int id = 0)
        {
            OptionChoices optionchoices = db.OptionChoices.Find(id);
            if (optionchoices == null)
            {
                return HttpNotFound();
            }
            ViewBag.OptionGroupID = new SelectList(db.OptionGroups, "ID", "Name", optionchoices.OptionGroupID);
            return View(optionchoices);
        }

        //
        // POST: /OptionChoices/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OptionChoices optionchoices)
        {
            if (ModelState.IsValid)
            {
                db.Entry(optionchoices).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OptionGroupID = new SelectList(db.OptionGroups, "ID", "Name", optionchoices.OptionGroupID);
            return View(optionchoices);
        }

        //
        // GET: /OptionChoices/Delete/5

        public ActionResult Delete(int id = 0)
        {
            OptionChoices optionchoices = db.OptionChoices.Find(id);
            if (optionchoices == null)
            {
                return HttpNotFound();
            }
            return View(optionchoices);
        }

        //
        // POST: /OptionChoices/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OptionChoices optionchoices = db.OptionChoices.Find(id);
            db.OptionChoices.Remove(optionchoices);
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