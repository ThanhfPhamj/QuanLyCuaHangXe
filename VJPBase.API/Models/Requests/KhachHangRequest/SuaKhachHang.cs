using System.ComponentModel.DataAnnotations;
using System;

namespace VJPBase.API.Models.Requests.KhachHangRequest
{
    public class SuaKhachHang
    {
         
        public string TenKhachHang { get; set; }

         
        public string SDT { get; set; }
         
        public string DiaChi { get; set; }
         
        public DateTime NgaySinh { get; set; }
         
        public string Email { get; set; }
    }
}
