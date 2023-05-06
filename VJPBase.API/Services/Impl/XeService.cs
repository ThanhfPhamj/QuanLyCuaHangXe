using System.Collections.Generic;
using VJPBase.API.Models.Requests.KhachHangRequest;
using VJPBase.Data.Entities;
using VJPBase.Data;
using System.Linq;
using VJPBase.API.Models.Requests.XeRequest;

namespace VJPBase.API.Services.Impl
{
    public class XeService : IXeService
    {
        private CuaHangXeDbContext _context;

        public XeService(CuaHangXeDbContext context)
        {
            _context = context;

        }
        public IEnumerable<Xe> GetAll()
        {
            return _context.Xes
                .Where(xe => !xe.DaXoa)
                .ToList();
        }
        public Xe GetById(int id)
        {
            var xe = _context.Xes
                .FirstOrDefault(xe => xe.MaXe == id && !xe.DaXoa);
            if (xe == null) throw new KeyNotFoundException("Không tìm thấy xe");
            return xe;
        }

        public void ThemXe(ThemXe themXe)
        {
            using (var xe = new CuaHangXeDbContext())
            {
                xe.Xes.Add(new Xe()
                {
                    TenXe = themXe.TenXe,
                    MoTa = themXe.MoTa,
                    ThongTinBaoHanh = themXe.ThongTinBaoHanh,
                    DonViTinh = themXe.DonViTinh,
                    SoLuong = themXe.SoLuong,
                    GiaBan = themXe.GiaBan,
                    MaHangXe = themXe.MaHangXe,
                    MaLoaiXe = themXe.MaLoaiXe,
                    DaXoa = false
                });
                xe.SaveChanges();
            }
        }
        public void SuaXe(int id, SuaXe suaXe)
        {
            var tonTaiXe = GetById(id);
            if (tonTaiXe == null)
            {
                throw new KeyNotFoundException("Không tìm thấy xe");
            }
            else
            {
                tonTaiXe.TenXe = suaXe.TenXe;
                tonTaiXe.MoTa = suaXe.MoTa;
                tonTaiXe.ThongTinBaoHanh = suaXe.ThongTinBaoHanh;
                tonTaiXe.DonViTinh = suaXe.DonViTinh;
                tonTaiXe.SoLuong = suaXe.SoLuong;
                tonTaiXe.GiaBan = suaXe.GiaBan;
                tonTaiXe.MaHangXe = suaXe.MaHangXe;
                tonTaiXe.MaLoaiXe = suaXe.MaLoaiXe;
                tonTaiXe.DaXoa = false;
                _context.Xes.Update(tonTaiXe);
                _context.SaveChanges();
            }

        }
        public void XoaXe(int id)
        {
            var xeCanXoa = GetById(id);
            if (xeCanXoa == null)
            {
                throw new KeyNotFoundException("Không tìm thấy xe");
            }
            else
            {
                xeCanXoa.DaXoa = true;
                _context.Xes.Update(xeCanXoa);
                _context.SaveChanges();
            }
        }
        public int KiemTraSoLuong(int id)
        {
            var xeCanKiemTraSoLuong = GetById(id);
            if (xeCanKiemTraSoLuong == null)
            {
                throw new KeyNotFoundException("Không tìm thấy xe");
            }
            return xeCanKiemTraSoLuong.SoLuong;
        }
    }
}
