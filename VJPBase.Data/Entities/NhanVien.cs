using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJPBase.Data.Entities
{
    public class NhanVien
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaNhanVien { get; set; }

        [StringLength(50)]
        public string TenNhanVien { get; set; }

        [StringLength(12)]
        public string CCCD { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgaySinh { get; set; }

        [StringLength(50)]
        public string HinhAnh { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public bool DaXoa { get; set; }
        [Required]
        public int MaCuaHang { get; set; }
        [ForeignKey("MaCuaHang")]
        public virtual CuaHang CuaHangs { get; set; }

        [Required]
        public int MaChucVu { get; set; }
        [ForeignKey("MaChucVu")]
        public virtual ChucVu ChucVus { get; set; }

        public ICollection<HoaDon> HoaDons { get; set; }

    }
}
