using Job_Broker_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Job_Broker_WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Help()
        {
            ViewBag.Message = "Your Help page.";

            return View();
        }

        public ActionResult PageNotFound()
        {
            return View();
        }

        public ActionResult ServerError()
        {
            return View();
        }
        public ActionResult IdComp()
        {
            return View();
        }

        public ActionResult Settings()
        {
            return View();
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(Register reset)
        {
            //if (ModelState.IsValid)
            //{
            using (JobBrokerEntities db = new JobBrokerEntities())
            {
                var obj = db.Register.Where(a => a.USERNAME.Equals(reset.USERNAME) && a.QUEST.Equals(reset.QUEST) && a.ANS.Equals(reset.ANS)).FirstOrDefault();

                if (obj != null)
                {
                    Session["ID"] = obj.ID.ToString();
                 
                    Session["PASSWORD"] = obj.PASSWORD.ToString();
                    Session["USERNAME"] = obj.USERNAME.ToString();
                    Session["FNAME"] = obj.FNAME.ToString();
                    Session["LNAME"] = obj.LNAME.ToString();
                    ViewBag.Message = "Password recovered successfully";
                    return View("PopUp",reset);
                }
                else 
                {

                    ViewBag.Message = "Password can't reset! You inserted wrong information";
                    return View("PopDown");
                    
                }
              

            }
            
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ResetPassword(Register user)
        //{
        //    using (JobBrokerEntities db = new JobBrokerEntities())
        //    {
        //        var obj = db.Register.Where(a => a.USERNAME.Equals(user.USERNAME) && a.QUEST.Equals(user.QUEST) && a.ANS.Equals(user.ANS)).FirstOrDefault();

        //        if (obj != null)
        //        {
        //            Session["ID"] = obj.ID.ToString();
        //            Session["USERNAME"] = obj.USERNAME.ToString();
        //            Session["PASSWPRD"] = obj.PASSWORD.ToString();
        //            //return RedirectToAction("UserDashBoard");
        //            return View("PopUp",user);
        //        }
        //        //else if (obj != null && objUser.ROLE == "Employer")
        //        //{
        //        //    Session["ID"] = obj.ID.ToString();
        //        //    Session["USERNAME"] = obj.USERNAME.ToString();
        //        //    //return RedirectToAction("EmployerDashBoard");
        //        //    return View("EmployerDashBoard");
        //        //}
        //        else
        //        {
        //            user.LoginErrorMsg = "Invalid Question or Answer";
        //            return View("Login", user);
        //        }
        //    }
        //}

        public ActionResult PopUp()
        {
            


            return View();
        }
        public ActionResult PopDown()
        {
           


            return View();
        }

        //public ActionResult ChangePassword()
        //{
        //    return View();
        //}

        public ActionResult ChangePassword(Register change)
        {
            using (JobBrokerEntities db = new JobBrokerEntities())
            {
                var detail = db.Register.Where(log => log.PASSWORD == change.PASSWORD && log.USERNAME == change.USERNAME).FirstOrDefault();
                if (detail != null)
                {
                    detail.PASSWORD = change.NewPassword;

                    db.SaveChanges();
                    ViewBag.Message = "Password updated Successfully!";
                    return View(change);

                }
                else
                {
                    ViewBag.Message = "Now Password did not Affected!";
                    return View(change);
                }


            }

           // return View(change);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ChangePassword(Register Ouser)
        //{
        //    using (JobBrokerEntities db = new JobBrokerEntities())
        //    {
        //        var obj = db.Register.Where(a => a.PASSWORD.Equals(Ouser.PASSWORD)).FirstOrDefault();

        //        if (obj != null)
        //        {
        //            //obj.PASSWORD = Ouser.NewPass;
        //            //db.SaveChanges();
        //            Session["ID"] = obj.ID.ToString();
        //            Session["USERNAME"] = obj.USERNAME.ToString();
        //            //return RedirectToAction("UserDashBoard");
        //            return View(Ouser);
        //        }
        //        //else if (obj != null && objUser.ROLE == "Employer")
        //        //{
        //        //    Session["ID"] = obj.ID.ToString();
        //        //    Session["USERNAME"] = obj.USERNAME.ToString();
        //        //    //return RedirectToAction("EmployerDashBoard");
        //        //    return View("EmployerDashBoard");
        //        //}
        //        else
        //        {
        //            Ouser.LoginErrorMsg = "The old password doesn't match ";
        //            return View(Ouser);
        //        }
        //    }
        //}




        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Register obUser)
        {
            //if (ModelState.IsValid)
            //{
                using (JobBrokerEntities db = new JobBrokerEntities())
                {
                    var obj = db.Register.Where(a => a.USERNAME.Equals(obUser.USERNAME)  && a.PASSWORD.Equals(obUser.PASSWORD) && a.ROLE.Equals(obUser.ROLE)).FirstOrDefault();
                   
                    if(obj!=null && obUser.ROLE== "Job seeker")  
                    {
                    Session["ID"] = obj.ID.ToString();
                    Session["FNAME"] = obj.FNAME.ToString();
                    Session["LNAME"] = obj.LNAME.ToString();
                    Session["REGION"] = obj.REGION.ToString();
                    Session["ZONE"] = obj.ZONE.ToString();
                    Session["TOWN"] = obj.TOWN.ToString();
                    Session["KEBELE"] = obj.KEBELE.ToString();
                    Session["EMAIL"] = obj.EMAIL.ToString();
                    Session["PHONE"] = obj.PHONE.ToString();
                    Session["SEX"] = obj.SEX.ToString();
                    Session["DOB"] = obj.DOB.ToString();
                    Session["USERNAME"] = obj.USERNAME.ToString();
                    Session["PASSWORD"] = obj.PASSWORD.ToString();
                    Session["QUEST"] = obj.QUEST.ToString();
                    Session["ANS"] = obj.ANS.ToString();
                  //  Session["PICTURE"] = obj.PICTURE.ToString();
                    Session["ROLE"] = obj.ROLE.ToString();
                    Session["REGDATE"] = obj.REGDATE.ToString();
                    Session["ACCEXPDATE"] = obj.ACCEXPDATE.ToString();
                    Session["STATUS"] = obj.STATUS.ToString();
                    //return RedirectToAction("UserDashBoard");
                    return View("UserDashBoard");
                    }
                else if (obj != null && obUser.ROLE == "Employer")
                {
                   
                    Session["ID"] = obj.ID.ToString();
                    Session["FNAME"] = obj.FNAME.ToString();
                    Session["LNAME"] = obj.LNAME.ToString();
                    Session["REGION"] = obj.REGION.ToString();
                    Session["ZONE"] = obj.ZONE.ToString();
                    Session["TOWN"] = obj.TOWN.ToString();
                    Session["KEBELE"] = obj.KEBELE.ToString();
                    Session["EMAIL"] = obj.EMAIL.ToString();
                    Session["PHONE"] = obj.PHONE.ToString();
                    Session["SEX"] = obj.SEX.ToString();
                    Session["DOB"] = obj.DOB.ToString();
                    Session["USERNAME"] = obj.USERNAME.ToString();
                    Session["PASSWORD"] = obj.PASSWORD.ToString();
                    Session["QUEST"] = obj.QUEST.ToString();
                    Session["ANS"] = obj.ANS.ToString();
                   // Session["PICTURE"] = obj.PICTURE.ToString();
                    Session["ROLE"] = obj.ROLE.ToString();
                    Session["REGDATE"] = obj.REGDATE.ToString();
                    Session["ACCEXPDATE"] = obj.ACCEXPDATE.ToString();
                    Session["STATUS"] = obj.STATUS.ToString();
                    //return RedirectToAction("EmployerDashBoard");
                    return View("EmployerDashBoard");
                }
                else
                {
                    obUser.LoginErrorMsg = "Invalid user name or password, also check your Role type";
                    return View("Login", obUser);
                }
              
            }
            //}
            //return View(objUser);
        }

        //public string UploadImage(HttpPostedFileBase imgfile)
        //{
        //    string path = "-1";
        //    return Path;
        //}


        //public ActionResult Login(Register objUser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (JobBrokerEntities db = new JobBrokerEntities())
        //        {
        //            var obj = db.Register.Where(a => a.USERNAME.Equals(objUser.USERNAME) && a.PASSWORD.Equals(objUser.PASSWORD)).FirstOrDefault();
        //            if (obj != null)
        //            {
        //                Session["ID"] = obj.ID.ToString();
        //                Session["USERNAME"] = obj.USERNAME.ToString();
        //                return RedirectToAction("UserDashBoard");
        //            }
        //        }
        //    }
        //    return View(objUser);
        //}



        public ActionResult UserDashBoard()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult EmployerDashBoard()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        //public ActionResult Logout()
        //{
        //    FormsAuthentication.SignOut();
        //    Session.Abandon(); // it will clear the session at the end of request
        //    return RedirectToAction("Index");
        //}

        public ActionResult LogOut()
        {
            //int userId = (int)Session["ID"];
            Session.Abandon();
            return RedirectToAction("Login","Home");
        }

    }
}


    