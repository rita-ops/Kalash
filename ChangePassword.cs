using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static Kalash.Login;

namespace Kalash
{
    public partial class ChangePassword : Form
    {
        Functions con;

        // Define a default password constant for first-time login comparison
        private const string DefaultPassword = "P@ssw0rd"; // Set this to your actual default password
        private bool isFirstLogin; // To store whether the user is logging in for the first time


        public ChangePassword(bool isFirstLogin = false)
        {
            InitializeComponent();
            InitializeUsernameLabel();
            con = new Functions();

            currentpassword.PasswordChar = '*'; // Hide the password
            newpassword.PasswordChar = '*';
            confirmpassword.PasswordChar = '*';

            this.isFirstLogin = isFirstLogin;

            // Hide the cancel button if it's the first login
            cancelbtn.Visible = !isFirstLogin;
        }

        private void showpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (showpassword.Checked)
            {
                currentpassword.PasswordChar = '\0';
                newpassword.PasswordChar = '\0';
                confirmpassword.PasswordChar = '\0';
            }
            else
            {
                currentpassword.PasswordChar = '*';
                newpassword.PasswordChar = '*';
                confirmpassword.PasswordChar = '*';
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private bool VerifyCurrentPassword(string currentPassword)
        {
            string hashedCurrentPassword = HashPassword(currentPassword);
            string query = $"SELECT * FROM userstable WHERE id_user = {UserSession.UserId}";
            DataTable dt = con.GetData(query);

            if (dt.Rows.Count == 0) return false;

            string storedHashedPassword = dt.Rows[0]["password"].ToString();

            return hashedCurrentPassword == storedHashedPassword || currentPassword == DefaultPassword;
        }

        private void changepasswordbtn_Click(object sender, EventArgs e)
        {

            try
            {
                // Check if required fields are filled
                if (string.IsNullOrWhiteSpace(currentpassword.Text) ||
                    string.IsNullOrWhiteSpace(newpassword.Text) ||
                    string.IsNullOrWhiteSpace(confirmpassword.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                // Verify the current password
                if (!VerifyCurrentPassword(currentpassword.Text))
                {
                    MessageBox.Show("Current password is incorrect.");
                    return;
                }

                // Check if new password is the default password
                if (newpassword.Text == DefaultPassword)
                {
                    MessageBox.Show("New password should not be the default password");
                    return;
                }

                // Check if new password is the same as the current password
                if (newpassword.Text == currentpassword.Text)
                {
                    MessageBox.Show("New password should not be the same as the current password");
                    return;
                }

                // Validate the new password using ValidationHelper
                if (!ValidationHelper.IsValidPassword(newpassword.Text))
                {
                    return; // If password doesn't meet the criteria, stop the process
                }

                // Check if new password and confirmation match
                if (newpassword.Text != confirmpassword.Text)
                {
                    MessageBox.Show("New password and confirmation do not match.");
                    return;
                }

                // Hash the new password
                string hashedNewPassword = HashPassword(newpassword.Text);

                // Update the password in the database
                string updateQuery = $"UPDATE userstable SET password = '{hashedNewPassword}' WHERE id_user = {UserSession.UserId}";
                int rowsAffected = con.setData(updateQuery);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Password changed successfully.");
                    Login loginform = new Login();
                    loginform.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Error updating password. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void canceldbtn_Click(object sender, EventArgs e)
        {
            GridMembers memberforms = new GridMembers();
            this.Hide();
            memberforms.Show();

        }

        private void InitializeUsernameLabel()
        {
            // If lblusername is not already initialized, create and add it to the form
            if (lblusername == null)
            {
                Label lblusername = new Label();
                lblusername.Location = new Point(10, 10);  // Adjust the position as necessary
                lblusername.Size = new Size(200, 30);      // Adjust the size as necessary
                lblusername.Text = UserSession.Username;  // Set the username text
                this.Controls.Add(lblusername);  // Add label to the form
            }
            else
            {
                lblusername.Text = UserSession.Username;  // Update the label text
            }
        }
    }
}
