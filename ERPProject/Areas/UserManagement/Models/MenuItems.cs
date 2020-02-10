using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Areas.UserManagement.Models
{
    public class MenuItems
    {
        public int Id { get; set; }
        public string MenuItemName { get; set; }
        public string Url { get; set; }
        public int? ParentMenuItemId { get; set; }
        public int DisplaySequence { get; set; }

    }
}