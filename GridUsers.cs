using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
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
    public partial class GridUsers : BaseForm
    {

        Functions con;
        public GridUsers()
        {
            InitializeComponent();
            con = new Functions();
            GetUsers();
            dataGridViewUser.Columns[0].Visible = false;
            dataGridViewUser.Columns[1].HeaderText = "Username";
            dataGridViewUser.Columns[2].Visible = false;
            dataGridViewUser.Columns[3].HeaderText = "Email";
            dataGridViewUser.Columns[4].HeaderText = "Phone Number";
            dataGridViewUser.Columns[5].HeaderText = "Admin";

            // Attach the event handler
            this.Click += new EventHandler(GridUsers_Load);
            dataGridViewUser.SelectionChanged += new EventHandler(dataGridViewUser_SelectionChanged);
        }

        private void GetUsers()
        {
            string Query = "SELECT userstable.id_user, userstable.username,userstable.password, userstable.email , userstable.phonenumber, userstable.isadmin FROM userstable ";
            dataGridViewUser.DataSource = con.GetData(Query);
            dataGridViewUser.ClearSelection();
        }

        private void dataGridViewUser_SelectionChanged(object sender, EventArgs e)
        {
            // Show the Edit button when a row is selected
            if (dataGridViewUser.SelectedRows.Count > 0)
            {
                editbtn.Visible = true;
                deletebtn.Visible = true;

                // Store the selected user's ID in the Tag property
                this.Tag = dataGridViewUser.SelectedRows[0].Cells[0].Value;

            }
            else
            {
                editbtn.Visible = false;
                deletebtn.Visible = false;
            }
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


        private void editbtn_Click(object sender, EventArgs e)
        {

            if (this.Tag != null)
            {
                int userId = (int)this.Tag;
                string query = "SELECT id_user, username, password, email, phonenumber, isadmin FROM userstable WHERE id_user = " + userId;
                DataTable memberData = con.GetData(query);

                if (memberData.Rows.Count > 0)
                {
                    DataRow row = memberData.Rows[0];
                    string user = row["username"].ToString();
                    string pass = row["password"].ToString();
                    string mail = row["email"].ToString();
                    string number = row["phonenumber"].ToString();
                    bool admin = Convert.ToBoolean(row["isadmin"]);

                    // Check if the email is not empty before validating it
                    if (!string.IsNullOrEmpty(mail) && !IsValidEmail(mail))
                    {
                        MessageBox.Show("The email address is not valid. Please correct it.");
                        return;
                    }

                    AddUser usersForm = new AddUser(null);
                    usersForm.LoadUserDetails(userId, user, pass, mail, number, admin);
                    this.Hide(); // Hide the current allusers form
                    usersForm.Show();
                   
                }
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewUser.SelectedRows.Count > 0)
            {
                int userId = (int)dataGridViewUser.SelectedRows[0].Cells[0].Value;
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM userstable WHERE id_user = " + userId;
                        con.setData(query);
                        dataGridViewUser.Rows.RemoveAt(dataGridViewUser.SelectedRows[0].Index);
                        MessageBox.Show("Username deleted successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while deleting the trainer: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            AddUser usersForm = new AddUser(this);
            this.Hide(); // Hide the current allUsers form
            usersForm.Show();
   
        }

        private void GridUsers_Load(object sender, EventArgs e)
        {
            // Check if the click is outside the DataGridView
            if (!dataGridViewUser.Bounds.Contains(PointToClient(Cursor.Position)))
            {
                editbtn.Visible = false;
                deletebtn.Visible = false;
                this.Tag = null; // Clear the selected trainer ID
            }
        }

        private void GridUsers_Click(object sender, EventArgs e)
        {
            editbtn.Visible = false;
            deletebtn.Visible = false;
        }
    }
}
