using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VJPBase.API.Models.Requests.HangXeRequest
{
    public class ThemHangXe
    {
       
        [Required]
        public string TenHang { get; set; }

        [Required]
        public string SDT { get; set; }

        [Required]
        public string DiaChi { get; set; }
    }
}
