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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kalash
{
    public partial class Login : Form
    {
        Functions con;

        public Login()
        {
            InitializeComponent();
            con = new Functions();
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

        public static class UserSession
        {
            public static int UserId { get; set; }
            public static string Username { get; set; }
            public static bool IsAdmin { get; set; }
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Check if the Enter key is pressed
            {
                loginbtn_Click(sender, e); // Call the login button click event
            }
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(username.Text) || string.IsNullOrWhiteSpace(password.Text))
                {
                    MessageBox.Show("Please enter both username and password.");
                    return;
                }

                string enteredUsername = username.Text.Trim();
                string enteredPassword = password.Text.Trim();
                string hashedPassword = HashPassword(enteredPassword);

                // Define the default password
                string DefaultPassword = "P@ssw0rd"; // Update this to match the actual default password

                // Query to retrieve the user details
                string query = $"SELECT * FROM userstable WHERE username = '{enteredUsername}'";
                DataTable dt = con.GetData(query);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid username or password.");
                    return;
                }

                // Get stored password and check admin status
                string storedHashedPassword = dt.Rows[0]["password"].ToString();
                string user = dt.Rows[0]["username"].ToString();
                bool isAdmin = Convert.ToBoolean(dt.Rows[0]["isadmin"]);
                int userId = Convert.ToInt32(dt.Rows[0]["id_user"]);

                // Check if entered password matches stored password
                if (hashedPassword == storedHashedPassword)
                {
                    // Store user details in UserSession
                    UserSession.UserId = userId;
                    UserSession.IsAdmin = isAdmin;
                    UserSession.Username = user;

                    // Check if this is the first login by comparing hashed password to default password hash
                    bool isFirstLogin = storedHashedPassword == HashPassword(DefaultPassword);

                    if (isFirstLogin)
                    {
                        // Redirect user to Change Password form
                        ChangePassword changePasswordForm = new ChangePassword(true);
                        changePasswordForm.Show(); 
                        this.Hide(); // Hide login form
                    }
                    // After successful login and if first login, show ChangePassword form

                    else
                    {
                        // Proceed to main application with BaseForm (to show lblusername)
                        GridMembers memberforms = new GridMembers();  // Use the same BaseForm instance
                        memberforms.Show();
                        this.Hide(); // Hide login form after successful login
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
