//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LuocSuMuaSach
    {
        public string maluocsumuasach { get; set; }
        public string manguoidung { get; set; }
        public string madausach { get; set; }
        public System.DateTime ngaymua { get; set; }
        public int tientra { get; set; }
    
        public virtual DauSach DauSach { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
    }
}