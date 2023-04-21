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
using PresentationLayer.Cache;

namespace PresentationLayer
{
    public partial class fStaff : Form
    {
        BLL_DataStaff dataStaff = new BLL_DataStaff();
        private bool Edita= false;
        public fStaff()
        {
            InitializeComponent();
           
        }
        private void fStaff_Load(object sender, EventArgs e)
        {
            ShowDataStaff();
            ListRolerStaff();
            ListAccountname();
        }
        #region ShowDgv
        private void ShowDataStaff()
        {
            BLL_DataStaff objecto = new BLL_DataStaff();
            DataTable dt1 = objecto.dataShowStaff();
            dataGridViewNhanVien.DataSource =dt1;
        }
        #endregion
        #region Them
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtNameStaff.Text != "")
            {
                if (Edita == false)
                {
                    try
                    {
                        DTO_Staff ex = new DTO_Staff();
                        ex.TenNV = txtNameStaff.Text;
                        ex.MaQuyen = Convert.ToInt32(comboBoxRole.SelectedValue);
                        if (cboSex.SelectedIndex == 0)
                        {
                            ex.GioiTinh = true;
                        }
                        else
                            ex.GioiTinh = false;
                        ex.NgaySinh = dateTimePickerStaff.Value;
                        ex.IDTK = Convert.ToInt32(comboBoxUsername.SelectedValue);
                        ex.SDT = txtPhoneNumberStaff.Text;
                        ex.Email = txtEmailStaff.Text;
                        ex.DiaChi = txtAdressStaff.Text;
                        dataStaff.InsertStaff(ex);
                        MessageBox.Show("Thêm nhân viên thành công!");
                        ShowDataStaff();
                        ClearForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("lỗi" + ex);
                    }
                }
            }
            else
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin!");
            
        }
        #endregion
        #region Sua
        private void btnEdit_Click(object sender, EventArgs e)
        {
           
             if (dataGridViewNhanVien.SelectedRows.Count > 0)
             {
                    Edita = true;

                    txtNameStaff.Text = dataGridViewNhanVien.CurrentRow.Cells[1].Value.ToString();
                    comboBoxRole.Text = dataGridViewNhanVien.CurrentRow.Cells[2].Value.ToString();
                    comboBoxUsername.Text = dataGridViewNhanVien.CurrentRow.Cells[3].Value.ToString();
                    cboSex.Text = dataGridViewNhanVien.CurrentRow.Cells[4].Value.ToString();
                    dateTimePickerStaff.Text = dataGridViewNhanVien.CurrentRow.Cells[5].Value.ToString();
                    txtAdressStaff.Text= dataGridViewNhanVien.CurrentRow.Cells[6].Value.ToString();
                    txtPhoneNumberStaff.Text = dataGridViewNhanVien.CurrentRow.Cells[7].Value.ToString();
                    txtEmailStaff.Text = dataGridViewNhanVien.CurrentRow.Cells["Email"].Value.ToString();
                    txtIdStaff.Text = dataGridViewNhanVien.CurrentRow.Cells[0].Value.ToString();
             }
                else
                    MessageBox.Show("Xin chọn 1 hàng để thay đổi");
            

        }
        private void ClearForm()
        {
            txtIdStaff.Clear();
            txtNameStaff.Clear();         
            cboSex.Text="Nam";
            txtAdressStaff.Clear();
            txtPhoneNumberStaff.Clear();
            txtEmailStaff.Clear();
        }
        #endregion
        #region CapNhat
        private void btnUpdateStaff_Click(object sender, EventArgs e)
        {
            if (Edita == true)
            {
                try
                {
                    DTO_Staff ex = new DTO_Staff();
                    ex.TenNV = txtNameStaff.Text;
                    ex.MaQuyen =Convert.ToInt32( comboBoxRole.SelectedValue);
                    if (cboSex.SelectedIndex == 0)
                    {
                        ex.GioiTinh = false;
                    }
                    else
                        ex.GioiTinh = true;
                    ex.NgaySinh = dateTimePickerStaff.Value;
                    ex.DiaChi = txtAdressStaff.Text;
                    ex.SDT = txtPhoneNumberStaff.Text;
                    ex.Email = txtEmailStaff.Text;
                    ex.IDTK =Convert.ToInt32(comboBoxUsername.SelectedValue);
                    ex.MaNV = Convert.ToInt32(txtIdStaff.Text);
                    dataStaff.EditStaff(ex);
                    MessageBox.Show("Cập nhật thành công!");
                    ShowDataStaff();
                    Edita = false;
                    ClearForm();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("lỗi" + ex);
                }
            }
        }
        #endregion
        #region Xoa
        private void btnDeleteStaff_Click(object sender, EventArgs e)
        {
            if (dataGridViewNhanVien.SelectedRows.Count > 0)
            {
                DTO_Staff ex = new DTO_Staff();
                txtIdStaff.Text = dataGridViewNhanVien.CurrentRow.Cells["Mã nhân viên"].Value.ToString();
                ex.MaNV = Convert.ToInt32(txtIdStaff.Text);
                if(MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này!","",MessageBoxButtons.YesNo)==DialogResult.Yes)
                dataStaff.DeletedStaff(ex);
                ShowDataStaff();
                ClearForm();
            }
        }
        #endregion
        #region DanhSachQuyenVsTenTaiKhoan
        private void ListRolerStaff()
        {
            BLL_DataStaff bll = new BLL_DataStaff();
            comboBoxRole.DataSource = bll.ListRoleStaff();
            comboBoxRole.DisplayMember = "tenQuyen";
            comboBoxRole.ValueMember = "maQuyen";
            
        }
        private void ListAccountname()
        {
            BLL_DataStaff bll = new BLL_DataStaff();
            comboBoxUsername.DataSource = bll.ListAccount();
            comboBoxUsername.DisplayMember = "Username";
            comboBoxUsername.ValueMember = "id";
        }
        #endregion
        #region TimKiem
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BLL_DataStaff bl = new BLL_DataStaff();
            //string keyword = ;
            if (txtSearch.Text != "")
            {
                DataTable dt = bl.searchStaff(txtSearch.Text);
                dataGridViewNhanVien.DataSource = dt;

            }
            else
            {
                DataTable dtb = bl.dataShowStaff();
                dataGridViewNhanVien.DataSource =dtb;
            }
            Clear();
        }
        #endregion
        #region Clear
        private void Clear()
        {
            txtAdressStaff.Clear();
            txtEmailStaff.Clear();
            txtIdStaff.Clear();
            txtNameStaff.Clear();
            txtPhoneNumberStaff.Clear();

        }
        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
