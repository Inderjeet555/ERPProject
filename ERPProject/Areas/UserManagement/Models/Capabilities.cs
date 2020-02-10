using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Areas.UserManagement.Models
{
    public class Capabilities
    {
        public int Id { get; set; }
        public string CapabilityName { get; set; }
        public int MenuItemId { get; set; }
        public int AccessType { get; set; }
        public bool Restrictions { get; set; }

        public MenuItems MenuItem { get; set; }

    }
}