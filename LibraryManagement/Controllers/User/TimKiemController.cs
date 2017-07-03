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
        public ActionResult Timkiemcoban()
        {
            return View("~/Views/User/Timkiem/Xemtimkiem.cshtml");
        }

        public ActionResult Xemtimkiemnangcao()
        {
            return View("~/Views/User/Timkiem/Xemtimkiem.cshtml");
        }

        public ActionResult Timkiemnangcao()
        {
            return View("~/Views/User/Timkiem/Xemtimkiem.cshtml");
        }
    }
}