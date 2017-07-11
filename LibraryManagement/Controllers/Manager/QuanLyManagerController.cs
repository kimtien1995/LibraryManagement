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

        public ActionResult Xacnhanxoanguoidung(string maxoauser)
        {
            if (Session["quyen"].ToString() != "admin")
            {
                return Redirect("/TrangChu/Xem");
            }
            ViewBag.maxoauser = maxoauser;
            return View("~/Views/Manager/Quanlymanager/Xacnhanxoauser.cshtml");
        }

        public ActionResult Thuchienxoanguoidung(string maxoauser)
        {
            if (Session["quyen"].ToString() != "admin" )
            {
                return Redirect("/TrangChu/Xem");
            }
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                var user = db.NguoiDungs.First(s => s.manguoidung == maxoauser);

                db.NguoiDungs.Remove(user);
                db.SaveChanges();
            }
            return Redirect("/QuanLyManager/Xem");
        }

        public ActionResult Formsuaquyen(string manguoidung)
        {
            if (Session["quyen"].ToString() != "admin" )
            {
                return Redirect("/TrangChu/Xem");
            }
            LIBRARYDATAMODEL db = new LIBRARYDATAMODEL();

            NguoiDung nguoidung = db.NguoiDungs.First(s => s.manguoidung == manguoidung);
            ViewBag.nguoidung = nguoidung;
            return View("~/Views/Manager/Quanlymanager/Suaquyen.cshtml");
        }

        public ActionResult Thuchiensuaquyen(string manguoidung, string maloainguoidung, string khoanguoidung)
        {
            if (Session["quyen"].ToString() != "admin")
            {
                return Redirect("/TrangChu/Xem");
            }
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                var nguoidung = db.NguoiDungs.First(s => s.manguoidung == manguoidung);
                nguoidung.maloainguoidung = maloainguoidung;
                nguoidung.khoanguoidung = khoanguoidung;
                db.SaveChanges();
            }
            return Redirect("/QuanLyManager/Xem");
        }
    }
}