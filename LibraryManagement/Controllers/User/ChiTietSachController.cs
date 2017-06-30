using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers.User
{
    public class ChiTietSachController : Controller
    {
        // GET: ChiTietSach
        public ActionResult Xem()
        {
            return View("~/Views/User/Xemchitiet/Xemchitiet.cshtml");
        }
    }
}