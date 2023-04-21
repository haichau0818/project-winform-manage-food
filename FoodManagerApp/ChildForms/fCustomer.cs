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
    public partial class fCustomer : Form
    {   
        BLL_DataCustomer dataCustomer = new BLL_DataCustomer();
        public fCustomer()
        {
            InitializeComponent();
        }

        private void fCustomer_Load(object sender, EventArgs e)
        {
           ShowDataCustomer();
            ListStaff();
        }
        #region ShowKH
        public void ShowDataCustomer()
        {
            BLL_DataCustomer dtPr = new BLL_DataCustomer();
            DataTable dt = dtPr.dataShowCustomer();
            dataGridViewCustomer.DataSource = dt;
        }
        #endregion
        #region DSNhanVien
        public void ListStaff()
        {
            BLL_DataCustomer bl = new BLL_DataCustomer();
            comboBoxIdStaff.DataSource = bl.ListStaff();
            comboBoxIdStaff.DisplayMember = "hoTen";
            comboBoxIdStaff.ValueMember = "maNV";
        }
#endregion
        #region ThemKH
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (txtIdCustomer.Text != "")
            {
                DTO_Customer ex = new DTO_Customer();
                ex.MaKH = txtIdCustomer.Text;
                ex.TenKH = txtNameCustomer.Text;
                ex.ThemBoi = Convert.ToInt32(comboBoxIdStaff.SelectedValue);
                if (comboBoxSex.SelectedIndex == 0)
                {
                    ex.GioiTinh = true;
                }
                else
                    ex.GioiTinh = false;
                ex.SDT = txtPhoneCustomer.Text;
                ex.Email = txtEmailCustomer.Text;
                ex.DiaChi = txtAdressCustomer.Text;
                dataCustomer.InsertCustomer(ex);
                MessageBox.Show("Thêm khách hàng thành công!");
                ShowDataCustomer();
                ClearForms();
            }else
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng");
            }    
        }
        #endregion
        #region SuaKH
        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if(dataGridViewCustomer.SelectedRows.Count > 0)
             {

                txtIdCustomer.Text = dataGridViewCustomer.CurrentRow.Cells["Mã khách hàng"].Value.ToString();
                txtNameCustomer.Text = dataGridViewCustomer.CurrentRow.Cells["Họ tên"].Value.ToString();
                comboBoxIdStaff.Text = dataGridViewCustomer.CurrentRow.Cells[2].Value.ToString();
                comboBoxSex.Text = dataGridViewCustomer.CurrentRow.Cells[3].Value.ToString();
                txtAdressCustomer.Text = dataGridViewCustomer.CurrentRow.Cells[4].Value.ToString();
                txtPhoneCustomer.Text =dataGridViewCustomer.CurrentRow.Cells["Số điện thoại"].Value.ToString();
                txtEmailCustomer.Text = dataGridViewCustomer.CurrentRow.Cells["Email"].Value.ToString();
                
            }
                else
                MessageBox.Show("Xin chọn 1 hàng để thay đổi");
        }
        #endregion
        #region CapNhatKH
        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                DTO_Customer ex = new DTO_Customer();
                ex.MaKH = txtIdCustomer.Text;
                ex.TenKH = txtNameCustomer.Text;
                ex.ThemBoi = Convert.ToInt32(comboBoxIdStaff.SelectedValue);
                if (comboBoxSex.SelectedIndex == 0)
                {
                    ex.GioiTinh = true;
                }
                else
                    ex.GioiTinh = false;
                ex.SDT = txtPhoneCustomer.Text;
                ex.Email = txtEmailCustomer.Text;
                ex.DiaChi = txtAdressCustomer.Text;
                dataCustomer.EditCustomer(ex);
                MessageBox.Show("Cập nhật thành công!");
                ShowDataCustomer();
                ClearForms();
            }
            catch(Exception a)
            {
                MessageBox.Show("lổi"+a);
            }
        }
        #endregion
        #region XoaKH
        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomer.SelectedRows.Count > 0)
            {
                DTO_Customer ex = new DTO_Customer();
                txtIdCustomer.Text = dataGridViewCustomer.CurrentRow.Cells["Mã khách hàng"].Value.ToString();
                ex.MaKH = txtIdCustomer.Text;
                if(MessageBox.Show("Bạn chắn chắn muốn xóa khách hàng này!","",MessageBoxButtons.YesNo)==DialogResult.Yes)
                dataCustomer.DeletedCustomer(ex);
                ShowDataCustomer();
                ClearForms();
            }
        }
        #endregion
        #region Clear
        private void ClearForms()
        {
            txtIdCustomer.Clear();
            txtAdressCustomer.Clear();
            txtEmailCustomer.Clear();
            txtPhoneCustomer.Clear();
            txtNameCustomer.Clear();
            comboBoxIdStaff.Refresh();
        }
        #endregion
        #region TimKiemKH
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BLL_DataCustomer bl = new BLL_DataCustomer();
            //string keyword = ;
            if (txtSearch.Text != "")
            {
                DataTable dt = bl.SearchCuss(txtSearch.Text);
                dataGridViewCustomer.DataSource = dt;

            }
            else
            {
                DataTable dtb = bl.dataShowCustomer();
                dataGridViewCustomer.DataSource = dtb;
            }
            ClearForms();
        }
        #endregion

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            ClearForms();
        }
    }
}
