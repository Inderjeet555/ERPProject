using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ERPProject.Areas.Sale.ViewModels
{
    public class SaleBillHeaderViewModel
    {

        public SaleBillHeaderViewModel()
        {
            this.SaleBillDetails = new List<SaleBillDetailViewModel>();
        }
        public long SaleBillHeaderid { get; set; }

        [Required(ErrorMessage = "Party Name is required")]
        [Display(Name = "PartyName")]
        public long PartyAccountId { get; set; }        
        public string PartyName { get; set; }        
        public int MyProperty { get; set; }

        [Required(ErrorMessage ="Invoice No is required")]
        [Display(Name ="Invoice No")]
        public string InvoiceNo { get; set; }

        [Required(ErrorMessage = "Sale Order No is required")]
        [Display(Name = "Sale Order No")]
        public long SaleOrderNo { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal FreightAmount { get; set; }
        public decimal Taxamount { get; set; }
        public string Narration { get; set; }
        public decimal DiscountAmount { get; set; }

        [Required(ErrorMessage = "Godown is required")]
        [Display(Name = "Godown")]
        public long GodownId { get; set; }
        public string GodownName { get; set; }

        [Required(ErrorMessage ="Date is required")]
        public System.DateTime Date { get; set; }
        public long VoucherHeaderId { get; set; }       
        public List<SaleBillDetailViewModel> SaleBillDetails { get; set; }

    }

   
}