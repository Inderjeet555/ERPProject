using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Areas.Sale.Models
{
    public class SaleBillDetail
    {
        public long SaleBillDetailId { get; set; }
        public long SaleBillHeaderid { get; set; }
        public long ItemId { get; set; }
        public string Description { get; set; }
        public int Bags { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal TaxableAmount { get; set; }
        public decimal CGSTAmount { get; set; }
        public decimal CGSTPer { get; set; }
        public decimal SGSTAmount { get; set; }
        public decimal SGSTPer { get; set; }
        public decimal IGSTAmount { get; set; }
        public decimal IGSTPer { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal GSTRate { get; set; }
        public decimal TaxAmount { get; set; }
        public SaleBillHeader SaleBillHeaders { get; set; }
        public Items Item { get; set; }
        public PackingSizes PackingSize { get; set; }
        public TaxClass Taxclass { get; set; }
        public long TaxClassId { get; set; }
        public long PackingSizeId { get; set; }
        
    }
}