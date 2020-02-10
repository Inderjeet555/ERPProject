using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Areas.Sale.Models
{
    public class PackingSizes
    {
        public long PackingSizeId { get; set; }
        public string packingSizeName { get; set; }
        public decimal PackingSizeCapacity { get; set; }
        public bool Active { get; set; }
    }
}