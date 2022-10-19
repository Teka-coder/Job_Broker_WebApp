using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Job_Broker_WebApp.Models;

namespace Job_Broker_WebApp.Controllers
{
    public class VacanciesController : Controller
    {
        private JobBrokerEntities db = new JobBrokerEntities();

        // GET: Vacancies
        public ActionResult Index()
        {
            var vacancy = db.Vacancy.Include(v => v.Company).Include(v => v.Job);
            return View(vacancy.ToList());
        }

        public ActionResult VacancyList()
        {
            var vacancy = db.Vacancy.Include(v => v.Company).Include(v => v.Job);
            return View(vacancy.ToList());
        }

        // GET: Vacancies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacancy vacancy = db.Vacancy.Find(id);
            if (vacancy == null)
            {
                return HttpNotFound();
            }
            return View(vacancy);
        }

        // GET: Vacancies/Create
        public ActionResult Create()
        {
            ViewBag.COMP_ID = new SelectList(db.Company, "ID", "COMP_NAME");
            ViewBag.JOB_ID = new SelectList(db.Job, "ID", "JOB_NAME");
            return View();
        }

        // POST: Vacancies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,COMP_ID,JOB_ID,MIN_QUALF,POSTDATE,INTERVDATE,INTERVTIME,DURATION,SALARY,REQ_NUM,REQ_SEX,DESCRPTION,STATUS")] Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                db.Vacancy.Add(vacancy);
                db.SaveChanges();
                return RedirectToAction("VacancyList");
            }

            ViewBag.COMP_ID = new SelectList(db.Company, "ID", "COMP_NAME", vacancy.COMP_ID);
            ViewBag.JOB_ID = new SelectList(db.Job, "ID", "JOB_NAME", vacancy.JOB_ID);
            return View(vacancy);
        }

        // GET: Vacancies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacancy vacancy = db.Vacancy.Find(id);
            if (vacancy == null)
            {
                return HttpNotFound();
            }
            ViewBag.COMP_ID = new SelectList(db.Company, "ID", "COMP_NAME", vacancy.COMP_ID);
            ViewBag.JOB_ID = new SelectList(db.Job, "ID", "JOB_NAME", vacancy.JOB_ID);
            return View(vacancy);
        }

        // POST: Vacancies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,COMP_ID,JOB_ID,MIN_QUALF,POSTDATE,INTERVDATE,INTERVTIME,DURATION,SALARY,REQ_NUM,REQ_SEX,DESCRPTION,STATUS")] Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacancy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COMP_ID = new SelectList(db.Company, "ID", "COMP_NAME", vacancy.COMP_ID);
            ViewBag.JOB_ID = new SelectList(db.Job, "ID", "JOB_NAME", vacancy.JOB_ID);
            return View(vacancy);
        }

        // GET: Vacancies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacancy vacancy = db.Vacancy.Find(id);
            if (vacancy == null)
            {
                return HttpNotFound();
            }
            return View(vacancy);
        }

        // POST: Vacancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacancy vacancy = db.Vacancy.Find(id);
            db.Vacancy.Remove(vacancy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
