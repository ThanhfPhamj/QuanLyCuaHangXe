    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJPBase.Data.Entities
{
    public class HangXe
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaHangXe { get; set; }

        [StringLength(50)]
        public string TenHang { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        public bool DaXoa { get; set; }
        public ICollection<Xe> Xes { get; set; }
    }
}
