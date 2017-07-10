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
        public ActionResult Xem()
        {
            if (Session["quyen"].ToString() == "guest")
            {
                return Redirect("/Trangchu/Xem");
            }
            return View("~/Views/User/Trangcanhan/Xemtrangcanhan.cshtml");
        }
        public ActionResult Formsuathongtin()
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
                    //Nếu nap file thì cập nhật Avatar, nếu không thì để nguyen ảnh củ.
                    //nguoidung.anhdaidien = "NoImg.jpg";
                }

                db.SaveChanges();

                Session["hovaten"] = nguoidung.hovaten;
                Session["email"] = nguoidung.email;
                Session["diachi"] = nguoidung.diachi;
                Session["ngaysinh"] = nguoidung.ngaysinh;
                Session["sodienthoai"] = nguoidung.sodienthoai;
                Session["motangan"] = nguoidung.motangan;
                Session["anhdaidien"] = nguoidung.anhdaidien;
                Session["anhdaidien"] = nguoidung.anhdaidien;
                // Nên để nguyên bản về sau sử dụng dễ hơn khi cap nhat, in ra ta hay chuyen về Nam hay Nữ
                //if (nguoidung.gioitinh == "G")
                //{
                //    Session["gioitinh"] = "Nữ";
                //}
                //else
                //{
                //    Session["gioitinh"] = "Nam";
                //}

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
        public ActionResult Luocsunaptien()
        {

            if (Session["quyen"].ToString() == "guest")
            {
                return Redirect("/Trangchu/Xem");
            }
            string manguoidung = Session["manguoidung"].ToString();
            List<LuocSuNapTien> naptien = new List<LuocSuNapTien>();
            int soluong;
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                naptien = db.LuocSuNapTiens.Include("NguoiDung").Where(s => s.manguoidung == manguoidung).ToList();
                soluong = db.LuocSuNapTiens.Count(s => s.manguoidung == manguoidung);
            }
            ViewBag.sllistnaptien = soluong;
            ViewBag.listnaptien = naptien;
            return View("~/Views/User/Trangcanhan/Luocsunaptien.cshtml");
        }

        public ActionResult Luocsumuasach()
        {

            if (Session["quyen"].ToString() == "guest")
            {
                return Redirect("/Trangchu/Xem");
            }
            string manguoidung = Session["manguoidung"].ToString();
            List<LuocSuMuaSach> listmua = new List<LuocSuMuaSach>();
            int soluong;
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                listmua = db.LuocSuMuaSaches.Include("DauSach").Include("NguoiDung").Where(s => s.manguoidung == manguoidung).ToList();
                soluong = db.LuocSuMuaSaches.Count(s => s.manguoidung == manguoidung);
                ViewBag.soluong = soluong;
                ViewBag.listmua = listmua;
            }
            return View("~/Views/User/Trangcanhan/Luocsumuasach.cshtml");
        }
    }
}