using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPProject.Infrastructure;
using ERPProject.Models;
using ERPProject.Areas.Sale.ViewModels;
using ERPProject.Utilities;

namespace ERPProject.Areas.Sale.Controllers
{
      public class AccountMasterController : Controller
    {
          private ERPProjectDataContext db;

          public AccountMasterController()
          {
              this.db = new ERPProjectDataContext();
          }
        // GET: Sale/Account
        public ActionResult CreateAccount()
        {
            var acccountViewModel = new AccountsViewModel();
            return PartialView("CreateAccount", acccountViewModel);
        }


        [HttpPost]
        public ActionResult Save(AccountsViewModel model)
        {
            if(model.AccountId == 0)
            {
                var entity = MapToEntity(model);
                db.Account.Add(entity);
                db.SaveChanges();                
            }
            return Json(ConfirmationMessages.CreateSuccessConfirmation("Record Saved Successfully"));
        }


        private Accounts MapToEntity(AccountsViewModel model)
        {
            var accounts = new Accounts
            {
                AccountId = model.AccountId,
                AccountName = model.AccountName,
                Address = model.Address,
                GSTNo = model.GSTNo,
                PAN = model.PAN
            };
            return accounts;
        }

    }
}