using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;


namespace LibraryManagement.Controllers.User
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        public ActionResult Xem()
        {
            //Khai bao danh sach cac cuon sach
            List<DauSach> sachnb = new List<DauSach>();
            List<DauSach> sachm = new List<DauSach>(); 
            
            //Thuc hien lay 16 cuon sach co luot xem nhieu nhat
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())    //Khai bao doi tuong database context de tuong tac csdl, no co pham vi trong {} cua using
            {
                //Thuc hien goi bang dau sach sort luot xem, lay 16 cuon
                sachnb=db.DauSaches.Include("TacGia").OrderByDescending(s => s.luotxem).Take(16).ToList();
                sachm = db.DauSaches.Include("TacGia").OrderByDescending(s => s.ngaydang).Take(6).ToList();
            }

            //Goi danh sach 16 cuốn sách xuong view thông qua đối tương viewbag
            ViewBag.sachnb = sachnb;
            ViewBag.sachm = sachm;
            
            return View("~/Views/User/Trangchu/Xemtrangchu.cshtml");
        }
    }
}