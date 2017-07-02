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
            
            //int soluong;
            //int sosachtrongmottrang = 20;
            //int tranghientai = 1;
            //string cotxapxep = "NgayDang";

            //LIBRARYDATAMODEL db = new LIBRARYDATAMODEL();
            //soluong = db.DauSaches.Count();

            

            //if (trang != null && trang != "")
            //{
            //    tranghientai = int.Parse(trang);
            //}

            //if (xapxep != null)
            //{
            //    cotxapxep = xapxep;
            //}

            //int sotrang = (int)Math.Ceiling((double)soluong / (double)sosachtrongmottrang);

            //if (tranghientai <= 0)
            //{
            //    tranghientai = 1;
            //}
            //if (tranghientai > sotrang)
            //{
            //    tranghientai = sotrang;
            //}

            //List<DauSach> saches = new List<DauSach>();
            //if (sotrang > 0)
            //{
            //    saches = db.DauSaches.ToList();
            //}

            //ViewBag.dausachs = saches;
            //ViewBag.sotrang = sotrang;
            //ViewBag.soluongsach = soluong;
            //ViewBag.tranghientai = tranghientai;
            //ViewBag.cotxapxep = cotxapxep;

            return View("~/Views/User/Khosach/Xemkhosach.cshtml");
        }
    }
}