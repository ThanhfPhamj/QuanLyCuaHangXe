using Microsoft.AspNetCore.Mvc;
using VJPBase.API.Models.Requests.KhachHangRequest;
using VJPBase.API.Models.Requests.XeRequest;
using VJPBase.API.Services;

namespace VJPBase.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class XeController : Controller
    {
        private IXeService _xeService;

        public XeController(IXeService xeService)
        {
            _xeService = xeService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var nhanVien = _xeService.GetAll();
            return Ok(nhanVien);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _xeService.GetById(id);
            return Ok(user);
        }
        [HttpPost("Them")]
        public IActionResult ThemXe(ThemXe themXe)
        {
            _xeService.ThemXe(themXe);
            return Ok(new { Message = "Thêm xe thành công" });
        }
        [HttpPut("{id}")]
        public IActionResult SuaXe(int id, SuaXe suaXe)
        {
            _xeService.SuaXe(id, suaXe);
            return Ok(new { Message = "Sửa thông tin xe thành công" });
        }
        [HttpDelete("{id}")]
        public IActionResult XoaXe(int id)
        {
            _xeService.XoaXe(id);
            return Ok(new { Message = "Xóa xe thành công" });
        }
        [HttpGet("KiemTraSoLuong/{id}")]
        public IActionResult KiemTraSoLuong(int id)
        {
            int soLuongTonKho = _xeService.KiemTraSoLuong(id);
            return Ok(new { Message = $"Số lượng xe tồn kho {soLuongTonKho}" });   
        }
    }

}
