using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models.Mobile
{
    public class RequestInfo
    {
        private String _Funtion = "CardCharge";

        public String Funtion
        {
            get { return _Funtion; }
        }
        private String _Version = "2.0";

        public String Version
        {
            get { return _Version; }
        }
        private String _Merchant_id = String.Empty;

        public String Merchant_id
        {
            get { return _Merchant_id; }
            set { _Merchant_id = value; }
        }
        private String _Merchant_acount = String.Empty;

        public String Merchant_acount
        {
            get { return _Merchant_acount; }
            set { _Merchant_acount = value; }
        }
        private String _Merchant_password = String.Empty;

        public String Merchant_password
        {
            get { return _Merchant_password; }
            set { _Merchant_password = value; }
        }
        private String _Pincard = String.Empty;

        public String Pincard
        {
            get { return _Pincard; }
            set { _Pincard = value; }
        }
        private String _SerialCard = String.Empty;

        public String SerialCard
        {
            get { return _SerialCard; }
            set { _SerialCard = value; }
        }
        private String _CardType = String.Empty;

        public String CardType
        {
            get { return _CardType; }
            set { _CardType = value; }
        }
        private String _Refcode = String.Empty;

        public String Refcode
        {
            get { return _Refcode; }
            set { _Refcode = value; }
        }
        private String _Client_fullname = String.Empty;

        public String Client_fullname
        {
            get { return _Client_fullname; }
            set { _Client_fullname = value; }
        }
        private String _Client_email = String.Empty;

        public String Client_email
        {
            get { return _Client_email; }
            set { _Client_email = value; }
        }
        private String _Client_mobile = String.Empty;

        public String Client_mobile
        {
            get { return _Client_mobile; }
            set { _Client_mobile = value; }
        }
    }
}