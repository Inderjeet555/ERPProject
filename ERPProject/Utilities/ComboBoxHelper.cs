using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPProject.Infrastructure;

namespace ERPProject.Utilities
{
    public class ComboBoxHelper
    {
        static ERPProjectDataContext db = new ERPProjectDataContext();


        public static IQueryable GetAccountByName()
        {
            var accountname = db.Account.Select(x => new { ID = x.AccountId, Value = x.AccountName }).OrderBy(x => x.Value);
            return accountname;
        }


        public static IQueryable GetGodowns()
        {
            var godowns = db.Godown.Select(x => new { ID = x.GodownId, Value = x.GodownName }).OrderBy(x => x.Value);
            return godowns;
        }

        public static IQueryable GetpackingSizes()
        {
            var packing = db.PackingSize.Select(x => new { ID = x.PackingSizeId, Value = x.packingSizeName, PackingSizeCapacity = x.PackingSizeCapacity }).OrderBy(x => x.Value);
            return packing;
        }

        public static IQueryable GetItems()
        {
            var items = db.Item.Select(x => new { ID = x.ItemId, Value = x.ItemName }).OrderBy(x => x.Value);
            return items;
        }

        public static IQueryable GetTaxClass()
        {
            var items = db.Taxclass.Select(x => new { ID = x.TaxId, Value = x.Taxname , TaxPer = x.TaxRate }).OrderBy(x => x.Value);
            return items;
        }
    }
}