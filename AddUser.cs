using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalash
{
    public partial class AddUser : BaseForm
    {
        Functions con;
        private GridUsers _allUUsersForm;
        public AddUser(GridUsers allUUsersForm)
        {
            InitializeComponent();
            con = new Functions();
            editbtn.Visible = false;
            _allUUsersForm = allUUsersForm;

            // Hide the password by default
            password.PasswordChar = '*';
        }

        // Hashing method
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public void LoadUserDetails(int userId, string username, string pass, string email, string phone, bool isadmin)
        {
            this.username.Text = username;

            // Check if email is null or empty before assigning
            this.email.Text = string.IsNullOrEmpty(email) ? string.Empty : email;

            this.phonenumber.Text = phone;
            this.isadmin.Checked = isadmin;

            // Set a flag indicating editing mode
            this.Tag = userId; // Store the user ID in the Tag property
            addbtn.Visible = false;
            editbtn.Visible = true;

            // Clear the password field for security reasons
            this.password.Text = string.Empty;
        }

        //Reset function to empty fields
        private void Reset()
        {
            username.Text = string.Empty;
            password.Text = string.Empty;
            email.Text = string.Empty;
            phonenumber.Text = string.Empty;
            isadmin.Checked = false;
        }

        private bool IsUsernameExists(string username)
        {
            string query = string.Format("SELECT COUNT(*) FROM userstable WHERE username = '{0}'", username);
            DataTable dt = con.GetData(query); // Assuming `getData` method returns a DataTable
            int count = Convert.ToInt32(dt.Rows[0][0]);
            return count > 0;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email && email.Count(c => c == '@') == 1;
            }
            catch
            {
                return false;
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if required fields are filled
                if (username.Text == "" || password.Text == "" || phonenumber.Text == "")
                {
                    MessageBox.Show("Fill required fields");
                    return;
                }


                // Validate username for special characters
                if (!ValidationHelper.IsValidUsername(username.Text))
                {
                    return; // Stop if username validation fails
                }

                // Validate password for special characters
                if (!ValidationHelper.IsValidInput(password.Text))
                {
                    return; // Stop if password validation fails
                }

                // Check if the username already exists
                if (IsUsernameExists(username.Text))
                {
                    MessageBox.Show("Username already exists. Please choose another one.");
                    return; // Stop the execution if username is already taken
                }


                // Hash the password
                string user = username.Text.Trim();
                string pass = HashPassword(password.Text).Trim(); // Hash the password
                string mail = email.Text.Trim();

                // If email is provided, validate it
                if (!string.IsNullOrEmpty(mail) && !IsValidEmail(mail))
                {
                    MessageBox.Show("The email address is not valid. Please correct it.");
                    return;
                }

                string number = phonenumber.Text.Trim();
                bool admin = isadmin.Checked;

                // Insert query
                string Query = "Insert into userstable (username, password, email, phonenumber, isadmin) values('{0}','{1}','{2}','{3}','{4}')";
                Query = string.Format(Query, user, pass, mail, number, admin ? 1 : 0);
                con.setData(Query);
                MessageBox.Show("User added");
                Reset();

                // Redirect to allusers form
                GridUsers allusersForm = new GridUsers();
                this.Hide();
                allusersForm.Show();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private string GetExistingPassword(int userId)
        {
            string query = $"SELECT password FROM userstable WHERE id_user = {userId}";
            DataTable dt = con.GetData(query);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["password"].ToString();
            }
            return string.Empty; // Or handle this case as needed
        }


        private void editbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if required fields are filled
                if (username.Text == "" || phonenumber.Text == "")
                {
                    MessageBox.Show("Fill required fields");
                    return;
                }

                // Validate username and password
                if (!ValidationHelper.IsValidUsername(username.Text))
                {
                    return; // Stop if username validation fails
                }

                if (!ValidationHelper.IsValidInput(password.Text))
                {
                    return; // Stop if password validation fails
                }

                int userId = (int)this.Tag;

                // Check if the username already exists, excluding the current user
                string query = string.Format("SELECT COUNT(*) FROM userstable WHERE username = '{0}' AND id_user != {1}", username.Text, userId);
                DataTable dt = con.GetData(query);
                int count = Convert.ToInt32(dt.Rows[0][0]);
                if (count > 0)
                {
                    MessageBox.Show("Username already exists. Please choose another one.");
                    return; // Stop the execution if username is already taken
                }

                // Hash the password only if it's provided
                string pass = string.IsNullOrEmpty(password.Text) ? GetExistingPassword(userId) : HashPassword(password.Text).Trim(); // Hash the password if provided
                string user = username.Text.Trim();
                string mail = email.Text.Trim();
                string number = phonenumber.Text.Trim();
                bool admin = isadmin.Checked;

                string Query = @"UPDATE userstable 
              SET username = '{0}', password = '{1}', email = '{2}' , phonenumber = '{3}' , isadmin = '{4}' 
              WHERE id_user = {5}";

                Query = string.Format(Query, user, pass, mail, number, admin ? 1 : 0, userId);
                con.setData(Query);
                MessageBox.Show("User updated");
                Reset();

                // Redirect to allusers form
                GridUsers allusersForm = new GridUsers();
                this.Hide();
                allusersForm.Show();
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (showpassword.Checked)
            {
                password.PasswordChar = '\0'; // Show the password by setting PasswordChar to null character
            }
            else
            {
                password.PasswordChar = '*'; // Hide the password by setting PasswordChar to asterisk
            }
        }

    }
}
