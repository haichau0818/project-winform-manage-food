using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
using DTO.Cache;

namespace BusinessLogicLayer
{
    public class BLL_TypePro
    {
        DataTypePro dttp = new DataTypePro();
        public DataTable ShowTypePro()
        {
            DataTable dataTable = new DataTable();
            dataTable = dttp.LoaiSP();
            return dataTable;
        }
        public DataTable SearchProd(string keyword)
        {
            DataTable dataTable = new DataTable();
            dataTable = dttp.Search(keyword);
            return dataTable;
        }
        public void InsertType(DTO_TypePro ex)
        {
            dttp.Insert(ex);
        }
        public void Update(DTO_TypePro ex)
        {
            dttp.Update(ex);
        }
        public void Delete(DTO_TypePro ex)
        {
            dttp.Delete(ex);
        }
    }
}
