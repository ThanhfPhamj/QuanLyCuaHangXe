using System.ComponentModel.DataAnnotations;

namespace VJPBase.API.Models.Requests.HoaDonRequest
{
    public class SuaHoaDon
    {
        
        public int MaKhachHang { get; set; }

        public int MaNhanVien { get; set; }
    }
}
