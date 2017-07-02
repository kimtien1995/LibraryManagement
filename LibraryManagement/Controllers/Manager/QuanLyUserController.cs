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
            List<NguoiDung> nguoidungs = new List<NguoiDung>();
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                nguoidungs = db.NguoiDungs.Include("LoaiNguoiDung").ToList();
            }

            ViewBag.nguoidungs = nguoidungs;
            return View("~/Views/Manager/Quanlyuser/Xemqluser.cshtml");
        }
    }
}