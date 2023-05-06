using System.Collections.Generic;
using VJPBase.API.Models.Requests.HangXeRequest;
using VJPBase.Data.Entities;
using VJPBase.Data;
using System.Linq;
using VJPBase.API.Models.Requests.CuaHangRequest;
using System.Text.Encodings.Web;

namespace VJPBase.API.Services.Impl
{
    public class CuaHangService : ICuaHangService
    {
        private CuaHangXeDbContext _context;

        public CuaHangService(CuaHangXeDbContext context)
        {
            _context = context;

        }
        public IEnumerable<CuaHang> GetAll()
        {
            return _context.CuaHangs
                .Where(xe => !xe.DaXoa)
                .ToList();
        }
        public CuaHang GetById(int id)
        {
            var cuaHang = _context.CuaHangs
                .FirstOrDefault(xe => xe.MaCuaHang == id && !xe.DaXoa);
            if (cuaHang == null) throw new KeyNotFoundException("Không tìm thấy cửa hàng");
            return cuaHang;
        }

        public void ThemCuaHang(ThemCuaHang themCuaHang)
        {
            using (var ch = new CuaHangXeDbContext())
            {
                ch.CuaHangs.Add(new CuaHang()
                {
                    TenCuaHang = themCuaHang.TenCuaHang,
                    DiaChi = themCuaHang.DiaChi,
                    SDT = themCuaHang.SDT,                
                    DaXoa = false
                });
                ch.SaveChanges();
            }
        }
        public void SuaCuaHang(int id, SuaCuaHang suaCuaHang)
        {
            var tonTaiCuaHang = GetById(id);
            if (tonTaiCuaHang == null)
            {
                throw new KeyNotFoundException("Không tìm thấy cửa hàng");
            }
            else
            {
                tonTaiCuaHang.TenCuaHang = suaCuaHang.TenCuaHang;
                tonTaiCuaHang.DiaChi = suaCuaHang.DiaChi;
                tonTaiCuaHang.SDT = suaCuaHang.SDT;
                tonTaiCuaHang.DaXoa = false;
                _context.CuaHangs.Update(tonTaiCuaHang);
                _context.SaveChanges();
            }

        }
        public void XoaCuaHang(int id)
        {
            var cuaHangCanXoa = GetById(id);
            if (cuaHangCanXoa == null)
            {
                throw new KeyNotFoundException("Không tìm thấy cửa hàng");
            }
            else
            {
                cuaHangCanXoa.DaXoa = true;
                _context.CuaHangs.Update(cuaHangCanXoa);
                _context.SaveChanges();
                var xoaCuaHang = _context.NhanViens.Where(nv => nv.MaCuaHang == id).ToList();
                foreach (var item in xoaCuaHang)
                {
                    item.DaXoa = true;
                    _context.NhanViens.Update(item);
                    _context.SaveChanges();
                }
            }
        }
    }
}
