using InventoryManagerment.Common;
using InventoryManagerment.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagerment.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {           
            return View();
        }
        public ActionResult Login(InventoryManagerment.Models.LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var functions = new DataAccess();
                int result = functions.CheckUser(model);
                if (result == 1)
                {
                    var user = functions.GetUser(model.UserName);
                    Session.Add(CommonConstants.USER_SESSION, user);
                    Session.Timeout = 1440;
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Sai mật khẩu, vui lòng nhập lại mật khẩu");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại, vui nhập lại tài khoản");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản bạn đang bị khóa, vui lòng thử lại sau");
                }
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return View("Index");
        }
    }
}