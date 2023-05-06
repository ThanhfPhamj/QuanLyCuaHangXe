using System.Collections.Generic;
using VJPBase.API.Models.Requests.CuaHangRequest;
using VJPBase.API.Models.Requests.HangXeRequest;
using VJPBase.Data.Entities;

namespace VJPBase.API.Services
{
    public interface ICuaHangService
    {
        IEnumerable<CuaHang> GetAll();
        CuaHang GetById(int id);

        void ThemCuaHang(ThemCuaHang themCuaHang);
        void SuaCuaHang(int id, SuaCuaHang suaCuaHang);

        void XoaCuaHang(int id);
    }
}
