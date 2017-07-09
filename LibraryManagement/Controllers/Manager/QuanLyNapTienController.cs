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
            List<LuocSuNapTien> naptien = new List<LuocSuNapTien>();
            int soluong;
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                naptien = db.LuocSuNapTiens.Include("NguoiDung").Where(s => s.manguoidung == ma).ToList();
                soluong = db.LuocSuNapTiens.Count(s => s.manguoidung == ma);
            }
            ViewBag.sllistnaptien = soluong;
            ViewBag.listnaptien = naptien;
            return View("~/Views/User/Trangcanhan/Luocsunaptien.cshtml");
        }
    }
}