using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryManagerment.Models.EF;

namespace InventoryManagerment.Controllers
{
    public class PackageController : AdminController
    {
        // GET: Package
        public ActionResult Index(string searchString,int page=1,int pageSize=10)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Đóng gói";
            ViewBag.Title = "Tuấn Hoan - Đóng Gói";
            var model = new DataAccess().ListAllPackageOnPagedlist(searchString,page,pageSize);
            ViewBag.searchString = searchString;
            if(pageSize != 10)
            {
                ViewBag.pageSize = pageSize;
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Thêm cách đóng gói";
            ViewBag.Title = "Tuấn Hoan - Thêm Cách Đóng Gói";            
            return View();
        }
        [HttpPost]
        public ActionResult Create(Package model)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Thêm cách đóng gói";
            ViewBag.Title = "Tuấn Hoan - Thêm Cách Đóng Gói";
            if (model.Name == null)
            {
                return View();
            }
            var result = new DataAccess().InsertPackage(model,GetUserName());
            if (result)
            {
                SetAlert("Thêm cách đóng gói thành công", "success");
                ModelState.Clear();
            }
            else
            {
                SetAlert("Thêm cách đóng gói thất bại", "danger");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Chỉnh sửa cách đóng gói";
            ViewBag.Title = "Tuấn Hoan - Chỉnh Sửa Cách Đóng Gói";
            var model = new DataAccess().GetPackage(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Package model)
        {
            var result = new DataAccess().UpdatePackage(model, GetUserName());
            if (result)
            {
                SetAlert("Cập nhật cách đóng gói thành công","success");
            }
            else
            {
                SetAlert("Cập nhật cách đóng gói thất bại", "danger");
            }
            return RedirectToAction("Edit");
        }
        [HttpPost]
        public ActionResult Delete(long id)
        {
            var result = new DataAccess().DeletePackage(id,GetUserName());
            return RedirectToAction("Index");
        }
    }
}