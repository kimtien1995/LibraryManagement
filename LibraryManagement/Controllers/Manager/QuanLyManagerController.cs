using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers.Manager
{
    public class QuanLyManagerController : Controller
    {
        // GET: QuanLyManager
        public ActionResult Xem()
        {
            return View("~/Views/Manager/Quanlymanager/Xemqlmanager.cshtml");
        }
    }
}