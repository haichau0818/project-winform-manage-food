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

namespace PresentationLayer
{
    public partial class fAllProduct : Form
    {
        public fAllProduct()
        {
            InitializeComponent();
        }

        private void fAllProduct_Load(object sender, EventArgs e)
        {
            Item();
        }
        BLL_DataProduct bllPro = new BLL_DataProduct();
        #region Load Item
        private void Item()
        {

            DataTable dt = bllPro.AllProduct();

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
                fPanelAllProduct.Controls.Add(listItems);

            }

        }
        #endregion

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
