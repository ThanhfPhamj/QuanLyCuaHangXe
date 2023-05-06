using Microsoft.AspNetCore.Mvc;
using VJPBase.API.Models.Requests.HangXeRequest;
using VJPBase.API.Models.Requests.KhachHangRequest;
using VJPBase.API.Services;

namespace VJPBase.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HangXeController : Controller
    {
        private IHangXeService _hangXeService;

        public HangXeController(IHangXeService hangXeService)
        {
            _hangXeService = hangXeService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var nhanVien = _hangXeService.GetAll();
            return Ok(nhanVien);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _hangXeService.GetById(id);
            return Ok(user);
        }
        [HttpPost("Them")]
        public IActionResult ThemHangXe(ThemHangXe themHangXe)
        {
            _hangXeService.ThemHangXe(themHangXe);
            return Ok(new { Message = "Thêm hãng xe thành công" });
        }
        [HttpPut("{id}")]
        public IActionResult SuaHangXe(int id, SuaHangXe suaHangXe)
        {
            _hangXeService.SuaHangXe(id, suaHangXe);
            return Ok(new { Message = "Sửa thông tin hãng xe thành công" });
        }
        [HttpDelete("{id}")]
        public IActionResult XoaHangXe(int id)
        {
            _hangXeService.XoaHangXe(id);
            return Ok(new { Message = "Xóa hãng xe thành công" });
        }
    }
}
