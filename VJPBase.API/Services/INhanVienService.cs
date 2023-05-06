using System.Collections.Generic;
using VJPBase.API.Models.Requests.NhanVienRequest;
using VJPBase.Data.Entities;

namespace VJPBase.API.Services
{
    public interface INhanVienService
    {
        IEnumerable<NhanVien> GetAll();
        NhanVien GetById(int id);

        void ThemNhanVien(ThemThongTinNhanVien themNV);
        void SuaNhanVien(int id, SuaThongTinNhanVien suaNV);

        void XoaNhanVien(int id);
    }
}
