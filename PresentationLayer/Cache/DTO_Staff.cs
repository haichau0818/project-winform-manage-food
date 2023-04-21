using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Cache
{
    public class DTO_Staff
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public int MaQuyen { get; set; }
        public string tenQuyen { get; set; }
        public int IDTK { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
       
    }
}
