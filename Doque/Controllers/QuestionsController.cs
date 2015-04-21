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
    public class QuestionsController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Questions/

        public ActionResult Index()
        {
            var questions = db.Questions.Include(q => q.InputTypes).Include(q => q.OptionGroups).Include(q => q.SurveySection);
            return View(questions.ToList());
        }

        //
        // GET: /Questions/Details/5

        public ActionResult Details(int id = 0)
        {
            Questions questions = db.Questions.Find(id);
            if (questions == null)
            {
                return HttpNotFound();
            }
            return View(questions);
        }

        //
        // GET: /Questions/Create

        public ActionResult Create()
        {
            ViewBag.InputTypeID = new SelectList(db.InputTypes, "ID", "Name");
            ViewBag.OptionGroupID = new SelectList(db.OptionGroups, "ID", "Name");
            ViewBag.SurveySectionID = new SelectList(db.SurveySection, "ID", "Name");
            return View();
        }

        //
        // POST: /Questions/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Questions questions)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Add(questions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InputTypeID = new SelectList(db.InputTypes, "ID", "Name", questions.InputTypeID);
            ViewBag.OptionGroupID = new SelectList(db.OptionGroups, "ID", "Name", questions.OptionGroupID);
            ViewBag.SurveySectionID = new SelectList(db.SurveySection, "ID", "Name", questions.SurveySectionID);
            return View(questions);
        }

        //
        // GET: /Questions/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Questions questions = db.Questions.Find(id);
            if (questions == null)
            {
                return HttpNotFound();
            }
            ViewBag.InputTypeID = new SelectList(db.InputTypes, "ID", "Name", questions.InputTypeID);
            ViewBag.OptionGroupID = new SelectList(db.OptionGroups, "ID", "Name", questions.OptionGroupID);
            ViewBag.SurveySectionID = new SelectList(db.SurveySection, "ID", "Name", questions.SurveySectionID);
            return View(questions);
        }

        //
        // POST: /Questions/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Questions questions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InputTypeID = new SelectList(db.InputTypes, "ID", "Name", questions.InputTypeID);
            ViewBag.OptionGroupID = new SelectList(db.OptionGroups, "ID", "Name", questions.OptionGroupID);
            ViewBag.SurveySectionID = new SelectList(db.SurveySection, "ID", "Name", questions.SurveySectionID);
            return View(questions);
        }

        //
        // GET: /Questions/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Questions questions = db.Questions.Find(id);
            if (questions == null)
            {
                return HttpNotFound();
            }
            return View(questions);
        }

        //
        // POST: /Questions/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Questions questions = db.Questions.Find(id);
            db.Questions.Remove(questions);
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