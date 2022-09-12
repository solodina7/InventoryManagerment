using InventoryManagerment.Models;
using InventoryManagerment.Models.EF;
using InventoryManagerment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagerment.Controllers
{
    public class ListReceiptExportController : BaseController
    {
        // GET: ListReceipt
        public ActionResult Index(string searchString,DateTime? dateExport,int page =1,int pageSize =10)
        {
            ViewBag.Title = "Tuấn Hoan - Phiếu Xuất Của Nhân Viên " + new DataAccess().GetUser(GetUserName()).Name.ToUpper();
            TempData[Common.CommonConstants.PAGE_NAME] = "Phiếu xuất của nhân viên " + new DataAccess().GetUser(GetUserName()).Name;
            ViewBag.searchString = searchString;
            if (dateExport.HasValue)
            {
                ViewBag.dateExport = dateExport.Value.ToString("yyyy-MM-dd");
            }
            var model = new DataAccess().ListAllReceiptExportOnPagedlist(searchString, dateExport, GetUserName(), false, page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Chỉnh sửa phiếu xuất";
            ViewBag.Title = "Tuấn Hoan - Chỉnh Sửa Phiếu Xuất";
            var model = new DataAccess().GetExportForm(id);
            SetViewBag();
            return View(model);
        }
        [HttpPost]
        public JsonResult Edit(List<ListExport> model)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Chỉnh sửa phiếu xuất";
            ViewBag.Title = "Tuấn Hoan - Chỉnh Sửa Phiếu Xuất";
            int result = new DataAccess().UpdateExportForStaff(model,GetUserName());
            switch (result)
            {
                case -1:
                    SetAlert("Phiếu xuất đã được duyệt, không thể chỉnh sửa", "danger");
                    break;
                case 0:
                    SetAlert("Cập nhật thất bại", "danger");
                    break;
                case 1:
                    SetAlert("Cập nhật phiếu xuất thành công", "success");
                    break;
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(long id)
        {
            new DataAccess().DeleteExportForStaff(id, GetUserName());
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