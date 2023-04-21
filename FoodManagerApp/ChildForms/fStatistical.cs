using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO.Cache;
using BusinessLogicLayer;
using System.Windows.Forms.DataVisualization.Charting;

namespace PresentationLayer
{
    public partial class fStatistical : Form
    {
        public fStatistical()
        {
            InitializeComponent();
        }

        BLL_DataStatistic Bll = new BLL_DataStatistic();
        DTO_Statistic dto = new DTO_Statistic();
        private void Statistic()
        {
            Bll.StatisticTotalV(dto);

            lblValuesRevenue.Text = dto.Total;
            lblValueCust.Text = dto.TotalCus;
            lblValueSellingProd.Text = dto.TotalProdSel;
            lblValueTotalProduct.Text = dto.TotalProd;
        }

        private void fStatistical_Load(object sender, EventArgs e)
        {
            Statistic();
            cmbSelectChartColumn.Text = "Biểu đồ doanh thu theo ngày";
            cmbSelectChartCircula.Text = "Sản phẩm bán chạy";

        }
        private void cmbSelectChartColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelectChartColumn.Text == "Biểu đồ doanh thu theo tháng")
            {
                if (chartMountYear.Series[0].Points != null)
                {
                    chartMountYear.Visible = true;
                    Bll.MonthlyRevenue(dto);
                    chartMountYear.Series[0].Points.DataBindXY(dto.Mounth, dto.Slmounth1);
                    chartAmoutProd.Visible = false;
                }
                else
                    chartMountYear.Series.Clear();
            }
            else
            {
                if (cmbSelectChartColumn.Text == "Biểu đồ doanh thu theo ngày")
                {
                    chartAmoutProd.Visible = true;
                    Bll.DateRevenue(dto);
                    chartAmoutProd.Series[0].Points.DataBindXY(dto.Date, dto.Sldate1);
                    chartMountYear.Visible = false;

                }
                else
                {
                    chartMountYear.Visible = true;
                    chartAmoutProd.Visible = false;
                    Bll.AnnualyRevenue(dto);
                    chartMountYear.Series[0].Points.DataBindXY(dto.Year, dto.Slyear1);

                }
            }
        }

        private void cmbSelectChartCircula_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbSelectChartCircula.Text == "Sản phẩm bán chạy")
            {
                if (chartSellingProd.Series.Count > 0)
                {
                    Bll.ProSelling(dto);
                    chartSellingProd.Series[0].Points.DataBindXY(dto.NamePro, dto.SlnamePro);
                }
                else
                    chartSellingProd.Series[0].Points.Clear();
            }
            else
            {
                if (chartSellingProd.Series.Count > 0)
                {
                    Bll.TypeProAmount(dto);
                    chartSellingProd.Series[0].Points.DataBindXY(dto.TypeProd, dto.SlTypeProd);
                }
                else
                    chartSellingProd.Series[0].Points.Clear();
            }

        }
    }
}
