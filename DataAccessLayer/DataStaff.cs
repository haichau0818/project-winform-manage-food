using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO.Cache;
using PresentationLayer.Cache;

namespace DataAccessLayer
{
    public class DataStaff
    {
        private ConnectionSql connectionStaff = new ConnectionSql();
        SqlDataReader sqlDataReader;
        DataTable tableCustomer = new DataTable();
        SqlCommand sqlCm = new SqlCommand();
        #region DS NhanVien
        public DataTable tableDataStaff()
        {
            sqlCm.Connection = connectionStaff.OpenConnection();
            sqlCm.CommandText = "SHOWDATASTAFF";
            sqlCm.CommandType = CommandType.StoredProcedure;
            sqlDataReader = sqlCm.ExecuteReader();
            tableCustomer.Load(sqlDataReader);
            connectionStaff.CloseConnection();
            return tableCustomer;
        }
        #endregion
        #region DS Quyen
        public DataTable ListRole()
        {
            sqlCm.Connection = connectionStaff.OpenConnection();
            sqlCm.CommandText = "LISTROLE";
            sqlCm.CommandType = CommandType.StoredProcedure;
            sqlDataReader = sqlCm.ExecuteReader();
            tableCustomer.Load(sqlDataReader);
            sqlDataReader.Close();
            connectionStaff.CloseConnection();
            return tableCustomer;
        }
        #endregion
        #region DanhSachTaiKhoan
        public DataTable ListUser()
        {
            sqlCm.Connection = connectionStaff.OpenConnection();
            sqlCm.CommandText = "LISTACCOUNT";
            sqlCm.CommandType = CommandType.StoredProcedure;
            sqlDataReader = sqlCm.ExecuteReader();
            tableCustomer.Load(sqlDataReader);
            sqlDataReader.Close();
            connectionStaff.CloseConnection();
            return tableCustomer;
        }
        #endregion
        #region TimKiem
        public DataTable Search(string keyword)
        {
            DataTable dataTable = new DataTable();
            sqlCm.Connection = connectionStaff.OpenConnection();
            sqlCm.CommandText = "SELECT maNV as [Mã nhân viên],hoTen as [Họ tên],tenQuyen as [Quyền],Username as [Tài khoản],gioiTinh as [Giới tính],ngaySinh as [Ngày sinh],diaChi as [Địa chỉ],SDT as [Số điện thoại],email as [Email]"
                                + "FROM(NHANVIEN INNER JOIN PHANQUYEN ON NHANVIEN.maQuyen = PHANQUYEN.maQuyen INNER JOIN TAIKHOAN ON NHANVIEN.idTK = TAIKHOAN.id) WHERE hoTen LIKE N'%"+keyword+"%'";
            sqlCm.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCm);
            adapter.Fill(dataTable);

            connectionStaff.CloseConnection();
            return dataTable;
        }
        #endregion
        #region ThemNV
        public void Insert(DTO_Staff ex)

        {
            sqlCm.Connection = connectionStaff.OpenConnection();
            sqlCm.CommandText = "INSERTSTAFF";
            sqlCm.CommandType = CommandType.StoredProcedure;
            sqlCm.Parameters.AddWithValue("@hoTen", ex.TenNV);
            sqlCm.Parameters.AddWithValue("@maQuyen", ex.MaQuyen);
            sqlCm.Parameters.AddWithValue("@gioiTinh", ex.GioiTinh);
            sqlCm.Parameters.AddWithValue("@ngaySinh", ex.NgaySinh);
            sqlCm.Parameters.AddWithValue("@DiaChi", ex.DiaChi);
            sqlCm.Parameters.AddWithValue("@sdt", ex.SDT);
            sqlCm.Parameters.AddWithValue("@email", ex.Email);
            sqlCm.Parameters.AddWithValue("@idTK", ex.IDTK);
            sqlCm.ExecuteNonQuery();
            sqlCm.Parameters.Clear();
        }
        #endregion
        #region SuaNV
        public void Edit(DTO_Staff ex)
        {
            sqlCm.Connection = connectionStaff.OpenConnection();
            sqlCm.CommandText = "EDITSTAFF";
            sqlCm.CommandType = CommandType.StoredProcedure;
            sqlCm.Parameters.AddWithValue("@hoTen", ex.TenNV);
            sqlCm.Parameters.AddWithValue("@maQuyen", ex.MaQuyen);
            sqlCm.Parameters.AddWithValue("@idTK", ex.IDTK);
            sqlCm.Parameters.AddWithValue("@gioiTinh", ex.GioiTinh);
            sqlCm.Parameters.AddWithValue("@ngaySinh", ex.NgaySinh);
            sqlCm.Parameters.AddWithValue("@DiaChi", ex.DiaChi);
            sqlCm.Parameters.AddWithValue("@sdt", ex.SDT);
            sqlCm.Parameters.AddWithValue("@email", ex.Email);
            sqlCm.Parameters.AddWithValue("@maNV", ex.MaNV);
            sqlCm.ExecuteNonQuery();
            sqlCm.Parameters.Clear();
        }
        #endregion
        #region XoaNV
        public void Deleted(DTO_Staff ex)
        {
            sqlCm.Connection = connectionStaff.OpenConnection();
            sqlCm.CommandText = "DELECTEDSTAFF";
            sqlCm.CommandType = CommandType.StoredProcedure;
            sqlCm.Parameters.AddWithValue("@maNV", ex.MaNV);
            sqlCm.ExecuteNonQuery();
            sqlCm.Parameters.Clear();

        }
        #endregion
    }
}
