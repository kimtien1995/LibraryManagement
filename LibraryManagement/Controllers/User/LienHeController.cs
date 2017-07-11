using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers.User
{
    public class LienHeController : Controller
    {
        // GET: LienHe
        public ActionResult Xem()
        {
            return View("~/Views/User/LienHe/Lienhe.cshtml");
        }
    }
}