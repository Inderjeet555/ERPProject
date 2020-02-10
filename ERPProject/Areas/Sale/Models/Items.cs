using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Areas.Sale.Models
{
    public class Items
    {
        public long ItemId { get; set; }
        public string ItemName { get; set; }
        public long ItemCategory { get; set; }
        public long? SaleAccountId { get; set; }
        public long? PurchaseAccountId { get; set; }
        public Accounts Account { get; set; }
    }
}