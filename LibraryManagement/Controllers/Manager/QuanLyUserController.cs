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
                nguoidungs = db.NguoiDungs.Include("LoaiNguoiDung").Where(s => s.maloainguoidung == "1" || s.maloainguoidung == "2").ToList();
                soluong = db.NguoiDungs.Count(s => s.maloainguoidung == "1" || s.maloainguoidung == "2");
            }
            ViewBag.soluongnd = soluong;
            ViewBag.nguoidungs = nguoidungs;
            return View("~/Views/Manager/Quanlyuser/Xemqluser.cshtml");
        }

        public ActionResult Formthemnguoidung()
        {
            return View("~/Views/Manager/Quanlyuser/Formthemuser.cshtml");
        }

        public ActionResult Thuchienthemnguoidung()
        {
            return View("~/Views/Manager/Quanlyuser/Xemqluser.cshtml");
        }

        public ActionResult Xacnhanxoanguoidung(string maxoauser)
        {
            ViewBag.maxoauser = maxoauser;
            return View("~/Views/Manager/Quanlyuser/Xacnhanxoauser.cshtml");
        }

        public ActionResult Thuchienxoanguoidung(string maxoauser)
        {
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                var user = db.NguoiDungs.First(s => s.manguoidung == maxoauser);
                db.NguoiDungs.Remove(user);
                db.SaveChanges();
            }
            return Redirect("~/QuanLyUser/Xem");
        }

        public ActionResult Formsuaquyen(string manguoidung)
        {
            ViewBag.masuaquyen = manguoidung;
            return View("~/Views/Manager/Quanlyuser/Suaquyen.cshtml");
        }

        public ActionResult Thuchiensuaquyen(string manguoidung)
        {
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                var nguoidung = db.NguoiDungs.First(s => s.manguoidung == manguoidung);
                nguoidung.maloainguoidung = Request.Form["loainguoidung"].ToString();
                db.SaveChanges();
            }
            return Redirect("~/QuanLyUser/Xem");
        }
    }
}