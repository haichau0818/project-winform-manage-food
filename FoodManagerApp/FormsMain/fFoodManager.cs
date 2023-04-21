using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using DTO.Cache;

namespace PresentationLayer
{
    public partial class fFoodManager : Form
    {
        
        
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        ThemeColor a = new ThemeColor();
        BLL_DataProduct bllPro = new BLL_DataProduct();

        public fFoodManager()
        {
            InitializeComponent();
            random = new Random();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        #region MouseDown
        private void panelTimebar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
        #region Cai Dat Random Mau
        private Color SelectThemColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(12,98,198);
                    previousBtn.ForeColor = Color.White;
                    previousBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
                }
            }
        }
        private void OpenChillForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();

            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDestopPane.Controls.Add(childForm);
            this.panelDestopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;

        }
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "TRANG CHỦ";
            currentButton = null;
            
        }
        #endregion
        #region Click Button
        private void btnHome_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            if (activeForm != null)
            {
                activeForm.Close();
                ActivateButton(sender);
                lblTitle.Text = "TRANG CHỦ";
            }
          
        }
        private void btnSell_Click(object sender, EventArgs e)
        {
           OpenChillForm(new PresentationLayer.fSell(), sender);
        }
        private void btnProduct_Click(object sender, EventArgs e)
        {
            OpenChillForm(new PresentationLayer.fProduct(), sender);
        }
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            OpenChillForm(new PresentationLayer.fCustomer(), sender);
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            OpenChillForm(new PresentationLayer.fStaff(), sender);
        }

        private void btnStatistical_Click(object sender, EventArgs e)
        {
            OpenChillForm(new PresentationLayer.fStatistical(), sender);
        }

        private void btnEstablish_Click(object sender, EventArgs e)
        {
            OpenChillForm(new PresentationLayer.fEstablish(), sender);
        }

        private void btnSaleProduct_Click(object sender, EventArgs e)
        {
            OpenChillForm(new PresentationLayer.fSale(), sender);
        }

        private void btnAllProduct_Click(object sender, EventArgs e)
        {
            OpenChillForm(new PresentationLayer.fAllProduct(), sender);
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            OpenChillForm(new PresentationLayer.fFood(), sender);
        }

        private void btnDrink_Click(object sender, EventArgs e)
        {
            OpenChillForm(new PresentationLayer.fDrink(), sender);
        }

        private void btnBestSeller_Click(object sender, EventArgs e)
        {
            OpenChillForm(new PresentationLayer.fBestSeller(), sender);
        }

        private void btnLogOut_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender);
            if (MessageBox.Show("Bạn có muốn đăng xuất?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }


        
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void pictureBoxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion
        #region Load Forms
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

     

        private void timerDatetime_Tick(object sender, EventArgs e)
        {
            lblTimetitle.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss ");
        }

        private void timerMenu1_Tick(object sender, EventArgs e)
        {
            if(panelMenu.Width<=60)
            {
                timerMenu1.Enabled = false;
            }else
            {
                panelMenu.Width = panelMenu.Width - 20;
            }    
        }

        private void timerMenu2_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Width >=300)
            {
                timerMenu2.Enabled = false;
            }
            else
            {
                panelMenu.Width = panelMenu.Width + 20;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(panelMenu.Width==300)
            {
                timerMenu1.Enabled = true;
            }else
            {
                panelMenu.Width = 60;
                timerMenu2.Enabled = true;
            }    
        }
        #endregion
        #region Load Infor User
        private void LoadUserData()
        {
            lblUsername.Text = DTO_Login.TenNV;
            lblShowRole.Text = DTO_Login.TenQuyen;
            if (DTO_Login.TenQuyen!="Administrator" || DTO_Login.TenNV!="Châu Thanh Hải")
            {
                btnStaff.Visible = false;
                btnStatistical.Visible = false;
                btnProduct.Visible = false;
               
            }
        }
        #endregion
        #region Load Item
        private void fFoodManager_Load(object sender, EventArgs e)
        {
            LoadUserData();
           ItemSale();
            ItemSelling();
        }
        #endregion
        #region Load Item
        private void ItemSale()
        {

            DataTable dt = bllPro.SaleProduct();

            for (int j = 0; j < dt.Rows.Count; j++)
            {
                ListItem listItems = new ListItem();
                listItems.NameProduct = dt.Rows[j][0].ToString();
                listItems.PriceProduct = dt.Rows[j][1].ToString();
                listItems.AmountProduct = dt.Rows[j][2].ToString();
                listItems.PercentSale = dt.Rows[j][3].ToString();
                listItems.ImageProduct = (byte[])dt.Rows[j][4];
                listItems.Width = 227;
                listItems.Height = 199;
                fPanelSale.Controls.Add(listItems);
            }
        }

        private void ItemSelling()
        {

            DataTable dt = bllPro.SellingProd();

            for (int j = 0; j < dt.Rows.Count; j++)
            {
                ListItem listItems = new ListItem();
                listItems.NameProduct = dt.Rows[j][0].ToString();
                listItems.PriceProduct = dt.Rows[j][1].ToString();
                listItems.AmountProduct = dt.Rows[j][2].ToString();
                listItems.PercentSale = dt.Rows[j][3].ToString();
                listItems.ImageProduct = (byte[])dt.Rows[j][4];
                listItems.Width = 227;
                listItems.Height = 199;
                fPanelSellingProd.Controls.Add(listItems);
            }
        }
        #endregion
    }
}
