using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ERPProject.ViewModels;


namespace ERPProject.Infrastructure
{
    public class CustomMembershipUser: MembershipUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }      
        public int UnitId { get; set; }
        public int EmployeeId { get; set; }
        public string[] Roles { get; set; }

        public CustomMembershipUser(UserModel user)
            : base("CustomMembershipProvider", user.UserName, user.Id, user.Email, string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            UnitId = user.UnitId;
            EmployeeId = user.EmployeeId;
           
            Roles = (from r in user.UserRoles select r.RoleName).ToArray();

        }
    }
}