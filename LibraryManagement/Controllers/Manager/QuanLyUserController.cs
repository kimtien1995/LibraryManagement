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
            if (Session["quyen"].ToString() != "admin" && Session["quyen"].ToString() != "manager")
            {
                return Redirect("/TrangChu/Xem");
            }
            if (Session["quyen"].ToString() != "admin" && Session["quyen"].ToString() != "manager")
            {
                return Redirect("/TrangChu/Xem");
            }
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
        public ActionResult Xemchitietuser(string manguoidung)
        {

            if (Session["quyen"].ToString() != "admin" && Session["quyen"].ToString() != "manager")
            {
                return Redirect("/TrangChu/Xem");
            }
            NguoiDung chitietnd = new NguoiDung();
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                chitietnd = db.NguoiDungs.Include("LoaiNguoiDung").FirstOrDefault(s => s.manguoidung == manguoidung);
            }
            ViewBag.chitietnd = chitietnd;
            return View("~/Views/Manager/Quanlyuser/Chitietuser.cshtml");
        }

        public ActionResult Formthemnguoidung()
        {
            if (Session["quyen"].ToString() != "admin" && Session["quyen"].ToString() != "manager")
            {
                return Redirect("/TrangChu/Xem");
            }
            return View("~/Views/Manager/Quanlyuser/Formthemuser.cshtml");
        }

        public ActionResult Thuchienthemnguoidung()
        {
            if (Session["quyen"].ToString() != "admin" && Session["quyen"].ToString() != "manager")
            {
                return Redirect("/TrangChu/Xem");
            }
            return View("~/Views/Manager/Quanlyuser/Xemqluser.cshtml");
        }

        public ActionResult Xacnhanxoanguoidung(string maxoauser)
        {
            if (Session["quyen"].ToString() != "admin" && Session["quyen"].ToString() != "manager")
            {
                return Redirect("/TrangChu/Xem");
            }
            ViewBag.maxoauser = maxoauser;
            return View("~/Views/Manager/Quanlyuser/Xacnhanxoauser.cshtml");
        }

        public ActionResult Thuchienxoanguoidung(string maxoauser)
        {
            if (Session["quyen"].ToString() != "admin" && Session["quyen"].ToString() != "manager")
            {
                return Redirect("/TrangChu/Xem");
            }
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
            if (Session["quyen"].ToString() != "admin" && Session["quyen"].ToString() != "manager")
            {
                return Redirect("/TrangChu/Xem");
            }
            LIBRARYDATAMODEL db = new LIBRARYDATAMODEL();
            
            NguoiDung nguoidung = db.NguoiDungs.First(s => s.manguoidung == manguoidung);
            ViewBag.nguoidung = nguoidung;
            return View("~/Views/Manager/Quanlyuser/Suaquyen.cshtml");
        }

        public ActionResult Thuchiensuaquyen(string manguoidung, string maloainguoidung, string khoanguoidung)
        {
            if (Session["quyen"].ToString() != "admin" && Session["quyen"].ToString() != "manager")
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
            return Redirect("~/QuanLyUser/Xem");
        }
    }
}