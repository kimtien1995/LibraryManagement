using LibraryManagement.Models.Mobile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers.User
{
    public class NapTienController : Controller
    {
        // GET: NapTien
        public ActionResult Formnaptien()
        {
            return View("~/Views/User/Naptien/Xemnaptien.cshtml");
        }

        public ActionResult Thuchiennaptien(Object sender, EventArgs e)
        {
            RequestInfo info = new RequestInfo();
            info.Merchant_id = "";
            info.Merchant_acount = "biashanlocgia@gmail.com";
            info.Merchant_password = "";

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