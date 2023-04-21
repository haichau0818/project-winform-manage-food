using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO.Cache;
using System.Windows.Forms;

namespace DataAccessLayer
{
   
    public class DataCustomer
    {
        private ConnectionSql connectionCustomer = new ConnectionSql();
        private SqlDataReader sqlDrCustomer;
        DataTable tableCustomer = new DataTable();
        SqlCommand sqlCm = new SqlCommand();
        #region Lay Du Lieu KH
        public DataTable tableDataCustomer()
        {
            sqlCm.Connection = connectionCustomer.OpenConnection();
            sqlCm.CommandText = "SHOWDATACUSTOMER";
            sqlCm.CommandType = CommandType.StoredProcedure;
            sqlDrCustomer = sqlCm.ExecuteReader();
            tableCustomer.Load(sqlDrCustomer);
            connectionCustomer.CloseConnection();
            return tableCustomer;
        }
        #endregion
        #region TimKiemKH
        public DataTable Search(string keyword)
        {
            DataTable dataTable = new DataTable();
            sqlCm.Connection = connectionCustomer.OpenConnection();
            sqlCm.CommandText = "SELECT maKH AS [Mã khách hàng],KH.hoTen AS [Họ Tên],NV.hoTen AS [Thêm bởi],KH.gioiTinh as [Giới tính],KH.diaChi as [Địa chỉ],KH.SDT as [Số điện thoại],KH.email as [Email]"
                                    +"FROM(KHACHHANG AS KH INNER JOIN NHANVIEN AS NV ON NV.maNV = KH.themBoiNV) where kh.maKH like '%"+keyword+"%' OR KH.hoTen LIKE N'%"+keyword+"%'";
            sqlCm.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCm);
            adapter.Fill(dataTable);

            connectionCustomer.CloseConnection();
            return dataTable;
        }
        #endregion
        #region Tim Kiem KH Cho Hoa Don
        public DTO_Customer searchCustomerForBill(string keyword)
        {

            DataTable dataTable = new DataTable();
            DTO_Customer k = new DTO_Customer();
            
            sqlCm.Connection = connectionCustomer.OpenConnection();
            sqlCm.CommandText = "SELECT hoTen,SDT FROM KHACHHANG WHERE SDT LIKE '%" + keyword + "%' OR hoTen LIKE N'%" + keyword + "%'";
            sqlCm.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCm);
            adapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                k.TenKH = dataTable.Rows[0]["hoTen"].ToString();
                k.SDT = dataTable.Rows[0]["SDT"].ToString();
            }
            connectionCustomer.CloseConnection();
            return k;
            
        }
        #endregion
        #region Lay Id KH cho HoaDon
        public DTO_Customer GetIdCustomer(string name)
        {

            DataTable dataTable = new DataTable();
            DTO_Customer k = new DTO_Customer();

            sqlCm.Connection = connectionCustomer.OpenConnection();
            sqlCm.CommandText = "SELECT maKH FROM KHACHHANG WHERE hoTen=N'" +name + "'";
            sqlCm.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCm);
            adapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                k.MaKH = dataTable.Rows[0]["maKH"].ToString();
            
            }
            connectionCustomer.CloseConnection();
            return k;

        }

        #endregion
        #region Lay Danh Sach Nhan Vien
        public DataTable listStaff()
        {
            sqlCm.Connection = connectionCustomer.OpenConnection();
            sqlCm.CommandText = "LISTSTAFF";
            sqlCm.CommandType = CommandType.StoredProcedure;
            sqlDrCustomer = sqlCm.ExecuteReader();
            tableCustomer.Load(sqlDrCustomer);
            connectionCustomer.CloseConnection();
            return tableCustomer;

        }
        #endregion
        #region Them KH
        public void Insert(DTO_Customer ex)

        {
           
                sqlCm.Connection = connectionCustomer.OpenConnection();
                sqlCm.CommandText = "INSERTCUSTOMER";
                sqlCm.CommandType = CommandType.StoredProcedure;
                sqlCm.Parameters.AddWithValue("@maKH", ex.MaKH);
                sqlCm.Parameters.AddWithValue("@hoTen", ex.TenKH);
                sqlCm.Parameters.AddWithValue("@gioiTinh", ex.GioiTinh);
                sqlCm.Parameters.AddWithValue("@themBoi", ex.ThemBoi);
                sqlCm.Parameters.AddWithValue("@diaChi", ex.DiaChi);
                sqlCm.Parameters.AddWithValue("@SDT", ex.SDT);
                sqlCm.Parameters.AddWithValue("@Email", ex.Email);

                sqlCm.ExecuteNonQuery();
                sqlCm.Parameters.Clear();
                 
        }
        #endregion
        #region SuaKH
        public void Edit(DTO_Customer ex)

        {
            sqlCm.Connection = connectionCustomer.OpenConnection();
            sqlCm.CommandText = "EDITCUSTOMER";
            sqlCm.CommandType = CommandType.StoredProcedure;
            sqlCm.Parameters.AddWithValue("@maKH", ex.MaKH);
            sqlCm.Parameters.AddWithValue("@hoTen", ex.TenKH);
            sqlCm.Parameters.AddWithValue("@gioiTinh", ex.GioiTinh);
            sqlCm.Parameters.AddWithValue("@themBoi", ex.ThemBoi);
            sqlCm.Parameters.AddWithValue("@diaChi", ex.DiaChi);
            sqlCm.Parameters.AddWithValue("@SDT", ex.SDT);
            sqlCm.Parameters.AddWithValue("@Email", ex.Email);

            sqlCm.ExecuteNonQuery();
            sqlCm.Parameters.Clear();
        }
        #endregion
        #region XoaKH
        public void Deleted(DTO_Customer ex)

        {
            sqlCm.Connection = connectionCustomer.OpenConnection();
            sqlCm.CommandText = "DELETEDCUSTOMER";
            sqlCm.CommandType = CommandType.StoredProcedure;
            sqlCm.Parameters.AddWithValue("@maKH", ex.MaKH);
            sqlCm.ExecuteNonQuery();
            sqlCm.Parameters.Clear();
        }
        #endregion
    }

}
