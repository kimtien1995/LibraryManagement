using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers.Manager
{
    public class QuanLyUserController : Controller
    {
        // GET: QuanLyUser
        public ActionResult Xem()
        {
            return View("~/Views/Manager/Quanlyuser/Xemqluser.cshtml");
        }
    }
}