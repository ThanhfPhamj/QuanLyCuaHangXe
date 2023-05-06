using System.ComponentModel.DataAnnotations;
using System;

namespace VJPBase.API.Models.Requests.NhanVienRequest
{
    public class SuaThongTinNhanVien
    {
        public string TenNhanVien { get; set; }

       
        public string CCCD { get; set; }


        public DateTime NgaySinh { get; set; }

      
        public string HinhAnh { get; set; }

       
        public string DiaChi { get; set; }

    
        public string SDT { get; set; }

     
        public string Email { get; set; }

    
        public int MaCuaHang { get; set; }

        public int MaChucVu { get; set; }
    }
}
