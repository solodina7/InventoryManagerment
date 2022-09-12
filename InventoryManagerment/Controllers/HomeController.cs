using InventoryManagerment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagerment.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index(string searchString,long typeProduct=0,int page=1,int pageSize=10)
        {
            ViewBag.Title = "Tuấn Hoan - Dash Board";
            TempData[Common.CommonConstants.PAGE_NAME] = "Trang chủ";
            ViewBag.User = new DataAccess().GetUser(GetUserName());
            ViewBag.searchString = searchString;
            ViewBag.typeProduct = typeProduct;
            var model = new DataAccess().ListAllProductOnPagedlist(searchString, typeProduct, page, pageSize);
            return View(model);
        }
        public ActionResult Test()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult topNav()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public PartialViewResult leftMenu()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public PartialViewResult leftMenuStaff()
        {
            return PartialView();
        }
        public void SetViewBag() 
        {
            
        }
    }
}