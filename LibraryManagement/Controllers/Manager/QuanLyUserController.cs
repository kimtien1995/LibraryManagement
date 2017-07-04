using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers.Manager
{
    public class QuanLyUserController : Controller
    {
        // GET: QuanLyUser
        public ActionResult Xem()
        {
            List<NguoiDung> nguoidungs = new List<NguoiDung>();
            int soluong;
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                nguoidungs = db.NguoiDungs.Include("LoaiNguoiDung").Where(s => s.maloainguoidung == "1" && s.maloainguoidung == "2").ToList();
                soluong = db.NguoiDungs.Count();
            }
            ViewBag.soluongnd = soluong;
            ViewBag.nguoidungs = nguoidungs;
            return View("~/Views/Manager/Quanlyuser/Xemqluser.cshtml");
        }
    }
}