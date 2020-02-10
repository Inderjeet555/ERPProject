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
    public class ComboController : Controller
    {
        public ActionResult GetAccountName()
        {
            var listItems = ComboBoxHelper.GetAccountByName();
            return Json(listItems, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetGodowns()
        {
            var godowns = ComboBoxHelper.GetGodowns();
            return Json(godowns, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetItems()
        {
            var items = ComboBoxHelper.GetItems();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPackingSize()
        {
            var packingSize = ComboBoxHelper.GetpackingSizes();
            return Json(packingSize, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTaxClass()
        {
            var tax = ComboBoxHelper.GetTaxClass();
            return Json(tax, JsonRequestBehavior.AllowGet);
        }
    }
}