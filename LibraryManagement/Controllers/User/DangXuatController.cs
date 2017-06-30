using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers.User
{
    public class DangXuatController : Controller
    {
        // GET: DangXuat
        public ActionResult Dangxuat()
        {
            return View("~/Views/User/Trangchu/Xemtrangchu.cshtml");
        }
    }
}