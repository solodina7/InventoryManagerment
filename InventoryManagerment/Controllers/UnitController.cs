using InventoryManagerment.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagerment.Controllers
{
    public class UnitController : AdminController
    {
        // GET: Unit
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Đơn vị tính";
            ViewBag.Title = "Tuấn Hoan - Đơn Vị Tính";
            var dao = new DataAccess();
            var model = dao.ListAllUnitOnPagedlist(searchString,page,pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Thêm đơn vị tính";
            ViewBag.Title = "Tuấn Hoan - Thêm Đơn Vị Tính";
            return View();
        }
        [HttpPost]
        public ActionResult Create(Unit model)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Thêm đơn vị tính";
            ViewBag.Title = "Tuấn Hoan - Thêm Đơn Vị Tính";
            var result = new DataAccess().InsertUnit(model, GetUserName());
            if (result)
            {
                SetAlert("Thêm đơn vị tính thành công", "success");
                ModelState.Clear();
            }
            else
            {
                SetAlert("Thêm đơn vị tính thất bại", "danger");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Chỉnh sửa đơn vị tính";
            ViewBag.Title = "Tuấn Hoan - Chỉnh Sửa Đơn Vị Tính";
            var dao = new DataAccess();
            var model = dao.GetUnit(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Unit model)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Chỉnh sửa đơn vị tính";
            ViewBag.Title = "Tuấn Hoan - Chỉnh Sửa Đơn Vị Tính";
            var dao = new DataAccess();
            bool result = dao.UpdateUnit(model, GetUserName());
            if (result)
            {
                SetAlert("Cập nhật đơn vị tính thành công", "success");
            }
            else
            {
                SetAlert("Cập nhật đơn vị tính thất bại", "danger");
            }
            return View();
        }
        public ActionResult Delete(long id)
        {
            var dao = new DataAccess();
            bool result = dao.DeleteUnit(id, GetUserName());
            return RedirectToAction("Index");
        }
    }
}