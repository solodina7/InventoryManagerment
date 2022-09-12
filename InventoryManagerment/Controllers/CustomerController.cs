using InventoryManagerment.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagerment.Controllers
{
    public class CustomerController : AdminController
    {
        // GET: Customer
        public ActionResult Index(string searchString,string phone,string address,int page=1,int pageSize=10)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Khách hàng";
            ViewBag.Title = "Tuấn Hoan - Khách Hàng";
            if (pageSize != 10)
            {
                ViewBag.pageSize = pageSize;
            }
            ViewBag.searchString = searchString;
            ViewBag.phone = phone;
            ViewBag.address = address;
            var model = new DataAccess().ListAllCustomerOnPagedlist(searchString,phone,address,page,pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Thêm khách hàng";
            ViewBag.Title = "Tuấn Hoan - Thêm Khách Hàng";
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Thêm khách hàng";
            ViewBag.Title = "Tuấn Hoan - Thêm Khách Hàng";
            bool result = new DataAccess().InsertCustomer(customer,GetUserName());
            if (result)
            {
                SetAlert("Thêm khách hàng mới thành công","success");
                ModelState.Clear();
            }
            else
            {
                SetAlert("Thêm khách hàng mới thất bại", "success");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Chỉnh sửa khách hàng";
            ViewBag.Title = "Tuấn Hoan - Chỉnh Sửa Khách Hàng";
            var model = new DataAccess().GetCustomer(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Customer model)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Chỉnh sửa khách hàng";
            ViewBag.Title = "Tuấn Hoan - Chỉnh Sửa Khách Hàng";
            bool result = new DataAccess().UpdateCustomer(model, GetUserName());
            if (result)
            {
                SetAlert("Cập nhật khách mới thành công", "success");
            }
            else
            {
                SetAlert("Cập nhật khách hàng thất bại", "success");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(long id)
        {
            new DataAccess().DeleteCustomer(id, GetUserName());
            return RedirectToAction("Index");
        }
    }
}