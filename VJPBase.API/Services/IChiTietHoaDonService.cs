using System.Collections.Generic;
using VJPBase.API.Models.Requests.ChiTietHoaDonRequest;
using VJPBase.API.Models.Requests.HoaDonRequest;
using VJPBase.Data.Entities;

namespace VJPBase.API.Services
{
    public interface IChiTietHoaDonService
    {
        IEnumerable<ChiTietHoaDon> GetAll();
        ChiTietHoaDon GetById(int id);

        void ThemCTHD(ThemCTHD themCTHD);
        float ThanhTien(ThemCTHD themCTHD);

        float ThanhTien(SuaCTHD suaCTHD);
        void SuaCTHD(int id ,SuaCTHD suaCTHD);
        void XoaCTHD(int id);
    }
}
