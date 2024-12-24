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
    public partial class FormReportExpense : BaseForm
    {

        private DataTable sortedData; 
        
        string desc;
        DateTime fromDate, toDate;
        decimal sumUSD;
        decimal sumLBP;

        public FormReportExpense(DataTable sortedData, decimal sumUSD, decimal sumLBP)
        {
            InitializeComponent();
            this.sortedData = sortedData;
            this.sumLBP = sumLBP;
            this.sumUSD = sumUSD;
            LoadReport();
        }

        public FormReportExpense(DataTable sortedData, string desc, DateTime fromDate, DateTime toDate, decimal sumUSD, decimal sumLBP)
        {
            InitializeComponent();
            this.sortedData = sortedData;
            this.desc = desc;
            this.fromDate = fromDate;
            this.toDate = toDate;
            this.sumLBP = sumLBP;
            this.sumUSD = sumUSD;
            LoadReport();
        }

        private void LoadReport()
        {
            // Fill the data table based on the filter criteria
            if (!string.IsNullOrEmpty(desc) && fromDate != DateTime.MinValue && toDate != DateTime.MinValue)
            {
                this.expensestableTableAdapter.FillByall(this.dataSetExpense.expensestable, desc, fromDate.ToString(), toDate.ToString());
            }
            else if (!string.IsNullOrEmpty(desc) && fromDate == DateTime.MinValue)
            {
                this.expensestableTableAdapter.FillBydesc(this.dataSetExpense.expensestable, desc);
            }
            else if (desc == null && fromDate != DateTime.MinValue && toDate != DateTime.MaxValue)
            {
                this.expensestableTableAdapter.FillBydate(this.dataSetExpense.expensestable, fromDate.ToString(), toDate.ToString());
            }
            else
            {
                this.expensestableTableAdapter.Fill(this.dataSetExpense.expensestable);
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

        private void FormReportExpense_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetExpense.expensestable' table. You can move, or remove it, as needed.
            //this.expensestableTableAdapter.Fill(this.dataSetExpense.expensestable);

            //this.reportViewer1.RefreshReport();
        }
    }
}
