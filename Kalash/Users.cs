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
    public partial class Users : Form
    {
        Functions Con;
        public Users()
        {
            InitializeComponent();
            Con = new Functions();
            ShowUsers();
        }
        
        private void ShowUsers()
        {
            string Query = "Select * from UsersTable";
            UsersList.DataSource = Con.GetData(Query);
        }

        private void Reset()
        {
            Username.Text = "";
            Password.Text = "";
            Gender.Text = "";
            Phone.Text = "";
            BloodType.Text = "";
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Username.Text == "" || Password.Text == "" || Gender.SelectedIndex == -1 || Phone.Text == "" || BloodType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please enter the required fields!!");

                }
                else
                {
                    string User = Username.Text;
                    string Pass = Password.Text;
                    string Date = DOB.Value.Date.ToString();
                    string Gen = Gender.SelectedItem.ToString();
                    string Number = Phone.Text;
                    string Blood = BloodType.SelectedItem.ToString();
                    string Query = "insert into UsersTable values('{0}','{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query, User, Pass, DOB.Value.Date, Gen, Number,Blood);
                    Con.setData(Query);
                    ShowUsers();
                    MessageBox.Show("User added");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        int Key = 0;
        private void Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Username.Text == "" || Password.Text == "" || Gender.SelectedIndex == -1 || Phone.Text == "" || BloodType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please enter the required fields!!");

                }
                else
                {
                    string User = Username.Text;
                    string Pass = Password.Text;
                    string Gen = Gender.SelectedItem.ToString();
                    string Number = Phone.Text;
                    string Blood = BloodType.SelectedItem.ToString();
                    string Query = "update UsersTable set Username = '{0}', Password= '{1}', DOB = '{2}', Gender = '{3}', Phone = '{4}', BloodType = '{5}' where UserId = {6}";
                    Query = string.Format(Query, User, Pass, DOB.Value.Date, Gen, Number, Blood, Key);
                    Con.setData(Query);
                    ShowUsers();
                    MessageBox.Show("User Updated");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("Please select a username!!");
                }
                else
                { 
                    string Query = "delete from  UsersTable where UserId ={0}";
                    Query = string.Format(Query, Key);
                    Con.setData(Query);
                    ShowUsers();
                    MessageBox.Show("User deleted");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void UsersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Username.Text = UsersList.SelectedRows[0].Cells[1].Value.ToString();
            Password.Text = UsersList.SelectedRows[0].Cells[2].Value.ToString();
            DOB.Text = UsersList.SelectedRows[0].Cells[3].Value.ToString();
            Gender.Text = UsersList.SelectedRows[0].Cells[4].Value.ToString();
            Phone.Text = UsersList.SelectedRows[0].Cells[5].Value.ToString();
            BloodType.Text = UsersList.SelectedRows[0].Cells[6].Value.ToString();
            if (Username.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(UsersList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
