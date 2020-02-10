using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Models
{
    public class AccountingYears
    {
        public long AccountingYearId { get; set; }
        public string AccountingYearName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}