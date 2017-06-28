using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LibraryManagement.Controllers.User
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        public ActionResult Xem()
        {
            dynamic truonghoc= new System.Dynamic.ExpandoObject();


            truonghoc.ten = "ffffff";
            truonghoc.tel = "sssss";
            truonghoc.key = "value";


            




            return View();
        }
    }
}