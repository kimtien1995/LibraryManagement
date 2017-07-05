using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Models.DTO;

namespace LibraryManagement.Controllers.User
{
    public class GioSachController : Controller
    {
        // GET: GioSach
        public ActionResult Xem()
        {
            return View("~/Views/User/Giosach/Xemgiosach.cshtml");
        }

        public ActionResult Themsachvaogio(string masach)
        {
            if(Session["quyen"].ToString() == "guest")
            {
                return View("~/Views/User/Dangky/Xemdangnhap.cshtml");
            }
            if(Session["quyen"].ToString() != "guest")
            {
                DauSach chitietsach = new DauSach();
                LIBRARYDATAMODEL db = new LIBRARYDATAMODEL();
                chitietsach = db.DauSaches.Include("Tacgia").FirstOrDefault(s => s.madausach == masach);
                if(chitietsach != null)
                {
                    bool cotontai = false;
                    foreach(Items item in (List<Items>) Session["giohang"])
                    {
                        if(item.Madausach == chitietsach.madausach)
                        {
                            item.Soluong = item.Soluong + 1;
                            cotontai = true;
                        }
                    }

                    if (cotontai == false)
                    {
                        Items item = new Items();
                        item.Bia = chitietsach.bia;
                        item.Madausach = chitietsach.madausach;
                        item.Soluong = 1;
                        item.Tensach = chitietsach.tensach;
                        item.Tacgia = chitietsach.TacGia.tentacgia;
                        ((List<Items>)Session["giohang"]).Add(item);
                    }
                }
                ViewBag.sachgiosach = chitietsach;
            }
            return View("~/Views/User/Giosach/Xemgiosach.cshtml");
        }
    }
}