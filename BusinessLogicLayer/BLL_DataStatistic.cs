using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Cache;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BLL_DataStatistic
    {
        private DataStatistical datastatc = new DataStatistical();
        public void MonthlyRevenue(DTO_Statistic ex)
        {
            datastatc.monthlyRevenue(ex);
          
        }

        public void AnnualyRevenue(DTO_Statistic ex)
        {
            datastatc.annualRevenue(ex);

        }
        public void DateRevenue(DTO_Statistic ex)
        {
            datastatc.dateRevenue(ex);

        }
        public void TypeProAmount(DTO_Statistic ex)
        {
            datastatc.AmountProType(ex);
        }
       
        public void ProSelling(DTO_Statistic ex)
        {
            datastatc.ProSelling(ex);
        }
        public void StatisticTotalV(DTO_Statistic ex)
        {

            datastatc.StatisticalAll(ex);
        }

    }
}
