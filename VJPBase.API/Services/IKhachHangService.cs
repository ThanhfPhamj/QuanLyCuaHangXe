using System.Collections.Generic;
using VJPBase.API.Models.Requests.KhachHangRequest;
using VJPBase.API.Models.Requests.NhanVienRequest;
using VJPBase.Data.Entities;

namespace VJPBase.API.Services
{
    public interface IKhachHangService
    {
        IEnumerable<KhachHang> GetAll();
        KhachHang GetById(int id);

        void ThemKhachHang(ThemKhachHang themKH);
        void SuaKhachHang(int id, SuaKhachHang suaKH);

        void XoaKhachHang(int id);
    }
}
