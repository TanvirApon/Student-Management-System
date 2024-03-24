using Student_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Management_System.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User chkobj)
        {
            if (ModelState.IsValid)
            {
                using (StudentEntities db = new StudentEntities())
                {

                    var obj = db.Users.Where(a => a.username.Equals(chkobj.username) && a.password.Equals(chkobj.password)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["UserId"] = obj.id.ToString();
                        Session["UserName"] = obj.username.ToString();
                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {

                        ModelState.AddModelError("", "The Username and Password is incorrect");

                    }

                }

            }

            return View("Index", "Login");
        }



        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }





    }
}