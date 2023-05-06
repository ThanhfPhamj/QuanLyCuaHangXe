using System.Collections.Generic;
using VJPBase.API.Models.Requests.HangXeRequest;
using VJPBase.API.Models.Requests.XeRequest;
using VJPBase.Data.Entities;

namespace VJPBase.API.Services
{
    public interface IHangXeService
    {
        IEnumerable<HangXe> GetAll();
        HangXe GetById(int id);

        void ThemHangXe(ThemHangXe themHangXe);
        void SuaHangXe(int id, SuaHangXe suaHangXe);

        void XoaHangXe(int id);
    }
}
