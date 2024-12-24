using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Kalash.Login;

namespace Kalash
{
    public partial class AddIncome : BaseForm
    {

        Functions con;
        private GridIncomes _allIncomesForm;

        public AddIncome(GridIncomes allIncomesForm)
        {
            InitializeComponent();
            con = new Functions();
            _allIncomesForm = allIncomesForm;
            GetMembers();
            GetMemberships();
            editbtn.Visible = false;

            // Add KeyPress event for cost TextBox
            cost.KeyPress += cost_KeyPress;

        }


        private void GetMembers()
        {
            string Query = "SELECT member_id, CONCAT(firstname, ' ', lastname) AS Member FROM memberstable";
            DataTable dt = con.GetData(Query);

            // Create a new row with the default text
            DataRow newRow = dt.NewRow();
            newRow["member_id"] = 0; // Set an ID for the default option
            newRow["Member"] = "Select a member"; // This should match the column name used in the query
            dt.Rows.InsertAt(newRow, 0); // Insert at the top of the DataTable

            // Bind the DataTable to the dropdown
            membername.DisplayMember = "Member"; // This should match the column name used in the query
            membername.ValueMember = "member_id"; // This should match the column name used in the query
            membername.DataSource = dt;
        }


        private void GetMemberships()
        {
            string Query = "SELECT membership_id, description FROM membershiptable";
            DataTable dt = con.GetData(Query);

            // Create a new row with the default text
            DataRow newRow = dt.NewRow();
            newRow["membership_id"] = 0; // Set an ID for the default option
            newRow["description"] = "Select a membership"; // This should match the column name used in the query
            dt.Rows.InsertAt(newRow, 0); // Insert at the top of the DataTable

            // Bind the DataTable to the dropdown
            description.DisplayMember = "description"; // This should match the column name used in the query
            description.ValueMember = "membership_id"; // This should match the column name used in the query
            description.DataSource = dt;
        }


        public void LoadIncomeDetails(int incomeId, int memberId, string desc, DateTime date, decimal money, string curr)
        {
            membername.SelectedValue = memberId;
            description.Text = desc;
            this.date.Value = date;
            cost.Text = money.ToString();
            currency.SelectedItem = curr;


            // Set a flag indicating editing mode
            this.Tag = incomeId; // Store the income ID in the Tag property
            addbtn.Visible = false;
            editbtn.Visible = true;
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check for required fields
                if (membername.SelectedIndex == -1 || membername.SelectedValue.ToString() == "0" || description.Text == "" || cost.Text == "" || currency.SelectedIndex == -1)
                {
                    MessageBox.Show("Fill all required fields");
                    return;
                }

                // Parse date
                if (DateTime.TryParse(date.Text, out DateTime incomedate))
                {
                    if (incomedate > DateTime.Now)
                    {
                        MessageBox.Show("Please enter a date less than or equal to the current date.");
                        return;
                    }

                    if (!decimal.TryParse(cost.Text, out decimal money) || money < 0)
                    {
                        MessageBox.Show("Invalid cost value. It must be a positive number.");
                        return;
                    }

                    // Get values
                    int memberId = Convert.ToInt32(membername.SelectedValue);
                    string desc = description.Text;
                    string curr = currency.SelectedItem.ToString();
                    string remark = remarks.Text;

                    // Prepare and execute SQL query
                    string Query = "INSERT INTO incomestable (member_id, description, date, cost, currency, remarks) VALUES ({0}, '{1}', '{2}', '{3}', '{4}','{5}')";
                    Query = string.Format(Query, memberId, desc, incomedate.ToString("yyyy-MM-dd"), money, curr, remark);
                    con.setData(Query);

                    MessageBox.Show("Income added");

                    // Redirect to allincomes form
                    GridIncomes allincomesForm = new GridIncomes();
                    this.Hide();
                    allincomesForm.Show();
                 
                }
                else
                {
                    MessageBox.Show("Invalid date.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check for required fields
                if (membername.SelectedIndex == -1 || membername.SelectedValue.ToString() == "0" || description.Text == "" || cost.Text == "" || currency.SelectedIndex == -1)
                {
                    MessageBox.Show("Fill all required fields");
                    return;
                }

                // Parse date
                if (DateTime.TryParse(date.Text, out DateTime incomedate))
                {
                    if (incomedate > DateTime.Now)
                    {
                        MessageBox.Show("Please enter a date less than or equal to the current date.");
                        return;
                    }

                    if (!decimal.TryParse(cost.Text, out decimal money) || money < 0)
                    {
                        MessageBox.Show("Invalid cost value. It must be a positive number.");
                        return;
                    }

                    // Get values
                    int memberId = Convert.ToInt32(membername.SelectedValue);
                    string desc = description.Text;
                    string curr = currency.SelectedItem.ToString();
                    string remark = remarks.Text;

                    int incomeId = (int)this.Tag;
                    string Query = @"UPDATE incomestable 
                      SET member_id = {0}, description = '{1}', date = '{2}', cost = '{3}', currency = '{4}', remarks = '{5}' 
                      WHERE income_id = {6}";
                    Query = string.Format(Query, memberId, desc, incomedate.ToString("yyyy-MM-dd"), money, curr, remark, incomeId);
                    con.setData(Query);
                    MessageBox.Show("Income updated");

                    // Redirect to allincomes form
                    GridIncomes allincomesForm = new GridIncomes();
                    this.Hide();
                    allincomesForm.Show();
                   
                }
                else
                {
                    MessageBox.Show("Invalid date.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, one decimal point, and backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Block invalid input
            }

            // Ensure only one decimal point is allowed
            if (e.KeyChar == '.' && (sender as System.Windows.Forms.TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}
