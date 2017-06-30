using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers.Manager
{
    public class TrangChuAdminController : Controller
    {
        // GET: TrangChuAdmin
        public ActionResult Xem()
        {
            return View("~/Views/Manager/Trangchu/Trangchumanager.cshtml");
        }
    }
}