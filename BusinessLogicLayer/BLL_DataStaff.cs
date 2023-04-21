using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using DTO.Cache;
using PresentationLayer.Cache;

namespace BusinessLogicLayer
{
    public class BLL_DataStaff
    {
        private DataStaff dataStaff = new DataStaff();
        // lấy dữ liệu từ DAL
        public DataTable dataShowStaff()
        {
            DataTable dataTable = new DataTable();
            dataTable = dataStaff.tableDataStaff();
            return dataTable;
        }
        public DataTable ListRoleStaff()
        {
            DataTable dataTable = new DataTable();
            dataTable = dataStaff.ListRole();
            return dataTable;
        }
        public DataTable ListAccount()
        {
            DataTable dataTable = new DataTable();
            dataTable = dataStaff.ListUser();
            return dataTable;
        }
        public DataTable searchStaff(string keyword)
        {
            DataTable dataTable = new DataTable();
            dataTable = dataStaff.Search(keyword);
            return dataTable;
        }
        public void InsertStaff(DTO_Staff ex)
        {
            dataStaff.Insert(ex);
        }
        public void EditStaff(DTO_Staff ex)
        {
            dataStaff.Edit(ex);
        }
        
        public void DeletedStaff(DTO_Staff ex)
        {
            dataStaff.Deleted(ex);
        }

    }
}
