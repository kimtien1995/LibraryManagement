﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers.User
{
    public class DangKyController : Controller
    {
        // GET: DangKy
        public ActionResult Xem()
        {
            return View("~/Views/User/Dangky/Xemdangky.cshtml");
        }
    }
}