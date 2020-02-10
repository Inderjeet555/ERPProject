using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Areas.Sale.ViewModels
{
    public class VoucherViewModel
    {
        public long AccountID { get; set; }
        public string AccountName { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Amount { get; set; }
        public bool WasSuccessful { get; set; }
    }
}