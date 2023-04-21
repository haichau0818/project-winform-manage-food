using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Cache
{
    public class DTO_Bill
    {
        public int MaHD { get; set; }
        public int NVLap { get; set; }
        public  string ThongTinKH { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public string GhiChu { get; set; }
        public bool DaThanhToan { get; set; }
        public decimal SoTienTra { get; set; }
        public decimal SoTienThua { get; set; }
    }
}
