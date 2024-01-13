using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void ShowTrainers()
        {
            string Query = "Select TrainersTable.TrainersID, TrainersTable.TrainerFName , TrainersTable.TrainerLName , TrainersTable.TrainerDOB, TrainersTable.Phone, TrainersTable.Experience, TrainersTable.Address, TrainersTable.Gender, TrainersTable.BloodType from TrainersTable";
            dataGridView1.DataSource = Con.GetData(Query);
            dataGridView1.ClearSelection();

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
                    int Key = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
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
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    // Assuming "ID" is the primary key column
            //    int membershipID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["TrainersID"].Value);

            //    // Call the function to delete the record
            //    DeleteRecordFromTable(TrainersID);

            //}
            //else
            //{
            //    MessageBox.Show("Please select a row to delete.");
            //}
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

        private void Trainers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kalashDBDataSet10.TrainersTable' table. You can move, or remove it, as needed.
            this.trainersTableTableAdapter.Fill(this.kalashDBDataSet10.TrainersTable);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                //string[] Trainer = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Split(' ');
                //TrainerFName.Text = Trainer[0];
                //TrainerLName.Text = Trainer[1];
                
                TrainerFName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                TrainerLName.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                TrainerDOB.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                Phone.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                Experience.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                Address.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                Gender.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                BloodType.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            }
        }

       
    }
}
