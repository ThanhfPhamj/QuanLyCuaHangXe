using Microsoft.AspNetCore.Mvc;
using VJPBase.API.Models.Requests.HangXeRequest;
using VJPBase.API.Models.Requests.HoaDonRequest;
using VJPBase.API.Services;
using VJPBase.API.Services.Impl;

namespace VJPBase.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HoaDonController : Controller
    {
        private IHoaDonService _hoaDonService;

        public HoaDonController(IHoaDonService hoaDonService)
        {
            _hoaDonService = hoaDonService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var nhanVien = _hoaDonService.GetAll();
            return Ok(nhanVien);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _hoaDonService.GetById(id);
            return Ok(user);
        }
        [HttpPost("Them")]
        public IActionResult ThemHoaDon(ThemHoaDon themHoaDon)
        {
            _hoaDonService.ThemHoaDon(themHoaDon);
            return Ok(new { Message = "Thêm hóa đơn thành công" });
        }
        [HttpDelete("{id}")]
        public IActionResult XoaHoaDon(int id)
        {
            _hoaDonService.XoaHoaDon(id);
            return Ok(new { Message = "Xóa hóa đơn thành công" });
        }
    }
}
