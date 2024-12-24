using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Kalash.Login;

namespace Kalash
{
    public partial class BaseForm : Form
    {

        public bool IsFirstLogin; // Instance property

        public BaseForm()
        {
            InitializeComponent();
            ConfigureMenuItems();
            InitializeUsernameLabel();
        }

        // Initialize lblusername once in the BaseForm
        private void InitializeUsernameLabel()
        {
            // If lblusername is not already initialized, create and add it to the form
            if (lblusername == null)
            {
               Label lblusername = new Label();
               lblusername.Location = new Point(10, 10);  // Adjust the position as necessary
               lblusername.Size = new Size(200, 30);      // Adjust the size as necessary
               lblusername.Text =  UserSession.Username;  // Set the username text
               this.Controls.Add(lblusername);  // Add label to the form
            }
            else
            {
                lblusername.Text = UserSession.Username;  // Update the label text
            }
        }
        private void ConfigureMenuItems()
        {
            //// Check if the user is an admin
            if (!UserSession.IsAdmin)
            {
                // Hide the users related menu items if not admin
                usersToolStripMenuItem.Visible = false;
            }
        }


            // Open different forms based on menu selection
        private void newMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMember membersForm = new AddMember(null);
            membersForm.Show();
            this.Hide(); // Hide the current allmembers form
        }

        private void allMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridMembers allmembersForm = new GridMembers();
            allmembersForm.Show();
            this.Hide();
        }

        private void newMembershipsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMembership membershipForm = new AddMembership();
            membershipForm.Show();
            this.Hide();
        }

        private void allMembershipsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridMemberships allmembershipForm = new GridMemberships();
            allmembershipForm.Show();
            this.Hide();
        }

        private void newTrainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTrainer trainersForm = new AddTrainer();
            trainersForm.Show();
            this.Hide();
        }

        private void allTrainersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridTrainers alltrainersForm = new GridTrainers();
            alltrainersForm.Show();
            this.Hide();
        }

        private void newIncomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddIncome addincome = new AddIncome(null);
            addincome.Show();
            this.Hide();
        }

        private void allIncomesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridIncomes allincomesForm = new GridIncomes();
            allincomesForm.Show();
            this.Hide();
        }

        private void newExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddExpense addexpense = new AddExpense(null);
            addexpense.Show();
            this.Hide();
        }

        private void allExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridExpenses allExpensesForm = new GridExpenses();
            allExpensesForm.Show();
            this.Hide();
        }

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser usersForm = new AddUser(null);
            usersForm.Show();
            this.Hide();
        }

        private void allUSersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridUsers allusersForm = new GridUsers();
            allusersForm.Show();
            this.Hide();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword changePasswordForm = new ChangePassword(false);
            changePasswordForm.Show();
            this.Hide();

        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
