using Microsoft.AspNetCore.Mvc;
using VJPBase.API.Models.Requests.KhachHangRequest;
using VJPBase.API.Models.Requests.NhanVienRequest;
using VJPBase.API.Services;

namespace VJPBase.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KhachHangController : Controller
    {
        private IKhachHangService _khachHangService;

        public KhachHangController(IKhachHangService khachHangService)
        {
            _khachHangService = khachHangService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var nhanVien = _khachHangService.GetAll();
            return Ok(nhanVien);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _khachHangService.GetById(id);
            return Ok(user);
        }
        [HttpPost("Them")]
        public IActionResult ThemKhachHang(ThemKhachHang themKH)
        {
            _khachHangService.ThemKhachHang(themKH);
            return Ok(new { Message = "Thêm khách hàng thành công" });
        }
        [HttpPut("{id}")]
        public IActionResult SuaKhachHang(int id, SuaKhachHang suaKH)
        {
            _khachHangService.SuaKhachHang(id, suaKH);
            return Ok(new { Message = "Sửa thông tin khách hàng thành công" });
        }
        [HttpDelete("{id}")]
        public IActionResult XoaKhachHang(int id)
        {
            _khachHangService.XoaKhachHang(id);
            return Ok(new { Message = "Xóa khách hàng thành công" });
        }
    }
}
