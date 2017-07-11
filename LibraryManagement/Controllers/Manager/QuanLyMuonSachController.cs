using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers.Manager
{
    public class QuanLyMuonSachController : Controller
    {
        // GET: QuanLyMuonSach
        public ActionResult Xem()
        {
            if (Session["quyen"].ToString() != "admin" && Session["quyen"].ToString() != "manager")
            {
                return Redirect("/TrangChu/Xem");
            }
            List<DonMuonSach> donmuon = new List<DonMuonSach>();
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                donmuon = db.DonMuonSaches.Include("TrangThai").Include("NguoiDung").ToList();
            }
            ViewBag.donmuon = donmuon;
            return View("~/Views/Manager/QuanLyMuonSach/Donmuonsach.cshtml");
        }
        public ActionResult Xemchitietdonmuon(string madon)
        {
            if (Session["quyen"].ToString() != "admin" && Session["quyen"].ToString() != "manager")
            {
                return Redirect("/TrangChu/Xem");
            }
            List<ChiTietDonMuonSach> chitietdonmuon = new List<ChiTietDonMuonSach>();
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                chitietdonmuon = db.ChiTietDonMuonSaches.Include("DauSach")
                    .Where(s => s.madonmuonsach == madon).ToList();
            }
            ViewBag.chitietdonmuon = chitietdonmuon;
            return View("~/Views/Manager/QuanLyMuonSach/Chitietdonmuonsach.cshtml");
        }
        public ActionResult CapNhat(string madon)
        {
            if (Session["quyen"].ToString() != "admin" && Session["quyen"].ToString() != "manager")
            {
                return Redirect("/TrangChu/Xem");
            }
            List<TrangThai> tts = new List<TrangThai>();
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                 tts= db.TrangThais.ToList();
                DonMuonSach dm = db.DonMuonSaches.Include("NguoiDung").FirstOrDefault(d => d.madonmuonsach == madon);
                ViewBag.dm = dm;
                ViewBag.tts = tts;

            }
            return View("~/Views/Manager/QuanLyMuonSach/Capnhat.cshtml");
        }
        public ActionResult ThucHienCapNhat(string madon,string ngaymuon,string ngaytra, string trangthai)
        {
            if (Session["quyen"].ToString() != "admin" && Session["quyen"].ToString() != "manager")
            {
                return Redirect("/TrangChu/Xem");
            }
            try
            {
                using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
                {


                    List<TrangThai> tts = db.TrangThais.ToList();
                    DonMuonSach dm = db.DonMuonSaches.Include("NguoiDung").FirstOrDefault(d => d.madonmuonsach == madon);
                    DateTime tam = new DateTime();
                    if(DateTime.TryParse(ngaymuon,out tam)==true)
                    {
                        dm.ngaymuon = tam;
                    }
                    else
                    {
                        dm.ngaymuon = null;
                    }
                    if (DateTime.TryParse(ngaytra, out tam) == true)
                    {
                        dm.ngaytra = tam;
                    }
                    else
                    {
                        dm.ngaytra = null;
                    }
                    dm.matrangthai = trangthai;
                    db.SaveChanges();

                }
                return Redirect("/QuanLyMuonSach/Xem");
            }
            catch(Exception ex)
            {
                using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
                {
                    List<TrangThai> tts = db.TrangThais.ToList();
                    DonMuonSach dm = db.DonMuonSaches.Include("NguoiDung").FirstOrDefault(d => d.madonmuonsach == madon);
                    ViewBag.dm = dm;
                    ViewBag.tts = tts;
                    ViewBag.thongbaoloi = "Cập nhật đơn đặt hành không thành công, vui lòng thực hiện lại";
                }
                return View("~/Views/Manager/QuanLyMuonSach/Capnhat.cshtml");
            }
        }
        public ActionResult Xoa(string madon)
        {
            if (Session["quyen"].ToString() != "admin" && Session["quyen"].ToString() != "manager")
            {
                return Redirect("/TrangChu/Xem");
            }
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                List<ChiTietDonMuonSach> chitietdonmuon = new List<ChiTietDonMuonSach>();
                chitietdonmuon = db.ChiTietDonMuonSaches.Include("DauSach").Where(s => s.madonmuonsach == madon).ToList();
                foreach(ChiTietDonMuonSach ct in chitietdonmuon)
                {
                    db.ChiTietDonMuonSaches.Remove(ct);
                }
                DonMuonSach dm = db.DonMuonSaches.FirstOrDefault(d=>d.madonmuonsach==madon);
                db.DonMuonSaches.Remove(dm);
                db.SaveChanges();
            }
            return Redirect("/QuanLyMuonSach/XemDonMuonSach");
        }
    }
}