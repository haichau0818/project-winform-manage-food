using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using DTO.Cache;

namespace DataAccessLayer
{
     public class DataStatistical
    {
        private ConnectionSql connectionStatistic = new ConnectionSql();
        SqlDataReader sqlDataReader;
        SqlCommand sqlCm = new SqlCommand();

        #region Thong Ke Doanh Thu

        public void monthlyRevenue(DTO_Statistic sta)
        {
            
            sqlCm.Connection = connectionStatistic.OpenConnection();
            sqlCm.CommandText = "SELECT month(hd.NgayLap) Thang ,sum(hd.TongTien) Tong FROM HOADON hd GROUP BY month(hd.NgayLap)ORDER BY SUM(hd.TongTien) DESC";
            sqlCm.CommandType = CommandType.Text;
            sqlDataReader = sqlCm.ExecuteReader();
            while(sqlDataReader.Read())
            {
                sta.Mounth.Add(sqlDataReader.GetInt32(0));
                sta.Slmounth1.Add(sqlDataReader.GetDecimal(1));
            }
            sqlDataReader.Close();
            connectionStatistic.CloseConnection();

        }

        public void annualRevenue(DTO_Statistic sta)
        {

            sqlCm.Connection = connectionStatistic.OpenConnection();
            sqlCm.CommandText = "SELECT year(hd.NgayLap) Nam , sum(hd.TongTien) Tong FROM HOADON hd GROUP BY year(hd.NgayLap)ORDER BY SUM(hd.TongTien) DESC";
            sqlCm.CommandType = CommandType.Text;
            sqlDataReader = sqlCm.ExecuteReader();
            while (sqlDataReader.Read())
            {
                sta.Year.Add(sqlDataReader.GetInt32(0));
                sta.Slyear1.Add(sqlDataReader.GetDecimal(1));
            }
            sqlDataReader.Close();
            connectionStatistic.CloseConnection();

        }
        public void dateRevenue(DTO_Statistic sta)
        {

            sqlCm.Connection = connectionStatistic.OpenConnection();
            sqlCm.CommandText = "SELECT top 5 hd.NgayLap as Ngay , sum(hd.TongTien) Tong FROM HOADON hd GROUP BY hd.NgayLap ORDER BY SUM(hd.TongTien) DESC";
            sqlCm.CommandType = CommandType.Text;
            sqlDataReader = sqlCm.ExecuteReader();
            while (sqlDataReader.Read())
            {
                sta.Date.Add(sqlDataReader.GetDateTime(0));
                sta.Sldate1.Add(sqlDataReader.GetDecimal(1));
            }
            sqlDataReader.Close();
            connectionStatistic.CloseConnection();

        }

        #endregion
        #region DS Sản phẩm bán chạy vs số lượng sản phẩm theo loại
    
        public void AmountProType(DTO_Statistic sta)
        {

            sqlCm.Connection = connectionStatistic.OpenConnection();
            sqlCm.CommandText = "SELECT LSP.tenLoaiSP AS [Tên sản phẩm], COUNT(SP.maLSP) AS [Số lượng] FROM SANPHAM AS SP INNER JOIN LOAISP LSP ON SP.maLSP=LSP.maLSP GROUP BY SP.soLuong,LSP.tenLoaiSP ORDER BY COUNT(2) DESC";
            sqlCm.CommandType = CommandType.Text;
            sqlDataReader = sqlCm.ExecuteReader();
            while (sqlDataReader.Read())
            {
                sta.TypeProd.Add(sqlDataReader.GetString(0));
                sta.SlTypeProd.Add(sqlDataReader.GetInt32(1));
            }
            sqlDataReader.Close();
            connectionStatistic.CloseConnection();

        }



        public void ProSelling(DTO_Statistic sta)
        {

            sqlCm.Connection = connectionStatistic.OpenConnection();
            sqlCm.CommandText = "SELLINGPRO";
            sqlCm.CommandType = CommandType.Text;
            sqlDataReader = sqlCm.ExecuteReader();
            while (sqlDataReader.Read())
            {
                sta.NamePro.Add(sqlDataReader.GetString(0));
                sta.SlnamePro.Add(sqlDataReader.GetDouble(1));
            }
            sqlDataReader.Close();
            connectionStatistic.CloseConnection();

        }
        #endregion
        #region Thống kê theo danh mục
        public void StatisticalAll(DTO_Statistic sta)
        {
            sqlCm.Connection = connectionStatistic.OpenConnection();
            sqlCm.CommandText = "STATISTICAL";
            sqlCm.CommandType = CommandType.StoredProcedure;
            SqlParameter total = new SqlParameter("@tongtien",0);
            total.Direction = ParameterDirection.Output;
            SqlParameter totalProd = new SqlParameter("@tongsp", 0); 
            totalProd.Direction = ParameterDirection.Output;
            SqlParameter totalCus = new SqlParameter("@tongkh", 0); 
            totalCus.Direction = ParameterDirection.Output;
            SqlParameter totalProdSel = new SqlParameter("@tongspbc", 0);
            totalProdSel.Direction = ParameterDirection.Output;
            sqlCm.Parameters.Add(total);
            sqlCm.Parameters.Add(totalProd);
            sqlCm.Parameters.Add(totalCus);
            sqlCm.Parameters.Add(totalProdSel);
            connectionStatistic.OpenConnection();
            sqlCm.ExecuteNonQuery();
          
            sta.Total = sqlCm.Parameters["@tongtien"].Value.ToString();
            sta.TotalCus = sqlCm.Parameters["@tongkh"].Value.ToString();
            sta.TotalProd = sqlCm.Parameters["@tongsp"].Value.ToString();
            sta.TotalProdSel = sqlCm.Parameters["@tongspbc"].Value.ToString();
            sqlCm.Parameters.Clear();
            connectionStatistic.CloseConnection();
        }
        #endregion
    }
}
