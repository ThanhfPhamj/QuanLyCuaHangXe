using System.Collections.Generic;
using VJPBase.API.Models.Requests.XeRequest;
using VJPBase.Data.Entities;
using VJPBase.Data;
using System.Linq;
using VJPBase.API.Models.Requests.HangXeRequest;
using VJPBase.API.Models.Response.Dto;

namespace VJPBase.API.Services.Impl
{
    public class HangXeService : IHangXeService
    {
        private CuaHangXeDbContext _context;

        public HangXeService(CuaHangXeDbContext context)
        {
            _context = context;

        }
        public IEnumerable<HangXe> GetAll()
        {
            return _context.HangXes
                .Where(xe => !xe.DaXoa)
                .ToList();
        }
        public HangXe GetById(int id)
        {
            var xe = _context.HangXes
                .FirstOrDefault(xe => xe.MaHangXe == id && !xe.DaXoa);
            if (xe == null) throw new KeyNotFoundException("Không tìm thấy hãng xe");
            return xe;
        }

        public void ThemHangXe(ThemHangXe themHangXe)
        {
            using (var xe = new CuaHangXeDbContext())
            {
                xe.HangXes.Add(new HangXe()
                {
                    TenHang = themHangXe.TenHang,
                    DiaChi = themHangXe.DiaChi,
                    SDT = themHangXe.SDT,                  
                    DaXoa = false
                });
                xe.SaveChanges();
            }
        }
        public void SuaHangXe(int id, SuaHangXe suaHangXe)
        {
            var tonTaiHangXe = GetById(id);
            if (tonTaiHangXe == null)
            {
                throw new KeyNotFoundException("Không tìm thấy xe");
            }
            else
            {
                tonTaiHangXe.TenHang = suaHangXe.TenHang;
                tonTaiHangXe.DiaChi = suaHangXe.DiaChi;
                tonTaiHangXe.SDT = suaHangXe.SDT;
                tonTaiHangXe.DaXoa = false;
                _context.HangXes.Update(tonTaiHangXe);
                _context.SaveChanges();
            }

        }
        public void XoaHangXe(int id)
        {
            var hangXeCanXoa = GetById(id);
            if (hangXeCanXoa == null)
            {
                throw new KeyNotFoundException("Không tìm thấy nhân viên");
            }
            else
            {
                hangXeCanXoa.DaXoa = true;
                _context.HangXes.Update(hangXeCanXoa);
                _context.SaveChanges();
                var xeCoHangDaXoa = _context.Xes.Where(xe => xe.MaHangXe == id).ToList();
                foreach(var item in xeCoHangDaXoa){
                    item.DaXoa = true;
                    _context.Xes.Update(item);
                    _context.SaveChanges();
                }
            }
        }
    }
}
