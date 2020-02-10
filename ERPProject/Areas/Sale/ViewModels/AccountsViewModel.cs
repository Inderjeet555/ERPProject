using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ERPProject.Areas.Sale.ViewModels
{
    public class AccountsViewModel
    {        
        public long AccountId { get; set; }
        [Required(ErrorMessage = "Account Name is required!")]
        [Display(Name = "Account Name")]
        public string AccountName { get; set; }        
        [Display(Name = "GST No")]
        public string GSTNo { get; set; }
        public string PAN { get; set; }
        public string Address { get; set; }
    }
}