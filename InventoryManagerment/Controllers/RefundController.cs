using InventoryManagerment.Models;
using InventoryManagerment.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagerment.Controllers
{
    public class RefundController : BaseController
    {
        // GET: Refund
        public ActionResult Index(string searchString,string note,string nameProduct,string nameStaff, DateTime? dateRefund, int status = 2, int page = 1, int pageSize = 10)
        {
            User user = (User)Session[Common.CommonConstants.USER_SESSION];
            TempData[Common.CommonConstants.PAGE_NAME] = "Phiếu trả";
            ViewBag.Title = "Tuấn Hoan - Phiếu Trả";
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
            else if(status == 1)
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
            var model = new DataAccess().ListAllRefundOnPagedlist(searchString,note,nameProduct,nameStaff,stt,dateRefund, page, pageSize);
            if (user.RoleID == 1)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Thêm phiếu trả";
            ViewBag.Title = "Tuấn Hoan - Thêm Phiếu Trả";
            SetViewBag();
            User user = (User)Session[Common.CommonConstants.USER_SESSION];
            ViewBag.User = (User)Session[Common.CommonConstants.USER_SESSION];
            return View();
        }
        [HttpPost]
        public JsonResult Create(List<ListRefund> model)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Thêm phiếu trả";
            ViewBag.Title = "Tuấn Hoan - Thêm Phiếu Trả";
            SetViewBag();
            bool result = new DataAccess().InsertRefund(model, GetUserName());
            if (result)
            {
                SetAlert("Thêm phiếu trả thành công", "success");
            }
            else
            {
                SetAlert("Thêm phiếu trả thất bại", "danger");
            }
            return Json("SUCCESS", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Chỉnh sửa phiếu trả";
            ViewBag.Title = "Tuấn Hoan - Chỉnh Sửa Phiếu Trả";
            SetViewBag();
            User user = (User)Session[Common.CommonConstants.USER_SESSION];
            var model = new DataAccess().GetRefundForm(id);
            if (user.RoleID == 1)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public JsonResult Edit(List<ListRefund> model)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Chỉnh sửa phiếu trả";
            ViewBag.Title = "Tuấn Hoan - Chỉnh Sửa Phiếu Trả";
            SetViewBag();
            bool result = new DataAccess().UpdateRefund(model,GetUserName());
            if (result)
            {
                SetAlert("Cập nhật phiếu trả thành công", "success");
            }
            else
            {
                SetAlert("Cập nhật phiếu trả thất bại", "danger");
            }
            return Json("SUCCESS", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(long id)
        {
            User user = (User)Session[Common.CommonConstants.USER_SESSION];
            if (user.RoleID == 1)
            {
                new DataAccess().DeleteRefund(id,GetUserName());
            }
            return RedirectToAction("Index");
        }
        public void SetViewBag()
        {
            ViewBag.Unit = new DataAccess().ListAllUnitToViewBag();
            ViewBag.Product = new DataAccess().ListAllProductToViewBag();
            ViewBag.Customer = new DataAccess().ListtAllCustomerToViewBag();
        }
        public void ChangeStatus(string code)
        {
            code = code.Substring(1, code.Length - 1);
            new DataAccess().ChangeStatus(code, "refund");
        }
        [HttpGet]
        public JsonResult GetDataRefund(string code)
        {
            var listRefund = new DataAccess().GetDataRefund(code);
            return Json(listRefund, JsonRequestBehavior.AllowGet);
        }
    }
}