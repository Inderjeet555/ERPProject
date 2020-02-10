using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPProject.Infrastructure;
using ERPProject.Areas.Sale.Models;

namespace ERPProject.Areas.Sale.DataManagers
{
    public class ItemManager
    {
        private ERPProjectDataContext db;

        public ItemManager()
        {
            db = new ERPProjectDataContext();
        }
        public Items GetItemAccountById(Int64 ItemId)
        {
           return this.db.Item.Where(x => x.ItemId.Equals(ItemId)).FirstOrDefault();
        }
    }
}