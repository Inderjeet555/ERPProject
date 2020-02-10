using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Areas.Sale
{
    public class Accounts
    {
        public long AccountId { get; set; }
        public string AccountName { get; set; }
        public string GSTNo { get; set; }
        public string PAN { get; set; }
        public string Address { get; set; }

    }
}