﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;


namespace LibraryManagement.Controllers.User
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        public ActionResult Xem()
        {
            

                return View("~/Views/User/Trangchu/Xemtrangchu.cshtml");
        }
    }
}