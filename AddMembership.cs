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
    public partial class AddMembership : BaseForm
    {
        Functions con;

        public AddMembership()
        {
            InitializeComponent();
            con = new Functions();
            editbtn.Visible = false;
            // Add KeyPress event for cost TextBox
            cost.KeyPress += cost_KeyPress;

        }

        //Reset function to empty fields
        private void Reset()
        {
            description.Text = string.Empty;
            cost.Text = string.Empty;
            currency.SelectedIndex = 0;
        }

        //Capitalize description
        private string Capitalize(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }

        public void LoadMembershipDetails(int membershipId, string descr, decimal money, string curr)
        {
            description.Text = descr;
            cost.Text = money.ToString();
            currency.SelectedItem = curr;

            // Set a flag indicating editing mode
            Tag = membershipId; // Store the member ID in the Tag property
            addbtn.Visible = false;
            editbtn.Visible = true;
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (description.Text == "" || cost.Text == "" || currency.SelectedIndex == -1)
                {
                    MessageBox.Show("Fill required fields");
                    return;
                }
                else
                {
                    string desc = Capitalize(description.Text.Trim());
                    if (!decimal.TryParse(cost.Text, out decimal money) || money < 0)
                    {
                        MessageBox.Show("Invalid cost value. It must be a positive number.");
                        return;
                    }

                    string curr = currency.SelectedItem.ToString();
                    int membershipId = (int)this.Tag;

                    string Query = @"UPDATE membershiptable 
                              SET description = '{0}', cost = '{1}', currency = '{2}' 
                              WHERE membership_id = {3}";
                    Query = string.Format(Query, desc, money, curr, membershipId);
                    con.setData(Query);
                    MessageBox.Show("Membership updated");
                    Reset();

                    // Redirect to allmemberships form
                    GridMemberships allmembershipForm = new GridMemberships();
                    this.Hide();
                    allmembershipForm.Show();


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (description.Text == "" || cost.Text == "" || currency.SelectedIndex == -1)
                {
                    MessageBox.Show("Fill required fields");
                    return;
                }
                else
                {
                    string desc = Capitalize(description.Text.Trim());
                    if (!decimal.TryParse(cost.Text, out decimal money) || money < 0)
                    {
                        MessageBox.Show("Invalid cost value. It must be a positive number.");
                        return;
                    }

                    string curr = currency.SelectedItem.ToString();
                    string Query = "INSERT INTO membershiptable (description, cost, currency) VALUES ('{0}', {1}, '{2}')";
                    Query = string.Format(Query, desc, money, curr);
                    con.setData(Query);
                    MessageBox.Show("Membership added");
                    Reset();

                    // Redirect to allmemberships form
                    GridMemberships allmembershipForm = new GridMemberships();
                    this.Hide();
                    allmembershipForm.Show();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
