using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Cache
{
   public class DTO_Product
    {
        public  string MaSP { get; set; }
        public  string TenSP { get; set; }
        public  int MaLSP { get; set; }
        public  decimal GiaNhap { get; set; }
        public  decimal GiaBan { get; set; }
        public  int KhuyenMai { get; set; }
        public  int SoLuong { get; set; }
        public DateTime NSX { get; set; }
        public  DateTime HSD { get; set; }
        public  byte[] HinhAnh { get; set; }
        public string keyword { get; set; }

    }
}
