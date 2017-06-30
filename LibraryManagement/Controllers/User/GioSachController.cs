using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers.User
{
    public class GioSachController : Controller
    {
        // GET: GioSach
        public ActionResult Xem()
        {
            return View("~/Views/User/Giosach/Xemgiosach.cshtml");
        }
    }
}