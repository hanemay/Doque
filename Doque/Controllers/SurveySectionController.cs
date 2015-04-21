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
    public class SurveySectionController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /SurveySection/

        public ActionResult Index()
        {
            var surveysection = db.SurveySection.Include(s => s.SurveyHeader);
            return View(surveysection.ToList());
        }

        //
        // GET: /SurveySection/Details/5

        public ActionResult Details(int id = 0)
        {
            SurveySection surveysection = db.SurveySection.Find(id);
            if (surveysection == null)
            {
                return HttpNotFound();
            }
            return View(surveysection);
        }

        //
        // GET: /SurveySection/Create

        public ActionResult Create()
        {
            ViewBag.SurveyHeaderID = new SelectList(db.SurveyHeader, "ID", "SurveyName");
            return View();
        }

        //
        // POST: /SurveySection/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SurveySection surveysection)
        {
            if (ModelState.IsValid)
            {
                db.SurveySection.Add(surveysection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SurveyHeaderID = new SelectList(db.SurveyHeader, "ID", "SurveyName", surveysection.SurveyHeaderID);
            return View(surveysection);
        }

        //
        // GET: /SurveySection/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SurveySection surveysection = db.SurveySection.Find(id);
            if (surveysection == null)
            {
                return HttpNotFound();
            }
            ViewBag.SurveyHeaderID = new SelectList(db.SurveyHeader, "ID", "SurveyName", surveysection.SurveyHeaderID);
            return View(surveysection);
        }

        //
        // POST: /SurveySection/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SurveySection surveysection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(surveysection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SurveyHeaderID = new SelectList(db.SurveyHeader, "ID", "SurveyName", surveysection.SurveyHeaderID);
            return View(surveysection);
        }

        //
        // GET: /SurveySection/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SurveySection surveysection = db.SurveySection.Find(id);
            if (surveysection == null)
            {
                return HttpNotFound();
            }
            return View(surveysection);
        }

        //
        // POST: /SurveySection/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SurveySection surveysection = db.SurveySection.Find(id);
            db.SurveySection.Remove(surveysection);
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