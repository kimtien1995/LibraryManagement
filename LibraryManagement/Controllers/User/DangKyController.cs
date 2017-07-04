using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;
using System.Data.Entity.Validation;

namespace LibraryManagement.Controllers.User
{
    public class DangKyController : Controller
    {
        // GET: DangKy
        public ActionResult Xem()
        {
            if(Session["quyen"].ToString() != "guest")
            {
                return Redirect("/Trangchu/Xem");
            }
                
            return View("~/Views/User/Dangky/Xemdangky.cshtml");
        }
        public ActionResult Thuchiendangky()
        {
            if (Session["quyen"].ToString() != "guest")
            {
                return Redirect("~/Trangchu/Xem");
            }
            try
            {
                LIBRARYDATAMODEL db = new LIBRARYDATAMODEL();
                var nguoidung = new NguoiDung();
                nguoidung.manguoidung = Guid.NewGuid().ToString();
                nguoidung.hovaten = Request.Form["hovaten"].ToString();
                nguoidung.tendangnhap = Request.Form["tendangnhap"].ToString();
                nguoidung.matkhau = Request.Form["matkhau"].ToString();
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
                nguoidung.sotientaikhoan = 5000;
                nguoidung.maloainguoidung = "1";
                nguoidung.khoanguoidung = "U";
                nguoidung.makichhoat = "";
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


                db.NguoiDungs.Add(nguoidung);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                //Neu bi loi  trong dang ky thi chuen den cho dang ky lai
                return Redirect("/DangKy/Xem");

            }
            //Neu dang ky ok thi hien thanh cong
            return View("~/Views/User/Dangky/Dangkythanhcong.cshtml");
            
        }
    }
}
