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
        public ActionResult Xem(string urlnext)
        {
            ViewBag.urlgiosach = urlnext;
            return View("~/Views/User/Giosach/Xemgiosach.cshtml");
        }

        public ActionResult Themsachvaogio(string masach, string urlnext)
        {
            if(Session["quyen"].ToString() == "guest")
            {
                return View("~/Views/User/Dangnhap/Xemdangnhap.cshtml");
            }
            if(Session["quyen"].ToString() == "member")
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
                return Redirect(urlnext);
            }
            else
            {
                //Không phải là quyen member, không được thêm sách vào giỏ hàng.
                ViewBag.urlnext = urlnext;
                return View("~/Views/User/Giosach/thongbaoloi.cshtml");
            }

        }
        public ActionResult Xoasachtronggio(string masach)
        {
            List<Items> items = (List<Items>)Session["giohang"];
            foreach(Items item in items)
            {
                if(item.Madausach == masach)
                {
                    items.Remove(item);
                    break;
                }
            }
            return View("~/Views/User/Giosach/Xemgiosach.cshtml");
        }
        public ActionResult Formthemsltronggio(string masach)
        {
            List<Items> items = (List<Items>)Session["giohang"];
            foreach(Items item in items)
            {
                if(item.Madausach == masach)
                {
                    ViewBag.item = item;
                    break;
                }
            }
            return View("~/Views/User/Giosach/Themslsach.cshtml");
        }
        public ActionResult Thuchienthemsltronggio(string masach, int soluong)
        {
            List<Items> items = (List<Items>)Session["giohang"];
            foreach (Items item in items)
            {
                if (item.Madausach == masach)
                {
                    item.Soluong = soluong;
                    break;
                }
            }
            return View("~/Views/User/Giosach/Xemgiosach.cshtml");
        }
    }
}