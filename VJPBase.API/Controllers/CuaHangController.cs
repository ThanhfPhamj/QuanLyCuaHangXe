using Microsoft.AspNetCore.Mvc;
using VJPBase.API.Models.Requests.CuaHangRequest;
using VJPBase.API.Models.Requests.HangXeRequest;
using VJPBase.API.Services;

namespace VJPBase.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuaHangController : Controller
    {
        private ICuaHangService _cuaHangService;

        public CuaHangController(ICuaHangService cuaHangService)
        {
            _cuaHangService = cuaHangService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var nhanVien = _cuaHangService.GetAll();
            return Ok(nhanVien);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _cuaHangService.GetById(id);
            return Ok(user);
        }
        [HttpPost("Them")]
        public IActionResult ThemCuaHang(ThemCuaHang themCuaHang)
        {
            _cuaHangService.ThemCuaHang(themCuaHang);
            return Ok(new { Message = "Thêm cửa hàng thành công" });
        }
        [HttpPut("{id}")]
        public IActionResult SuaCuaHang(int id, SuaCuaHang suaCuaHang)
        {
            _cuaHangService.SuaCuaHang(id, suaCuaHang);
            return Ok(new { Message = "Sửa thông tin cửa hàng thành công" });
        }
        [HttpDelete("{id}")]
        public IActionResult XoaCuaHang(int id)
        {
            _cuaHangService.XoaCuaHang(id);
            return Ok(new { Message = "Xóa cửa hàng thành công" });
        }
    }
}
