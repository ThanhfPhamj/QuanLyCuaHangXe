using System.ComponentModel.DataAnnotations;

namespace VJPBase.API.Models.Requests.CuaHangRequest
{
    public class ThemCuaHang
    {
        [Required]
        public string TenCuaHang { get; set; }

        [Required]
        public string SDT { get; set; }

        [Required]
        public string DiaChi { get; set; }
    }
}
