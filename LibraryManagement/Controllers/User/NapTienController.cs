using LibraryManagement.Models.Mobile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers.User
{
    public class NapTienController : Controller
    {
        // GET: NapTien
        public ActionResult Formnaptien()
        {
            //Chỉ dành cho thành viên người dùng ngoài nạp tiền.
            if (Session["quyen"].ToString() != "user")
            {
                return Redirect("/Trangchu/Xem");
            }
            return View("~/Views/User/Naptien/Xemnaptien.cshtml");
        }


        /*
        Tham Khao NganLuong
        -Tai Khoan:
            email: biashanlocgia@gmail.com
            pass: kimtien01042012 
        -Kết nối thanh toán:
            id kết nối:51419
            pass: 0528b0a0c411b4a63d4541433cd570fa
            ten ứng dụng: LibraryOnline
        */

        public ActionResult Thuchiennaptien()
        {
            //Mã người dùng ta đã lưu trong session khi thực hiện đăng nhập
            string manguoidung = Session["manguoidung"].ToString();

            RequestInfo info = new RequestInfo();
            info.Merchant_id = "51419";
            info.Merchant_acount = "biashanlocgia@gmail.com";
            info.Merchant_password = "0528b0a0c411b4a63d4541433cd570fa";  

            //Nhà mạng
            info.CardType = Request.Form["nhamang"].ToString();
            info.Pincard = Request.Form["mapin"].ToString();

            info.Refcode = (new Random().Next(0, 10000)).ToString();
            info.SerialCard = Request.Form["serial"].ToString();

            ResponseInfo resutl = NLCardLib.CardChage(info);
            String html = "";

            if (resutl.Errorcode.Equals("00"))
            {
                html += "<div>" + resutl.Message + "</div>";
                html += "<div>Số tiền nạp : <b>" + resutl.Card_amount + "</b> đ</div>";
                html += "<div>Mã giao dịch : <b>" + resutl.TransactionID + "</b></div>";
                html += "<div>Mã đơn hàng : <b>" + resutl.Refcode + "</b></div>";
                using (LIBRARYDATAMODEL db = new LIBRARYDATAMODEL())
                {
                    var naptien = db.NguoiDungs.FirstOrDefault(s => s.manguoidung == manguoidung);
                    naptien.sotientaikhoan = naptien.sotientaikhoan + Convert.ToInt32(resutl.Card_amount);
                    db.SaveChanges();
                    var luocsu = new LuocSuNapTien();
                    luocsu.maluocsunaptien = Guid.NewGuid().ToString();
                    luocsu.manguoidung = naptien.manguoidung;
                    luocsu.tiennap = Convert.ToInt32(resutl.Card_amount);
                    luocsu.ngaynap = DateTime.Now;
                    db.SaveChanges();
                    Session["sotientaikhoan"] = naptien.sotientaikhoan;
                }
            }
            else
            {
                html += "<div>Nạp thẻ không thành công</div>";
                html += "<div>" + resutl.Message + "</div>";
            }
            ViewBag.thongbaonaptien = html;
            return View("~/Views/User/Naptien/Thongbaonaptien.cshtml");
        }
    }
}