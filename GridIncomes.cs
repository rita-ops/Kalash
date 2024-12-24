using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Kalash
{
    public partial class GridIncomes : BaseForm
    {
        Functions con;
        public GridIncomes()
        {
            InitializeComponent();
            con = new Functions();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            GetIncomes();

            // Set column properties
            dataGridViewIncomes.Columns[0].Visible = false;
            dataGridViewIncomes.Columns[1].Visible = false;
            dataGridViewIncomes.Columns[3].HeaderText = "Description";
            dataGridViewIncomes.Columns[4].HeaderText = "Date";
            dataGridViewIncomes.Columns[5].HeaderText = "Cost";
            dataGridViewIncomes.Columns[6].HeaderText = "Currency";
            dataGridViewIncomes.Columns[7].HeaderText = "Remarks";
            dataGridViewIncomes.Columns["Cost"].DefaultCellStyle.Format = "N2";

            // Enable column sorting
            foreach (DataGridViewColumn column in dataGridViewIncomes.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            // Attach event handlers
            dataGridViewIncomes.SelectionChanged += dataGridViewIncomes_SelectionChanged;
        }

        private void GetIncomes()
        {
            string Query = "SELECT i.income_id, i.member_id, CONCAT ( m.firstname, ' ', m.lastname) As Member,  i.description,  i.[date], i.cost,  i.currency,i.remarks FROM  incomestable i JOIN  memberstable m ON i.member_id = m.member_id";
            dataGridViewIncomes.DataSource = con.GetData(Query);
            dataGridViewIncomes.ClearSelection();
        }
        private void GridIncomes_Load(object sender, EventArgs e)
        {

            // Check if the click is outside the DataGridView
            if (!dataGridViewIncomes.Bounds.Contains(PointToClient(Cursor.Position)))
            {
                editbtn.Visible = false;
                deletebtn.Visible = false;
                this.Tag = null; // Clear the selected trainer ID
            }

            // Access the DataGridView from Form1
            if (dataGridViewIncomes != null)
            {
                // Do something with the received DataGridView
                dataGridViewIncomes.DataSource = dataGridViewIncomes.DataSource;
                dataGridViewIncomes.Columns["cost"].DefaultCellStyle.Format = "N2";
            }

            // Access and manipulate the DataGridView as needed
            if (dataGridViewIncomes != null)
            {
                // Hide specific columns
                dataGridViewIncomes.Columns["income_id"].Visible = false;
            }

            decimal SumUSD = 0;
            decimal SumLBP = 0;

            foreach (DataGridViewRow row in dataGridViewIncomes.Rows)
            {
                // Assuming your amount column is at index 1 and currency column is at index 2
                decimal amount = Convert.ToDecimal(row.Cells["cost"].Value);

                // You can use the currency information if needed
                string currency = Convert.ToString(row.Cells["currency"].Value);


                // Convert to dollars and Lebanese pounds based on exchange rates
                if (currency == "USD")
                {
                    SumUSD += amount;
                }
                else if (currency == "LBP")
                {
                    SumLBP += amount;
                }

            }

            // Display or use the calculated totals
            TxtBoxUSD.Text = SumUSD.ToString("#,##0");
            TxtBoxLBP.Text = SumLBP.ToString("#,##0");
        }

        private void dataGridViewIncomes_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewIncomes.SelectedRows.Count > 0)
            {
                editbtn.Visible = true;
                deletebtn.Visible = true;
                this.Tag = dataGridViewIncomes.SelectedRows[0].Cells[0].Value;
            }
            else
            {
                editbtn.Visible = false;
                deletebtn.Visible = false;
            }
        }

        private DataTable GetSortedDataFromGrid()
        {
            if (dataGridViewIncomes.DataSource is DataTable dataTable)
            {
                // Create a clone of the DataTable structure
                var sortedTable = dataTable.Clone();

                // Iterate through the DataGridView rows in their current visual order
                foreach (DataGridViewRow row in dataGridViewIncomes.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var newRow = sortedTable.NewRow();

                        // Copy all cell values into the new row
                        foreach (DataGridViewColumn column in dataGridViewIncomes.Columns)
                        {
                            newRow[column.Name] = row.Cells[column.Name].Value;
                        }

                        sortedTable.Rows.Add(newRow);
                    }
                }

                return sortedTable;
            }

            return null;
        }
    

        private void printbtn_Click(object sender, EventArgs e)
        {
            DataTable sortedData = GetSortedDataFromGrid();
            if (sortedData == null || sortedData.Rows.Count == 0)
            {
                MessageBox.Show("No data available to print.", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FormReportIncome Obj;
            decimal sumUSD = 0;
            decimal sumLBP = 0;

            if (SearchTxtBox.Text.Length == 0 && checkBox1.Checked == false)
            {
                foreach (DataRow row in sortedData.Rows)
                {
                    decimal amount = Convert.ToDecimal(row["Cost"]);
                    string currency = Convert.ToString(row["Currency"]);

                    if (currency == "USD") sumUSD += amount;
                    else if (currency == "LBP") sumLBP += amount;
                }


                // Pass sorted data and sums to the report
                this.Hide();
                Obj = new FormReportIncome(sortedData, sumUSD, sumLBP);
            }
            else
            {
                string member = SearchTxtBox.Text.Trim().Length == 0 ? null : SearchTxtBox.Text;
                DateTime fromDate = checkBox1.Checked ? StartDate.Value.Date : DateTime.MinValue;
                DateTime toDate = checkBox1.Checked ? EndDate.Value.Date : DateTime.MaxValue;

                foreach (DataGridViewRow row in dataGridViewIncomes.Rows)
                {
                    decimal amount = Convert.ToDecimal(row.Cells["Cost"].Value);
                    string currency = Convert.ToString(row.Cells["Currency"].Value);

                    if (currency == "USD")
                    {
                        sumUSD += amount;
                    }
                    else if (currency == "LBP")
                    {
                        sumLBP += amount;
                    }
                }

                // Pass filtered data and sums to the report
                Obj = new FormReportIncome(sortedData,member, fromDate, toDate, sumUSD, sumLBP);
            }

            this.Hide();
            Obj.Show();
        }


        private void clearbtn_Click(object sender, EventArgs e)
        {
            // Clear search parameters
            SearchTxtBox.Text = string.Empty;
            StartDate.Value = DateTime.Now.Date;
            EndDate.Value = DateTime.Now.Date;
            checkBox1.Checked = false;

            // Reset the filter by setting an empty filter string
            ((DataTable)dataGridViewIncomes.DataSource).DefaultView.RowFilter = string.Empty;

            // Update the DataGridView to reflect the changes
            dataGridViewIncomes.DataSource = dataGridViewIncomes.DataSource;

            // Recalculate and display the sum
            CalculateAndDisplaySum();
        }

        private void CalculateAndDisplaySum()
        {
            decimal sumUSD = 0;
            decimal sumLBP = 0;

            foreach (DataGridViewRow row in dataGridViewIncomes.Rows)
            {
                decimal amount = Convert.ToDecimal(row.Cells["cost"].Value);
                string currency = Convert.ToString(row.Cells["currency"].Value);

                if (currency == "USD")
                {
                    sumUSD += amount;
                }
                else if (currency == "LBP")
                {
                    sumLBP += amount;
                }
            }

            // Display or use the calculated totals
            TxtBoxUSD.Text = sumUSD.ToString("#,##0");
            TxtBoxLBP.Text = sumLBP.ToString("#,##0");
        }


        private void searchbtn_Click(object sender, EventArgs e)
        {
            // Get search parameters
            string memberName = SearchTxtBox.Text.Trim();
            DateTime startDate = StartDate.Value;
            DateTime endDate = EndDate.Value;

            // Assuming your DataGridView has a DataTable as its DataSource
            DataTable dataTable = ((DataTable)dataGridViewIncomes.DataSource);

            // Check if both the search text box is empty and the checkbox is not checked
            if (string.IsNullOrEmpty(memberName) && !checkBox1.Checked)
            {
                MessageBox.Show("Please enter a search term or select a date range.", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the search function
            }

            // Construct the filter based on member name and date range
            string filter = "";

            if (!string.IsNullOrEmpty(memberName))
            {
                filter += $"Member LIKE '%{memberName}%'";
            }

            if (checkBox1.Checked)
            {
                if (!string.IsNullOrEmpty(filter))
                {
                    filter += " AND ";
                }

                filter += $"Date >= #{startDate.ToString("MM/dd/yyyy")}# AND Date <= #{endDate.ToString("MM/dd/yyyy")}#";
            }

            // Apply the filter to the DataTable
            dataTable.DefaultView.RowFilter = filter;

            // Update the DataGridView to reflect the changes
            dataGridViewIncomes.DataSource = dataTable;

            // Calculate the sum of amounts for USD and LBP
            decimal sumUSD = 0;
            decimal sumLBP = 0;

            foreach (DataRowView rowView in dataTable.DefaultView)
            {
                DataRow row = rowView.Row;

                decimal amount = Convert.ToDecimal(row["cost"]);
                string currency = Convert.ToString(row["currency"]);

                if (currency == "USD")
                {
                    sumUSD += amount;
                }
                else if (currency == "LBP")
                {
                    sumLBP += amount;
                }
            }

            // Display the sums in the appropriate TextBoxes or labels
            TxtBoxUSD.Text = sumUSD.ToString("#,##0");
            TxtBoxLBP.Text = sumLBP.ToString("#,##0");
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            AddIncome addincome = new AddIncome(null);
            this.Hide();
            addincome.ShowDialog();
         
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                int incomeId = (int)this.Tag;
                string query = "SELECT income_id, member_id, description, date, cost, currency, remarks FROM incomestable WHERE income_id = " + incomeId;
                DataTable incomeData = con.GetData(query);

                if (incomeData.Rows.Count > 0)
                {
                    DataRow row = incomeData.Rows[0];
                    int member = Convert.ToInt32(row["member_id"]);
                    string desc = row["description"].ToString();
                    DateTime date = Convert.ToDateTime(row["date"]);
                    decimal money = Convert.ToDecimal(row["cost"]);
                    dataGridViewIncomes.Columns["Cost"].DefaultCellStyle.Format = "N2";
                    string curr = row["currency"].ToString();

                    AddIncome incomesForm = new AddIncome(this);
                    incomesForm.LoadIncomeDetails(incomeId, member, desc, date, money, curr);
                    this.Hide(); // Hide the current allincomes form
                    incomesForm.Show();
                  
                }
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewIncomes.SelectedRows.Count > 0)
            {
                int incomeId = (int)dataGridViewIncomes.SelectedRows[0].Cells[0].Value;
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this income?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM incomestable WHERE income_id = " + incomeId;
                        con.setData(query);
                        dataGridViewIncomes.Rows.RemoveAt(dataGridViewIncomes.SelectedRows[0].Index);

                        // Recalculate the total sums after deletion
                        CalculateAndDisplaySum();

                        MessageBox.Show("Income deleted successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while deleting the income: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an income to delete.");
            }
        }

        //private DateTime disabledDatePickerValue;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            StartDate.Enabled = checkBox1.Checked;
            EndDate.Enabled = checkBox1.Checked;

            if (checkBox1.Checked)
            {
                // If the checkbox is checked, the date range is enabled, but you don’t need to reload data here.
                DateTime startDate = StartDate.Value.Date;
                DateTime endDate = EndDate.Value.Date;
            }
            else
            {
                // When the checkbox is unchecked, reset the date
                ResetFilters();
            }
        }

        private void ResetFilters()
        {
            StartDate.Value = DateTime.Now;
            EndDate.Value = DateTime.Now;
        }

        private void GridIncomes_Click(object sender, EventArgs e)
        {
            editbtn.Visible = false;
            deletebtn.Visible = false;
        }
    }
}
