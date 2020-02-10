using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPProject.Infrastructure;
using ERPProject.Areas.Sale.Models;

namespace ERPProject.Areas.Sale.DataManagers
{
    public class AccountsManager
    {
        private ERPProjectDataContext db;

        public AccountsManager()
        {
            db = new ERPProjectDataContext();
        }
        public Accounts GetAccountNameById(Int64 AccountId)
        {
            return this.db.Account.Where(x => x.AccountId.Equals(AccountId)).FirstOrDefault();
        }
    }
}