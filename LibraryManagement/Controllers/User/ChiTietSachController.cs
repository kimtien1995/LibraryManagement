using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers.User
{
    public class ChiTietSachController : Controller
    {
        // GET: ChiTietSach
        public ActionResult Xem(string masach)
        {
            DauSach chitietsach = new DauSach();
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                string m = masach;
                chitietsach = db.DauSaches.Include("TacGia").Include("ChuDe").Include("NhaXuatBan").FirstOrDefault(s => s.madausach == m);
            }
            ViewBag.chitietsach = chitietsach;
            return View("~/Views/User/Xemchitiet/Xemchitiet.cshtml");
        }
    }
}