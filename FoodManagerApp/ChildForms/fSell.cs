using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using BusinessLogicLayer;
using DTO.Cache;
using Microsoft.Reporting.WinForms;

namespace PresentationLayer
{
    public partial class fSell : Form
    {
        Form form = new Form();
        BLL_DataCustomer blCus = new BLL_DataCustomer();
        BLL_DataProduct blProd = new BLL_DataProduct();
        BLL_DataBill Bldtb = new BLL_DataBill();
        BLL_DataBillDetail bldldt = new BLL_DataBillDetail();

        DTO_Product proDTO = new DTO_Product();
        DTO_BillDetail billDTO = new DTO_BillDetail();
        DTO_Bill bilDTO = new DTO_Bill();
        DTO_Customer cusDTO = new DTO_Customer();


        DataTable Bill = new DataTable();

        string tensp = "";
        public fSell()
        {
            InitializeComponent();
        }
        private void fSell_Load(object sender, EventArgs e)
        {
            ListStaff();
            Item();
            #region DataTablee
            Bill.Columns.Add("Tên sản phẩm");
            Bill.Columns.Add("Số lượng");
            Bill.Columns.Add("Giá bán");
            Bill.Columns.Add("Thành tiền");
            #endregion
        }

        #region LoadDanhSachNV 
        public void ListStaff()
        {
            BLL_DataBill bl = new BLL_DataBill();
            cmbAddbyStaff.DataSource = bl.ListStaff();
            cmbAddbyStaff.DisplayMember = "hoTen";
            cmbAddbyStaff.ValueMember = "maNV";
        }
        #endregion
        #region TimKH
        private void txtSearchCus_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearchCus.Text;
            if (txtSearchCus.Text == "")
            {
                txtNameCustomer.Text = "";
            }
            else
            {

                cusDTO = blCus.SearchCus(keyword);
                txtNameCustomer.Text = cusDTO.TenKH;
            }

        }
        #endregion
        #region LoadDgv
        private void LoadDgv()
        {
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            DataGridViewButtonColumn btnColumn1 = new DataGridViewButtonColumn();
           
            //Tính tiền
            string productName = txtProductName.Text;
            decimal price = Convert.ToDecimal(txtPriceProduct.Text);
            int amount;
            bool result = int.TryParse(txtAmoutProduct.Text, out amount);
            if (!result)
                return;
            decimal total = price * amount;

            decimal totalBillProduct = decimal.Parse(txtTotalProduct.Text);
            totalBillProduct = totalBillProduct + total;


            if (productName == "")
            {
                //MessageBox.Show("Hãy chọn sản phẩm");
            }
            else
            {
                Bill.Rows.Add(productName, amount, price, total);
                dataGridViewBill.DataSource = Bill;
                txtTotalProduct.Text = totalBillProduct.ToString();
                if (dataGridViewBill.Columns.Count <= 5)
                {
                    if (dataGridViewBill.Columns["Add"] == null)
                    {

                        btnColumn.FlatStyle = FlatStyle.Flat;
                        btnColumn.DefaultCellStyle.BackColor = Color.Gainsboro;
                        btnColumn.DefaultCellStyle.ForeColor = Color.Black;
                        btnColumn1.FlatStyle = FlatStyle.Flat;
                        btnColumn1.DefaultCellStyle.BackColor = Color.Gainsboro;
                        btnColumn1.DefaultCellStyle.ForeColor = Color.Black;
                        dataGridViewBill.Columns.Add(btnColumn);
                        dataGridViewBill.Columns.Add(btnColumn1);

                        //this needs to be altered for every DataGridViewButtonColumn with different Text
                        int buttonColumn = 4;
                        if (dataGridViewBill.Columns[buttonColumn] is DataGridViewButtonColumn)
                        {
                            if (dataGridViewBill.RowCount >= 0)
                            {
                                dataGridViewBill.Rows[dataGridViewBill.RowCount - 1].Cells[buttonColumn].Value = "-";
                            }
                        }
                        int buttonColumn1 = 5;
                        if (dataGridViewBill.Columns[buttonColumn1] is DataGridViewButtonColumn)
                        {
                            if (dataGridViewBill.RowCount >= 0)
                            {
                                dataGridViewBill.Rows[dataGridViewBill.RowCount - 1].Cells[buttonColumn1].Value = "+";
                            }
                        }
                    }
                }
                txtProductName.Clear();
                txtSearchProduct.Text = "";
                txtPriceProduct.Text = "0.00";
                txtAmoutProduct.Text = "0";
          
            }
        }
        #endregion
        #region ThemSPToDgv
        private void btnAddProduct_Click(object sender, EventArgs e)
        {

            LoadDgv();
            int buttonColumn = 4;
            if (dataGridViewBill.Columns[buttonColumn] is DataGridViewButtonColumn)
            {
                if (dataGridViewBill.RowCount >= 0)
                {
                    dataGridViewBill.Rows[dataGridViewBill.RowCount - 1].Cells[buttonColumn].Value = "-";
                }
            }
            int buttonColumn1 = 5;
            if (dataGridViewBill.Columns[buttonColumn1] is DataGridViewButtonColumn)
            {
                if (dataGridViewBill.RowCount >= 0)
                {
                    dataGridViewBill.Rows[dataGridViewBill.RowCount - 1].Cells[buttonColumn1].Value = "+";
                }
            }

        }
        #endregion
        #region GiamGia
        private void txtSaleProduct_TextChanged(object sender, EventArgs e)
        {
         
            decimal totalBillProduct;
            bool result1 = decimal.TryParse(txtTotalProduct.Text, out totalBillProduct);
            if (!result1)
                return;
            decimal discount;
            bool result = decimal.TryParse(txtSaleProduct.Text, out discount);
            if (!result)
                return;
            decimal totalBill = ((100 - discount) / 100) * totalBillProduct;
            txtTotalBill.Text = totalBill.ToString();  
        }
        #endregion
        #region TienKHTra
        private void txtPayAmout_TextChanged(object sender, EventArgs e)
        {
            decimal totalBill = decimal.Parse(txtTotalBill.Text);

            decimal val;
            bool result = decimal.TryParse(txtPayAmout.Text, out val);
            if (!result)
                return;
            decimal payAmount = Convert.ToDecimal(val);
            decimal returnPayAmount = payAmount - totalBill;
            txtReturnPay.Text = returnPayAmount.ToString();
        }
        #endregion
        #region TimKiem
        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            DTO_Product ex = new DTO_Product();
            BLL_DataProduct bl = new BLL_DataProduct();
            string keyword = txtSearchProduct.Text;
            try
            {
                if (keyword == "")
                {
                    tensp = txtProductName.Text;
                    txtAmoutProduct.Text = "";
                    txtPriceProduct.Text = "";
                    txtProductName.Text = "";
                    pictureBoxImageeProduct.Image = null;
                    return;
                }
                else
                {
                    ex = bl.searchProductBill(keyword);
                    int khuyenmai = ex.KhuyenMai;
                    txtProductName.Text = ex.TenSP;
                    decimal giaban = (ex.GiaBan * ((100 - (decimal)khuyenmai) / 100));
                    txtPriceProduct.Text = Convert.ToString(giaban);
                    pictureBoxImageeProduct.Image = byteArrayToImage(ex.HinhAnh);

                }
            }
            catch
            {
                //MessageBox.Show(exx.Message);
            }

        }
        #endregion
        #region ChuyenByteSangAnh
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        #endregion
        #region ThanhToan
        string masp = "";
        private void btnPayment_Click(object sender, EventArgs e)
        {

            // thêm hóa đơn
            bilDTO.NVLap = Convert.ToInt32(cmbAddbyStaff.SelectedValue);
            cusDTO = blCus.GetIdCus(txtNameCustomer.Text);
            bilDTO.ThongTinKH = cusDTO.MaKH;
            bilDTO.NgayLap = DateTime.Now;
            bilDTO.TongTien = Convert.ToDecimal(txtTotalBill.Text);
            bilDTO.DaThanhToan = true;
            decimal val;
            bool result = decimal.TryParse(txtPayAmout.Text, out val);
            if (!result)
                return;
            bilDTO.SoTienTra = Convert.ToDecimal(val);
            bilDTO.SoTienThua = Convert.ToDecimal(txtReturnPay.Text);
            Bldtb.InsertBill(bilDTO);

            // thêm chi tiết hóa đơn
            try
            {
                for (int i = 0; i < Bill.Rows.Count; i++)
                {

                    masp = blProd.GetIDProductBill(Convert.ToString(Bill.Rows[i][0].ToString()));
                    billDTO.MaSP = masp;
                    billDTO.SoLuong = Convert.ToInt32(Bill.Rows[i][1].ToString());
                    billDTO.GiaBan = decimal.Parse(Bill.Rows[i][2].ToString());
                    billDTO.ThanhTien = decimal.Parse(Bill.Rows[i][3].ToString());
                    billDTO.KhuyenMai = int.Parse(txtSaleProduct.Text);
                    bilDTO = Bldtb.GetIdBill();
                    billDTO.MaHD = bilDTO.MaHD;
                    blProd.DecreaseProd(billDTO.MaSP, billDTO.SoLuong);
                    bldldt.InsertBillDetail(billDTO);

                }
                MessageBox.Show("Thanh toán thành công");
                ReportB rp = new ReportB(Convert.ToString(billDTO.MaHD));
                rp.Show();
                clearform();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
        #region Reset Forms
        private void clearform()
        {
            txtSaleProduct.Clear();
            txtReturnPay.Clear();
            txtPriceProduct.Clear();
            txtNameCustomer.Clear();
            txtPayAmout.Clear();
            txtProductName.Clear();
            txtSearchCus.Clear();
            txtSaleProduct.Clear();
            txtSearchProduct.Clear();
            txtTotalBill.Clear();
            dataGridViewBill.DataSource = null;
            txtTotalProduct.Clear();
        }
       
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearform();
        }
        #endregion
        #region ListItem
        private void Item()
        {

            DataTable dt = blProd.AllProduct();

            for (int j = 0; j < dt.Rows.Count; j++)
            {
                ListItem listItems = new ListItem();
                listItems.NameProduct = dt.Rows[j][0].ToString();
                listItems.PriceProduct = dt.Rows[j][1].ToString();
                listItems.AmountProduct = dt.Rows[j][2].ToString();
                listItems.PercentSale = dt.Rows[j][3].ToString();
                listItems.ImageProduct = (byte[])dt.Rows[j][4];
                listItems.Width = 199;
                listItems.Height = 170;
                fPanelSell.Controls.Add(listItems);
                listItems.pictureBoxImageProductSale.Click += pictureBoxImageProductSale_Click;
                listItems.lblPriceProductSale.Click += lblPriceProductSale_Click;
                listItems.btnUserCtrPercent.Click += btnUserCtrPercent_Click;
                listItems.lblAmout.Click += lblAmout_Click;
            }

        }
        #endregion
        #region ItemClick
        private void lblAmout_Click(object sender, EventArgs e)
        {
            int khuyenmai = Convert.ToInt32(ListItem.khuyenmai);
            decimal giaban = (Convert.ToDecimal(ListItem.gia) * ((100 - (decimal)khuyenmai) / 100));
            txtProductName.Text = ListItem.tensp;
            txtPriceProduct.Text = Convert.ToString(giaban);
            pictureBoxImageeProduct.Image = ListItem.hinhanh;

        }

        private void btnUserCtrPercent_Click(object sender, EventArgs e)
        {
            int khuyenmai = Convert.ToInt32(ListItem.khuyenmai);
            decimal giaban = (Convert.ToDecimal(ListItem.gia) * ((100 - (decimal)khuyenmai) / 100));
            txtProductName.Text = ListItem.tensp;
            txtPriceProduct.Text = Convert.ToString(giaban);
            pictureBoxImageeProduct.Image = ListItem.hinhanh;
        }

        private void lblPriceProductSale_Click(object sender, EventArgs e)
        {
            int khuyenmai = Convert.ToInt32(ListItem.khuyenmai);
            decimal giaban = (Convert.ToDecimal(ListItem.gia) * ((100 - (decimal)khuyenmai) / 100));
            txtProductName.Text = ListItem.tensp;
            txtPriceProduct.Text = Convert.ToString(giaban);
            pictureBoxImageeProduct.Image = ListItem.hinhanh;
        }

        private void pictureBoxImageProductSale_Click(object sender, EventArgs e)
        {
            int khuyenmai = Convert.ToInt32(ListItem.khuyenmai);
            decimal giaban = (Convert.ToDecimal(ListItem.gia) * ((100 - (decimal)khuyenmai) / 100));
            txtProductName.Text = ListItem.tensp;
            txtPriceProduct.Text = Convert.ToString(giaban);
            pictureBoxImageeProduct.Image = ListItem.hinhanh;
        }
        #endregion
        #region DgvClick
        private void dataGridViewBill_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                DataGridViewRow r = dataGridViewBill.SelectedRows[0];
                for (int i = 0; i < dataGridViewBill.Rows.Count; i++)
                {
                    if (r.Cells[0].Value.ToString() == dataGridViewBill.Rows[i].Cells[0].Value.ToString())
                    {
                        if (int.Parse(r.Cells[1].Value.ToString()) == 1)
                        {
                            dataGridViewBill.Rows.Remove(r);
                            //LoadDgv();
                            return;
                        }
                        dataGridViewBill.Rows[i].Cells[1].Value = int.Parse(r.Cells[1].Value.ToString()) - 1;
                        decimal giagoc = decimal.Parse(r.Cells[2].Value.ToString());
                        int soluong = int.Parse(r.Cells[1].Value.ToString());
                        decimal giamoi = giagoc * soluong;
                        dataGridViewBill.Rows[i].Cells[3].Value = giamoi;
                        LoadTongTien();
                        LoadDgv();
                        return;
                    }
                }
            }
            if (e.ColumnIndex == 5)
            {
                DataGridViewRow r = dataGridViewBill.SelectedRows[0];
                for (int i = 0; i < dataGridViewBill.Rows.Count; i++)
                {
                    if (r.Cells[0].Value.ToString() == dataGridViewBill.Rows[i].Cells[0].Value.ToString())
                    {
                        dataGridViewBill.Rows[i].Cells[1].Value = int.Parse(r.Cells[1].Value.ToString()) + 1;
                        decimal giagoc = decimal.Parse(r.Cells[2].Value.ToString());
                        int soluong = int.Parse(r.Cells[1].Value.ToString());
                        decimal tong = giagoc * soluong;
                        dataGridViewBill.Rows[i].Cells[3].Value = tong;
                        LoadTongTien();
                        LoadDgv();
                    }
                }
            }
            int buttonColumn = 4;
            if (dataGridViewBill.Columns[buttonColumn] is DataGridViewButtonColumn)
            {
                if (dataGridViewBill.RowCount >= 0)
                {
                    dataGridViewBill.Rows[dataGridViewBill.RowCount - 1].Cells[buttonColumn].Value = "-";
                }
            }
            int buttonColumn1 = 5;
            if (dataGridViewBill.Columns[buttonColumn1] is DataGridViewButtonColumn)
            {
                if (dataGridViewBill.RowCount >= 0)
                {
                    dataGridViewBill.Rows[dataGridViewBill.RowCount - 1].Cells[buttonColumn1].Value = "+";
                }
            }
        }
        decimal TongTien = 0;
        private void LoadTongTien()
        {
            for (int i = 0; i < dataGridViewBill.Rows.Count; i++)
            {
                TongTien += decimal.Parse(dataGridViewBill.Rows[i].Cells[3].Value.ToString());
            }
            txtTotalProduct.Text = TongTien.ToString();
            TongTien = 0;
        }
        #endregion

    }
}

