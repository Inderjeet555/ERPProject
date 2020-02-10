using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ERPProject.Areas.Sale.ViewModels
{
    public class SaleBillDetailViewModel
    {
        public long SaleBillDetailId { get; set; }
        public long SaleBillHeaderid { get; set; }
        public string ItemName { get; set; }

        [Required(ErrorMessage ="Item is required")]
        [Display(Name ="Item")]
        public long ItemId { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Bags are required")]
        [Display(Name = "Bags")]
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
        public long TaxId { get; set; }
        public string TaxName { get; set; }
        [Required(ErrorMessage ="Packing Size required")]
        [Display(Name ="Packing Size")]
        public long PackingSizeId { get; set; }
        public string PackingSize { get; set; }
        public decimal PackingSizeCapacity { get; set; }
    }
}