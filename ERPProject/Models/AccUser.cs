using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ERPProject.Models
{
    public class AccUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsOnline { get; set; }
        public string PasswordSalt { get; set; }
        public bool IsApproved { get; set; }    
        public int? EmployeeId { get; set; }
      //  public Employee Employee { get; set; }
        public int? UnitId { get; set; }
        public List<AccUserRoles> UserRoles { get; set; }
    }
}