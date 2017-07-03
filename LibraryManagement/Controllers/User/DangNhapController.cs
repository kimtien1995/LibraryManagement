﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;
using System.Data;

namespace LibraryManagement.Controllers.User
{
    public class DangNhapController : Controller
    {
        // GET: DangNhap
        public ActionResult Thuchiendangnhap(string tendangnhap, string matkhau, string check_ghinho)
        {
            if (Session["quyen"].ToString() != "guest")
            {
                return Redirect("/Trangchu/Xem");
            }
            bool oghinho;
            if (check_ghinho == "true")
            {
                oghinho = true;
            }
            else
            {
                oghinho = false;
            }
            LIBRARYDATAMODEL db = new LIBRARYDATAMODEL();
            NguoiDung user = new NguoiDung();
            var ketqua = db.sp_timkiemnguoidungdangnhap(tendangnhap, matkhau).Count();
            if(ketqua != 0)
            {
                
                user = db.NguoiDungs.Include("Loainguoidung").SingleOrDefault(s => s.tendangnhap == tendangnhap && s.matkhau == matkhau);
                Session["manguoidung"] = user.manguoidung;
                Session["tendangnhap"] = user.tendangnhap;
                Session["quyen"] = user.LoaiNguoiDung.phanquyen.ToString();
                Session["anhdaidien"] = user.anhdaidien;
                Session["diachi"] = user.diachi;
                Session["hovaten"] = user.hovaten;
                Session["sodienthoai"] = user.sodienthoai;
                Session["sotientaikhoan"] = user.sotientaikhoan;
                Session["motangan"] = user.motangan;
                Session["email"] = user.email;
                Session["gioitinh"] = user.gioitinh;

                if (oghinho == true)
                {
                    Response.Cookies["tendangnhap"].Value = user.tendangnhap;
                    Response.Cookies["tendangnhap"].Expires = DateTime.Now.AddMonths(1);

                    Response.Cookies["matkhau"].Value = user.matkhau;
                    Response.Cookies["matkhau"].Expires = DateTime.Now.AddMonths(1);
                }

                return RedirectToAction("Xem", "TrangCaNhan");
            }
            ViewBag.ThongBao = "Người dùng không tồn tại, vui lòng thử lại!";
            return View("~/Views/User/Dangnhap/Xemdangnhap.cshtml");
        }

        public ActionResult Thuchiendangxuat()
        {
            Session["quyen"] = "guest";
            if (Request.Cookies["tendangnhap"] != null && Request.Cookies["matkhau"] != null)
            {
                Response.Cookies["tendangnhap"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["matkhau"].Expires = DateTime.Now.AddDays(-1);
            }
            return Redirect("/TrangChu/Xem");
        }
    }
}