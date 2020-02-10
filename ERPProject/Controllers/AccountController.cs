using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPProject.ViewModels;
using System.Web.Security;
using ERPProject.Infrastructure;
using System.Web.Configuration;
using System.Collections.Specialized;
using ERPProject.Models;


namespace ERPProject.Controllers
{
    public class AccountController : Controller
    {
        private ERPProjectDataContext db;

        public AccountController()
        {
            db = new ERPProjectDataContext();
        }
        // GET: Account
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();

        }

        [HttpPost]
        public ActionResult Login(LoginModel loginmodel, string url)
        {
            if (Membership.ValidateUser(loginmodel.UserName, loginmodel.Password))
            {
                DateTime fromDate = db.AccountingYear.Select(x => x.FromDate).FirstOrDefault();
                DateTime Todate = db.AccountingYear.Select(x => x.ToDate).FirstOrDefault();

                var userdata = new UserDataModel { UserName = loginmodel.UserName, YearStart = fromDate, YearEnd = Todate };
                FormsAuthenticationTicket ticket = null;
                ticket = new FormsAuthenticationTicket(1, loginmodel.UserName, DateTime.Now, DateTime.Now.Add(FormsAuthentication.Timeout),false,userdata.ToJson(),
                    FormsAuthentication.FormsCookiePath);

                string encticket = FormsAuthentication.Encrypt(ticket);

                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName,encticket));

                return RedirectToLocal(url);
            }


            ModelState.AddModelError("", "The User Name or Password Provided is Incorrect.");
            return View(loginmodel);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");

            
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}