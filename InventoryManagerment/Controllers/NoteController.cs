using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagerment.Controllers
{
    public class NoteController : AdminController
    {
        // GET: Note
        public ActionResult Index(string searchString, string noteGhiChu,DateTime? dateNote,string status,int page=1,int pageSize =10)
        {
            TempData[Common.CommonConstants.PAGE_NAME] = "Số xuất";
            ViewBag.Title = "Tuấn Hoan - Danh Sách Sổ Xuất";
            ViewBag.searchString = searchString;
            if (dateNote.HasValue)
            {
                ViewBag.dateNote = dateNote.Value.ToString("yyyy-MM-dd");
            }            
            if(pageSize > 10)
            {
                ViewBag.pageSize = pageSize;
            }
            ViewBag.noteGhiChu = noteGhiChu;
            ViewBag.status = status;
            var model = new DataAccess2().ListAllNotesToPagedList(searchString,noteGhiChu,dateNote,status, page, pageSize);
            return View(model);
        }
        [HttpGet]
        public JsonResult GetDetailNote(string code)
        {
            string note = new DataAccess2().GetNote(code);
            return Json(note, JsonRequestBehavior.AllowGet);
        }
    }
}