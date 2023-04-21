using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTO.Cache;

namespace BusinessLogicLayer
{
    public class BLL_DataBillDetail
    {
        DataBillDetail db = new DataBillDetail();
        
       public void InsertBillDetail(DTO_BillDetail dt)
        {
            db.InsertBillDeTail(dt);
        }
    }
}
