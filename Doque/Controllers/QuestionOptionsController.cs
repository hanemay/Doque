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
    public class QuestionOptionsController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /QuestionOptions/

        public ActionResult Index()
        {
            var questionoptions = db.QuestionOptions.Include(q => q.OptionChoices).Include(q => q.Questions);
            return View(questionoptions.ToList());
        }

        //
        // GET: /QuestionOptions/Details/5

        public ActionResult Details(int id = 0)
        {
            QuestionOptions questionoptions = db.QuestionOptions.Find(id);
            if (questionoptions == null)
            {
                return HttpNotFound();
            }
            return View(questionoptions);
        }

        //
        // GET: /QuestionOptions/Create

        public ActionResult Create()
        {
            ViewBag.OptionChoiceID = new SelectList(db.OptionChoices, "ID", "Name");
            ViewBag.QuestionID = new SelectList(db.Questions, "ID", "Name");
            return View();
        }

        //
        // POST: /QuestionOptions/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestionOptions questionoptions)
        {
            if (ModelState.IsValid)
            {
                db.QuestionOptions.Add(questionoptions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OptionChoiceID = new SelectList(db.OptionChoices, "ID", "Name", questionoptions.OptionChoiceID);
            ViewBag.QuestionID = new SelectList(db.Questions, "ID", "Name", questionoptions.QuestionID);
            return View(questionoptions);
        }

        //
        // GET: /QuestionOptions/Edit/5

        public ActionResult Edit(int id = 0)
        {
            QuestionOptions questionoptions = db.QuestionOptions.Find(id);
            if (questionoptions == null)
            {
                return HttpNotFound();
            }
            ViewBag.OptionChoiceID = new SelectList(db.OptionChoices, "ID", "Name", questionoptions.OptionChoiceID);
            ViewBag.QuestionID = new SelectList(db.Questions, "ID", "Name", questionoptions.QuestionID);
            return View(questionoptions);
        }

        //
        // POST: /QuestionOptions/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuestionOptions questionoptions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionoptions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OptionChoiceID = new SelectList(db.OptionChoices, "ID", "Name", questionoptions.OptionChoiceID);
            ViewBag.QuestionID = new SelectList(db.Questions, "ID", "Name", questionoptions.QuestionID);
            return View(questionoptions);
        }

        //
        // GET: /QuestionOptions/Delete/5

        public ActionResult Delete(int id = 0)
        {
            QuestionOptions questionoptions = db.QuestionOptions.Find(id);
            if (questionoptions == null)
            {
                return HttpNotFound();
            }
            return View(questionoptions);
        }

        //
        // POST: /QuestionOptions/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionOptions questionoptions = db.QuestionOptions.Find(id);
            db.QuestionOptions.Remove(questionoptions);
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