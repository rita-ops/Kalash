using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using static Kalash.Login;
using System.Text;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;

namespace Kalash
{
    public partial class AddExpense : BaseForm
    {
        Functions con;
        private readonly GridExpenses _allExpensesForm;

        public AddExpense(GridExpenses allExpensesForm)
        {
            InitializeComponent();
            con = new Functions();
            _allExpensesForm = allExpensesForm;
            editbtn.Visible = false;

            // Add KeyPress event for cost TextBox
            cost.KeyPress += cost_KeyPress;

        }

        public void LoadExpenseDetails(int expenseId, string desc, DateTime date, decimal money, string curr, string remark)
        {
            description.Text = desc;
            this.date.Value = date;
            cost.Text = money.ToString();
            currency.SelectedItem = curr;
            remarks.Text = remark;

            // Set a flag indicating editing mode
            this.Tag = expenseId; // Store the income ID in the Tag property
            addbtn.Visible = false;
            editbtn.Visible = true;
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check for required fields
                if (description.Text == "" || cost.Text == "" || currency.SelectedIndex == -1)
                {
                    MessageBox.Show("Fill all required fields");
                    return;
                }

                // Parse date
                if (DateTime.TryParse(date.Text, out DateTime expensedate))
                {
                    if (expensedate > DateTime.Now)
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
                    string desc = description.Text;
                    string curr = currency.SelectedItem.ToString();
                    string remark = remarks.Text;

                    // Prepare and execute SQL query
                    string Query = "INSERT INTO expensestable (description, date, cost, currency, remarks) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')";
                    Query = string.Format(Query, desc, expensedate.ToString("yyyy-MM-dd"), money, curr, remark);
                    con.setData(Query);

                    MessageBox.Show("Expense added");

                    // Redirect to allexpenses form
                    GridExpenses allExpensesForm = new GridExpenses();
                    this.Hide();
                    allExpensesForm.Show();

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
                if (description.Text == "" || cost.Text == "" || currency.SelectedIndex == -1)
                {
                    MessageBox.Show("Fill all required fields");
                    return;
                }

                // Parse date
                if (DateTime.TryParse(date.Text, out DateTime expensedate))
                {
                    if (expensedate > DateTime.Now)
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
                    string desc = description.Text;
                    string curr = currency.SelectedItem.ToString();
                    string remark = remarks.Text;

                    // Prepare and execute SQL query

                    int expenseId = (int)this.Tag;
                    string Query = @"UPDATE expensestable 
                      SET description = '{0}', date = '{1}', cost = '{2}', currency = '{3}', remarks = '{4}' 
                      WHERE expense_id = {5}";
                    Query = string.Format(Query, desc, expensedate.ToString("yyyy-MM-dd"), money, curr, remark, expenseId);
                    con.setData(Query);
                    MessageBox.Show("Expense updated");

                    // Redirect to allexpenses form
                    GridExpenses allExpensesForm = new GridExpenses();
                    this.Hide();
                    allExpensesForm.Show();

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
