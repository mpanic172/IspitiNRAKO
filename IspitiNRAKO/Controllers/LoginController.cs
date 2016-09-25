using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IspitiNRAKO.Controllers
{
    public class LoginController : Controller
    {

        private IspitiEntities db = new IspitiEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string usernameinput, string passwordinput)
        {
            var admin = db.Administrators.Where(u => u.Username == usernameinput && u.Password == passwordinput).FirstOrDefault();

            if (admin != null)
            {
                Session["UserID"] = admin.IdAdministrator.ToString();
                Session["Username"] = admin.Username.ToString();
                if (admin.Razina == 1)
                {
                    Session["UserType"] = "SuperAdmin";
                }
                else
                {
                    Session["UserType"] = "Admin";
                }
                return RedirectToAction("Index", "Home");
            }

            var user = db.Korisniks.Where(k => k.Username == usernameinput && k.Password == passwordinput).FirstOrDefault();

            if (user != null)
            {
                Session["UserID"] = user.IdKorisnik.ToString();
                Session["Username"] = user.Username.ToString();
                Session["UserType"] = "User";

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Greska = "Krivi parametri!";
            return View("Login");

        }


    }
}