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
    public class SurveyHeaderController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /SurveyHeader/

        public ActionResult Index()
        {
            var surveyheader = db.SurveyHeader.Include(s => s.Organization);
            return View(surveyheader.ToList());
        }

        //
        // GET: /SurveyHeader/Details/5

        public ActionResult Details(int id = 0)
        {
            SurveyHeader surveyheader = db.SurveyHeader.Find(id);
            if (surveyheader == null)
            {
                return HttpNotFound();
            }
            return View(surveyheader);
        }

        //
        // GET: /SurveyHeader/Create

        public ActionResult Create()
        {
            ViewBag.OrganizationID = new SelectList(db.Organization, "ID", "Name");
            return View();
        }

        //
        // POST: /SurveyHeader/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SurveyHeader surveyheader)
        {
            if (ModelState.IsValid)
            {
                db.SurveyHeader.Add(surveyheader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationID = new SelectList(db.Organization, "ID", "Name", surveyheader.OrganizationID);
            return View(surveyheader);
        }

        //
        // GET: /SurveyHeader/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SurveyHeader surveyheader = db.SurveyHeader.Find(id);
            if (surveyheader == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationID = new SelectList(db.Organization, "ID", "Name", surveyheader.OrganizationID);
            return View(surveyheader);
        }

        //
        // POST: /SurveyHeader/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SurveyHeader surveyheader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(surveyheader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationID = new SelectList(db.Organization, "ID", "Name", surveyheader.OrganizationID);
            return View(surveyheader);
        }

        //
        // GET: /SurveyHeader/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SurveyHeader surveyheader = db.SurveyHeader.Find(id);
            if (surveyheader == null)
            {
                return HttpNotFound();
            }
            return View(surveyheader);
        }

        //
        // POST: /SurveyHeader/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SurveyHeader surveyheader = db.SurveyHeader.Find(id);
            db.SurveyHeader.Remove(surveyheader);
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