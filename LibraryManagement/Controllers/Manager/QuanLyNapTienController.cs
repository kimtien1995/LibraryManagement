using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers.Manager
{
    public class QuanLyNapTienController : Controller
    {
        // GET: QuanLyNapTien
        public ActionResult Xem()
        {
            return View("~/Views/Manager/Quanlynaptien/Xemqlnaptien.cshtml");
        }
    }
}