using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers.User
{
    public class DocOnlineController : Controller
    {
        // GET: DocOnline
        public ActionResult Xem()
        {
            return View("~/Views/User/Doconline/Xemonline.cshtml");
        }
    }
}