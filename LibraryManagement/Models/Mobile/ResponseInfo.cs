using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models.Mobile
{
    public class ResponseInfo
    {
        private String _Errorcode = string.Empty;

        public String Errorcode
        {
            get { return _Errorcode; }
            set { _Errorcode = value; }
        }
        private String _TransactionID = String.Empty;

        public String TransactionID
        {
            get { return _TransactionID; }
            set { _TransactionID = value; }
        }
        private String _Message = String.Empty;

        public String Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        private String _Card_amount = "0";

        public String Card_amount
        {
            get { return _Card_amount; }
            set { _Card_amount = value; }
        }
        private String _Transaction_amount = "0";

        public String Transaction_amount
        {
            get { return _Transaction_amount; }
            set { _Transaction_amount = value; }
        }
        private String _Refcode = String.Empty;

        public String Refcode
        {
            get { return _Refcode; }
            set { _Refcode = value; }
        }
    }
}