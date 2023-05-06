using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VJPBase.API.Models.Requests.NhanVienRequest;
using VJPBase.API.Models.Response.Dto;
using VJPBase.API.Services;
using VJPBase.Data;
using VJPBase.Data.Entities;

namespace VJPBase.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class NhanVienController : Controller
    {
        private INhanVienService _nhanVienService;

        public NhanVienController(INhanVienService nhanVienService)
        {
            _nhanVienService = nhanVienService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var nhanVien = _nhanVienService.GetAll();
            return Ok(nhanVien);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _nhanVienService.GetById(id);
            return Ok(user);
        }
        [HttpPost("Them")]
        public IActionResult ThemNhanVien(ThemThongTinNhanVien themNV)
        {
           _nhanVienService.ThemNhanVien(themNV);
            return Ok(new { Message = "Thêm nhân viên thành công" });
        }
        [HttpPut("{id}")]
        public IActionResult SuaNhanVien(int id ,SuaThongTinNhanVien suaNV)
        {         
            _nhanVienService.SuaNhanVien(id,suaNV);
            return Ok(new { Message = "Sửa thông tin nhân viên thành công" });
        }
        [HttpDelete("{id}")]
        public IActionResult XoaNhanVien(int id )
        {
            _nhanVienService.XoaNhanVien(id);
            return Ok(new { Message = "Xóa nhân viên thành công" });
        }
    }
}
