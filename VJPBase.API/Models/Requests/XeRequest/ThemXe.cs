using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VJPBase.Data.Entities;

namespace VJPBase.API.Models.Requests.XeRequest
{
    public class ThemXe
    {
        [Required]
        public string TenXe { get; set; }

        [Required]
        public string MoTa { get; set; }

        [Required]
        public string ThongTinBaoHanh { get; set; }

        [Required]
        public string DonViTinh { get; set; }

        [Required]
        public int SoLuong { get; set; }
        [Required]
        public float GiaBan { get; set; }
        
        [Required]
        public int MaHangXe { get; set; }
        
        [Required]
        public int MaLoaiXe { get; set; }
    }
}
