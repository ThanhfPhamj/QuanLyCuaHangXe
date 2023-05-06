using VJPBase.API.Models.Response.Dto;
using VJPBase.Data.Entities;

namespace VJPBase.API.Models.Response
{
    public class HoaDonRespone
    {
        public ThongTinHoaDon ThongTinHoaDon { get; set; }
        public HoaDonRespone(HoaDon hoaDon, ChiTietHoaDon chiTietHoaDon)
        {

            ThongTinHoaDon = new ThongTinHoaDon
            {
                TenKhachHang = hoaDon.KhachHangs.TenKhachHang,
                TenNhanVien = hoaDon.NhanViens.TenNhanVien,
                TenXe = chiTietHoaDon.Xe.TenXe,
                SoLuong = chiTietHoaDon.SoLuong,
                TongTien = hoaDon.TongTien
            };
        }
    }
}
