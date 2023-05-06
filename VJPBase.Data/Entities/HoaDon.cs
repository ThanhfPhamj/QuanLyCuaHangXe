using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VJPBase.Data.Entities
{
    public class HoaDon
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaHoaDon { get; set; }

        [Key]
        [Required]
        public int MaKhachHang { get; set; }
        [ForeignKey("MaKhachHang")]
        public virtual KhachHang KhachHangs { get; set; }

        [Key]
        [Required]
        public int MaNhanVien { get; set; }
        [ForeignKey("MaNhanVien")]
        public virtual NhanVien NhanViens { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayBan { get; set; }
        
        public float TongTien { get; set; }

        public bool DaXoa { get; set; }
        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    }
}
