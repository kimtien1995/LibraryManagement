using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers.User
{
    public class KhoSachController : Controller
    {
        // GET: KhoSach
        public ActionResult Xem(/*string xapxep, string trang*/)
        {
            //LIBRARYDATAMODEL context = new LIBRARYDATAMODEL();
            //int soluong = context.Database.SqlQuery<int>("SELECT COUNT(*) FROM DauSach").Single();
            //int sosachtrongmottrang = 12;
            //int tranghientai = 1;
            //string cotxapxep = "ngaydang";
            return View("~/Views/User/Khosach/Xemkhosach.cshtml");
        }
    }
}