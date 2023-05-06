 using System.ComponentModel.DataAnnotations;
using System;

namespace VJPBase.API.Models.Requests.NhanVienRequest
{
    public class ThemThongTinNhanVien
    {
        [Required]
        public string TenNhanVien { get; set; }

        [Required]
        //[MinLength(12)]
        public string CCCD { get; set; }

        [Required]
       
        public DateTime NgaySinh { get; set; }

        [Required]

        public string HinhAnh { get; set; }

        [Required]
        public string DiaChi { get; set; }

        [Required]
        //[MinLength(10)]
        public string SDT { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int MaCuaHang { get; set; }

        [Required]
        public int MaChucVu { get; set; }
    }
}
