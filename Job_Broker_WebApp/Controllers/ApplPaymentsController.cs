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
    public class ApplPaymentsController : Controller
    {
        private JobBrokerEntities db = new JobBrokerEntities();

        // GET: ApplPayments
        public ActionResult Index()
        {
            var applPayment = db.ApplPayment.Include(a => a.Applicant);
            return View(applPayment.ToList());
        }

        // GET: ApplPayments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplPayment applPayment = db.ApplPayment.Find(id);
            if (applPayment == null)
            {
                return HttpNotFound();
            }
            return View(applPayment);
        }

        // GET: ApplPayments/Create
        public ActionResult Create()
        {
            ViewBag.APP_ID = new SelectList(db.Applicant, "ID", "SEX");
            return View();
        }

        // POST: ApplPayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,APP_ID,TYPEOFPAY,AMOUNT,DOP")] ApplPayment applPayment)
        {
            if (ModelState.IsValid)
            {
                db.ApplPayment.Add(applPayment);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.APP_ID = new SelectList(db.Applicant, "ID", "SEX", applPayment.APP_ID);
            return View(applPayment);
        }

        // GET: ApplPayments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplPayment applPayment = db.ApplPayment.Find(id);
            if (applPayment == null)
            {
                return HttpNotFound();
            }
            ViewBag.APP_ID = new SelectList(db.Applicant, "ID", "SEX", applPayment.APP_ID);
            return View(applPayment);
        }

        // POST: ApplPayments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,APP_ID,TYPEOFPAY,AMOUNT,DOP")] ApplPayment applPayment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applPayment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.APP_ID = new SelectList(db.Applicant, "ID", "SEX", applPayment.APP_ID);
            return View(applPayment);
        }

        // GET: ApplPayments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplPayment applPayment = db.ApplPayment.Find(id);
            if (applPayment == null)
            {
                return HttpNotFound();
            }
            return View(applPayment);
        }

        // POST: ApplPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApplPayment applPayment = db.ApplPayment.Find(id);
            db.ApplPayment.Remove(applPayment);
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
