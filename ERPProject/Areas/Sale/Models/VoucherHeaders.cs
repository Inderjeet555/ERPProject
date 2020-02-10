using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Areas.Sale.Models
{
    public class VoucherHeaders
    {
        public long RecordHeaderID { get; set; }
        public long HistoryHeaderID { get; set; }
        public long VoucherHeaderID { get; set; }
        public long VoucherTypeSeriesID { get; set; }
        public decimal VoucherNo { get; set; }
        public System.DateTime VoucherDate { get; set; }
        public Nullable<long> VoucherAccountID { get; set; }
        public byte[] Version { get; set; }
        public Nullable<long> GrainMarketID { get; set; }
        public ICollection<SaleBillHeader> SaleBillHeaders { get; set; }

        public virtual ICollection<VoucherDetail> VoucherDetails { get; set; }
        public Accounts Account { get; set; }
    }
}

