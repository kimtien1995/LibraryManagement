using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers.User
{
    public class ChiTietSachController : Controller
    {
        // GET: ChiTietSach
        public ActionResult Xem(string masach)
        {
            DauSach chitietsach = new DauSach();
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                string m = masach;
                chitietsach = db.DauSaches.Include("TacGia").Include("ChuDe").Include("NhaXuatBan").FirstOrDefault(s => s.madausach == m);
            }
            ViewBag.chitietsach = chitietsach;
            return View("~/Views/User/Xemchitiet/Xemchitiet.cshtml");
        }

        public ActionResult Download(string masach)
        {
            if (Session["quyen"].ToString() == "guest")
            {
                return Redirect("/Trangchu/Xem");
            }
            string manguoidung = Session["manguoidung"].ToString();
            LIBRARYDATAMODEL db = new LIBRARYDATAMODEL();
            DauSach sachs = new DauSach();
            sachs = db.DauSaches.Include("TacGia").FirstOrDefault(s => s.madausach == masach);
            //Nếu người dùng nội bộ thì cho phep download không tính phí.
            if (Session["quyen"].ToString() == "manager" || Session["quyen"].ToString() == "member" || Session["quyen"].ToString() == "admin")
            {
                sachs.luotdownload = sachs.luotdownload + 1;
                db.SaveChanges();

                
                string path = System.AppDomain.CurrentDomain.BaseDirectory + "Content/BookPdf/";
                byte[] fileBytes = System.IO.File.ReadAllBytes(path+sachs.filesach);
                string fileName = sachs.filesach;
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            else
            {
                //Neu nguoi dung dang ky thi tru tien
                int sotientk = int.Parse(Session["sotientaikhoan"].ToString());
                
                if (Session["quyen"].ToString() == "user")
                {
                    if (sachs.giaban <= sotientk && sotientk > 0)
                    {
                        ViewBag.sach = sachs;
                        var thanhtoan = db.NguoiDungs.FirstOrDefault(s => s.manguoidung == manguoidung);
                        thanhtoan.sotientaikhoan = (thanhtoan.sotientaikhoan - sachs.giaban);
                        sachs.luotmua = sachs.luotmua + 1;
                        sachs.luotdownload = sachs.luotdownload + 1;
                        db.SaveChanges();

                        var luocsu = new LuocSuMuaSach();
                        luocsu.maluocsumuasach = Guid.NewGuid().ToString();
                        luocsu.manguoidung = manguoidung;
                        luocsu.madausach = sachs.madausach;
                        luocsu.tientra =(int) sachs.giaban;
                        
                        luocsu.ngaymua = DateTime.Now;
                        db.LuocSuMuaSaches.Add(luocsu);
                        db.SaveChanges();

                        Session["sotientaikhoan"] = thanhtoan.sotientaikhoan;

                        string path = System.AppDomain.CurrentDomain.BaseDirectory + "Content/BookPdf/";
                        byte[] fileBytes = System.IO.File.ReadAllBytes(path + sachs.filesach);
                        string fileName = sachs.filesach;
                        return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
                    }
                    else
                    {
                        //Không dược download vi khong du tien
                        
                        return View("~/Views/User/Xemchitiet/Downloadkhongthanhcong.cshtml.cshtml");
                    }
                }
            }

            return View("~/Views/User/Doconline/Dockhongthanhcong.cshtml");
        }
    }
}