using System.Web.Mvc;
using LibraryManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Controllers.Manager
{
    public class QuanLySachController : Controller
    {
        // GET: QuanLySach
        public ActionResult Xem()
        {
            List<DauSach> sachs = new List<DauSach>();
            int soluong;
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                sachs = db.DauSaches.Include("TacGia").Include("NhaXuatBan").Include("ChuDe").ToList();
                soluong = db.DauSaches.Count();
            }
            ViewBag.soluongsach = soluong;
            ViewBag.sachs = sachs;
            return View("~/Views/Manager/Quanlysach/Xemqlsach.cshtml");
        }

        public ActionResult Formthemsach()
        {
            return View("~/Views/Manager/Quanlysach/Formthemsach.cshtml");
        }

        public ActionResult Thuchienthemsach()
        {
            return View("~/Views/Manager/Quanlysach/Xemqlsach.cshtml");
        }

        public ActionResult Xacnhanxoasach(string masachxoa)
        {
            ViewBag.masachxoa = masachxoa;
            return View("~/Views/Manager/Quanlysach/Xacnhanxoasach.cshtml");
        }

        public ActionResult Thuchienxoasach(string masachxoa)
        {
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                var sach = db.DauSaches.FirstOrDefault(s => s.madausach == masachxoa);
                db.DauSaches.Remove(sach);
                db.SaveChanges();
            }
            return Redirect("~/QuanLySach/Xem");
        }

        public ActionResult Formsuasach(string masach)
        {

            DauSach thongtinsach = new DauSach();
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                thongtinsach = db.DauSaches.Include("Tacgia").
                    Include("Nhaxuatban").
                    Include("Chude").
                    FirstOrDefault(s => s.madausach == masach);
            }
            ViewBag.qlsachsuasach = thongtinsach;
            return View("~/Views/Manager/Quanlysach/Formsuasach.cshtml");
        }

        public ActionResult Thuchiensuasach(string masach)
        {

            DauSach thongtinsach = new DauSach();
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                thongtinsach = db.DauSaches.Include("Tacgia").
                    Include("Nhaxuatban").
                    Include("Chude").
                    FirstOrDefault(s => s.madausach == masach);
            }
            ViewBag.qlsachsuasach = thongtinsach;
            return View("~/Views/Manager/Quanlysach/Formsuasach.cshtml");
        }
    }
}