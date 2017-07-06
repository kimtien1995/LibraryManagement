using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models.DTO
{
    public class Items
    {
        private string tensach;
        private string madausach;
        private string bia;
        private string tacgia;
        private int soluong;


        public string Tensach
        {
            get
            {
                return tensach;
            }

            set
            {
                tensach = value;
            }
        }
        public string Bia
        {
            get
            {
                return bia;
            }

            set
            {
                bia = value;
            }
        }
        public int Soluong
        {
            get
            {
                return soluong;
            }

            set
            {
                soluong = value;
            }
        }
        public string Madausach
        {
            get
            {
                return madausach;
            }

            set
            {
                madausach = value;
            }
        }
        public string Tacgia
        {
            get
            {
                return tacgia;
            }

            set
            {
                tacgia = value;
            }
        }

        public Items()
        {
            tensach = "";
            bia = "";
            soluong = 0;
            madausach = "";
            tacgia = "";
        }
    }
}