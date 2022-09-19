using InventoryManagerment.Common;
using InventoryManagerment.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagerment.Controllers
{
    public class ProductController : AdminController
    {
        // GET: Product
        [HttpGet]
        public ActionResult Index(string searchString,long quantity = 0,long typeProduct=0,int page =1,int pageSize = 10)
        {
            var dao = new DataAccess();
            var model = dao.ListAllProductOnPagedlist(searchString,quantity,typeProduct,page,pageSize);
            ViewBag.searchProductString = searchString;
            TempData[Common.CommonConstants.PAGE_NAME] = "Sản phẩm";
            ViewBag.Title = "Tuấn Hoan - Sản Phẩm";
            // Danh mục sản phẩm
            ViewBag.ListProductCategory = dao.ListAllProductCategoryOnPagedlist(searchString,page,pageSize);
            ViewBag.searchCategoryString = searchString;
            if (pageSize > 10)
            {
                ViewBag.pageSize = pageSize;
            }
            return View(model);
        }       
        [HttpGet]
        public ActionResult EditProduct(long id)
        {
            var dao = new DataAccess();
            var model = dao.GetProduct(id);
            SetViewBag(model.UnitID,model.CategoryID,model.PackageID);
            TempData[Common.CommonConstants.PAGE_NAME] = "Chỉnh sửa sản phẩm";
            ViewBag.Title = "Tuấn Hoan - Chỉnh Sửa Sản Phẩm";
            return View(model);
        }
        [HttpPost]
        public ActionResult EditProduct(Product model)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Chỉnh sửa sản phẩm";
            ViewBag.Title = "Tuấn Hoan - Chỉnh Sửa Sản Phẩm";
            SetViewBag(model.UnitID, model.CategoryID, model.PackageID);
            var result = new DataAccess().UpdateProduct(model,GetUserName());
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
        public ActionResult Create(Product product)
        {
            TempData[CommonConstants.PAGE_NAME] = "Thêm sản phẩm";
            ViewBag.Title = "Tuấn Hoan - Thêm Sản Phẩm";
            var dao = new DataAccess();
            if (product.QuantityAlert == 0)
            {
                product.QuantityAlert = 0;
            }
            product.Code = Functions.CreateCode("SP");
            if (ModelState.IsValid)
            {              
                if (dao.InsertProduct(product,GetUserName()))
                {
                    ModelState.Clear();
                    SetAlert("Thêm sản phẩm thành công", "success");
                }
                else
                {
                    SetAlert("Thêm sản phẩm thất bại", "success");
                }
            }
            SetViewBag();
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Thêm sản phẩm";
            ViewBag.Title = "Tuấn Hoan - Thêm Sản Phẩm";
            SetViewBag();
            return View();
        }
        public void SetViewBag(long? idUnit = null,long? idCategory =null,long? idPackage = null)
        {
            var dao = new DataAccess();
            ViewBag.UnitID = new SelectList(dao.ListAllUnitToViewBag(), "ID", "Name", idUnit);
            ViewBag.CategoryID = new SelectList(dao.ListAllCategoryToViewBag(), "ID", "Name", idCategory);
            ViewBag.PackageID = new SelectList(dao.ListtAllPackageToViewBag(), "ID", "Name", idPackage);
        }
        [HttpPost]
        public ActionResult DeleteProduct(long id)
        {
            var dao = new DataAccess();
            bool result = dao.DeleteProduct(id,GetUserName());
            return RedirectToAction("Index");
        }
    }
}