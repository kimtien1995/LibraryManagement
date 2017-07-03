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
        public ActionResult Doconline(string masach, int sotientk, string manguoidung)
        {


            LIBRARYDATAMODEL db = new LIBRARYDATAMODEL();
            DauSach sachs = new DauSach();
            sachs = db.DauSaches.Include("TacGia").FirstOrDefault(s => s.madausach == masach);
            if (Session["quyen"].ToString() == "manager" || Session["quyen"].ToString() == "member")
            {
                ViewBag.sach = sachs;
            }
            if (Session["quyen"].ToString() == "user")
            {
                if (sachs.giaban <= sotientk)
                {
                    ViewBag.sach = sachs;
                    var thanhtoan = db.NguoiDungs.FirstOrDefault(s => s.manguoidung == manguoidung);
                    thanhtoan.sotientaikhoan = (thanhtoan.sotientaikhoan - sachs.giaban);
                    db.SaveChanges();
                }
                else
                {
                    return View("~/Views/User/Doconline/Dockhongthanhcong.cshtml");
                }
            }
            return View("~/Views/User/Doconline/Xemonline.cshtml");
        }
    }
}