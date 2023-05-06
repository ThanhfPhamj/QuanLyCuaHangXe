using System.Collections.Generic;
using System.Linq;
using VJPBase.API.Models.Requests.KhachHangRequest;
using VJPBase.API.Models.Requests.NhanVienRequest;
using VJPBase.Data;
using VJPBase.Data.Entities;

namespace VJPBase.API.Services.Impl
{
    public class KhachHangService : IKhachHangService
    {
        private CuaHangXeDbContext _context;

        public KhachHangService(CuaHangXeDbContext context)
        {
            _context = context;

        }
        public IEnumerable<KhachHang> GetAll()
        {
            return _context.KhachHangs
                .Where(nv => !nv.DaXoa)
                .ToList();
        }
        public KhachHang GetById(int id)
        {
            var khachHang = _context.KhachHangs
                .FirstOrDefault(nv => nv.MaKhachHang == id && !nv.DaXoa);
            if (khachHang == null) throw new KeyNotFoundException("Không tìm thấy khách hàng");
            return khachHang;
        }

        public void ThemKhachHang(ThemKhachHang themKH)
        {
            using (var kh = new CuaHangXeDbContext())
            {
                kh.KhachHangs.Add(new KhachHang()
                {
                    TenKhachHang= themKH.TenKhachHang,
                    SDT = themKH.SDT,
                    NgaySinh = themKH.NgaySinh,                  
                    DiaChi = themKH.DiaChi,               
                    DaXoa = false
                });
                kh.SaveChanges();
            }
        }
        public void SuaKhachHang(int id, SuaKhachHang suaKH)
        {
            var tonTaiKhachHang = GetById(id);
            if (tonTaiKhachHang == null)
            {
                throw new KeyNotFoundException("Không tìm thấy nhân viên");
            }
            else
            {
                tonTaiKhachHang.TenKhachHang = suaKH.TenKhachHang;
                tonTaiKhachHang.SDT = suaKH.SDT;
                tonTaiKhachHang.NgaySinh = suaKH.NgaySinh;
                tonTaiKhachHang.DiaChi = suaKH.DiaChi;
                tonTaiKhachHang.DaXoa = false;
                _context.KhachHangs.Update(tonTaiKhachHang);
                _context.SaveChanges();
            }

        }
        public void XoaKhachHang(int id)
        {
            var khachHangCanXoa = GetById(id);
            if (khachHangCanXoa == null)
            {
                throw new KeyNotFoundException("Không tìm thấy nhân viên");
            }
            else
            {
                khachHangCanXoa.DaXoa = true;
                _context.KhachHangs.Update(khachHangCanXoa);
                _context.SaveChanges();
            }
        }
    }

}
