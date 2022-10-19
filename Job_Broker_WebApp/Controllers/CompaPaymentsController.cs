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
    public class CompaPaymentsController : Controller
    {
        private JobBrokerEntities db = new JobBrokerEntities();

        // GET: CompaPayments
        public ActionResult Index()
        {
            var compaPayment = db.CompaPayment.Include(c => c.Company);
            return View(compaPayment.ToList());
        }

        // GET: CompaPayments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompaPayment compaPayment = db.CompaPayment.Find(id);
            if (compaPayment == null)
            {
                return HttpNotFound();
            }
            return View(compaPayment);
        }

        // GET: CompaPayments/Create
        public ActionResult Create()
        {
            ViewBag.COMP_ID = new SelectList(db.Company, "ID", "COMP_NAME");
            return View();
        }

        // POST: CompaPayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,COMP_ID,TYPEOFPAY,AMOUNT,DOP")] CompaPayment compaPayment)
        {
            if (ModelState.IsValid)
            {
                db.CompaPayment.Add(compaPayment);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.COMP_ID = new SelectList(db.Company, "ID", "COMP_NAME", compaPayment.COMP_ID);
            return View(compaPayment);
        }

        // GET: CompaPayments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompaPayment compaPayment = db.CompaPayment.Find(id);
            if (compaPayment == null)
            {
                return HttpNotFound();
            }
            ViewBag.COMP_ID = new SelectList(db.Company, "ID", "COMP_NAME", compaPayment.COMP_ID);
            return View(compaPayment);
        }

        // POST: CompaPayments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,COMP_ID,TYPEOFPAY,AMOUNT,DOP")] CompaPayment compaPayment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compaPayment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COMP_ID = new SelectList(db.Company, "ID", "COMP_NAME", compaPayment.COMP_ID);
            return View(compaPayment);
        }

        // GET: CompaPayments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompaPayment compaPayment = db.CompaPayment.Find(id);
            if (compaPayment == null)
            {
                return HttpNotFound();
            }
            return View(compaPayment);
        }

        // POST: CompaPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompaPayment compaPayment = db.CompaPayment.Find(id);
            db.CompaPayment.Remove(compaPayment);
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
