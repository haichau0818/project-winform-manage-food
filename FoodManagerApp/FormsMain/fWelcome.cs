using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO.Cache;

namespace PresentationLayer
{
    public partial class fWelcome : Form
    {
        public fWelcome()
        {
            InitializeComponent();
        }
        #region Timerr  
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1) this.Opacity += 0.05;
            circularProgressBar1.Value += 1;
            circularProgressBar1.Text = circularProgressBar1.Value.ToString();
            if (circularProgressBar1.Value == 100)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                timer2.Stop();
                this.Close();
            }
        }
        #endregion
        #region Load Welcome
        private void fWelcome_Load(object sender, EventArgs e)
        {
            lblUsername.Text = DTO_Login.TenNV;
            this.Opacity = 0.0;
            //khởi tạo thuộc tính này của thanh tiến trình bằng code
            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
            //bắt đầu hẹn giờ bằng 1
            timer1.Start();
        }
        #endregion
    }
}
