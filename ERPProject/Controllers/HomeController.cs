using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPProject.Models;
using ERPProject.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace ERPProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            using (ERPProjectDataContext db = new ERPProjectDataContext())
            {
                //var user = new AccUser();
                //user.FirstName = "Inder";
                //user.LastName = "Singh";
                //user.Password = "adminx123";
                //user.UserName = "Inder";

                //db.AccUsers.Add(user);
                //db.SaveChanges();
            }
           

            return View();
        }
    }
}