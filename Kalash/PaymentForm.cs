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

    public partial class PaymentForm : Form
    {
        Functions Con;
        private DataTable originalDataTable;

        public PaymentForm(DataGridView dataGridView1)
        {
            InitializeComponent();
            Con = new Functions();
            showPayments();
            LoadDataAndCalculateTotals();
            dataGridView1.Columns[0].Visible = false;
            originalDataTable = (DataTable)dataGridView1.DataSource;
            dataGridView1.DataSource = originalDataTable;
        }

        private void showPayments()
        {
            string Query = "select PaymentsTable.PaymentId,  PaymentsTable.ClientName, PaymentsTable.Date, PaymentsTable.Phone, PaymentsTable.Amount, PaymentsTable.Currency from PaymentsTable";
            dataGridView1.DataSource = Con.GetData(Query);
        }

        private void TrainersLbl_Click(object sender, EventArgs e)
        {
            Trainers Obj = new Trainers();
            Obj.Show();
            this.Hide();
        }

        private void MemberLbl_Click(object sender, EventArgs e)
        {
            Members Obj = new Members();
            Obj.Show();
            this.Hide();
        }

        private void MemberShipLbl_Click(object sender, EventArgs e)
        {
            Memberships Obj = new Memberships();
            Obj.Show();
            this.Hide();
        }

        private void BillsLbl_Click(object sender, EventArgs e)
        {
            Bills Obj = new Bills();
            Obj.Show();
            this.Hide();
        }

        private void PaymentLbl_Click(object sender, EventArgs e)
        {
            Payments Obj = new Payments();
            Obj.Show();
            this.Hide();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void SearchTxtBox_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = SearchTxtBox.Text.Trim();
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = string.Format("ClientName LIKE '%{0}%'", searchTerm);
            dataGridView1.DataSource = bs;

            decimal SumD = 0;
            decimal SumLBP = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Replace "PaymentAmount" and "CurrencyType" with the actual column names in your DataGridView
                DataGridViewCell paymentCell = row.Cells["Amount"];
                DataGridViewCell currencyCell = row.Cells["Currency"];

                // Check if the cells are not null and contain valid values
                if (paymentCell.Value != null && currencyCell.Value != null)
                {
                    decimal Amount;
                    if (decimal.TryParse(paymentCell.Value.ToString(), out Amount))
                    {
                        string Currency = currencyCell.Value.ToString();

                        // Convert to dollars and Lebanese pounds based on exchange rates
                        if (Currency == "$")
                        {
                            SumD += Amount;
                        }
                        else if (Currency == "LBP")
                        {
                            SumLBP += Amount;
                        }
                    }
                }
            }

            // Display or use the calculated totals
            LblTotalDol.Text = SumD.ToString();
            LblTotalLBP.Text = SumLBP.ToString();
        }

        private void LoadDataAndCalculateTotals()
        {
            decimal SumD = 0;
            decimal SumLBP = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Replace "PaymentAmount" and "CurrencyType" with the actual column names in your DataGridView
                DataGridViewCell paymentCell = row.Cells["Amount"];
                DataGridViewCell currencyCell = row.Cells["Currency"];

                // Check if the cells are not null and contain valid values
                if (paymentCell.Value != null && currencyCell.Value != null)
                {
                    decimal Amount;
                    if (decimal.TryParse(paymentCell.Value.ToString(), out Amount))
                    {
                        string Currency = currencyCell.Value.ToString();

                        // Convert to dollars and Lebanese pounds based on exchange rates
                        if (Currency == "$")
                        {
                            SumD += Amount;
                        }
                        else if (Currency == "LBP")
                        {
                            SumLBP += Amount;
                        }
                    }
                }
            }

            // Display or use the calculated totals
            LblTotalDol.Text = SumD.ToString();
            LblTotalLBP.Text = SumLBP.ToString();
        }

        private void FilterDataByDateRange(DateTime startDate, DateTime endDate)
        {
            // Use LINQ to filter the data between the specified date range
            var filteredData = originalDataTable.AsEnumerable()
                  .Where(row => row.Field<DateTime>("Date") >= startDate && row.Field<DateTime>("Date") <= endDate)
                  .CopyToDataTable();

            // Bind the filtered data to the GridView
            dataGridView1.DataSource = filteredData;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            //  DateTime startDate = StartDate.Value;
            //  DateTime endDate = EndDate.Value;
            //  // Assuming you have a BindingSource as the data source for your DataGridView
            //  //BindingSource bindingSource = (BindingSource)dataGridView1.DataSource;

            //  // Assuming the underlying data source of the BindingSource is a DataTable
            //  DataTable originalDataTable = (DataTable)dataGridView1.DataSource;

            //  // Create a new DataTable to store the filtered data
            //  DataTable filteredDataTable = originalDataTable.Clone();

            //  // Iterate through the original DataTable and add rows to the filtered DataTable if the date is within the specified range
            //  foreach (DataRow row in originalDataTable.Rows)
            //  {
            //      DateTime rowDate = Convert.ToDateTime(row["Date"]); // Replace "DateColumn" with the actual column name in your table

            //      if (rowDate >= startDate && rowDate <= endDate)
            //      {
            //          filteredDataTable.ImportRow(row);
            //      }
            //  }
            //  // Set the filtered DataTable as the new data source for your BindingSource
            //  dataGridView1.DataSource = filteredDataTable;
            ////  dataGridView1.DataSource = bindingSource;

            //  // Refresh the DataGridView to reflect the changes
            ////  dataGridView1.Refresh();
            ///

            // Get the start and end dates from your UI controls
            DateTime startDate = StartDate.Value;
            DateTime endDate = EndDate.Value;

            // Call the filtering method
            FilterDataByDateRange(startDate, endDate);
        }

        private void Print_Click(object sender, EventArgs e)
        {
            // Open the SecondForm and pass a reference to the DataGridView
            Report_Payments reportpay = new Report_Payments(dataGridView1);
            reportpay.Text = LblTotalDol.Text;
            reportpay.Text = LblTotalLBP.Text;
            reportpay.Show();
          
        }
    }
}
