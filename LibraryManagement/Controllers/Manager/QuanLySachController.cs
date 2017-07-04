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
            using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
            {
                sachs = db.DauSaches.Include("TacGia").Include("NhaXuatBan").Include("ChuDe").ToList();
            }
            ViewBag.sachs = sachs;
            return View("~/Views/Manager/Quanlysach/Xemqlsach.cshtml");
        }
    }
}