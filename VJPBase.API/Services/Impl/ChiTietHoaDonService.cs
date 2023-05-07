using System.Collections.Generic;
using VJPBase.API.Models.Requests.CuaHangRequest;
using VJPBase.Data.Entities;
using VJPBase.Data;
using System.Linq;
using VJPBase.API.Models.Requests.ChiTietHoaDonRequest;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Xml.Schema;

namespace VJPBase.API.Services.Impl
{
    public class ChiTietHoaDonService : IChiTietHoaDonService
    {
        private CuaHangXeDbContext _context;

        public ChiTietHoaDonService(CuaHangXeDbContext context)
        {
            _context = context;

        }
        public IEnumerable<ChiTietHoaDon> GetAll()
        {
            return _context.ChiTietHoaDons
                .Where(xe => !xe.DaXoa)
                .ToList();
        }
        public ChiTietHoaDon GetById(int id)
        {
            var cthd = _context.ChiTietHoaDons
                .FirstOrDefault(xe => xe.MaChiTietHoaDon == id && !xe.DaXoa);
            if (cthd == null) throw new KeyNotFoundException("Không tìm thấy chi tiết hóa đơn");
            return cthd;
        }

        public void ThemCTHD(ThemCTHD themCTHD)
        {
            var xe = _context.Xes.Where(x => x.MaXe == themCTHD.MaXe && !x.DaXoa).FirstOrDefault();
            using (var cthd = new CuaHangXeDbContext())
            {
                cthd.ChiTietHoaDons.Add(new ChiTietHoaDon()
                {
                    MaHoaDon = themCTHD.MaHoaDon,
                    MaXe = themCTHD.MaXe,
                    SoLuong = themCTHD.SoLuong,
                    ThanhTien = ThanhTien(themCTHD),
                    GiaBan = xe.GiaBan,
                    DaXoa = false
                }) ;
                cthd.SaveChanges();
                var updateTongTien = _context.ChiTietHoaDons.Where(c => !c.DaXoa && c.MaHoaDon == themCTHD.MaHoaDon).ToList();
                if (updateTongTien != null)
                {
                   foreach(var item in updateTongTien)
                    {
                        var tongTienHoaDon = _context.HoaDons.Where(c => c.MaHoaDon == themCTHD.MaHoaDon).FirstOrDefault();
                        tongTienHoaDon.TongTien = +item.ThanhTien;
                        _context.HoaDons.Update(tongTienHoaDon);
                        _context.SaveChanges();
                    }
                   
                }
            }
        }
        
        public float ThanhTien(ThemCTHD themCTHD)
        {
            float thanhtien;
            var xe = _context.Xes.Where(x =>x.MaXe == themCTHD.MaXe && !x.DaXoa).FirstOrDefault();
            thanhtien = xe.GiaBan * themCTHD.SoLuong;
            return thanhtien;
        }
        public float ThanhTien(SuaCTHD suaCTHD)
        {
            float thanhtien;
            var xe = _context.Xes.Where(x => x.MaXe == suaCTHD.MaXe && !x.DaXoa).FirstOrDefault();
            thanhtien = xe.GiaBan * suaCTHD.SoLuong;
            return thanhtien;
        }
        public void SuaCTHD(int id, SuaCTHD suaCTHD)
        {
            var xe = _context.Xes.Where(x => x.MaXe == suaCTHD.MaXe && !x.DaXoa).FirstOrDefault();
            var tonTaiCTHD = GetById(id);
            if (tonTaiCTHD == null)
            {
                throw new KeyNotFoundException("Không tìm thấy chi tiết hóa đơn");
            }
            else
            {
                tonTaiCTHD.MaHoaDon = suaCTHD.MaHoaDon;
                tonTaiCTHD.MaXe = suaCTHD.MaXe;
                tonTaiCTHD.SoLuong = suaCTHD.SoLuong;
                tonTaiCTHD.ThanhTien = ThanhTien(suaCTHD);
                tonTaiCTHD.GiaBan = xe.GiaBan;
                tonTaiCTHD.DaXoa = false;
                _context.ChiTietHoaDons.Update(tonTaiCTHD);
                _context.SaveChanges();
            }

        }
        public void XoaCTHD(int id)
        {
            var cTHDCanXoa = GetById(id);
            if (cTHDCanXoa == null)
            {
                throw new KeyNotFoundException("Không tìm thấy chi tiết hóa đơn");
            }
            else
            {
                cTHDCanXoa.DaXoa = true;
                _context.ChiTietHoaDons.Update(cTHDCanXoa);
                _context.SaveChanges();
            }
        }
    }
}
