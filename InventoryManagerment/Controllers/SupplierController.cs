using InventoryManagerment.Models;
using InventoryManagerment.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagerment.Controllers
{
    public class SupplierController : AdminController
    {
        // GET: Supplier
        [HttpGet]
        public ActionResult Index(string searchString, int page = 1,int pageSize=10)
        {
            ViewBag.Title = "Tuấn Hoan - Nhà Cung Cấp";
            TempData[Common.CommonConstants.PAGE_NAME] = "Danh sách nhà cung cấp";
            var model = new DataAccess().ListAllSupplierOnPagedList(searchString,page,pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = "Tuấn Hoan - Thêm Nhà Cung Cấp";
            TempData[Common.CommonConstants.PAGE_NAME] = "Thêm nhà cung cấp";
            return View();
        }
        [HttpPost]
        public ActionResult Create(Supplier model)
        {
            ViewBag.Title = "Tuấn Hoan - Thêm Nhà Cung Cấp";
            TempData[Common.CommonConstants.PAGE_NAME] = "Thêm nhà cung cấp";
            var result = new DataAccess().InsertSupplier(model,GetUserName());
            if (result)
            {
                SetAlert("Thêm nhà cung cấp thành công", "success");
                ModelState.Clear();
            }
            else
            {
                SetAlert("Thêm nhà cung cấp thất bại","danger");
            }
            return View();
        }
        [HttpGet]
        public ActionResult CreateSupply(long id)
        {
            ViewBag.Title = "Tuấn Hoan - Thêm Sản Phẩm Nhà Cung Cấp";
            TempData[Common.CommonConstants.PAGE_NAME] = "Thêm sản phẩm nhà cung cấp";
            var model = new SupplyDetail();
            model.SupplierID = id;
            SetViewBag();
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateSupply(SupplyDetail model)
        {
            ViewBag.Title = "Tuấn Hoan - Thêm Sản Phẩm Nhà Cung Cấp";
            TempData[Common.CommonConstants.PAGE_NAME] = "Thêm sản phẩm nhà cung cấp";
            SetViewBag();
            var obj = new SupplyDetail();
            obj.SupplierID = model.SupplierID;
            if (new DataAccess().CheckSupply(model))
            {
                var result = new DataAccess().InsertSupply(model, GetUserName(), model.SupplierID);
                if (result)
                {
                    SetAlert("Thêm sản phẩm cho nhà cung cấp này thành công", "success");
                    ModelState.Clear();
                }
                else
                {
                    SetAlert("Thêm sản phẩm thất bại", "danger");
                }
            }                    
            return View(obj);
        }
        [HttpGet]
        public ActionResult Detail(long id)
        {            
            var supplier = new DataAccess().GetSupplier(id,"");
            ViewBag.Title = "Tuấn Hoan - Thông Tin Nhà Cung Cấp " + supplier.Name;
            TempData[Common.CommonConstants.PAGE_NAME] = "Thông tin nhà cung cấp " + supplier.Name;
            var listSupply = new DataAccess().GetListSupply(id);
            var model = new SupplierInformation();
            model.supllier = supplier;
            model.listSupply = listSupply;           
            return View(model);
        }
        [HttpGet]
        public ActionResult EditSupply(long id)
        {
            ViewBag.Title = "Tuấn Hoan - Cập Nhật Sản Phẩm Nhà Cung Cấp";
            TempData[Common.CommonConstants.PAGE_NAME] = "Cập nhật sản phẩm nhà cung cấp";
            var model = new DataAccess().GetSupply(id);
            SetViewBag(model.ProductCode, model.UnitID);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditSupply(SupplyDetail model)
        {
            ViewBag.Title = "Tuấn Hoan - Cập Nhật Sản Phẩm Nhà Cung Cấp";
            TempData[Common.CommonConstants.PAGE_NAME] = "Cập nhật sản phẩm nhà cung cấp";
            SetViewBag(model.ProductCode, model.UnitID);
            if (new DataAccess().CheckSupply(model))
            {
                bool result = new DataAccess().UpdateSupply(model, GetUserName());
                if (result)
                {
                    SetAlert("Cập nhật sản phẩm thành công", "success");
                }
                else
                {
                    SetAlert("Cập nhật sản phẩm thất bại", "success");
                }
            }
            else
            {
                SetAlert("Sản phẩm đã được cung cấp bởi nhà cung cấp này", "danger");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditSupplier(long id)
        {
            ViewBag.Title = "Tuấn Hoan - Cập Nhật Nhà Cung Cấp";
            TempData[Common.CommonConstants.PAGE_NAME] = "Cập nhật nhà cung cấp";
            var model = new DataAccess().GetSupplier(id,"");
            return View(model);
        }
        [HttpPost]
        public ActionResult EditSupplier(Supplier model)
        {
            ViewBag.Title = "Tuấn Hoan - Cập Nhật Nhà Cung Cấp";
            TempData[Common.CommonConstants.PAGE_NAME] = "Cập nhật nhà cung cấp";
            if (new DataAccess().CheckSupplier(model))
            {
                if(new DataAccess().UpdateSupplier(model,GetUserName()))
                {
                    SetAlert("Cập nhật nhà cung cấp thành công", "success");
                }
                else
                {
                    SetAlert("Cập nhật nhà cung cấp thất bại", "danger");
                }
            }
            else
            {
                SetAlert("Tên nhà cung cấp đã tồn tại vui lòng thử lại", "warning");
            }
            return View();
        }
        [HttpPost]
        public ActionResult DeleteSupply(long id)
        {
            bool result = new DataAccess().DeleteSupply(id,GetUserName());
            return RedirectToAction("Detail");
        }
        [HttpPost]
        public ActionResult DeleteSupplier(long id)
        {
            bool result = new DataAccess().DeleteSupplier(id, GetUserName());
            return RedirectToAction("Index");
        }
        public void SetViewBag(string selectedid = null,long? selectedunit = null)
        {
            var list = new DataAccess().ListAllProductToViewBag();
            ViewBag.ProductCode = new SelectList(list, "Code", "Name", selectedid);
            var listUnit = new DataAccess().ListAllUnitToViewBag();
            ViewBag.UnitID = new SelectList(listUnit, "ID", "Name", selectedunit);
        }
        public JsonResult GetDetailSupplier(long code)
        {
            var model = new DataAccess().GetDetailSupplier(code);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}