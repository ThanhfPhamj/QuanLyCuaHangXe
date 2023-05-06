
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VJPBase.API.Models.Requests.NhanVienRequest;
using VJPBase.API.Models.Response.Dto;
using VJPBase.Data;
using VJPBase.Data.Entities;

namespace VJPBase.API.Services.Impl
{
    public class NhanVienService : INhanVienService
    {
        private CuaHangXeDbContext _context;
        
        public NhanVienService(CuaHangXeDbContext context)
        {
            _context = context;
            
        }
        public IEnumerable<NhanVien> GetAll()
        {
            return _context.NhanViens
                .Where(nv => !nv.DaXoa)
                .ToList();
        }
        public NhanVien GetById(int id)
        {
            var nhanvien = _context.NhanViens
                .FirstOrDefault(nv => nv.MaNhanVien == id && !nv.DaXoa);
            if (nhanvien == null) throw new KeyNotFoundException("Không tìm thấy nhân viên");
            return nhanvien;
        }

        public void ThemNhanVien(ThemThongTinNhanVien themNV)
        {
            using (var nv = new CuaHangXeDbContext())
            {
                nv.NhanViens.Add(new NhanVien()
                {
                    TenNhanVien = themNV.TenNhanVien,
                    CCCD = themNV.CCCD,
                    NgaySinh = themNV.NgaySinh,
                    HinhAnh = themNV.HinhAnh,
                    DiaChi = themNV.DiaChi,
                    SDT = themNV.SDT,
                    DaXoa = false,
                    Email = themNV.Email,
                    MaCuaHang = themNV.MaCuaHang,
                    MaChucVu = themNV.MaChucVu
                });
                nv.SaveChanges();
            }
        }
        public void SuaNhanVien(int id , SuaThongTinNhanVien suaNV)
        {
            var nhanVienTonTai = GetById(id);
            if (nhanVienTonTai == null)
            {
                throw new KeyNotFoundException("Không tìm thấy nhân viên");
            }
            else
            {
                nhanVienTonTai.TenNhanVien = suaNV.TenNhanVien;
                nhanVienTonTai.CCCD = suaNV.CCCD;
                nhanVienTonTai.NgaySinh = suaNV.NgaySinh;
                nhanVienTonTai.HinhAnh = suaNV.HinhAnh;
                nhanVienTonTai.DiaChi = suaNV.DiaChi;
                nhanVienTonTai.SDT = suaNV.SDT;
                nhanVienTonTai.DaXoa = false;
                nhanVienTonTai.Email = suaNV.Email;
                nhanVienTonTai.MaCuaHang = suaNV.MaCuaHang;
                nhanVienTonTai.MaChucVu = suaNV.MaChucVu;
                _context.NhanViens.Update(nhanVienTonTai);
                _context.SaveChanges();
            }
          
        }
        public void XoaNhanVien(int id)
        {
            var nhanVienCanXoa = GetById(id);
            if (nhanVienCanXoa == null)
            {
                throw new KeyNotFoundException("Không tìm thấy nhân viên");
            }
            else
            {
                nhanVienCanXoa.DaXoa = true;
                _context.NhanViens.Update(nhanVienCanXoa);
                _context.SaveChanges();
            }    
        }
    }
}

