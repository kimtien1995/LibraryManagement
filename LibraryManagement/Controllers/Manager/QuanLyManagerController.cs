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
            if (Session["quyen"].ToString() != "admin")
            {
                return Redirect("/TrangChu/Xem");
            }


            List<NguoiDung> manager = new List<NguoiDung>();
            LIBRARYDATAMODEL db = new LIBRARYDATAMODEL();
            manager = db.NguoiDungs.Include("LoaiNguoiDung").Where(s => s.maloainguoidung == "5").ToList();
            int soluong = db.NguoiDungs.Count(s => s.maloainguoidung == "5");
            ViewBag.slmanager = soluong;
            ViewBag.managers = manager;
            return View("~/Views/Manager/Quanlymanager/Xemqlmanager.cshtml");
        }
    }
}