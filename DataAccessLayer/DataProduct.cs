using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO.Cache;
using System.IO;
using System.Drawing;
using System.Data.Common;

namespace DataAccessLayer
{
    public class DataProduct
    {
       private ConnectionSql connectionProduct = new ConnectionSql();
        SqlDataReader sqlDataReader;
        DataTable tableProduct = new DataTable();
        SqlCommand sqlCm = new SqlCommand();
        #region DS SanPham
        public DataTable tableDataProduct()
        {
            
            sqlCm.Connection = connectionProduct.OpenConnection();
            sqlCm.CommandText = "SHOWDATAPRODUCT";
            sqlCm.CommandType = CommandType.StoredProcedure;
            sqlDataReader = sqlCm.ExecuteReader();
            tableProduct.Load(sqlDataReader);
            connectionProduct.CloseConnection();
            return tableProduct;
        }
        #endregion
        #region Danh sách sản phẩm khuyến mãi
        public DataTable tableDataProductSale()
        {

            sqlCm.Connection = connectionProduct.OpenConnection();
            sqlCm.CommandText = "SHOWPRODUCTSALE";
            sqlCm.CommandType = CommandType.StoredProcedure;
            sqlDataReader = sqlCm.ExecuteReader();
            tableProduct.Load(sqlDataReader);
            connectionProduct.CloseConnection();
            return tableProduct;
        }
        #endregion
        #region danh sách tất cả sản phẩm trang trủ
                public DataTable tableDataProductAll()
                {

                    sqlCm.Connection = connectionProduct.OpenConnection();
                    sqlCm.CommandText = "SHOWPRODUCTAll";
                    sqlCm.CommandType = CommandType.StoredProcedure;
                    sqlDataReader = sqlCm.ExecuteReader();
                    tableProduct.Load(sqlDataReader);
                    connectionProduct.CloseConnection();
                    return tableProduct;
                }
                #endregion
        #region DANH SÁCH ĐỒ ĂN
        public DataTable tableDataProductFood()
        {

            sqlCm.Connection = connectionProduct.OpenConnection();
            sqlCm.CommandText = "SHOWPRODUCTFOOD";
            sqlCm.CommandType = CommandType.StoredProcedure;
            sqlDataReader = sqlCm.ExecuteReader();
            tableProduct.Load(sqlDataReader);
            connectionProduct.CloseConnection();
            return tableProduct;
        }
        #endregion
        #region DANH SÁCH ĐỒ UỐNG
                public DataTable tableDataProductDrink()
                {

                    sqlCm.Connection = connectionProduct.OpenConnection();
                    sqlCm.CommandText = "SHOWPRODUCTDRINK";
                    sqlCm.CommandType = CommandType.StoredProcedure;
                    sqlDataReader = sqlCm.ExecuteReader();
                    tableProduct.Load(sqlDataReader);
                    connectionProduct.CloseConnection();
                    return tableProduct;
                }
                #endregion
        #region Danh sách sản phẩm bán chạy
                public DataTable tableDataProductSeling()
                {

                    sqlCm.Connection = connectionProduct.OpenConnection();
                    sqlCm.CommandText = "SELECT sp.TENSP,replace(convert(varchar,cast(floor(sp.giaBan) as money),1), '.00', '')as giaBan,sp.soLuong,sp.khuyenMai,sp.hinhAnh FROM SANPHAM sp WHERE exists ( SELECT ct.MASP FROM CHITIETHD ct, HOADON hd WHERE HD.maHD=CT.maHD AND sp.MASP=ct.MASP AND ct.soLuong>0)";
                    sqlCm.CommandType = CommandType.Text;
                    sqlDataReader = sqlCm.ExecuteReader();
                    tableProduct.Load(sqlDataReader);
                    connectionProduct.CloseConnection();
                    return tableProduct;
                }
                #endregion
        #region Danh sách loại sản phẩm
                public DataTable ListType()
                {

                    sqlCm.Connection = connectionProduct.OpenConnection();
                    sqlCm.CommandText = "LISTPRODUCTTYPE";
                    sqlCm.CommandType = CommandType.StoredProcedure;
                    sqlDataReader = sqlCm.ExecuteReader();
                    tableProduct.Load(sqlDataReader);
                    sqlDataReader.Close();
                    connectionProduct.CloseConnection();
                    return tableProduct;
                }
                #endregion
        #region Tim Kiem San Pham
                public DataTable Search(string keyword)
                {
                    DataTable dataTable = new DataTable();
                    sqlCm.Connection = connectionProduct.OpenConnection();
                    sqlCm.CommandText = "SELECT maSP as [Mã sản phẩm],tenSP as [Tên sản phẩm],tenLoaiSP as [Tên loại sản phẩm],replace(convert(varchar,cast(floor(giaNhap) as money),1), '.00', '') as [Giá nhập],"
                                             +"replace(convert(varchar,cast(floor(giaBan) as money),1), '.00', '') as [Giá bán],khuyenMai as [Khuyến mãi],soLuong as [Số lượng],NSX as [Ngày sản xuất],HSD as [Hạn sử dụng],hinhAnh as [Hình ảnh]"
                                            + "FROM(SANPHAM INNER JOIN LOAISP ON LOAISP.maLSP = SANPHAM.maLSP) WHERE maSP LIKE '%"+keyword+"%' OR tenSP LIKE N'%"+keyword+"%'";
                    sqlCm.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCm);
                    adapter.Fill(dataTable);

