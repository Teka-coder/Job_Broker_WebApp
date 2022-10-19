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
    public class ApplicantsController : Controller
    {
        private JobBrokerEntities db = new JobBrokerEntities();

        // GET: Applicants
        public ActionResult Index()
        {
            var applicant = db.Applicant.Include(a => a.Register);
            return View(applicant.ToList());
        }

        public ActionResult ApplicantList()
        {
            var applicant = db.Applicant.Include(a => a.Register);
            return View(applicant.ToList());
        }

        // GET: Applicants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicant.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // GET: Applicants/Create
        public ActionResult Create()
        {
            ViewBag.REG_ID = new SelectList(db.Register, "ID", "FNAME");
            return View();
        }

        // POST: Applicants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,REG_ID,VAC_ID,AGE,SEX,QUALIFICATION,EXPERIENCE,KEBELEID,CV,DESCRPTION,REMARK")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.Applicant.Add(applicant);
                db.SaveChanges();
                return RedirectToAction("ApplicantList");
            }

            ViewBag.REG_ID = new SelectList(db.Register, "ID", "FNAME", applicant.REG_ID);
            return View(applicant);
        }
        public ActionResult Success()
        {
            return View();
        } 

        // GET: Applicants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicant.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            ViewBag.REG_ID = new SelectList(db.Register, "ID", "FNAME", applicant.REG_ID);
            return View(applicant);
        }

        // POST: Applicants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,REG_ID,VAC_ID,AGE,SEX,QUALIFICATION,EXPERIENCE,KEBELEID,CV,DESCRPTION,REMARK")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.REG_ID = new SelectList(db.Register, "ID", "FNAME", applicant.REG_ID);
            return View(applicant);
        }

        // GET: Applicants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicant.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Applicant applicant = db.Applicant.Find(id);
            db.Applicant.Remove(applicant);
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
