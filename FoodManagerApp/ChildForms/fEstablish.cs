using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using DTO.Cache;

namespace PresentationLayer
{
    public partial class fEstablish : Form
    {
        public fEstablish()
        {
            InitializeComponent();
        }

        private void fEstablish_Load(object sender, EventArgs e)
        {
            LoadThemeColor();
        }
        private void LoadThemeColor()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }
      
        private void btnLoginChange_Click(object sender, EventArgs e)
        {
            
                BLL_DataUser user = new BLL_DataUser();
                var validLogin = user.LoginUser(txtNameUser.Text, txtPassword.Text);
                if (validLogin == true)
                {
                    panel1.Visible = true;

                }else
                    MessageBox.Show("Mật khẩu hiện tại không chính xác, hãy thử lại");
       
        }

     
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtPasswordNew.TextLength >= 5)

            {
                if (txtPasswordNew.Text == txtConfirmPass.Text)
                {

                    var userModel = new BLL_DataUser(

                        username: txtNameUser.Text,
                        password: txtPasswordNew.Text);

                    var result = userModel.editUserProfile(txtNameUser.Text, txtPasswordNew.Text);
                    MessageBox.Show(result);
                    //reset();
                    panel1.Visible = false;

                }
                else
                    MessageBox.Show("Mật khẩu không khớp, hãy thử lại");
            }
            else
                MessageBox.Show("Mật khẩu phải nhiều hơn 5 ký tự");
           
        }

        private void txtNameUser_Click(object sender, EventArgs e)
        {
            if (txtNameUser.Text == "Tên tài khoản")
            {
                txtNameUser.Text = "";
                txtNameUser.ForeColor = Color.Black;
            }
        }

        private void txtNameUser_Leave(object sender, EventArgs e)
        {
            if (txtNameUser.Text == "")
            {
                txtNameUser.Text = "Tên tài khoản";
                txtNameUser.ForeColor = Color.Gainsboro;
            }
        }

      
        private void txtPasswordNew_Click(object sender, EventArgs e)
        {
            if (txtPasswordNew.Text == "Mật khẩu mới")
            {
                txtPasswordNew.Text = "";
                txtPasswordNew.ForeColor = Color.Black;
                txtPasswordNew.PasswordChar = '\u25CF';
            }
        }

        private void txtPasswordNew_Leave(object sender, EventArgs e)
        {
            if (txtPasswordNew.Text == "")
            {
                txtPasswordNew.Text = "Mật khẩu mới";
                txtPasswordNew.ForeColor = Color.Gainsboro;
                //txtPasswordNew.PasswordChar = false;
            }
        }

        private void txtConfirmPass_Click(object sender, EventArgs e)
        {
            if (txtConfirmPass.Text == "Xác nhận mật khẩu")
            {
                txtConfirmPass.Text = "";
                txtConfirmPass.ForeColor = Color.Black;
                txtConfirmPass.PasswordChar = '\u25CF';
            }
        }

        private void txtConfirmPass_Leave(object sender, EventArgs e)
        {
            if (txtConfirmPass.Text == "")
            {
                txtConfirmPass.Text = "Xác nhận mật khẩu";
                txtConfirmPass.ForeColor = Color.Black;
                //txtConfirmPass.UseSystemPasswordChar = false;
            }
        }

        private void txtPassword_Click_1(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Nhập mật khẩu")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.PasswordChar = '\u25CF';
            }
        }

        private void txtPassword_Leave_1(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Nhập mật khẩu";
                txtPassword.ForeColor = Color.Black;

            }
            else
                txtPasswordNew.PasswordChar = '\u25CF';
        }

        private void txtConfirmPass_TextChanged(object sender, EventArgs e)
        {
            txtConfirmPass.PasswordChar = '\u25CF';
        }

        private void txtPasswordNew_TextChanged(object sender, EventArgs e)
        {
            txtPasswordNew.PasswordChar= '\u25CF';
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar= '\u25CF';
        }
    }
   
}
