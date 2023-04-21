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
    public class DataTypePro
    {
        private ConnectionSql cnnTypePro = new ConnectionSql();
        SqlDataReader sqlDataReader;
        DataTable datble = new DataTable();
        SqlCommand sqlCm = new SqlCommand();
        #region DS Loại Sản phẩm
        public DataTable LoaiSP()
        {

            sqlCm.Connection = cnnTypePro.OpenConnection();
            sqlCm.CommandText = "SELECT MaLSP as[Mã loại sản phẩm],TenLoaiSP as [Tên loại sản phẩm],GhiChu as [Ghi chú] FROM LOAISP";
            sqlCm.CommandType = CommandType.Text;
            sqlDataReader = sqlCm.ExecuteReader();
            datble.Load(sqlDataReader);
            cnnTypePro.CloseConnection();
            return datble;
        }
        #endregion
        #region Tìm Kiếm Loại Sản Phẩm
        public DataTable Search(string keyword)
        {
            DataTable dataTable = new DataTable();
            sqlCm.Connection = cnnTypePro.OpenConnection();
            sqlCm.CommandText = "SELECT MaLSP as[Mã loại sản phẩm],TenLoaiSP as [Tên loại sản phẩm],GhiChu as [Ghi chú] FROM LOAISP WHERE TenLoaiSP LIKE N'%" + keyword + "%'";
            sqlCm.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCm);
            adapter.Fill(dataTable);

            cnnTypePro.CloseConnection();
            return dataTable;
        }
        #endregion
        #region Thêm loại sản phẩm
        public void Insert(DTO_TypePro ex)

        {
            sqlCm.Connection =cnnTypePro.OpenConnection();
            sqlCm.CommandText = "ThemLoaiSP";
            sqlCm.CommandType = CommandType.StoredProcedure;
            sqlCm.Parameters.AddWithValue("@tenLoai", ex.TenLoai);
            sqlCm.Parameters.AddWithValue("@ghiChu", ex.GhiChu);
            sqlCm.ExecuteNonQuery();
            sqlCm.Parameters.Clear();
        }
        #endregion
        #region Cập nhật sản phẩm
        public void Update(DTO_TypePro ex)
        {
            sqlCm.Connection = cnnTypePro.OpenConnection();
            sqlCm.CommandText = "SuaLoaiSP";
            sqlCm.CommandType = CommandType.StoredProcedure;
            sqlCm.Parameters.AddWithValue("@ghiChu", ex.GhiChu);
            sqlCm.Parameters.AddWithValue("@maLSP", ex.MaLoai);
            sqlCm.Parameters.AddWithValue("@tenLSP", ex.TenLoai);
            sqlCm.ExecuteNonQuery();
            sqlCm.Parameters.Clear();
        }
        #endregion
        #region Xóa sản phẩm
        public void Delete(DTO_TypePro ex)
        {
            sqlCm.Connection = cnnTypePro.OpenConnection();
            sqlCm.CommandText = "XoaLoaiSP";
            sqlCm.CommandType = CommandType.StoredProcedure;
            sqlCm.Parameters.AddWithValue("@maLoai", ex.MaLoai);
            sqlCm.ExecuteReader();
            sqlCm.Parameters.Clear();
        }
        #endregion
    }
}
