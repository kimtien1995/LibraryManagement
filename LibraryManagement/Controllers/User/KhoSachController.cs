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
        public ActionResult Xem(string xapxep, string trang)
        {

            int soluongsach;
            int sosachtrongmottrang = 15;
            int tranghientai = 1;
            string cotxapxep = "tensach";

            LIBRARYDATAMODEL db = new LIBRARYDATAMODEL();
            soluongsach = db.DauSaches.Count();



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

            List<sp_phantrangkhosach_Result> dausachs = new List<sp_phantrangkhosach_Result>();
            if (sotrang > 0)
            {
                dausachs = db.sp_phantrangkhosach(sosachtrongmottrang, tranghientai, cotxapxep).ToList();
            }

            ViewBag.dausachs = dausachs;
            ViewBag.sotrang = sotrang;
            ViewBag.soluongsach = soluongsach;
            ViewBag.tranghientai = tranghientai;
            ViewBag.cotxapxep = cotxapxep;

            return View("~/Views/User/Khosach/Xemkhosach.cshtml");
        }
        public ActionResult Xemdanhsachtheochude(string machude)
        {
            List<DauSach> sachtheochude = new List<DauSach>();
            ChuDe tenchude = new ChuDe();
            LIBRARYDATAMODEL db = new LIBRARYDATAMODEL();
            sachtheochude = db.DauSaches.Include("ChuDe").Where(s => s.machude == machude).ToList();
            int soluong = db.DauSaches.Count(s => s.machude == machude);
            tenchude = db.ChuDes.FirstOrDefault(s => s.machude == machude);
            ViewBag.sachchude = sachtheochude;
            ViewBag.slsachchude = soluong;
            ViewBag.tenchude = tenchude;
            return View("~/Views/User/KhoSach/Sachtheochude.cshtml");
        }
    }
}