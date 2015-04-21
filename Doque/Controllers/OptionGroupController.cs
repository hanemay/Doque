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
    public class OptionGroupController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /OptionGroup/

        public ActionResult Index()
        {
            return View(db.OptionGroups.ToList());
        }

        //
        // GET: /OptionGroup/Details/5

        public ActionResult Details(int id = 0)
        {
            OptionGroups optiongroups = db.OptionGroups.Find(id);
            if (optiongroups == null)
            {
                return HttpNotFound();
            }
            return View(optiongroups);
        }

        //
        // GET: /OptionGroup/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /OptionGroup/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OptionGroups optiongroups)
        {
            if (ModelState.IsValid)
            {
                db.OptionGroups.Add(optiongroups);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(optiongroups);
        }

        //
        // GET: /OptionGroup/Edit/5

        public ActionResult Edit(int id = 0)
        {
            OptionGroups optiongroups = db.OptionGroups.Find(id);
            if (optiongroups == null)
            {
                return HttpNotFound();
            }
            return View(optiongroups);
        }

        //
        // POST: /OptionGroup/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OptionGroups optiongroups)
        {
            if (ModelState.IsValid)
            {
                db.Entry(optiongroups).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(optiongroups);
        }

        //
        // GET: /OptionGroup/Delete/5

        public ActionResult Delete(int id = 0)
        {
            OptionGroups optiongroups = db.OptionGroups.Find(id);
            if (optiongroups == null)
            {
                return HttpNotFound();
            }
            return View(optiongroups);
        }

        //
        // POST: /OptionGroup/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OptionGroups optiongroups = db.OptionGroups.Find(id);
            db.OptionGroups.Remove(optiongroups);
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