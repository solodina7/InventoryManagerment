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
        public ActionResult Index(string searchString, string note, string nameProduct, string nameStaff, DateTime? dateRefund, int status = 2, int page = 1, int pageSize = 10)
        {
            ViewBag.Title = "Tuấn Hoan - Phiếu Xuất Của Nhân Viên " + new DataAccess().GetUser(GetUserName()).Name.ToUpper();
            TempData[Common.CommonConstants.PAGE_NAME] = "Phiếu trả của nhân viên " + new DataAccess().GetUser(GetUserName()).Name;
            bool? stt = null;
            ViewBag.status = status;
            ViewBag.searchString = searchString;
            ViewBag.note = note;
            ViewBag.nameProduct = nameProduct;
            ViewBag.nameStaff = nameStaff;
            if (status == 0)
            {
                stt = false;
            }
            else if (status == 1)
            {
                stt = true;
            }
            else
            {
                stt = null;
            }
            ViewBag.pageSize = pageSize;
            if (dateRefund.HasValue)
            {
                ViewBag.dateRefund = dateRefund.Value.ToString("yyyy-MM-dd");
            }
            var model = new DataAccess().ListAllReceiptRefundOnPagedlist(searchString, note, nameProduct, GetUserName(), stt, dateRefund, page, pageSize);
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
        public void Delete (long id)
        {
            new DataAccess().DeleteRefundForStaff(id, GetUserName());
        }
        public void SetViewBag()
        {
            ViewBag.Unit = new DataAccess().ListAllUnitToViewBag();
            ViewBag.Product = new DataAccess().ListAllProductToViewBag();
            ViewBag.Customer = new DataAccess().ListtAllCustomerToViewBag();
        }
        public JsonResult GetDataRefund(string code)
        {
            var listRefund = new DataAccess().GetDataRefund(code);
            return Json(listRefund, JsonRequestBehavior.AllowGet);
        }
    }
}