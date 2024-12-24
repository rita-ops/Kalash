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
    public partial class GridExpenses : BaseForm
    {
        Functions con;

        public GridExpenses()
        {
            InitializeComponent();
            con = new Functions();
            InitizeGrid();
            
        }

        private void InitizeGrid()
        {
            GetExpenses();
            dataGridViewExpenses.Columns[0].Visible = false;
            dataGridViewExpenses.Columns[1].HeaderText = "Description";
            dataGridViewExpenses.Columns[2].HeaderText = "Date";
            dataGridViewExpenses.Columns[3].HeaderText = "Cost";
            dataGridViewExpenses.Columns[4].HeaderText = "Currency";
            dataGridViewExpenses.Columns[5].HeaderText = "Remarks";
            dataGridViewExpenses.Columns["Cost"].DefaultCellStyle.Format = "N2";

            // Enable column sorting
            foreach (DataGridViewColumn column in dataGridViewExpenses.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            // Attach the event handler
            //this.Click += new EventHandler(GridExpenses_Load);
            dataGridViewExpenses.SelectionChanged += new EventHandler(dataGridViewExpenses_SelectionChanged);
        }
     
        private void GetExpenses()
        {
            string Query = "SELECT * FROM  expensestable";
            dataGridViewExpenses.DataSource = con.GetData(Query);
            dataGridViewExpenses.ClearSelection();
        }

        private void GridExpenses_Load(object sender, EventArgs e)
        {
            // Check if the click is outside the DataGridView
            if (!dataGridViewExpenses.Bounds.Contains(PointToClient(Cursor.Position)))
            {
                editbtn.Visible = false;
                deletebtn.Visible = false;
                this.Tag = null; // Clear the selected trainer ID
            }

            // Access the DataGridView from Form1
            if (dataGridViewExpenses != null)
            {
                // Do something with the received DataGridView
                dataGridViewExpenses.DataSource = dataGridViewExpenses.DataSource;
                dataGridViewExpenses.Columns["cost"].DefaultCellStyle.Format = "N2";
            }

            // Access and manipulate the DataGridView as needed
            if (dataGridViewExpenses != null)
            {
                // Hide specific columns
                dataGridViewExpenses.Columns["expense_id"].Visible = false;
            }

            decimal SumUSD = 0;
            decimal SumLBP = 0;

            foreach (DataGridViewRow row in dataGridViewExpenses.Rows)
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

        private void dataGridViewExpenses_SelectionChanged(object sender, EventArgs e)
        {
            // Show the Edit button when a row is selected
            if (dataGridViewExpenses.SelectedRows.Count > 0)
            {
                editbtn.Visible = true;
                deletebtn.Visible = true;

                // Store the selected income's ID in the Tag property
                this.Tag = dataGridViewExpenses.SelectedRows[0].Cells[0].Value;
            }
            else
            {
                editbtn.Visible = false;
                deletebtn.Visible = false;
            }
        }

        private DataTable GetSortedDataFromGrid()
        {
            if (dataGridViewExpenses.DataSource is DataTable dataTable)
            {
                // Create a clone of the DataTable structure
                var sortedTable = dataTable.Clone();

                // Iterate through the DataGridView rows in their current visual order
                foreach (DataGridViewRow row in dataGridViewExpenses.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var newRow = sortedTable.NewRow();

                        // Copy all cell values into the new row
                        foreach (DataGridViewColumn column in dataGridViewExpenses.Columns)
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

            FormReportExpense Obj;
            decimal sumUSD = 0;
            decimal sumLBP = 0;

            if (SearchTxtBox.Text.Length == 0 && checkBox1.Checked == false)
            {
                foreach (DataGridViewRow row in dataGridViewExpenses.Rows)
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

                this.Hide();
                Obj = new FormReportExpense(sortedData, sumUSD, sumLBP);
            }
            else
            {
                string desc = SearchTxtBox.Text.Trim().Length == 0 ? null : SearchTxtBox.Text;

                // Set fromDate to DateTime.MinValue if checkBox1 is not checked
                DateTime fromDate = checkBox1.Checked ? StartDate.Value.Date : DateTime.MinValue;

                // Set toDate to DateTime.MinValue if checkBox1 is not checked
                DateTime toDate = checkBox1.Checked ? EndDate.Value.Date : DateTime.MaxValue;

                // Calculate sums
                foreach (DataGridViewRow row in dataGridViewExpenses.Rows)
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
                Obj = new FormReportExpense(sortedData, desc, fromDate, toDate, sumUSD, sumLBP);
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
            ((DataTable)dataGridViewExpenses.DataSource).DefaultView.RowFilter = string.Empty;

            // Update the DataGridView to reflect the changes
            dataGridViewExpenses.DataSource = dataGridViewExpenses.DataSource;

            // Recalculate and display the sum
            CalculateAndDisplaySum();
        }

        private void CalculateAndDisplaySum()
        {
            decimal sumUSD = 0;
            decimal sumLBP = 0;

            foreach (DataGridViewRow row in dataGridViewExpenses.Rows)
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
            string desc = SearchTxtBox.Text.Trim();
            DateTime startDate = StartDate.Value;
            DateTime endDate = EndDate.Value;

            // Assuming your DataGridView has a DataTable as its DataSource
            DataTable dataTable = ((DataTable)dataGridViewExpenses.DataSource);

            // Check if both the search text box is empty and the checkbox is not checked
            if (string.IsNullOrEmpty(desc) && !checkBox1.Checked)
            {
                MessageBox.Show("Please enter a search term or select a date range.", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the search function
            }

            // Construct the filter based on member name and date range
            string filter = "";

            if (!string.IsNullOrEmpty(desc))
            {
                filter += $"Description LIKE '%{desc}%'";
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
            dataGridViewExpenses.DataSource = dataTable;

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
            AddExpense addexpense = new AddExpense(null);
            this.Hide();
            addexpense.Show();

        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                int expenseId = (int)this.Tag;
                string query = "SELECT expense_id, description, date, cost, currency, remarks FROM expensestable WHERE expense_id = " + expenseId;
                DataTable incomeData = con.GetData(query);

                if (incomeData.Rows.Count > 0)
                {
                    DataRow row = incomeData.Rows[0];
                    string desc = row["description"].ToString();
                    DateTime date = Convert.ToDateTime(row["date"]);
                    decimal money = Convert.ToDecimal(row["cost"]);
                    dataGridViewExpenses.Columns["Cost"].DefaultCellStyle.Format = "N2";
                    string curr = row["currency"].ToString();
                    string remark = row["remarks"].ToString();

                    AddExpense addexpense = new AddExpense(this);
                    addexpense.LoadExpenseDetails(expenseId, desc, date, money, curr, remark);
                    this.Hide(); // Hide the current allincomes form
                    addexpense.Show();
               
                }
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewExpenses.SelectedRows.Count > 0)
            {
                int expenseId = (int)dataGridViewExpenses.SelectedRows[0].Cells[0].Value;
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this expense?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM expensestable WHERE expense_id = " + expenseId;
                        con.setData(query);
                        dataGridViewExpenses.Rows.RemoveAt(dataGridViewExpenses.SelectedRows[0].Index);

                        // Recalculate the total sums after deletion
                        CalculateAndDisplaySum();

                        MessageBox.Show("Expense deleted successfully.");
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

        private void GridExpenses_Click(object sender, EventArgs e)
        {
            editbtn.Visible = false;
            deletebtn.Visible = false;
        }
    }
}
