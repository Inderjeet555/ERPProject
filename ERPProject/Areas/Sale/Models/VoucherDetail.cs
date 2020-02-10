using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Areas.Sale.Models
{
    public class VoucherDetail
    {
        public long VoucherDetailID { get; set; }
        public long VoucherHeaderID { get; set; }
        public long AccountID { get; set; }
        public Nullable<long> SAccountID { get; set; }
        public decimal Amount { get; set; }
        public string BillNo { get; set; }
        public string InstrumentNo { get; set; }
        public Nullable<System.DateTime> InstrumentDate { get; set; }
        public string InstrumentDesc { get; set; }
        public Nullable<System.DateTime> ClearingDate { get; set; }
        public string Narration { get; set; }
        public byte[] Version { get; set; }
        public VoucherHeaders  VoucherHeader { get; set; }
        public Accounts  Account { get; set; }

    }
}