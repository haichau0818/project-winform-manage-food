using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using DTO.Cache;
namespace PresentationLayer
{
    public partial class fSale : Form
    {

        public fSale()
        {
            InitializeComponent();
        }
        BLL_DataProduct bllPro = new BLL_DataProduct();
        private void poppulateItem()
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
                    listItems.Width = 200;
                    listItems.Height = 180;
                    fPanelSaleProduct.Controls.Add(listItems);
                    }
          
        }
       
        private void fPromotion_Load(object sender, EventArgs e)
        {
            poppulateItem();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
