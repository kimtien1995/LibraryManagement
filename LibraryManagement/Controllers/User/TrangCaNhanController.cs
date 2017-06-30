using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers.User
{
    public class TrangCaNhanController : Controller
    {
        // GET: TrangCaNhan
        public ActionResult Xem()
        {
            return View("~/Views/User/Trangcanhan/Xemtrangcanhan.cshtml");
        }
    }
}