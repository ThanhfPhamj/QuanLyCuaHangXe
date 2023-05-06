using System.Collections.Generic;
using VJPBase.API.Models.Requests.KhachHangRequest;
using VJPBase.API.Models.Requests.XeRequest;
using VJPBase.Data.Entities;

namespace VJPBase.API.Services
{
    public interface IXeService
    {
        IEnumerable<Xe> GetAll();
        Xe GetById(int id);

        void ThemXe(ThemXe themXe);
        void SuaXe(int id, SuaXe suaXe);

        void XoaXe(int id);

        int KiemTraSoLuong(int id);
    }
}
