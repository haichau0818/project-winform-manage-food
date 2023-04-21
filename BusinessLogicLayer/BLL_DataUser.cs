using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTO.Cache;
namespace BusinessLogicLayer
{
    public class BLL_DataUser
    {
            DataUser userDAO = new DataUser();
        public bool LoginUser(string user, string pass)
        {
            return userDAO.Login(user, pass);
        }


        //Attributes
        private string username;
        private string password;
        //Constructors
        public BLL_DataUser(string password, string username)
        {
            this.password = password;

            this.username = username;
        }
        public BLL_DataUser()
        {

        }
        //Methods
        public string editUserProfile(string username,string password)
        {
                userDAO.editProfile(username,password);
                LoginUser(username, password);
                return "Mật khẩu đã thay đổi thành công";
        }
    }
}
