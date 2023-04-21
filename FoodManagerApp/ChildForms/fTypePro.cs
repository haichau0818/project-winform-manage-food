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
    public partial class fTypePro : Form
    {
        public fTypePro()
        {
            InitializeComponent();
        }
        private bool Edit = false;
        private void fTypePro_Load(object sender, EventArgs e)
        {
            ShowDgv();
        }
        #region ShowDgv
        private void ShowDgv()
        {
            BLL_TypePro bltp = new BLL_TypePro();
            DataTable dt = bltp.ShowTypePro();
            dataGridView1.DataSource = dt;
        }
        #endregion
        #region SuKienDoiMauClickTextBox
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnEditProduct_MouseLeave(object sender, EventArgs e)
        {
            btnEditProduct.BackColor = Color.FromArgb(35, 48, 71);
        }

        private void btnDeleteProduct_MouseLeave(object sender, EventArgs e)
        {
            btnDeleteProduct.BackColor = Color.FromArgb(35, 48, 71);
        }

        private void btnUpdateProduct_MouseLeave(object sender, EventArgs e)
        {
            btnUpdateProduct.BackColor = Color.FromArgb(35, 48, 71);
        }
        private void btnUpdateProduct_MouseHover(object sender, EventArgs e)
        {
            btnUpdateProduct.BackColor = Color.FromArgb(23, 144, 249);
           
        }

        private void btnDeleteProduct_MouseHover(object sender, EventArgs e)
        {
            btnDeleteProduct.BackColor = Color.FromArgb(23, 144, 249);
        }

        private void btnEditProduct_MouseHover(object sender, EventArgs e)
        {
            btnEditProduct.BackColor = Color.FromArgb(23, 144, 249);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            txtSearch.ForeColor = Color.Black;
            BLL_TypePro bl = new BLL_TypePro();
            if (txtSearch.Text != "")
            {
                DataTable dt = bl.SearchProd(txtSearch.Text);
                dataGridView1.DataSource = dt;

            }
            else
            {
                DataTable dt = bl.ShowTypePro();
                dataGridView1.DataSource = dt;
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm...")
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if(txtSearch.Text=="")
            {
                txtSearch.Text = "Tìm...";
            }    
        }
        #endregion
        #region CapNhatVsThemLSP
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            BLL_TypePro bltp = new BLL_TypePro();
            DTO_TypePro ex = new DTO_TypePro();
            if (Edit == false)
            {
                
                try
                {
                    ex.TenLoai = txtTenLoaiSP.Text;
                    ex.GhiChu = txtNote.Text;
                    bltp.InsertType(ex);
                    MessageBox.Show("Thêm thành công!");
                    ShowDgv();
                }
                catch
                {
                    MessageBox.Show("Thêm thất bại!");
                }
            }
            if (Edit == true)
            {
                try {
                    ex.MaLoai =Convert.ToInt32(txtLoaiSP.Text);
                    ex.TenLoai = txtTenLoaiSP.Text;
                    ex.GhiChu = txtNote.Text;
                    bltp.Update(ex);
                    MessageBox.Show("Sửa thành công!");
                    ShowDgv();
                    }
                catch
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }

        }
        #endregion
        #region SuaLSP
        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count>0)
            {
                Edit = true;
                txtLoaiSP.Text = dataGridView1.CurrentRow.Cells["Mã loại sản phẩm"].Value.ToString();
                txtTenLoaiSP.Text = dataGridView1.CurrentRow.Cells["Tên loại sản phẩm"].Value.ToString();
                txtNote.Text = dataGridView1.CurrentRow.Cells["Ghi chú"].Value.ToString();
                
            }    
        }
        #endregion
        #region XoaLSP
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                BLL_TypePro bltp = new BLL_TypePro();
                DTO_TypePro ex = new DTO_TypePro();
                txtLoaiSP.Text = dataGridView1.CurrentRow.Cells["Mã loại sản phẩm"].Value.ToString();
                ex.MaLoai = Convert.ToInt32(txtLoaiSP.Text);
                MessageBox.Show("Bạn có chắn chắn muốn xóa loại sản phẩm này!", "", MessageBoxButtons.YesNo);
                bltp.Delete(ex);
                ShowDgv();
            }
            else
                MessageBox.Show("Hãy chọn sản phẩm để xóa");
        }
        #endregion
    }
}
