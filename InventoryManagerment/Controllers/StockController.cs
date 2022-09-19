using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagerment.Controllers
{
    public class StockController : AdminController
    {
        // GET: Stock
        public ActionResult Index(string searchString,long quantity = 0,long typeProduct = 0, int page = 1,int pageSize =10)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Quản lý kho";
            ViewBag.Title = "Tuấn Hoan - Quản Lý Kho";
            ViewBag.searchString = searchString;
            ViewBag.quantity = quantity;
            ViewBag.typeProduct = typeProduct;
            ViewBag.pageSize = pageSize;
            var model = new DataAccess().ListAllProductOnPagedlist(searchString,quantity,typeProduct, page,pageSize);
            return View(model);
        }
    }
}