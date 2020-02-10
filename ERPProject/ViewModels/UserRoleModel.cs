using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ERPProject.ViewModels
{
    public class UserRoleModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "User is required.")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Role is required.")]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsChecked { get; set; }
        public int GId { get; set; }
    }
}