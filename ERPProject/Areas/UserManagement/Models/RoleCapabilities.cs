using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPProject.Models;

namespace ERPProject.Areas.UserManagement.Models
{
    public class RoleCapabilities
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int CapabilityId { get; set; }
        public int AccessFlag { get; set; }
        public Roles Role { get; set; }
        public Capabilities CapaBilities { get; set; }
    }
}