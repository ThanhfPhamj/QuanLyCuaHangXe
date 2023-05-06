using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJPBase.Data.Entities
{
    public class Xe
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaXe { get; set; }

        [StringLength(50)]
        public string TenXe { get; set; }

        [StringLength(50)]
        public string MoTa { get; set; }

        [StringLength(50)]
        public string ThongTinBaoHanh { get; set; }

        [StringLength(10)]
        public string DonViTinh { get; set; }

        public int SoLuong { get; set; }

        public float GiaBan { get; set; }

        public bool DaXoa { get; set; }
        [Required]
        public int MaHangXe { get; set; }
        [ForeignKey("MaHangXe")]
        public virtual HangXe HangXes { get; set; }

        [Required]
        public int MaLoaiXe { get; set; }
        [ForeignKey("MaLoaiXe")]
        public virtual LoaiXe LoaiXes { get; set; }

        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
