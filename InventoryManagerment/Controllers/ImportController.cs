using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryManagerment.Common;
using InventoryManagerment.Models;
using InventoryManagerment.Models.EF;

namespace InventoryManagerment.Controllers
{
    public class ImportController : AdminController
    {
        // GET: Import
        public ActionResult Index(string searchString,string productName,string note,DateTime? dateImport, int page = 1,int pageSize=10)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Phiếu nhập";
            ViewBag.Title = "Tuấn Hoan - Phiếu Nhập";
            ViewBag.searchString = searchString;
            ViewBag.note = note;
            ViewBag.productName = productName;
            if (dateImport.HasValue)
            {
                ViewBag.dateImport = dateImport.Value.ToString("yyyy-MM-dd");
            }
            if (pageSize > 10)
            {
                ViewBag.pageSize = pageSize;
            }
            var model = new DataAccess().ListAllImportOnPagedList(searchString,productName,note, dateImport,false ,page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Thêm phiếu nhập";
            ViewBag.Title = "Tuấn Hoan - Thêm Phiếu Nhập";
            var dao = new DataAccess();
            ViewBag.UnitID = new SelectList(dao.ListAllUnitToViewBag(), "ID", "Name");
            ViewBag.CategoryID = new SelectList(dao.ListAllCategoryToViewBag(), "ID", "Name");
            ViewBag.PackageID = new SelectList(dao.ListtAllPackageToViewBag(), "ID", "Name");
            SetViewBag();
            return View();
        }
        [HttpPost]
        public JsonResult Create(List<ProductModel> listProduct)
        {
            ViewBag.Title = "Tuấn Hoan - Thêm Phiếu Nhập";
            TempData[Common.CommonConstants.PAGE_NAME] = "Thêm phiếu nhập";
            SetViewBag();
            bool result = new DataAccess().InsertImport(listProduct,GetUserName());
            if (result)
            {
                SetAlert("Thêm phiếu nhập thành công", "success");
            }
            return Json("Thêm phiếu nhập thành công",JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public void CreateProduct(Product product)
        {
            new DataAccess().InsertProduct(product, GetUserName());
        }
        [HttpPost]
        public void CreateSupplier (string name,string code)
        {
            var model = new Supplier();
            model.Name = name;
            model.Code = code;
            new DataAccess().InsertSupplier(model,GetUserName());
        }
        [HttpGet]
        public ActionResult Edit(long id) 
        { 
            TempData[Common.CommonConstants.PAGE_NAME] = "Chỉnh sửa phiếu nhập";
            ViewBag.Title = "Tuấn Hoan - Chỉnh Sửa Phiếu Nhập";
            SetViewBag();
            var model = new DataAccess().GetAllProduct(id);
            return View(model);
        }
        [HttpPost]
        public JsonResult Edit(List<ProductModel> model)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Chỉnh sửa phiếu nhập";
            ViewBag.Title = "Tuấn Hoan - Chỉnh Sửa Phiếu Nhập";

            SetViewBag();
            bool result = new DataAccess().UpdateImport(model,GetUserName());
            if (result)
            {
                SetAlert("Cập nhật phiếu nhập thành công", "success");               
            }
            else
            {
                SetAlert("Cập nhật phiếu nhập thất bại","danger");
            }
            return Json("success", JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(long id)
        {
            new DataAccess().DeleteImport(id,GetUserName());
            return RedirectToAction("Index");
        }
        [HttpGet]
        public JsonResult GetDataImport(string code)
        {
            var listImport = new DataAccess().GetDataImport(code);
            return Json(listImport, JsonRequestBehavior.AllowGet);
        }
        public void SetViewBag(long? id = null)
        {
            ViewBag.SupplierID = new SelectList(new DataAccess().ListAllSupplierToViewBag(), "ID", "Name", id);
            ViewBag.Supplier = new DataAccess().ListAllSupplierToViewBag();
            ViewBag.Unit = new DataAccess().ListAllUnitToViewBag();
            ViewBag.Package = new DataAccess().ListallPackageToViewBag();
            ViewBag.Product = new DataAccess().ListAllProductToViewBag();
        }
    }
}