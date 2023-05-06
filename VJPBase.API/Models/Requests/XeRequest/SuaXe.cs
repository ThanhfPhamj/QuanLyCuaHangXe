using System.ComponentModel.DataAnnotations;

namespace VJPBase.API.Models.Requests.XeRequest
{
    public class SuaXe
    {
       
        public string TenXe { get; set; }

        
        public string MoTa { get; set; }

        
        public string ThongTinBaoHanh { get; set; }

        
        public string DonViTinh { get; set; }

        
        public int SoLuong { get; set; }
        
        public float GiaBan { get; set; }
        
        public bool DaXoa { get; set; }
        
        public int MaHangXe { get; set; }

        
        public int MaLoaiXe { get; set; }
    }
}
