using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Areas.Sale.Models
{
    public class Godowns
    {
        public long GodownId { get; set; }
        public string GodownName { get; set; }
        public string GodownAddress { get; set; }
        public string City { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}