
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJPBase.Data.Entities
{
    public class LoaiXe
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaLoaiXe { get; set; }

        [StringLength(50)]
        public string TenLoaiXe { get; set; }

        [DisplayFormat(DataFormatString = "{yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NamSanXuat { get; set; }

        public bool DaXoa { get; set; }
        public ICollection<Xe> Xes { get; set; }
    }
}
