using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers.Manager
{
    public class QuanLySachController : Controller
    {
        // GET: QuanLySach
        public ActionResult Xem()
        {
            return View("~/Views/Manager/Quanlysach/Xemqlsach.cshtml");
        }
    }
}