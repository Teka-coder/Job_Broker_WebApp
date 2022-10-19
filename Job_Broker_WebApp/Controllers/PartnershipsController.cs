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
    public class PartnershipsController : Controller
    {
        private BE2 db = new BE2();

        // GET:Partnerships
        public ActionResult Index()
        {
            return View(db.Partnership.ToList());
        }

        public ActionResult PartnerList()
        {
            return View(db.Partnership.ToList());
        }

        //public ActionResult Index2()
        //{
        //    return View();
        //}

        // GET: Partnerships/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partnership partnership = db.Partnership.Find(id);
            if (partnership == null)
            {
                return HttpNotFound();
            }
            return View(partnership);
        }

        // GET: Partnerships/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Partnerships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PARTNERNAME,EMAILADD,PHONE,PROFESSION,SUPPORT,BROKER_ACCNO,BROKER_MAIL,REGdate")] Partnership partnership)
        {
            if (ModelState.IsValid)
            {
                db.Partnership.Add(partnership);
                db.SaveChanges();
                return RedirectToAction("PartnerList");
            }

            return View(partnership);
        }

        // GET: Partnerships/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partnership partnership = db.Partnership.Find(id);
            if (partnership == null)
            {
                return HttpNotFound();
            }
            return View(partnership);
        }

        // POST: Partnerships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PARTNERNAME,EMAILADD,PHONE,PROFESSION,SUPPORT,BROKER_ACCNO,BROKER_MAIL,REGdate")] Partnership partnership)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partnership).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partnership);
        }

        // GET: Partnerships/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partnership partnership = db.Partnership.Find(id);
            if (partnership == null)
            {
                return HttpNotFound();
            }
            return View(partnership);
        }

        // POST: Partnerships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Partnership partnership = db.Partnership.Find(id);
            db.Partnership.Remove(partnership);
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
