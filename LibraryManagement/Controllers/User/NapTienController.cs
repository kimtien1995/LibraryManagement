using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers.User
{
    public class NapTienController : Controller
    {
        // GET: NapTien
        public ActionResult Xem()
        {
            return View("~/Views/User/Naptien/Xemnaptien.cshtml");
        }
    }
}