using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using DTO.Cache;
using Microsoft.VisualBasic;
using PresentationLayer.Cache;

namespace PresentationLayer
{
    public partial class fProduct : Form
    {
        BLL_DataProduct dataProduct1 = new BLL_DataProduct();
        public fProduct()
        {
            InitializeComponent();
        }
        private void fProduct_Load(object sender, EventArgs e)
        {
            
            ShowDataProduct();
            ListDataTypeProduct();
        }
        #region ChonAnhTuFile
        private void btnLoadImage_Click(object sender, EventArgs e)
        {   //Lấy ảnh từ file
            openFileDialogLoadImage.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
            DialogResult res = openFileDialogLoadImage.ShowDialog();
            if (res == DialogResult.OK)
            {
                pictureBoxImageProduct.Image = Image.FromFile(openFileDialogLoadImage.FileName);
            }
        }
        #endregion
        #region Show SanPham vs LoaiSanPham
        private void ShowDataProduct()
        {   //Show dữ liệu
            BLL_DataProduct dataProduct = new BLL_DataProduct();
            DataTable dt = dataProduct.dataShowProduct();
            dataGridViewProduct.DataSource = dt;
            dataGridViewProduct.Columns["Hình ảnh"].Width = 150;

        }
        private void ListDataTypeProduct()
        {
            BLL_DataProduct dataProduct = new BLL_DataProduct();
            comboBoxTypeProduct.DataSource = dataProduct.ListTypeProduct();
            comboBoxTypeProduct.DisplayMember = "tenLoaiSP";
            comboBoxTypeProduct.ValueMember = "maLSP";
        }
        #endregion
        #region ChuyenHinhAnhSangByte And ChuyenByteSangHinhAnh
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        #endregion
        #region ThemSanPham
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                
                Image imagee = pictureBoxImageProduct.Image;
                byte[] image_aray;
                ImageConverter converter = new ImageConverter();
                image_aray = (byte[])converter.ConvertTo(imagee, typeof(byte[]));
                DTO_Product pd = new DTO_Product();
                pd.MaSP = txtIdProduct.Text;
                pd.TenSP = txtNameProduct.Text;
                pd.MaLSP = Convert.ToInt32(comboBoxTypeProduct.SelectedValue);
                decimal gianhap = Convert.ToDecimal(txtPriceProduct.Text);
                pd.GiaNhap = gianhap;
                decimal loinhuan = ((100 + (Convert.ToDecimal(txtProfit.Text))) * gianhap) / 100;
                txtSellPriceProduct.Text = Convert.ToString(loinhuan);
                pd.GiaBan = loinhuan;
                pd.SoLuong = Convert.ToInt32(txtAmoutProduct.Text);
                pd.HinhAnh = image_aray;
                pd.KhuyenMai = Convert.ToInt32(txtSaleProduct.Text);
                pd.HSD = dateTimePickerEXP.Value;
                pd.NSX =dateTimePickerMFG.Value;
                if (gianhap > 0)
                {
                    dataProduct1.InsertProduct(pd);
                    MessageBox.Show("Thêm sản phẩm thành công!");
                }
                ShowDataProduct();
                ClearForms();

            }
            catch (Exception ex)
            {
                MessageBox.Show("loi"+ex);
            }
        }
        #endregion
        #region SuaSanPham
        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (dataGridViewProduct.SelectedRows.Count > 0)
            {
                txtIdProduct.Text = dataGridViewProduct.CurrentRow.Cells[0].Value.ToString();
                comboBoxTypeProduct.Text = dataGridViewProduct.CurrentRow.Cells["Tên loại sản phẩm"].Value.ToString();
                txtNameProduct.Text = dataGridViewProduct.CurrentRow.Cells[1].Value.ToString();
                txtAmoutProduct.Text = dataGridViewProduct.CurrentRow.Cells["Số lượng"].Value.ToString();
                txtPriceProduct.Text = dataGridViewProduct.CurrentRow.Cells[3].Value.ToString();
                txtSellPriceProduct.Text = dataGridViewProduct.CurrentRow.Cells["Giá bán"].Value.ToString();
                decimal gianhap = Convert.ToDecimal(txtPriceProduct.Text);
                decimal giaban = Convert.ToDecimal(txtSellPriceProduct.Text);
                decimal loinhuan = ((giaban * 100) / gianhap) - 100;
                txtProfit.Text = Convert.ToString(loinhuan);
                txtSaleProduct.Text = dataGridViewProduct.CurrentRow.Cells[5].Value.ToString();
                dateTimePickerEXP.Value = Convert.ToDateTime(dataGridViewProduct.CurrentRow.Cells[8].Value);
                dateTimePickerMFG.Value = Convert.ToDateTime(dataGridViewProduct.CurrentRow.Cells["Ngày sản xuất"].Value);
                if (dataGridViewProduct.CurrentRow.Cells["Hình ảnh"].Value != null)
                {
                    Byte[] data = new Byte[0];
                    data = (byte[])dataGridViewProduct.CurrentRow.Cells["Hình ảnh"].Value;
                    MemoryStream mem = new MemoryStream(data);
                    pictureBoxImageProduct.Image = Image.FromStream(mem);

                }
                else
                    pictureBoxImageProduct.Image = null;
               
            }
        }
        #endregion
        #region CapNhatSanPham
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            
            Image imagee = pictureBoxImageProduct.Image;

            byte[] image_aray;
            ImageConverter converter = new ImageConverter();
            image_aray = (byte[])converter.ConvertTo(imagee, typeof(byte[]));
            DTO_Product ex = new DTO_Product();
            ex.MaSP = txtIdProduct.Text;
            ex.TenSP = txtNameProduct.Text;
            ex.MaLSP = Convert.ToInt32(comboBoxTypeProduct.SelectedValue);
            ex.GiaNhap = Convert.ToDecimal(txtPriceProduct.Text);
            ex.GiaBan = Convert.ToDecimal(txtSellPriceProduct.Text);
            ex.SoLuong = Convert.ToInt32(txtAmoutProduct.Text);
            ex.HinhAnh = image_aray;
            ex.KhuyenMai = Convert.ToInt32(txtSaleProduct.Text);
            ex.HSD = Convert.ToDateTime(dateTimePickerEXP.Text);
            ex.NSX = Convert.ToDateTime(dateTimePickerMFG.Text);
            dataProduct1.EditProduct(ex);
            MessageBox.Show("Cập nhật sản phẩm thành công!");
            ShowDataProduct();
            ClearForms();
        }
        #endregion
        #region XoaSanPham
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            DTO_Product ex = new DTO_Product();
            txtIdProduct.Text = dataGridViewProduct.CurrentRow.Cells["Mã sản phẩm"].Value.ToString();
            ex.MaSP = txtIdProduct.Text;
            if(MessageBox.Show("Bạn có chắn chắn muốn xóa sản phẩm này!","",MessageBoxButtons.YesNo)==DialogResult.Yes)
            dataProduct1.DeletedProduct(ex);
            ShowDataProduct();
            ClearForms();
        }
        #endregion
        #region Clear
        private void ClearForms()
        {
            txtIdProduct.Clear();
            txtNameProduct.Clear();
            txtPriceProduct.Clear();
            txtSaleProduct.Clear();
            txtSellPriceProduct.Clear();
            txtAmoutProduct.Clear();
            txtProfit.Clear();
            dateTimePickerEXP.Refresh();
            dateTimePickerMFG.Refresh();
        }
        #endregion
        #region TimKiem
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BLL_DataProduct bl = new BLL_DataProduct();
            //string keyword = ;
            if (txtSearch.Text != "")
            {
                DataTable dt = bl.SearchProd(txtSearch.Text);
                dataGridViewProduct.DataSource = dt;

            }
            else
            {
                DataTable dt = bl.dataShowProduct();
                dataGridViewProduct.DataSource = dt;
            }
            ClearForms();
        }
        #endregion
        #region LoaiSanPham
        private void btnTypeProd_Click(object sender, EventArgs e)
        {
            fTypePro f = new fTypePro();
            f.Show();
        }
        #endregion

        private void txtProfit_TextChanged(object sender, EventArgs e)
        {
            decimal gianhap;
               bool result = decimal.TryParse(txtPriceProduct.Text,out gianhap);
            if (!result)
                return;
            decimal loinhuan; 
               bool result1 = decimal.TryParse(txtProfit.Text,out loinhuan);
            if (!result1)
                return;
            txtSellPriceProduct.Text = Convert.ToString(((100+loinhuan)*gianhap)/100);
        }
    }
}
