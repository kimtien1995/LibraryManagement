using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers.User
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        public ActionResult Xem()
        {
            return View("~/Views/User/Timkiem/Xemtimkiem.cshtml");
        }
    }
}