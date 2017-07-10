using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers.User
{
    public class DocOnlineController : Controller
    {
        // GET: DocOnline
        public ActionResult Doconline(string masach)
        {
            //Chỉ thành viên nội bộ mới được xem
            if (Session["quyen"].ToString() == "manager" || Session["quyen"].ToString() == "member" || Session["quyen"].ToString() == "admin")
            {
                LIBRARYDATAMODEL db = new LIBRARYDATAMODEL();
                DauSach sachs = new DauSach();
                sachs = db.DauSaches.Include("TacGia").FirstOrDefault(s => s.madausach == masach);
                sachs.luotxem = sachs.luotxem + 1;
                db.SaveChanges();
                ViewBag.sach = sachs;
                return View("~/Views/User/Doconline/Xemonline.cshtml");
            }
            //if (Session["quyen"].ToString() == "user")
            //{
            //    if (sachs.giaban <= sotientk && sotientk > 0)
            //    {
            //        ViewBag.sach = sachs;
            //        var thanhtoan = db.NguoiDungs.FirstOrDefault(s => s.manguoidung == manguoidung);
            //        thanhtoan.sotientaikhoan = (thanhtoan.sotientaikhoan - sachs.giaban);
            //        sachs.luotmua = sachs.luotmua + 1;
            //        sachs.luotxem = sachs.luotxem + 1;
            //        db.SaveChanges();
            //        Session["sotientaikhoan"] = thanhtoan.sotientaikhoan;
            //        return View("~/Views/User/Doconline/Xemonline.cshtml");
            //    }
            //    else
            //    {
            //        return View("~/Views/User/Doconline/Dockhongthanhcong.cshtml");
            //    }
            //}
            return View("~/Views/User/Doconline/Dockhongthanhcong.cshtml");
        }
    }
}