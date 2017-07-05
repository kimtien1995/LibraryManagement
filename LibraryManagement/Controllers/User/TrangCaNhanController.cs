using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers.User
{
    public class TrangCaNhanController : Controller
    {
        // GET: TrangCaNhan
        NguoiDung nguoidung = new NguoiDung();
        public ActionResult Xem(string manguoidung)
        {
            NguoiDung chitietnd = new NguoiDung();
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                chitietnd = db.NguoiDungs.FirstOrDefault(s => s.manguoidung == manguoidung);
            }
            ViewBag.chitietnd = chitietnd;
            return View("~/Views/User/Trangcanhan/Xemtrangcanhan.cshtml");
        }

        public ActionResult Xemsuathongtin()
        {
            return View("~/Views/User/Trangcanhan/Suathongtin.cshtml");
        }

        public ActionResult Thuchiensuathongtin(string manguoidung)
        {
            try
            {
                LIBRARYDATAMODEL db = new LIBRARYDATAMODEL();
                var nguoidung = db.NguoiDungs.FirstOrDefault(s => s.manguoidung == manguoidung);
                nguoidung.hovaten = Request.Form["hovaten"].ToString();
                nguoidung.email = Request.Form["email"].ToString();
                nguoidung.diachi = Request.Form["diachi"].ToString();
                try
                {
                    nguoidung.ngaysinh = Convert.ToDateTime(Request.Form["ngaysinh"]).Date;
                }
                catch (Exception e)
                {
                    nguoidung.ngaysinh = null;
                }
                nguoidung.sodienthoai = Request.Form["sodienthoai"].ToString();
                nguoidung.motangan = Request.Form["motangan"].ToString();
                nguoidung.gioitinh = Request.Form["gioitinh"].ToString();
                if (Request.Files["anhdaidien"].ContentLength > 0 && Request.Files["anhdaidien"].FileName != "")
                {
                    string path = System.AppDomain.CurrentDomain.BaseDirectory + "Content/UserImg/";
                    string tenanh = Request.Files["anhdaidien"].FileName;
                    Request.Files["anhdaidien"].SaveAs(path + tenanh);
                    nguoidung.anhdaidien = tenanh;
                }
                else
                {
                    nguoidung.anhdaidien = "NoImg.jpg";
                }
                db.SaveChanges();
                return Redirect("/TrangCaNhan/Xem");
            }
            catch (Exception ex)
            {
                //Neu bi loi  trong dang ky thi chuen den cho dang ky lai
                return Redirect("/TrangCaNhan/Xemsuathongtin");

            }
        }

        public ActionResult Xemkiemtramatkhau()
        {
            return View("~/Views/User/Trangcanhan/Suamatkhau/Matkhaucu.cshtml");
        }

        public ActionResult Kiemtramatkhau(string manguoidung)
        {
            LIBRARYDATAMODEL db = new LIBRARYDATAMODEL();
            var mk = db.NguoiDungs.FirstOrDefault(s => s.manguoidung == manguoidung);
            if(mk.matkhau == Request.Form["matkhaucu"].ToString())
            {
                return View("~/Views/User/Trangcanhan/Suamatkhau/Matkhaumoi.cshtml");
            }
            ViewBag.thongbaomk = " * Mật khẩu không đúng, vui lòng nhập lại";
            return View("~/Views/User/Trangcanhan/Suamatkhau/Matkhaucu.cshtml");
        }

        public ActionResult Suamatkhau(string manguoidung)
        {
            LIBRARYDATAMODEL db = new LIBRARYDATAMODEL();
            var mk = db.NguoiDungs.FirstOrDefault(s => s.manguoidung == manguoidung);
            if(mk.matkhau != Request.Form["matkhaumoi"].ToString())
            {
                mk.matkhau = Request.Form["matkhaumoi"].ToString();
                db.SaveChanges();
                return Redirect("/TrangChu/Xem");
            }
            ViewBag.tbtrunglap = "* Mật khẩu mới trùng với mật khẩu cũ, vui lòng nhập lại";
            return View("~/Views/User/Trangcanhan/Suamatkhau/Matkhaumoi.cshtml");
        }
    }
}