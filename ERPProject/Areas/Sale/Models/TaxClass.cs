using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Areas.Sale.Models
{
    public class TaxClass
    {
        public long TaxId { get; set; }
        public string Taxname { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxPercentage { get; set; }
    }
}