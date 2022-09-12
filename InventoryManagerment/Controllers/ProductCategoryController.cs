using InventoryManagerment.Common;
using InventoryManagerment.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagerment.Controllers
{
    public class ProductCategoryController : AdminController
    {
        // GET: ProductCategory
        public ActionResult Index(string searchString,int page=1,int pageSize=10)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Loại sản phẩm";
            ViewBag.Title = "Tuấn Hoan - Loại Sản Phẩm";
            var model = new DataAccess().ListAllProductCategoryOnPagedlist(searchString,page,pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateProductCategory(ProductCategory model)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Thêm loại sản phẩm";
            ViewBag.Title = "Tuấn Hoan - Thêm Loại Sản Phẩm";
            var dao = new DataAccess();
            var session = (User)Session[CommonConstants.USER_SESSION];
            bool result = dao.InsertProductCategory(model, session.UserName);
            if (result)
            {
                ModelState.Clear();
                SetAlert("Tạo loại sản phẩm thành công", "success");
            }
            else
            {
                SetAlert("Tạo loại sản phẩm thất bại", "danger");
            }
            return View();
        }
        [HttpGet]
        public ActionResult CreateProductCategory()
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Thêm loại sản phẩm";
            ViewBag.Title = "Tuấn Hoan - Thêm Loại Sản Phẩm";
            return View();
        }
        [HttpGet]
        public ActionResult EditProductCategory(long id)
        {
            var dao = new DataAccess();
            var model = dao.GetProductCategory(id);
            TempData[Common.CommonConstants.PAGE_NAME] = "Chỉnh sửa loại sản phẩm";
            ViewBag.Title = "Tuấn Hoan - Chỉnh Sửa Loại Sản Phẩm";
            return View(model);
        }
        [HttpPost]
        public ActionResult EditProductCategory(ProductCategory model)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Chỉnh sửa loại sản phẩm";
            ViewBag.Title = "Tuấn Hoan - Chỉnh Sửa Loại Sản Phẩm";
            var result = new DataAccess().UpdateProductCategory(model, GetUserName());
            if (result)
            {
                SetAlert("Cập nhật sản phẩm thành công", "success");
            }
            else
            {
                SetAlert("Cập nhật sản phẩm thất bại", "danger");
            }
            return View();
        }
        [HttpPost]
        public ActionResult DeleteProductCategory(long id)
        {
            var dao = new DataAccess();
            bool result = dao.DeleteProductCategory(id, GetUserName());
            return RedirectToAction("Index");
        }
    }
}