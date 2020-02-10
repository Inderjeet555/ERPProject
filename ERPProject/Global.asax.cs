using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using ERPProject.App_Start;
using ERPProject.Infrastructure;

namespace ERPProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                var userdata = UserDataModel.CreateUserData(ticket.UserData);
                FormsIdentity identity = (FormsIdentity)HttpContext.Current.User.Identity;
                CustomMembershipUser user = (CustomMembershipUser)Membership.GetUser(identity.Name);
                var principal = new CustomPrincipal(identity, user, userdata.YearStart, userdata.YearEnd);
                HttpContext.Current.User = principal;
            }
        }
        
    }
}
