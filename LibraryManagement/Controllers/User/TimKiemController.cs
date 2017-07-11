using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers.User
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        public ActionResult Timkiemcoban(string key,string xapxep, string trang)
        {

            int soluongsach;
            int sosachtrongmottrang = 15;
            int tranghientai = 1;
            string cotxapxep = "tensach";

            LIBRARYDATAMODEL db = new LIBRARYDATAMODEL();
            //do tim so luong sach
            soluongsach = db.sp_timkiem(key, 10000000, 1, "tensach").Count();



            if (trang != null && trang != "")
            {
                tranghientai = int.Parse(trang);
            }

            if (xapxep != null)
            {
                cotxapxep = xapxep;
            }

            int sotrang = (int)Math.Ceiling((double)soluongsach / (double)sosachtrongmottrang);

            if (tranghientai <= 0)
            {
                tranghientai = 1;
            }
            if (tranghientai > sotrang)
            {
                tranghientai = sotrang;
            }

            List<sp_timkiem_Result> dausachs = new List<sp_timkiem_Result>();
            if (sotrang > 0)
            {
                dausachs = db.sp_timkiem(key,sosachtrongmottrang, tranghientai, cotxapxep).ToList();
            }

            ViewBag.dausachs = dausachs;
            ViewBag.sotrang = sotrang;
            ViewBag.soluongsach = soluongsach;
            ViewBag.tranghientai = tranghientai;
            ViewBag.cotxapxep = cotxapxep;
            ViewBag.key = key;
            return View("~/Views/User/Timkiem/Xemtimkiem.cshtml");
        }

        public ActionResult Xemtimkiemnangcao()
        {
            return View("~/Views/User/Timkiem/Xemtimkiem.cshtml");
        }

        public ActionResult Timkiemnangcao()
        {
            return View("~/Views/User/Timkiem/Xemtimkiem.cshtml");
        }
    }
}