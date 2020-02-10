using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.ViewModels
{
    public class UserModel
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name is Required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required.")]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is Required.")]
        public string ConfirmPassword { get; set; }
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public bool IsOnline { get; set; }
        public string PasswordSalt { get; set; }
        public bool IsApproved { get; set; }
        public int UnitId { get; set; } 
        public int EmployeeId { get; set; }
      
        public List<UserRoleModel> UserRoles { get; set; }

    }
}