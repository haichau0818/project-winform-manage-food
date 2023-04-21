using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PresentationLayer
{
    public partial class ListItem : UserControl
    {
        public ListItem()
        {
            InitializeComponent();
        }
        #region Properties
        public static string tensp;
        public static string gia;
        public static Image hinhanh;
        public static string khuyenmai;

        private string _nameProduct;
        private string _priceProduct;
        private Byte[] _imageProduct;
        private string _percentSale;
        private string _soluong;

        [Category("Custom Props")]
        public string NameProduct
        {
            get { return _nameProduct; }
            set { _nameProduct = value; lblNameProductSale.Text = value; }
        }

        [Category("Custom Props")]
        public string PriceProduct
        {
            get { return _priceProduct; }
            set { _priceProduct = value;lblPriceProductSale.Text = value; }
        }


        [Category("Custom Props")]
        public Byte[] ImageProduct
        {
            get { return _imageProduct; }
            set { _imageProduct = value; pictureBoxImageProductSale.Image = byteArrayToImage(value); }
        }
        
        [Category("Custom Props")]
        public string PercentSale
        {
            get { return _percentSale; }
            set { _percentSale = value;btnUserCtrPercent.Text = value; }
        }
       

        public string AmountProduct
        {
            get { return _soluong; }
            set { _soluong = value;lblAmout.Text = value; }
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }


        #endregion
        #region Click And Mouse
        private void ListItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(25, 118, 210);
        }

        private void ListItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(0, 75, 160);
        }

        private void pictureBoxImageProductSale_Click(object sender, EventArgs e)
        {
            khuyenmai = btnUserCtrPercent.Text;
            tensp = lblNameProductSale.Text;
            gia = lblPriceProductSale.Text;
            hinhanh = pictureBoxImageProductSale.Image;
        }

        private void lblNameProductSale_Click(object sender, EventArgs e)
        {
            khuyenmai = btnUserCtrPercent.Text;
            tensp = lblNameProductSale.Text;
            gia = lblPriceProductSale.Text;
            hinhanh = pictureBoxImageProductSale.Image;
        }

        private void lblPriceProductSale_Click(object sender, EventArgs e)
        {
            khuyenmai = btnUserCtrPercent.Text;
            tensp = lblNameProductSale.Text;
            gia = lblPriceProductSale.Text;
            hinhanh = pictureBoxImageProductSale.Image;
        }

        private void btnUserCtrPercent_Click(object sender, EventArgs e)
        {
            khuyenmai = btnUserCtrPercent.Text;
            tensp = lblNameProductSale.Text;
            gia = lblPriceProductSale.Text;
            hinhanh = pictureBoxImageProductSale.Image;
        }

        private void lblAmout_Click(object sender, EventArgs e)
        {
            khuyenmai = btnUserCtrPercent.Text;
            tensp = lblNameProductSale.Text;
            gia = lblPriceProductSale.Text;
            hinhanh = pictureBoxImageProductSale.Image;
        }

      

        private void panel2_Click(object sender, EventArgs e)
        {
            khuyenmai = btnUserCtrPercent.Text;
            tensp = lblNameProductSale.Text;
            gia = lblPriceProductSale.Text;
            hinhanh = pictureBoxImageProductSale.Image;
        }
        #endregion
    }
}
