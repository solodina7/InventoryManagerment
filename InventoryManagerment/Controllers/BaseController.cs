using InventoryManagerment.Common;
using InventoryManagerment.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InventoryManagerment.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //kiem tra session da ghi thong tin user login chua
            var session = (User)Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index"}));
            }
            base.OnActionExecuting(filterContext);
        }
        protected void SetAlert(string messenger, string type)
        {
            TempData["AlertMessenger"] = messenger;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if(type == "danger")
            {
                TempData["AlertType"] = "alert-danger";
            }
            else
            {
                TempData["AlertType"] = "alert-warning";
            }
        }
        protected string GetUserName()
        {
            var user = (User)Session[Common.CommonConstants.USER_SESSION];
            return user.UserName;
        }
    }
}