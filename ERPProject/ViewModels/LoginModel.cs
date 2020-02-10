using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ERPProject.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage= "User Name is required")]
        [Display(Name= "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage="Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}