using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LibraryManagement.Models;
using LibraryManagement.Models.DTO;

namespace LibraryManagement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_End()
        {

        }

        protected void Application_BeginRequest()
        {

        }

        protected void Application_EndRequest()
        {

        }
        protected void Session_Start()
        {
            Session.Add("quyen", "guest");
            if (Request.Cookies["tendangnhap"] != null && Request.Cookies["matkhau"] != null)
            {
                string tendangnhap = Request.Cookies["tendangnhap"].Value;
                string matkhau = Request.Cookies["matkhau"].Value;

                LIBRARYDATAMODEL db = new LIBRARYDATAMODEL();
                NguoiDung user = new NguoiDung();
                var ketqua = db.sp_timkiemnguoidungdangnhap(tendangnhap, matkhau).Count();

                if (ketqua == 0)
                {
                    
                    Session["quyen"] = "guest";
                }
                else
                {
                    user = db.NguoiDungs.Include("Loainguoidung").FirstOrDefault(s => s.tendangnhap == tendangnhap);
                    Session["manguoidung"] = user.manguoidung;
                    Session["tendangnhap"] = user.tendangnhap;
                    Session["matkhau"] = user.matkhau;
                    Session["quyen"] = user.LoaiNguoiDung.phanquyen.ToString();
                    Session["loainguoidung"] = user.LoaiNguoiDung.tenloainguoidung;
                    Session["anhdaidien"] = user.anhdaidien;
                    Session["ngaysinh"] = user.ngaysinh;
                    Session["diachi"] = user.diachi;
                    Session["hovaten"] = user.hovaten;
                    Session["sodienthoai"] = user.sodienthoai;
                    Session["sotientaikhoan"] = user.sotientaikhoan;
                    Session["motangan"] = user.motangan;
                    Session["email"] = user.email;
                    Session["gioitinh"] = user.gioitinh;
                }
                //if (Session["quyen"].ToString() != "admin" || Session["quyen"].ToString() != "manager")
                //{
                //    List<Items> giohang = new List<Items>();
                //    Session["giohang"] = giohang;
                //}
            }
        }
        protected void Session_Ends()
        {
            
        }
    }
}
