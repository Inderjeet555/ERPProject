using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace ERPProject.Infrastructure
{
    public class CustomPrincipal: IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime YearStart { get; set; }
        public DateTime YearEnd { get; set; }
        public int EmployeeId { get; set; }
        public int UnitId { get; set; }
        public string[] Roles { get; set; }


        public CustomPrincipal(IIdentity identity, CustomMembershipUser user, DateTime yearStart, DateTime yearEnd)
        {
            Identity = identity;
            UserId = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            EmployeeId = user.EmployeeId;
            UnitId = user.UnitId;
            Roles = user.Roles;
            YearStart = yearStart;
            YearEnd = yearEnd;
        }

        public bool IsInRole(string roleName)
        {
            foreach (var role in Roles)
            {
                if (string.Compare(role, roleName, true) == 0)
                    return true;
            }
            return false;
        }

        public bool IsInAnyRole(params string[] roleNames)
        {
            return Roles.Any(u => roleNames.Contains(u));
        }
    }
}