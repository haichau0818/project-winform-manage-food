using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTO.Cache;


namespace BusinessLogicLayer
{
     public class BLL_DataBill
    {
        DataBill db = new DataBill();
        #region DS Nhân Viên
        public DataTable ListStaff()
        {
            DataTable dataTable = new DataTable();
            dataTable = db.listStaff();
            return dataTable;
        }
        #endregion
        #region Lấy Id
        public DTO_Bill GetIdBill()
        {
            DTO_Bill dt = new DTO_Bill();
            dt = db.GetIdBill();
            return dt;
        }
        #endregion
        #region Thêm HD
        public void InsertBill(DTO_Bill bil)
        {
            db.Insert(bil);
        }
        #endregion
        #region In hóa đơn
        public DataTable Invoice(string keyword)
        {
            DataTable data = new DataTable();
            data =db.GetBill(keyword);
            return data;
        }
        #endregion
    }
}
