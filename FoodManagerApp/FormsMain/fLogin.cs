using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using System.Data.SqlClient;
using BusinessLogicLayer;
using Microsoft.TeamFoundation.Common.Internal;

namespace PresentationLayer
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        #region Text Change
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }
        private void txtUsername_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text=="Username")
            {
                txtUsername.Text ="";
                txtUsername.ForeColor = Color.FromArgb(13, 98, 198);
            }    
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if(txtUsername.Text=="")
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.FromArgb(37, 198, 218);
            }
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.FromArgb(13, 98, 198);
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
            }    
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.FromArgb(37, 198, 218);
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }    
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBoxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            lblErrorMassage.Text = "";
        }

        private void panelImage_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void fLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
        #region Dang Nhap
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //if (txtUsername.Text != "Username" && txtUsername.TextLength > 2)
            //{
            //    if (txtPassword.Text != "Password")
            //    {
            //        BLL_DataUser user = new BLL_DataUser();
            //        var validLogin = user.LoginUser(txtUsername.Text, txtPassword.Text);
            //        if (validLogin == true)
            //        {
            //            this.Hide();
            //            fWelcome welcome = new fWelcome();
            //            welcome.ShowDialog();
            //            fFoodManager mainMenu = new fFoodManager();

            //            mainMenu.Show();
            //            mainMenu.FormClosed += Logout;

            //        }
            //        else
            //        {
            //            msgError("Bạn đã nhập sai tên đăng nhập hoặc mật khẩu. \n Xin mời nhập lại!");
            //            txtPassword.Text = "Password";
            //            txtPassword.UseSystemPasswordChar = false;
            //            txtUsername.Focus();
            //        }
            //    }
            //    else msgError("Hãy nhập mật khẩu!");


            //}
            //else msgError("Hãy nhập tên tài khoản!");
            fFoodManager mainMenu = new fFoodManager();
            mainMenu.Show();
        }
        #endregion
        #region Thong Bao Sai TT Dang Nhap
        private void msgError(string msg)
        {
            lblErrorMassage.Text = "    " + msg;
            lblErrorMassage.Visible = true;
        }
        #endregion
        //private static readonly NativeMethods.WndProc StaticWndProcDelegate = WndProc;
        #region Dang Xuat
        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            lblErrorMassage.Visible = false;
            this.Show();
            txtUsername.Focus();

        }
        #endregion

        private void fLogin_Load(object sender, EventArgs e)
        {
            btnLogin_Click(null, null);
        }
    }
}

