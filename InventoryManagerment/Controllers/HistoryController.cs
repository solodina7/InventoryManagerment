using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagerment.Controllers
{
    public class HistoryController : AdminController
    {
        // GET: History
        public ActionResult Index(DateTime? time, string actionKey, int page = 1,int pageSize = 20)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Lịch sử hoạt động";
            ViewBag.Title = "Tuấn Hoan - Lịch Sử Hoạt Động";
            ViewBag.actionKey = actionKey;
            if (time.HasValue)
            {
                ViewBag.time = time.Value.ToString("yyyy-MM-dd");
            }
            var model = new DataAccess().GetHistory(time, actionKey, page, pageSize);
            return View(model);
        }
        public ActionResult Receipt(DateTime? time, string actionKey, int page = 1, int pageSize = 20)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Lịch sử các phiếu";
            ViewBag.Title = "Tuấn Hoan - Lịch Sử Các Phiếu";
            ViewBag.actionKey = actionKey;
            ViewBag.time = time;
            if (time.HasValue)
            {
                ViewBag.time = time.Value.ToString("yyyy-MM-dd");
            }
            var model = new DataAccess().GetHistoryReceipt(time, actionKey, page, pageSize);
            return View(model);
        }
        public ActionResult DetailRefund(long id)
        {
            var db = new InventoryManagerment.Models.EF.InventoryDbContext();
            TempData[Common.CommonConstants.PAGE_NAME] = "Phiếu trả "+db.Refunds.Find(id).Code;
            ViewBag.Title = "Tuấn Hoan - Lịch Sử Các Phiếu";
            var model = new DataAccess().GetRefundForm(id);
            SetViewBag();
            return View(model);
        }
        public ActionResult DetailExport(long id)
        {
            var db = new InventoryManagerment.Models.EF.InventoryDbContext();
            TempData[Common.CommonConstants.PAGE_NAME] = "Phiếu xuất "+db.Exports.Find(id).Code;
            ViewBag.Title = "Tuấn Hoan - Lịch Sử Các Phiếu";
            var model = new DataAccess().GetExportForm(id);
            SetViewBag();
            return View(model);
        }
        public ActionResult DetailImport(long id)
        {
            var db = new InventoryManagerment.Models.EF.InventoryDbContext();
            TempData[Common.CommonConstants.PAGE_NAME] = "Phiếu nhập "+db.Imports.Find(id).Code;
            ViewBag.Title = "Tuấn Hoan - Lịch Sử Các Phiếu";
            var model = new DataAccess().GetAllProduct(id);
            SetViewBag();
            return View(model);
        }
        public ActionResult ReceiptDeleted()
        {
            return View();
        }
        public void SetViewBag()
        {
            ViewBag.Unit = new DataAccess().ListAllUnitToViewBag();
            ViewBag.Product = new DataAccess().ListAllProductToViewBag();
            ViewBag.Customer = new DataAccess().ListtAllCustomerToViewBag();
        }
    }
}