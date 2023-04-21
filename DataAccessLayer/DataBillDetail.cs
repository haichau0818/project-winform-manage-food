using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO.Cache;

namespace DataAccessLayer
{
    public class DataBillDetail
    {
        private ConnectionSql connectionBill = new ConnectionSql();
        DataTable tableCustomer = new DataTable();
        SqlCommand sqlCm = new SqlCommand();
        //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        #region Thêm Chi Tiết Hóa Đơn
        public void InsertBillDeTail(DTO_BillDetail ex)
        {
            sqlCm.Connection = connectionBill.OpenConnection();
            sqlCm.CommandText = "INSERTDATABILLDETAIL";
            sqlCm.CommandType = CommandType.StoredProcedure;
            sqlCm.Parameters.AddWithValue("@maSP", ex.MaSP);
            sqlCm.Parameters.AddWithValue("@soLuong", ex.SoLuong);
            sqlCm.Parameters.AddWithValue("@giaBan", ex.GiaBan);
            sqlCm.Parameters.AddWithValue("@khuyenMai", ex.KhuyenMai);
            sqlCm.Parameters.AddWithValue("@thanhTien", ex.ThanhTien);
            sqlCm.Parameters.AddWithValue("@maHD",ex.MaHD);
            sqlCm.ExecuteNonQuery();
            sqlCm.Parameters.Clear();
        }
        #endregion
    }
}
