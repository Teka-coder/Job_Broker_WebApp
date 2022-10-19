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
    public class AdminsController : Controller
    {
       

        private JobBrokerEntities db = new JobBrokerEntities();

        // GET: Admins
        public ActionResult Index()
        {
            return View(db.Admin.ToList());
        }

        // GET: Admins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admin.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // GET: Admins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,USERNAME,PASSWORD,QUEST,ANS")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admin.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        // GET: Admins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admin.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,USERNAME,PASSWORD,QUEST,ANS")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        // GET: Admins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admin.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = db.Admin.Find(id);
            db.Admin.Remove(admin);
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

        public ActionResult Autherize()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Autherize(Admin userModel)
        //{
        // if (ModelState.IsValid) {
        //    using (JobBrokerEntities db = new JobBrokerEntities())
        //    {
        //        var userDetails = db.Admin.Where(x => x.USERNAME == userModel.USERNAME && x.PASSWORD == userModel.PASSWORD).FirstOrDefault();
        //        if (userDetails == null)
        //        {
        //            userModel.LoginErrorMessage = "Wrong username or password.";
        //            return View("Autherize", userModel);
        //        }
        //        else
        //        {
        //            Session["ID"] = userDetails.ID;
        //            Session["USERNAME"] = userDetails.USERNAME;
        //            return RedirectToAction("AdminDashBoard", "Admins");
        //        }
        //    }
        //}
        //}

        public ActionResult Autherize(Admin objUser)
        {
            //if (ModelState.IsValid)
            //{
                using (JobBrokerEntities db = new JobBrokerEntities())
                {
                    var obj = db.Admin.Where(a => a.USERNAME.Equals(objUser.USERNAME) && a.PASSWORD.Equals(objUser.PASSWORD)).FirstOrDefault();
                    if (obj == null)
                {
                    objUser.LoginErrorMessage = "Invalid user name or password";
                    return View("Autherize", objUser);
                }
                    else
                    {
                        Session["ID"] = obj.ID.ToString();
                        Session["USERNAME"] = obj.USERNAME.ToString();
                        return View("AdminDashBoard");
                    }

                }
            //}
            //return View(objUser);
        }

        public ActionResult AdminDashBoard()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Autherize");
            }
        }

        public ActionResult LogOut()
        {
            //int ID = (int)Session["ID"];
            Session.Abandon();
            //return RedirectToAction("Autherize", "Admins");
            return RedirectToAction("Autherize","Admins");
        }

    }
}
