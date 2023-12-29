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
    public partial class Trainers : Form
    {
        Functions Con;
        public Trainers()
        {
            InitializeComponent();
            Con = new Functions();
            ShowTrainers();
            TrainersList.Columns[0].Visible = false;
        }

        private void ShowTrainers()
        {
            string Query = "Select TrainersTable.TrainersID, CONCAT(TrainersTable.TrainerFName,' ' ,TrainersTable.TrainerLName,' ') As Trainer , TrainersTable.TrainerDOB, TrainersTable.Phone, TrainersTable.Experience, TrainersTable.Address, TrainersTable.Gender, TrainersTable.BloodType from TrainersTable";
            TrainersList.DataSource = Con.GetData(Query);
        }

        private void Reset()
        {
            TrainerFName.Text = "";
            TrainerLName.Text = "";
            TrainerDOB.Value = TrainerDOB.Value.Date;
            Phone.Text = "";
            Experience.Text = "";
            Address.Text = "";
            Gender.Text = "";
            BloodType.Text = "";
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (TrainerFName.Text == "" || TrainerLName.Text == "" || Phone.Text == "" || Experience.SelectedIndex == -1 || Address.Text == "" || Gender.SelectedIndex == -1 || BloodType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please enter the required fields!!");
                }
                else
                {
                    string FirstName = TrainerFName.Text;
                    string LastName = TrainerLName.Text;
                    string Number = Phone.Text;
                    int Exp = Convert.ToInt32(Experience.SelectedItem.ToString());
                    string Add = Address.Text;
                    string Gen = Gender.Text;
                    string Blood = BloodType.Text;
                    string Query = "Insert into TrainersTable Values('{0}','{1}','{2}','{3}', '{4}','{5}','{6}','{7}')";
                    Query = string.Format(Query, FirstName, LastName, TrainerDOB.Value.Date, Number, Exp, Add, Gen, Blood);
                    Con.setData(Query);
                    ShowTrainers();
                    MessageBox.Show("New Trainer Added");
                    Reset();
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        
        private void Edit_Click(object sender, EventArgs e)
            {
            try
            {
                if (TrainerFName.Text == "" || TrainerLName.Text == "" || Phone.Text == "" || Experience.SelectedIndex == -1 || Address.Text == "" || Gender.SelectedIndex == -1 || BloodType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please enter the required fields!!");
                }
                else
                {
                    int Key = int.Parse(TrainersList.SelectedRows[0].Cells[0].Value.ToString());
                    string FirstName = TrainerFName.Text;
                    string LastName = TrainerLName.Text;
                    string Number = Phone.Text;
                    int Exp = Convert.ToInt32(Experience.SelectedItem.ToString());
                    string Add = Address.Text;
                    string Gen = Gender.Text;
                    string Blood = BloodType.Text;
                    string Query = "update TrainersTable set TrainerFName = '{0}', TrainerLName = '{1}', TrainerDOB = '{2}', Phone = '{3}', Experience = '{4}', Address = '{5}', Gender = '{6}', BloodType = '{7}' where TrainersID = {8}";
                    Query = string.Format(Query, FirstName, LastName, TrainerDOB.Value.Date, Number, Exp, Add, Gen, Blood, Key);
                    Con.setData(Query);
                    ShowTrainers();
                    MessageBox.Show("Trainer updated");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void DeleteBtn_Click_Click(object sender, EventArgs e)
        {
            if (TrainersList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = TrainersList.SelectedRows[0];
                int rowIndex = selectedRow.Index;
                Reset();

                // Assuming your DataGridView is bound to a DataTable
                DataTable dataTable = (DataTable)TrainersList.DataSource;
                Reset();

                // Remove the row from the DataTable
                dataTable.Rows.RemoveAt(rowIndex);
                Reset();

                // Optionally, refresh the DataGridView to reflect the changes
                TrainersList.Refresh();
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //private void TrainersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
            
        //}

        private void TrainersList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            TrainerFName.Text = TrainersList.SelectedRows[0].Cells[1].Value.ToString();
            TrainerLName.Text = TrainersList.SelectedRows[0].Cells[2].Value.ToString();
            TrainerDOB.Text = TrainersList.SelectedRows[0].Cells[3].Value.ToString();
            Phone.Text = TrainersList.SelectedRows[0].Cells[4].Value.ToString();
            Experience.Text = TrainersList.SelectedRows[0].Cells[5].Value.ToString();
            Address.Text = TrainersList.SelectedRows[0].Cells[6].Value.ToString();
            Gender.Text = TrainersList.SelectedRows[0].Cells[7].Value.ToString();
            BloodType.Text = TrainersList.SelectedRows[0].Cells[8].Value.ToString();         
        }

        private void MemberLbl_Click(object sender, EventArgs e)
        {
            Members Obj = new Members();
            Obj.Show();
            this.Hide();
        }

        private void MemberShipLbl_Click(object sender, EventArgs e)
        {
            Memberships Obj = new Memberships();
            Obj.Show();
            this.Hide();
        }

        private void BillsLbl_Click(object sender, EventArgs e)
        {
            Bills Obj = new Bills();
            Obj.Show();
            this.Hide();
        }

       
    }
}
