using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO.Cache;
using Microsoft.Reporting.WinForms;


namespace DataAccessLayer
{
    public class DataBill
    {
        private ConnectionSql connectionBill = new ConnectionSql();
        SqlDataReader sqlDataReader;
        DataTable tableBill = new DataTable();
        SqlCommand sqlCm = new SqlCommand();
        #region Danh Sach Nhan Vien
        public DataTable listStaff()
        {
            sqlCm.Connection = connectionBill.OpenConnection();
            sqlCm.CommandText = "LISTSTAFF";
            sqlCm.CommandType = CommandType.StoredProcedure;
            sqlDataReader= sqlCm.ExecuteReader();
            tableBill.Load(sqlDataReader);
            connectionBill.CloseConnection();
            return tableBill;

        }
        #endregion
        #region Them Hoa Don
        public void Insert(DTO_Bill ex)
        {
            sqlCm.Connection = connectionBill.OpenConnection();
            sqlCm.CommandText = "INSERTDATABILL";
            sqlCm.CommandType = CommandType.StoredProcedure;
            sqlCm.Parameters.AddWithValue("@NVLap", ex.NVLap);
            sqlCm.Parameters.AddWithValue("@thongTinKH", ex.ThongTinKH);
            sqlCm.Parameters.AddWithValue("@ngayLap", ex.NgayLap);
            sqlCm.Parameters.AddWithValue("@tongTien", ex.TongTien);
            sqlCm.Parameters.AddWithValue("@daThanhToan", ex.DaThanhToan);
            sqlCm.Parameters.AddWithValue("@soTienTra", ex.SoTienTra);
            sqlCm.Parameters.AddWithValue("@soTienThua", ex.SoTienThua);
            sqlCm.ExecuteNonQuery();
            sqlCm.Parameters.Clear();

        }
        #endregion
        #region Lay Ma Hoa Don
        public DTO_Bill GetIdBill()
        {

            DataTable dataTable = new DataTable();
            DTO_Bill k = new DTO_Bill();

            sqlCm.Connection = connectionBill.OpenConnection();
            sqlCm.CommandText = "SELECT MAX(maHD) as maHD FROM HOADON";
            sqlCm.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCm);
            adapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                k.MaHD =int.Parse(dataTable.Rows[0]["maHD"].ToString());

            }
            connectionBill.CloseConnection();
            return k;

        }
        #endregion
        #region Lay Thong Tin Hoa Don Tu Ma
        public DataTable GetBill(string id)
        {

            DataTable dt = new DataTable();
            DTO_Bill k = new DTO_Bill();

            sqlCm.Connection = connectionBill.OpenConnection();
            sqlCm.CommandText = "SELECT * FROM PAYMENT WHERE maHD='"+id+"'";
            sqlCm.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCm);
            adapter.Fill(dt);
            connectionBill.CloseConnection();
            return dt;

        }
        #endregion
    }
}
