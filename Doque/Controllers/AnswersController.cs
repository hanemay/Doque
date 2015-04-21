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
    public class AnswersController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Answers/

        public ActionResult Index()
        {
            var answers = db.Answers.Include(a => a.QuestionOptions).Include(a => a.UnitOfMeasures);
            return View(answers.ToList());
        }

        //
        // GET: /Answers/Details/5

        public ActionResult Details(int id = 0)
        {
            Answers answers = db.Answers.Find(id);
            if (answers == null)
            {
                return HttpNotFound();
            }
            return View(answers);
        }

        //
        // GET: /Answers/Create

        public ActionResult Create()
        {
            ViewBag.QuestionOptionID = new SelectList(db.QuestionOptions, "ID", "ID");
            ViewBag.UnitOfMeasureID = new SelectList(db.UnitOfMeasures, "ID", "Name");
            return View();
        }

        //
        // POST: /Answers/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Answers answers)
        {
            if (ModelState.IsValid)
            {
                
                db.Answers.Add(answers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionOptionID = new SelectList(db.QuestionOptions, "ID", "ID", answers.QuestionOptionID);
            ViewBag.UnitOfMeasureID = new SelectList(db.UnitOfMeasures, "ID", "Name", answers.UnitOfMeasureID);
            return View(answers);
        }

        //
        // GET: /Answers/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Answers answers = db.Answers.Find(id);
            if (answers == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionOptionID = new SelectList(db.QuestionOptions, "ID", "ID", answers.QuestionOptionID);
            ViewBag.UnitOfMeasureID = new SelectList(db.UnitOfMeasures, "ID", "Name", answers.UnitOfMeasureID);
            return View(answers);
        }

        //
        // POST: /Answers/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Answers answers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionOptionID = new SelectList(db.QuestionOptions, "ID", "ID", answers.QuestionOptionID);
            ViewBag.UnitOfMeasureID = new SelectList(db.UnitOfMeasures, "ID", "Name", answers.UnitOfMeasureID);
            return View(answers);
        }

        //
        // GET: /Answers/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Answers answers = db.Answers.Find(id);
            if (answers == null)
            {
                return HttpNotFound();
            }
            return View(answers);
        }

        //
        // POST: /Answers/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Answers answers = db.Answers.Find(id);
            db.Answers.Remove(answers);
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