                    connectionProduct.CloseConnection();
                    return dataTable;
                }
                #endregion
        #region Tim Kiem Cho HD
                public DTO_Product searchProductforBill(string keyword)
                {
                    DTO_Product k = new DTO_Product();
                    DataTable dataTable = new DataTable();
                    sqlCm.Connection = connectionProduct.OpenConnection();
                    sqlCm.CommandText = "SELECT tenSP,replace(convert(varchar,cast(floor(giaBan) as money),1), '.00', '')as giaBan,soLuong,khuyenMai,hinhAnh FROM SANPHAM WHERE maSP LIKE '%" + keyword+"%' OR tenSP LIKE N'%"+keyword+"%' ";
                    sqlCm.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCm);
                    adapter.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        k.TenSP = dataTable.Rows[0]["tenSP"].ToString();
                        k.SoLuong = Convert.ToInt32(dataTable.Rows[0]["soLuong"].ToString());
                        k.GiaBan = Convert.ToDecimal(dataTable.Rows[0]["giaBan"].ToString());
                        k.KhuyenMai=Convert.ToInt32(dataTable.Rows[0]["khuyenMai"].ToString());
                        k.HinhAnh = (byte[])dataTable.Rows[0]["hinhAnh"];
                    }
                    connectionProduct.CloseConnection();
                    return k;

                }
                #endregion
        #region Lay ID San Pham
        public string GetIdProduct(string namepro)
        {

            DataTable dataTable = new DataTable();
            DTO_Product ex = new DTO_Product();
            string masp = "";

            sqlCm.Connection = connectionProduct.OpenConnection();
            sqlCm.CommandText = "SELECT maSP FROM SANPHAM WHERE tenSP=N'" + namepro + "'";
            sqlCm.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCm);
            adapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
           {
                masp = dataTable.Rows[0]["maSP"].ToString();
           }
            connectionProduct.CloseConnection();
            return masp;

        }
        #endregion
        #region Lay SoLuong SanPham
        public decimal GetProductAmount(string masp)
        {
            decimal Sluong = 0;
            DataTable dataTable = new DataTable();
            sqlCm.Connection = connectionProduct.OpenConnection();
            sqlCm.CommandText = "SELECT soLuong FROM SANPHAM WHERE maSP='" + masp + "'";
            sqlCm.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCm);
            adapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                Sluong = decimal.Parse(dataTable.Rows[0]["soLuong"].ToString());
            }
            connectionProduct.CloseConnection();
            return Sluong;
        }
        #endregion
        #region CapNhatSoLuongSauKhiBan
        public bool UpdateAmout(string masp, decimal soluong)
        {
            bool Update = false;

            sqlCm.Connection = connectionProduct.OpenConnection();
            sqlCm.CommandText = "Update SANPHAM SET soLuong=@soLuong where maSP=@maSP";
            sqlCm.CommandType = CommandType.Text;
            sqlCm.Parameters.AddWithValue("@soLuong",soluong);
            sqlCm.Parameters.AddWithValue("@maSP",masp);
            int rows = sqlCm.ExecuteNonQuery();
            if (rows > 0)
            {
                Update = true;
            }    
            connectionProduct.CloseConnection();
            return Update;
        }
        #endregion
        #region SoLuongTang
        public bool IncreaseProd(string masp, decimal increasepro)
        {
            bool increase = false;
            try
            {
                connectionProduct.OpenConnection();
                decimal currentAmount = GetProductAmount(masp);
                decimal newAmount = currentAmount + increasepro;
                increase = UpdateAmout(masp, newAmount);
            }
            catch
            {

            }

            connectionProduct.CloseConnection();
            return increase;
        }
        #endregion
        #region SoLuongGiam
        public bool DecreaseProd(string masp, decimal decreasepro)
        {
            bool decrease = false;
            connectionProduct.OpenConnection();
            try
            {
                decimal currentAmount = GetProductAmount(masp);
                decimal newAmount = currentAmount - decreasepro;
                decrease = UpdateAmout(masp, newAmount);
            }
            catch { }
            connectionProduct.CloseConnection();
            return decrease;

        }
        #endregion
        #region Thêm sản phẩm 
        public void Insert(DTO_Product ex)

        {
            sqlCm.Connection = connectionProduct.OpenConnection();
            sqlCm.CommandText = "INSERTDATAPRODUCT";
            sqlCm.CommandType = CommandType.StoredProcedure;
            sqlCm.Parameters.AddWithValue("@maSP",ex.MaSP);
            sqlCm.Parameters.AddWithValue("@tenSP", ex.TenSP);
            sqlCm.Parameters.AddWithValue("@maLSP", ex.MaLSP);
            sqlCm.Parameters.AddWithValue("@giaNhap", ex.GiaNhap);
            sqlCm.Parameters.AddWithValue("@giaBan", ex.GiaBan);
            sqlCm.Parameters.AddWithValue("@soLuong", ex.SoLuong);
            sqlCm.Parameters.AddWithValue("@khuyenMai", ex.KhuyenMai);
            sqlCm.Parameters.AddWithValue("@NSX", ex.NSX);
            sqlCm.Parameters.AddWithValue("@HSD", ex.HSD);
            sqlCm.Parameters.AddWithValue("@hinhAnh", ex.HinhAnh);
            sqlCm.ExecuteNonQuery();
            sqlCm.Parameters.Clear();
        }
        #endregion
        #region chỉnh sửa dữ liệu sản phẩm 
        public void Edita(DTO_Product ex)
        {
            sqlCm.Connection = connectionProduct.OpenConnection();
            sqlCm.CommandText = "EDITPRODUCT";
            sqlCm.CommandType = CommandType.StoredProcedure;
            sqlCm.Parameters.AddWithValue("@maSP", ex.MaSP);
            sqlCm.Parameters.AddWithValue("@tenSP", ex.TenSP);
            sqlCm.Parameters.AddWithValue("@maLSP", ex.MaLSP);
            sqlCm.Parameters.AddWithValue("@giaNhap", ex.GiaNhap);
            sqlCm.Parameters.AddWithValue("@giaBan", ex.GiaBan);
            sqlCm.Parameters.AddWithValue("@soLuong", ex.SoLuong);
            sqlCm.Parameters.AddWithValue("@khuyenMai", ex.KhuyenMai);
            sqlCm.Parameters.AddWithValue("@NSX", ex.NSX);
            sqlCm.Parameters.AddWithValue("@HSD", ex.HSD);
            sqlCm.Parameters.AddWithValue("@hinhAnh", ex.HinhAnh);
            sqlCm.ExecuteNonQuery();
            sqlCm.Parameters.Clear();

        }
        #endregion
        #region Xóa sản phẩm
        public void Deleted(DTO_Product ex)
        {
            sqlCm.Connection = connectionProduct.OpenConnection();
            sqlCm.CommandText = "DELETEDPRODUCT";
            sqlCm.CommandType = CommandType.StoredProcedure;
            sqlCm.Parameters.AddWithValue("@maSP", ex.MaSP);
            sqlCm.ExecuteNonQuery();
            sqlCm.Parameters.Clear();
        }
        #endregion
    }
}




