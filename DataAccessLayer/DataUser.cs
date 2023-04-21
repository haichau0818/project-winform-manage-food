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
    public class DataUser : ConnectionSql
    {
        #region DangNhap
        public bool Login(string user, string pass)
        {
            using (var connection= GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT TK.Username,TK.passwordChar,NV.hoTen,PQ.tenQuyen FROM ((TAIKHOAN AS TK JOIN NHANVIEN AS NV ON TK.id=NV.idTK) JOIN PHANQUYEN AS PQ ON PQ.maQuyen=NV.maQuyen) WHERE Username=@user AND passwordChar=@pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DTO_Login.Username = reader.GetString(0);
                            DTO_Login.Password = reader.GetString(1);
                            DTO_Login.TenNV = reader.GetString(2);
                            DTO_Login.TenQuyen = reader.GetString(3);
                        }
                        return true;
                    }
                    else
                        return false;
                }
                
            }
        }
        #endregion
        #region Đổi mật khẩu
        public void editProfile(string Username,string Password)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE TAIKHOAN SET passwordChar=@pass WHERE Username=@userName";
                    command.Parameters.AddWithValue("@userName", Username);
                    command.Parameters.AddWithValue("@pass",Password);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion
    }
}
