using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using VJPBase.Data.Entities;

namespace VJPBase.API.Models.Requests.HoaDonRequest
{
    public class ThemHoaDon
    {
        [Required]
        public int MaKhachHang { get; set; }
      
        [Required]
        public int MaNhanVien { get; set; }

        //[Required]
        //public int MaXe { get; set; }

        //[Required]
        //public int SoLuong { get; set; }
    }
}
