using InventoryManagerment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagerment.Controllers
{
    public class ListReceiptRefundController : BaseController
    {
        // GET: ListReceiptRefund
        public ActionResult Index(string searchString,DateTime? dateRefund,int page =1 ,int pageSize=10)
        {
            ViewBag.Title = "Tuấn Hoan - Phiếu Xuất Của Nhân Viên " + new DataAccess().GetUser(GetUserName()).Name.ToUpper();
            TempData[Common.CommonConstants.PAGE_NAME] = "Phiếu trả của nhân viên " + new DataAccess().GetUser(GetUserName()).Name;
            ViewBag.searchString = searchString;
            if (dateRefund.HasValue)
            {
                ViewBag.dateExport = dateRefund.Value.ToString("yyyy-MM-dd");
            }
            var model = new DataAccess().ListAllReceiptRefundOnPagedlist(searchString, dateRefund, GetUserName(), false, page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Chỉnh sửa phiếu trả";
            ViewBag.Title = "Tuấn Hoan - Chỉnh Sửa Phiếu Trả";
            var model = new DataAccess().GetRefundForm(id);
            SetViewBag();
            return View(model);
        }
        [HttpPost]
        public JsonResult Edit(List<ListRefund> model)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Chỉnh sửa phiếu trả";
            ViewBag.Title = "Tuấn Hoan - Chỉnh Sửa Phiếu Trả";
            int result = new DataAccess().UpdateRefundForStaff(model, GetUserName());
            switch (result)
            {
                case -1:
                    SetAlert("Phiếu trả đã được duyệt, không thể chỉnh sửa", "danger");
                    break;
                case 0:
                    SetAlert("Cập nhật phiếu trả thất bại", "danger");
                    break;
                case 1:
                    SetAlert("Cập nhật phiếu trả thành công", "success");
                    break;
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete (long id)
        {
            new DataAccess().DeleteRefundForStaff(id, GetUserName());
            return RedirectToAction("Index");
        }
        public void SetViewBag()
        {
            ViewBag.Unit = new DataAccess().ListAllUnitToViewBag();
            ViewBag.Product = new DataAccess().ListAllProductToViewBag();
            ViewBag.Customer = new DataAccess().ListtAllCustomerToViewBag();
        }
    }
}