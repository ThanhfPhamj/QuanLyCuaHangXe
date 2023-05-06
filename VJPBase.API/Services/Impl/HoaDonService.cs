using System.Collections.Generic;
using System.Linq;
using VJPBase.API.Models.Requests.HangXeRequest;
using VJPBase.API.Models.Requests.HoaDonRequest;
using VJPBase.Data;
using VJPBase.Data.Entities;

namespace VJPBase.API.Services.Impl
{
    public class HoaDonService : IHoaDonService
    {
        private CuaHangXeDbContext _context;

        public HoaDonService(CuaHangXeDbContext context)
        {
            _context = context;

        }
        public IEnumerable<HoaDon> GetAll()
        {

            return _context.HoaDons
                .Where(xe => !xe.DaXoa)
                .ToList();
        }
        public HoaDon GetById(int id)
        {
            var hoaDon = _context.HoaDons
                .FirstOrDefault(xe => xe.MaHoaDon == id && !xe.DaXoa);
            if (hoaDon == null) throw new KeyNotFoundException("Không tìm thấy hóa đơn");
            return hoaDon;
        }

        public void ThemHoaDon(ThemHoaDon themHoaDon)
        {
            using (var hd = new CuaHangXeDbContext())
            {
                hd.HoaDons.Add(new HoaDon()
                {
                    MaKhachHang = themHoaDon.MaKhachHang,
                    MaNhanVien = themHoaDon.MaNhanVien,
                    NgayBan = System.DateTime.Now,
                    TongTien = 0,
                    DaXoa = false
                });
                hd.SaveChanges();
                
            }
              
        }
        
        public void XoaHoaDon(int id)
        {
            var hoaDonCanXoa = GetById(id);
            if (hoaDonCanXoa == null)
            {
                throw new KeyNotFoundException("Không tìm thấy nhân viên");
            }
            else
            {
                hoaDonCanXoa.DaXoa = true;
                _context.HoaDons.Update(hoaDonCanXoa);
                _context.SaveChanges();
                var hoaDonDaXoa = _context.ChiTietHoaDons.Where(xe => xe.MaHoaDon == id).ToList();
                foreach (var item in hoaDonDaXoa)
                {                 
                    item.DaXoa = true;
                    _context.ChiTietHoaDons.Update(item);
                    _context.SaveChanges();
                }
            }
        }
    }
}
