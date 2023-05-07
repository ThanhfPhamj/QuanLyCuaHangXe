using Microsoft.AspNetCore.Mvc;
using VJPBase.API.Models.Requests.ChiTietHoaDonRequest;
using VJPBase.API.Models.Requests.CuaHangRequest;
using VJPBase.API.Services;
using VJPBase.API.Services.Impl;

namespace VJPBase.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChiTietHoaDonController : Controller
    {
        private IChiTietHoaDonService _chiTietHoaDonService;

        public ChiTietHoaDonController(IChiTietHoaDonService chiTietHoaDonService)
        {
            _chiTietHoaDonService = chiTietHoaDonService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var cthd = _chiTietHoaDonService.GetAll();
            return Ok(cthd);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cthd = _chiTietHoaDonService.GetById(id);
            return Ok(cthd);
        }
        [HttpPost("Them")]
        public IActionResult ThemCTHD(ThemCTHD themCTHD)
        {
            _chiTietHoaDonService.ThemCTHD(themCTHD);
            return Ok(new { Message = "Thêm chi tiết hóa đơn thành công" });
        }
        [HttpPut("{id}")]
        public IActionResult SuaCuaHang(int id, SuaCTHD suaCTHD)
        {
            _chiTietHoaDonService.SuaCTHD(id, suaCTHD);
            return Ok(new { Message = "Sửa chi tiết hóa đơn thành công" });
        }
        [HttpDelete("{id}")]
        public IActionResult XoaCTHD(int id)
        {
            _chiTietHoaDonService.XoaCTHD(id);
            return Ok(new { Message = "Xóa cửa hàng thành công" });
        }
    }
}
