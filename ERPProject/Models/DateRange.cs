using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ERPProject.Models;
using ERPProject.Infrastructure;
using System.Web.Security;
using System.Web.Script.Serialization;

namespace ERPProject.Models
{
    public class DateRange
    {
        [Display(Name= "From Date")]
        public DateTime FromDate { get; set; }

        [Display(Name = "ToDate Date")]
        public DateTime ToDate { get; set; }


        public DateRange()
        { }

        public DateRange(HttpRequest Request)
        {
            //this.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01);
            var model = GetFYDate(Request);

            this.FromDate = model.YearStart.ToLocalTime();//GetFYFromDate(Request);
            this.ToDate = model.YearEnd.ToLocalTime();//GetCurrentDate();

            //   this.FYFromDate = GetFYFromDate(Request).AddDays(1);
            //  this.FYToDate = GetCurrentDate();
        }

        private UserDataModel GetFYDate(HttpRequest request)
        {
            UserDataModel data = new UserDataModel();

            HttpCookie authcookie = request.Cookies[FormsAuthentication.FormsCookieName];
            if (authcookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authcookie.Value);
                data = CreateUserData(authTicket.UserData);

            }
            return data;
        }

        private DateTime GetFYFromDate(HttpRequest Request)
        {

            DateTime date;
            if (DateTime.Now.Month >= 4)
                date = new DateTime(DateTime.Now.Year, 04, 01);
            else
                date = new DateTime(DateTime.Now.Year - 1, 04, 01);

            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                date = CreateUserData(authTicket.UserData).YearStart.ToLocalTime();
            }
            return date;
        }


        private UserDataModel CreateUserData(string UserData)
        {
            JavaScriptSerializer serialiIzer = new JavaScriptSerializer();

            UserDataModel userModel = serialiIzer.Deserialize<UserDataModel>(UserData);

            return userModel;


        }


    }
}