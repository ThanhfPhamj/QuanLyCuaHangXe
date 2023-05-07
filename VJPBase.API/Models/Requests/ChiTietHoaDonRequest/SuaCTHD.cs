using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VJPBase.Data.Entities;

namespace VJPBase.API.Models.Requests.ChiTietHoaDonRequest
{
    public class SuaCTHD
    {
        public int MaHoaDon { get; set; }
        
        public int MaXe { get; set; }

        public int SoLuong { get; set; }
    }
}
