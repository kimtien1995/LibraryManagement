using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers.Manager
{
    public class QuanLyNapTienController : Controller
    {
        // GET: QuanLyNapTien
        public ActionResult Xem(string ma)
        {
            if (Session["quyen"].ToString() != "Admin" && Session["quyen"].ToString() != "manager")
            {
                return Redirect("/TrangChu/Xem");
            }
            List<LuocSuNapTien> naptien = new List<LuocSuNapTien>();
            int soluong;
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                naptien = db.LuocSuNapTiens.Include("NguoiDung").ToList();
                soluong = db.LuocSuNapTiens.Count();
            }
            ViewBag.sllistnaptien = soluong;
            ViewBag.listnaptien = naptien;
            return View("~/Views/Manager/Quanlynapthe/Luocsunaptien.cshtml");
        }
    }
}