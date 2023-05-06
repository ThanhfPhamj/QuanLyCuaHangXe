using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJPBase.Data.Entities
{
    public class ChucVu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaChucVu { get; set; }
        [StringLength(50)]
        public string TenChucVu { get; set; }

        public bool DaXoa { get; set; }

        public ICollection<NhanVien> NhanViens { get; set; }
    }
}
