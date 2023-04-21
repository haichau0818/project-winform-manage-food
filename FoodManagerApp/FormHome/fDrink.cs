﻿using System;
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
    public partial class fDrink : Form
    {
        public fDrink()
        {
            InitializeComponent();
        }

        private void fDrink_Load(object sender, EventArgs e)
        {

            poppulateItem();
        }
        BLL_DataProduct bllPro = new BLL_DataProduct();
        private void poppulateItem()
        {

            DataTable dt = bllPro.DrinkProduct();

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
                fPanelDrink.Controls.Add(listItems);
            }

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
