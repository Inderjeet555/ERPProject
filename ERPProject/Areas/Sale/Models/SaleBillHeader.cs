using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Areas.Sale.Models
{
    public class SaleBillHeader
    {
        public long SaleBillHeaderid { get; set; }
        public long PartyAccountId { get; set; }
        public int MyProperty { get; set; }
        public decimal InvoiceNo { get; set; }
        public System.DateTime Date { get; set; }
        public long VoucherHeaderId { get; set; }
        public Accounts Account { get; set; }
        public VoucherHeaders VoucherHeader { get; set; }
        public long SaleOrderNo { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal FreightAmount { get; set; }
        public decimal Taxamount { get; set; }
        public string Narration { get; set; }
        public decimal DiscountAmount { get; set; }
        public long GodownId { get; set; }
        public Godowns Godown { get; set; }
        public ICollection<SaleBillDetail> SaleBillDetails { get; set; }
    }
}