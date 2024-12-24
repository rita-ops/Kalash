using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalash
{
    public partial class FormReportIncome : BaseForm
    {
        private DataTable sortedData;

        string member;
        DateTime fromDate, toDate;
        decimal sumUSD;
        decimal sumLBP;

        public FormReportIncome(DataTable sortedData, decimal sumUSD, decimal sumLBP)
        {
            InitializeComponent();
            this.sortedData = sortedData;
            this.sumUSD = sumUSD;
            this.sumLBP = sumLBP;
            LoadReport();
        }

        public FormReportIncome(DataTable sortedData, string member, DateTime fromDate, DateTime toDate, decimal sumUSD, decimal sumLBP)
        {
            InitializeComponent();
            this.sortedData = sortedData;
            this.member = member;
            this.fromDate = fromDate;
            this.toDate = toDate;
            this.sumLBP = sumLBP;
            this.sumUSD = sumUSD;
            LoadReport();
        }

        private void LoadReport()
        {
            // Fill the data table based on the filter criteria
            if (!string.IsNullOrEmpty(member) && fromDate != DateTime.MinValue && toDate != DateTime.MinValue)
            {
                this.incomestableTableAdapter.FillByAll(this.dataSetIncome.incomestable, member, fromDate.ToString(), toDate.ToString());
            }
            else if (!string.IsNullOrEmpty(member) && fromDate == DateTime.MinValue)
            {
                this.incomestableTableAdapter.FillByMember(this.dataSetIncome.incomestable, member);
            }
            else if (member == null && fromDate != DateTime.MinValue && toDate != DateTime.MaxValue)
            {
                this.incomestableTableAdapter.FillBydate(this.dataSetIncome.incomestable, fromDate.ToString(), toDate.ToString());
            }
            else
            {
                this.incomestableTableAdapter.Fill(this.dataSetIncome.incomestable);
            }

            // Pass the sorted data to the report viewer
            ReportDataSource rds = new ReportDataSource("DataSet1", sortedData);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);


            ReportParameter parameter1 = new ReportParameter("sumUSD", this.sumUSD.ToString("#,##0"));
            ReportParameter parameter2 = new ReportParameter("sumLBP", this.sumLBP.ToString("#,##0"));

            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parameter1, parameter2 });
            this.reportViewer1.RefreshReport();
        }


        private void FormReportIncome_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetIncome.incomestable' table. You can move, or remove it, as needed.
           // this.incomestableTableAdapter.Fill(this.dataSetIncome.incomestable);

            //this.reportViewer1.RefreshReport();
        }
    }
}
