using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.SqlClient;
using System.Data;
using DTO.Cache;

namespace BusinessLogicLayer
{
     public class BLL_DataCustomer
    {
        DataCustomer dataCustomer = new DataCustomer();
        public DataTable dataShowCustomer()
        {
            DataTable dataTable = new DataTable();
            dataTable = dataCustomer.tableDataCustomer();
            return dataTable;
        }
        public DataTable ListStaff()
        {
            DataTable dataTable = new DataTable();
            dataTable = dataCustomer.listStaff();
            return dataTable;
        }
        public DataTable SearchCuss(string keyword)
        {
            DataTable dataTable = new DataTable();
            dataTable = dataCustomer.Search(keyword);
            return dataTable;
        }
        public DTO_Customer SearchCus(string keyword)
        {
            DTO_Customer dt = new DTO_Customer();
            dt = dataCustomer.searchCustomerForBill(keyword);
            return dt; 
        }
        public DTO_Customer GetIdCus(string name)
        {
            DTO_Customer dt = new DTO_Customer();
            dt = dataCustomer.GetIdCustomer(name);
            return dt;
        }
        public void InsertCustomer(DTO_Customer ex)
        {
            dataCustomer.Insert(ex);
        }
        public void EditCustomer(DTO_Customer ex)
        {
            dataCustomer.Edit(ex);
        }
        public void DeletedCustomer(DTO_Customer ex)
        {
            dataCustomer.Deleted(ex);
        }
    }
}
