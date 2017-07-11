using System.Web.Mvc;
using LibraryManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace LibraryManagement.Controllers.Manager
{
    public class QuanLySachController : Controller
    {
        // GET: QuanLySach
        public ActionResult Xem()
        {
            if (Session["quyen"].ToString() != "admin" && Session["quyen"].ToString() != "manager")
            {
                return Redirect("/TrangChu/Xem");
            }

            List<DauSach> sachs = new List<DauSach>();
            int soluong;
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                sachs = db.DauSaches.Include("TacGia").Include("NhaXuatBan").Include("ChuDe").OrderByDescending(s=>s.ngaydang).ToList();
                soluong = db.DauSaches.Count();
            }
            ViewBag.soluongsach = soluong;
            ViewBag.sachs = sachs;
            return View("~/Views/Manager/Quanlysach/Xemqlsach.cshtml");
        }

        public ActionResult Formthemsach()
        {
            List<TacGia> tgs = new List<TacGia>();
            List<NhaXuatBan> nxbs = new List<NhaXuatBan>();
            List<ChuDe> cds = new List<ChuDe>();
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                tgs = db.TacGias.ToList();
                nxbs = db.NhaXuatBans.ToList();
                cds = db.ChuDes.ToList();
            }
            
            ViewBag.tgs = tgs;
            ViewBag.nxbs = nxbs;
            ViewBag.cds = cds;
            return View("~/Views/Manager/Quanlysach/Formthemsach.cshtml");
        }


        public ActionResult Thuchienthemsach()
        {
            try
            {
                LIBRARYDATAMODEL db = new LIBRARYDATAMODEL();
                DauSach dausach= new DauSach();

                if (Request.Files["bia"].ContentLength > 0 && Request.Files["bia"].FileName != "")
                {
                    string path = System.AppDomain.CurrentDomain.BaseDirectory + "Content/BookImg/";
                    string tenanh = Request.Files["bia"].FileName;
                    Request.Files["bia"].SaveAs(path + tenanh);
                    dausach.bia= tenanh;
                }
                else
                {
                    dausach.bia = "noimage.jpg";
                }
                if (Request.Files["filesach"].ContentLength > 0 && Request.Files["filesach"].FileName != "")
                {
                    string path = System.AppDomain.CurrentDomain.BaseDirectory + "Content/BookPdf/";
                    string filesach = Request.Files["filesach"].FileName;
                    Request.Files["filesach"].SaveAs(path + filesach);
                    dausach.filesach = filesach;
                }
                else
                {
                    dausach.bia = null;
                }

                dausach.giaban = int.Parse(Request.Form["giaban"].ToString());
                dausach.machude = Request.Form["machude"].ToString();
                dausach.madausach= Guid.NewGuid().ToString();
                dausach.manhaxuatban= Request.Form["manhaxuatban"].ToString();
                dausach.matacgia= Request.Form["matacgia"].ToString();
                dausach.ngaydang = DateTime.Now;
                dausach.soluong= int.Parse(Request.Form["soluong"].ToString());
                dausach.tensach= Request.Form["tensach"].ToString();
                dausach.tomtat= Request.Form["tomtat"].ToString();

                db.DauSaches.Add(dausach);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                List<TacGia> tgs = new List<TacGia>();
                List<NhaXuatBan> nxbs = new List<NhaXuatBan>();
                List<ChuDe> cds = new List<ChuDe>();
                using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
                {
                    tgs = db.TacGias.ToList();
                    nxbs = db.NhaXuatBans.ToList();
                    cds = db.ChuDes.ToList();
                }

                ViewBag.tgs = tgs;
                ViewBag.nxbs = nxbs;
                ViewBag.cds = cds;
                ViewBag.thongbaoloi ="Thông tin sách nhâp không hợp lệ, vui lòng thử lại.";
                return View("~/Views/Manager/Quanlysach/Formthemsach.cshtml");

            }

            return Redirect("/QuanLySach/Xem");
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
            List<TacGia> tgs = new List<TacGia>();
            List<NhaXuatBan> nxbs = new List<NhaXuatBan>();
            List<ChuDe> cds = new List<ChuDe>();
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                tgs = db.TacGias.ToList();
                nxbs = db.NhaXuatBans.ToList();
                cds = db.ChuDes.ToList();
            }

            ViewBag.tgs = tgs;
            ViewBag.nxbs = nxbs;
            ViewBag.cds = cds;


            DauSach dausach = new DauSach();
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                dausach = db.DauSaches.Include("Tacgia").
                    Include("Nhaxuatban").
                    Include("Chude").
                    FirstOrDefault(s => s.madausach == masach);
            }
            ViewBag.dausach = dausach;
            return View("~/Views/Manager/Quanlysach/Formsuasach.cshtml");
        }

        public ActionResult Thuchiensuasach(string masach)
        {

            try
            {
                LIBRARYDATAMODEL db = new LIBRARYDATAMODEL();
                DauSach dausach = db.DauSaches.FirstOrDefault(s => s.madausach == masach);

                if (Request.Files["bia"].ContentLength > 0 && Request.Files["bia"].FileName != "")
                {
                    string path = System.AppDomain.CurrentDomain.BaseDirectory + "Content/BookImg/";
                    string tenanh = Request.Files["bia"].FileName;
                    Request.Files["bia"].SaveAs(path + tenanh);
                    dausach.bia = tenanh;
                }
                else
                {
                    //không can câp nhat
                }
                if (Request.Files["filesach"].ContentLength > 0 && Request.Files["filesach"].FileName != "")
                {
                    string path = System.AppDomain.CurrentDomain.BaseDirectory + "Content/BookPdf/";
                    string filesach = Request.Files["filesach"].FileName;
                    Request.Files["filesach"].SaveAs(path + filesach);
                    dausach.filesach = filesach;
                }
                else
                {
                    //không can câp nhat
                }

                dausach.giaban = int.Parse(Request.Form["giaban"].ToString());
                dausach.machude = Request.Form["machude"].ToString();
                //dausach.madausach = Guid.NewGuid().ToString();
                dausach.manhaxuatban = Request.Form["manhaxuatban"].ToString();
                dausach.matacgia = Request.Form["matacgia"].ToString();
                dausach.ngaydang = DateTime.Parse(Request.Form["ngaydang"].ToString());
                dausach.soluong = int.Parse(Request.Form["soluong"].ToString());
                dausach.tensach = Request.Form["tensach"].ToString();
                dausach.tomtat = Request.Form["tomtat"].ToString();

                
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                List<TacGia> tgs = new List<TacGia>();
                List<NhaXuatBan> nxbs = new List<NhaXuatBan>();
                List<ChuDe> cds = new List<ChuDe>();
                using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
                {
                    tgs = db.TacGias.ToList();
                    nxbs = db.NhaXuatBans.ToList();
                    cds = db.ChuDes.ToList();
                }

                ViewBag.tgs = tgs;
                ViewBag.nxbs = nxbs;
                ViewBag.cds = cds;


                DauSach dausach = new DauSach();
                using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
                {
                    dausach = db.DauSaches.Include("Tacgia").
                        Include("Nhaxuatban").
                        Include("Chude").
                        FirstOrDefault(s => s.madausach == masach);
                }
                ViewBag.dausach = dausach;
                ViewBag.thongbaoloi = "Thông tin sách nhâp không hợp lệ, vui lòng thử lại.";
                return View("~/Views/Manager/Quanlysach/Formsuasach.cshtml");
                


            }

            return Redirect("/QuanLySach/Xem");



        }
    }
}