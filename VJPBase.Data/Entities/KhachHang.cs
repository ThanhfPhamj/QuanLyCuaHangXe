using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace VJPBase.Data.Entities
{
    public class KhachHang
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaKhachHang { get; set; }

        [StringLength(50)]
        public string TenKhachHang { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgaySinh { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public bool DaXoa { get; set; }
        public ICollection<HoaDon> HoaDons { get; set; }
    }
}
