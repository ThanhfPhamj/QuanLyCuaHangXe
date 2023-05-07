using System.Collections.Generic;
using VJPBase.API.Models.Requests.HangXeRequest;
using VJPBase.API.Models.Requests.HoaDonRequest;
using VJPBase.API.Models.Response;
using VJPBase.Data.Entities;

namespace VJPBase.API.Services
{
    public interface IHoaDonService
    {
        List<HoaDon> ThongKeTheoThang(int thang);
        IEnumerable<HoaDon> GetAll();
        HoaDon GetById(int id);

        void ThemHoaDon(ThemHoaDon themHoaDon);
        void XoaHoaDon(int id);
    }
}
