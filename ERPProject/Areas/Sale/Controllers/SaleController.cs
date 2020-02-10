using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPProject.Infrastructure;
using ERPProject.Models;
using ERPProject.Areas.Sale.ViewModels;
using ERPProject.Utilities;
using ERPProject.Areas.Sale.Models;
using ERPProject.Areas.Sale.DataManagers;
using ERPProject.Utilities;
using System.Data.Entity;
namespace ERPProject.Areas.Sale
{
   
    public class SaleController : Controller
    {
        private ItemManager itemManager;
        private readonly ERPProjectDataContext db;
        private AccountsManager accountsmanager;
        public SaleController()
        {
             db = new ERPProjectDataContext();
             itemManager = new ItemManager();
             accountsmanager = new AccountsManager();
        }
        // GET: Sale/Sale
        public ActionResult Index()
        {
            var request = this.HttpContext.ApplicationInstance.Context.Request;
            DateRange dateRange = new DateRange(request);
            ViewBag.DateRange = dateRange;         
            return View();
        }

        public ActionResult Create()
        {
            var salebillheaderVM = new SaleBillHeaderViewModel();
            salebillheaderVM.Date = DateTime.Now;
            salebillheaderVM.InvoiceNo = GetNextInvoiceNumber();
            return View("Create", salebillheaderVM);
        }    


        private string GetNextInvoiceNumber()
        {
            decimal billno = 0;
            billno = db.SaleBillHeaders.Select(m => m.InvoiceNo).DefaultIfEmpty().Max() + 1;
            return billno.ToString();
        }

