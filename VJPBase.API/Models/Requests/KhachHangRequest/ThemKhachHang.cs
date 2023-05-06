using System;
using System.ComponentModel.DataAnnotations;

namespace VJPBase.API.Models.Requests.KhachHangRequest
{
    public class ThemKhachHang
    {
        [Required]
        public string TenKhachHang { get; set; }

        [Required]
        public string SDT { get; set; }
        [Required]
        public string DiaChi { get; set; }
        [Required]
        public DateTime NgaySinh { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
