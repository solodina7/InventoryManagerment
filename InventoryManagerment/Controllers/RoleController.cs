using InventoryManagerment.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagerment.Controllers
{
    public class RoleController : AdminController
    {
        // GET: Role
        public ActionResult Index(string searchString,int page = 1,int pageSize =10)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Chức vụ";
            var model = new DataAccess().ListAllRoleOnPagedlist(searchString,page,pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Chỉnh sửa chức vụ";
            var model = new DataAccess().GetRole(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Role model)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Chỉnh sửa chức vụ";
            var result = new DataAccess().UpdateRole(model, GetUserName());
            if (result)
            {
                SetAlert("Cập nhật chức vụ thành công", "success");

            }
            else
            {
                SetAlert("Cập nhật chức vụ thất bại", "danger");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Thêm chức vụ";
            return View();
        }
        [HttpPost]
        public ActionResult Create(Role model)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Thêm chức vụ";
            if (model.Name == null)
            {
                return View();
            }
            var result = new DataAccess().InsertRole(model,GetUserName());
            if (result)
            {
                SetAlert("Thêm chức vụ thành công", "success");
                ModelState.Clear();
            }
            else
            {
                SetAlert("Thêm chức vụ thất bại", "danger");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(long id)
        {
            var result = new DataAccess().DeleteRole(id, GetUserName());
            return RedirectToAction("Index");
        }
    }
}