using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VJPBase.Data.Entities;

namespace VJPBase.API.Models.Requests.ChiTietHoaDonRequest
{
    public class ThemCTHD
    {
        [Required]
        public int MaHoaDon { get; set; }
        [Required]
        public int MaXe { get; set; }
        [Required]
         public int SoLuong { get; set; }
    }
}
