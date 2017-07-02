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
        public ActionResult Xem(/*string manguoidung*/)
        {
            //string m = manguoidung;
            //using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            //{
            //    nguoidung = db.NguoiDungs.Include("LoaiNguoiDung").FirstOrDefault(s => s.manguoidung == m);
            //}

            //ViewBag.nguoidung = nguoidung; 
                return View("~/Views/User/Trangcanhan/Xemtrangcanhan.cshtml");
        }
    }
}