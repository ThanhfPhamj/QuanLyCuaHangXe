using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJPBase.Data.Entities
{
    public class ChiTietHoaDon
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaChiTietHoaDon { get; set; }      
        
        [Key]
        [Required]
        
        public int MaHoaDon { get; set; }
        [ForeignKey("MaHoaDon")]
        public virtual HoaDon HoaDon { get; set; }

        [Key]
        [Required]
        public int MaXe { get; set; }
        [ForeignKey("MaXe")]
        public virtual Xe Xe { get; set; }
        public int SoLuong { get; set; }

        public float GiaBan { get; set; }

        public bool DaXoa { get; set; }

    }
}