        [AcceptVerbs("Get", "Post")]
        public ActionResult Save(SaleBillHeaderViewModel model, bool IsPreviewVoucher)
        {
            if (ModelState.IsValid)
            {
                if (IsPreviewVoucher)
                {
                    var voucherHeader = this.MapToEntity(model);
                    var voucherdetails = this.ConvertVoucherModelToViewModel(voucherHeader.VoucherHeader.VoucherDetails);
                    return Json(voucherdetails, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (model.SaleBillHeaderid == 0)
                    {
                        var entity = this.MapToEntity(model);
                        db.SaleBillHeaders.Add(entity);
                        db.SaveChanges();
                    }
                    return Json(ConfirmationMessages.CreateSuccessConfirmation("Record Saved Successfully"));
                }
                
            }
            else
            {
                return View("Create", new SaleBillHeaderViewModel());
            }

            //return Json("Error Occurred While Saving");
            
        }

        private IEnumerable<VoucherViewModel> ConvertVoucherModelToViewModel(IEnumerable<VoucherDetail> detail)
        {
            return detail.Select(m => new VoucherViewModel
            {
                AccountID = m.AccountID,
                AccountName = Convert.ToString(accountsmanager.GetAccountNameById(m.AccountID).AccountName),
                Credit = m.Amount > 0 ? Math.Round(Math.Abs(m.Amount)) :0,
                Debit = m.Amount < 0 ? Math.Round(Math.Abs(m.Amount)) : 0,
                WasSuccessful = true
            });
        }
        private SaleBillHeader MapToEntity(SaleBillHeaderViewModel model)
        {
            var salebillheader = new SaleBillHeader
            {
                SaleBillHeaderid = model.SaleBillHeaderid,
                PartyAccountId = model.PartyAccountId,
                MyProperty  = model.MyProperty,
                InvoiceNo  = Convert.ToDecimal(model.InvoiceNo),
                Date  = model.Date,
                VoucherHeaderId = model.VoucherHeaderId,
                SaleOrderNo = model.SaleOrderNo,
                TotalAmount = model.TotalAmount,
                FreightAmount = model.FreightAmount,
                Taxamount = model.Taxamount,
                Narration = model.Narration,
                DiscountAmount = model.DiscountAmount,
                GodownId = model.GodownId,
                SaleBillDetails = ConvertViewModelToModel(model.SaleBillDetails)
            };
            salebillheader.VoucherHeader = CreateVouhcer(salebillheader);
            return salebillheader;
        }

        private List<SaleBillDetail> ConvertViewModelToModel(List<SaleBillDetailViewModel> model)
        {
            return model.Select(m => new SaleBillDetail { 
            SaleBillDetailId = m.SaleBillDetailId,
            SaleBillHeaderid = m.SaleBillHeaderid,
            ItemId = m.ItemId,
            Description = m.Description,
            Bags = m.Bags,
            PackingSizeId = m.PackingSizeId,
            Quantity = m.Quantity,
            Rate = m.Rate,
            TaxableAmount = m.TaxableAmount,
            CGSTAmount = m.CGSTAmount,
            CGSTPer = m.CGSTPer,
            SGSTAmount = m.SGSTAmount,
            SGSTPer = m.SGSTPer,
            IGSTAmount = m.IGSTAmount,
            IGSTPer = m.IGSTPer,
            TotalAmount = m.TotalAmount,
            GSTRate = m.GSTRate,
            TaxAmount = m.TaxAmount,
            TaxClassId = m.TaxId          
        }).ToList();
       }

        //public ActionResult GetSaleBill()
        //{
        //    var saledetail = this.db.SaleBillHeaders.Include(x => x.SaleBillDetails)
        //        .Include(x => x.p)
        //}

        private VoucherHeaders CreateVouhcer(SaleBillHeader model)
        {
            VoucherHeaders voucherheader = new VoucherHeaders()
            {
                VoucherDate = model.Date,
                VoucherHeaderID = model.VoucherHeaderId,
                VoucherTypeSeriesID = model.VoucherHeaderId,
                HistoryHeaderID = model.VoucherHeaderId                 
            };
            List<VoucherDetail> voucherdetail = new List<VoucherDetail>();
            Int64 SaleAccountId = 0;
            foreach (var item in model.SaleBillDetails)
            {
                 SaleAccountId = Convert.ToInt64(itemManager.GetItemAccountById(item.ItemId).SaleAccountId);
                //Debit To PartyAccount
                voucherdetail.Add(new VoucherDetail()
                {
                    VoucherHeaderID = voucherheader.VoucherHeaderID,
                    AccountID = SaleAccountId,
                    SAccountID = model.PartyAccountId,
                    Amount = item.TaxableAmount,
                    BillNo = model.InvoiceNo.ToString(),
                    InstrumentNo = model.InvoiceNo.ToString(),
                    InstrumentDesc = model.InvoiceNo.ToString(),
                    Narration = model.SaleBillDetails.Select(x => x.Description).FirstOrDefault()
                });

                if (item.SGSTAmount > 0)
                {
                    voucherdetail.Add(new VoucherDetail()
                    {
                        VoucherHeaderID = voucherheader.VoucherHeaderID,
                        AccountID = Convert.ToInt64(Variables.SGSTACCOUNT),
                        SAccountID = model.PartyAccountId,
                        Amount = item.SGSTAmount,
                        BillNo = model.InvoiceNo.ToString(),
                        InstrumentNo = model.InvoiceNo.ToString(),
                        InstrumentDesc = model.InvoiceNo.ToString(),
                        Narration = model.SaleBillDetails.Select(x => x.Description).FirstOrDefault()
                    });  
                }

                if (item.CGSTAmount > 0)
                {
                    voucherdetail.Add(new VoucherDetail()
                    {
                        VoucherHeaderID = voucherheader.VoucherHeaderID,
                        AccountID = Convert.ToInt64(Variables.CGSTACCOUNT),
                        SAccountID = model.PartyAccountId,
                        Amount = item.CGSTAmount,
                        BillNo = model.InvoiceNo.ToString(),
                        InstrumentNo = model.InvoiceNo.ToString(),
                        InstrumentDesc = model.InvoiceNo.ToString(),
                        Narration = model.SaleBillDetails.Select(x => x.Description).FirstOrDefault()
                    });
                }

                if (item.IGSTAmount > 0)
                {
                    voucherdetail.Add(new VoucherDetail()
                    {
                        VoucherHeaderID = voucherheader.VoucherHeaderID,
                        AccountID = Convert.ToInt64(Variables.IGSTACCOUNT),
                        SAccountID = model.PartyAccountId,
                        Amount = item.IGSTAmount,
                        BillNo = model.InvoiceNo.ToString(),
                        InstrumentNo = model.InvoiceNo.ToString(),
                        InstrumentDesc = model.InvoiceNo.ToString(),
                        Narration = model.SaleBillDetails.Select(x => x.Description).FirstOrDefault()
                    });
                }                
            }
            //credit To supplier
            voucherdetail.Add(new VoucherDetail()
            {
                VoucherHeaderID = voucherheader.VoucherHeaderID,
                AccountID = model.PartyAccountId,
                SAccountID = SaleAccountId,
                Amount = model.TotalAmount * -1,
                BillNo = model.InvoiceNo.ToString(),
                InstrumentNo = model.InvoiceNo.ToString(),
                InstrumentDesc = model.InvoiceNo.ToString(),
                Narration = model.SaleBillDetails.Select(x => x.Description).FirstOrDefault()
            });
            voucherheader.VoucherDetails = voucherdetail;
            return voucherheader;            
        }                
             
   }
}