using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers.Manager
{
    public class QuanLyManagerController : Controller
    {
        // GET: QuanLyManager
        public ActionResult Xem()
        {

            List<NguoiDung> manager = new List<NguoiDung>();
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                manager = db.NguoiDungs.Include("LoaiNguoiDung").Where(s => s.maloainguoidung == "5").ToList();
            }

            ViewBag.managers = manager;
            return View("~/Views/Manager/Quanlymanager/Xemqlmanager.cshtml");
        }
    }
}