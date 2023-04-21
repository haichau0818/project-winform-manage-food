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
using Microsoft.Reporting.WinForms;

namespace PresentationLayer
{
    public partial class ReportB : Form
    {
        string id;
        public ReportB(string id1)
        {
            id = id1;
            InitializeComponent();
        }
        BLL_DataBill bLL = new BLL_DataBill();
        #region Load Repord
        private void ReportB_Load(object sender, EventArgs e)
        {
            DataTable dd = bLL.Invoice(id);
            ReportDataSource dts = new ReportDataSource("DataSet1", dd);
            this.reportViewer1.LocalReport.ReportPath = @"G:\Đồ án1\FoodManagerApp\FoodManagerApp\Report\Report1.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(dts);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
        #endregion
    }
}
