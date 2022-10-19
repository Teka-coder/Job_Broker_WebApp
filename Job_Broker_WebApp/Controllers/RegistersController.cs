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
    public class RegistersController : Controller
    {
        private JobBrokerEntities db = new JobBrokerEntities();

        // GET: Registers
        public ActionResult Index()
        {
            return View(db.Register.ToList());
        }

        // GET: Registers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Register register = db.Register.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        // GET: Registers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FNAME,LNAME,REGION,ZONE,TOWN,KEBELE,EMAIL,PHONE,SEX,DOB,USERNAME,PASSWORD,QUEST,ANS,PICTURE,ROLE,REGDATE,ACCEXPDATE,STATUS")] Register register)
        {
            //if (ModelState.IsValid)
            //{
                using (JobBrokerEntities db = new JobBrokerEntities())
                {
                    var obj = db.Register.Where(a => a.USERNAME.Equals(register.USERNAME)).FirstOrDefault();
                    if (obj != null)
                    {

                        Session["USERNAME"] = obj.USERNAME.ToString();
                        return View("UnSuccess");
                    }
                    else
                    {
                        //Session["USERNAME"] = obj.USERNAME.ToString();
                        db.Register.Add(register);
                        db.SaveChanges();
                    //return RedirectToAction("Create");}
                   // Session["USERNAME"] = obj.USERNAME.ToString();
                    return View("Success", register);

                    }
                }
           // }

                    //return View("Success",register);
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult UnSuccess()
        {
            return View();
        }

        // GET: Registers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Register register = db.Register.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        // POST: Registers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FNAME,LNAME,REGION,ZONE,TOWN,KEBELE,EMAIL,PHONE,SEX,DOB,USERNAME,PASSWORD,QUEST,ANS,PICTURE,ROLE,REGDATE,ACCEXPDATE,STATUS")] Register register)
        {
            if (ModelState.IsValid)
            {
                db.Entry(register).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(register);
        }

        // GET: Registers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Register register = db.Register.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        // POST: Registers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Register register = db.Register.Find(id);
            db.Register.Remove(register);
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
