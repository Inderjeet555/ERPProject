using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Models
{
    public class AccUserRoles
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public AccUser User { get; set; }
        public int RoleId { get; set; }
        public Roles Role { get; set; }
    }
}