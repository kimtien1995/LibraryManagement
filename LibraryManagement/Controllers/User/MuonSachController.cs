using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Models.DTO;

namespace LibraryManagement.Controllers.User
{
    public class MuonSachController : Controller
    {
        // GET: MuonSach

        public ActionResult Xem()
        {
            return View("~/Views/User/Giosach/Xemgiosach.cshtml");
        }
        public ActionResult Thuchienmuonsach(string manguoidung)
        {
            int soluongtoida = 0;
            LIBRARYDATAMODEL db = new LIBRARYDATAMODEL();
            ThamSo thamso = new ThamSo();
            thamso = db.ThamSoes.FirstOrDefault(s => s.mathamso == "4");
            soluongtoida = Convert.ToInt32(thamso.giatridulieu) + soluongtoida;

            List<Items> items = (List<Items>)Session["giohang"];
            int tong = 0;
            foreach(Items item in items)
            {
                tong = tong + item.Soluong;
            }

            if (tong <= soluongtoida && tong >0)
            {
                DonMuonSach donmuonsach = new DonMuonSach();
                donmuonsach.madonmuonsach = Guid.NewGuid().ToString();
                donmuonsach.manguoidung = manguoidung;
                donmuonsach.ngaydat = DateTime.Now;
                donmuonsach.matrangthai = "1";
                db.DonMuonSaches.Add(donmuonsach);
                db.SaveChanges();
                foreach(Items item in items)
                {
                    ChiTietDonMuonSach chitietdonmuonsach = new ChiTietDonMuonSach();
                    chitietdonmuonsach.madonmuonsach = donmuonsach.madonmuonsach;
                    chitietdonmuonsach.machitietdonmuonsach = Guid.NewGuid().ToString();
                    chitietdonmuonsach.madausach = item.Madausach;
                    chitietdonmuonsach.soluong = item.Soluong;
                    db.ChiTietDonMuonSaches.Add(chitietdonmuonsach);
                    db.SaveChanges();
                }
                return View("~/Views/User/Muonsach/Thanhcong.cshtml");
            }
            ViewBag.tbvuotsl = "Số lượng cuốn sách muốn mượn không vượt quá 5 cuốn sách!";
            return View("~/Views/User/Giosach/Xemgiosach.cshtml");
        }
    }
}