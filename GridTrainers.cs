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
    public partial class GridTrainers : BaseForm
    {
        Functions con;

        public GridTrainers()
        {
            InitializeComponent();
            con = new Functions();
            GetTrainers();
            dataGridViewTrainer.Columns[0].Visible = false;
            dataGridViewTrainer.Columns[1].HeaderText = "Trainer Name";
            dataGridViewTrainer.Columns[2].HeaderText = "Date Of Birth";
            dataGridViewTrainer.Columns[3].HeaderText = "Experience";
            dataGridViewTrainer.Columns[4].HeaderText = "Phone Number";
            dataGridViewTrainer.Columns[5].HeaderText = "Start Date";
            dataGridViewTrainer.Columns[6].HeaderText = "End Date";
            dataGridViewTrainer.Columns[7].HeaderText = "Active";
            dataGridViewTrainer.Columns[8].Visible = false;
            dataGridViewTrainer.Columns[9].HeaderText = "Blood Type";

            // Attach the event handler
            this.Click += new EventHandler(GridTrainers_Load);
            dataGridViewTrainer.SelectionChanged += new EventHandler(dataGridViewTrainer_SelectionChanged);
        }

        private void GetTrainers()
        {
            string Query = "SELECT trainerstable.trainer_id,CONCAT(trainerstable.firstname, ' ', trainerstable.lastname) AS Trainer, trainerstable.dob,trainerstable.experience,trainerstable.phonenumber,trainerstable.startdate,trainerstable.enddate,trainerstable.isactive,bloodtable.blood_id,bloodtable.type FROM trainerstable LEFT JOIN bloodtable ON trainerstable.blood_id = bloodtable.blood_id ";
            dataGridViewTrainer.DataSource = con.GetData(Query);
            dataGridViewTrainer.ClearSelection();
        }


        private void editbtn_Click(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                int trainerId = (int)this.Tag;
                string query = "SELECT trainer_id, firstname, lastname, dob, experience, phonenumber, startdate, enddate, blood_id, isactive FROM trainerstable WHERE trainer_id = " + trainerId;
                DataTable trainerData = con.GetData(query);

                if (trainerData.Rows.Count > 0)
                {
                    DataRow row = trainerData.Rows[0];
                    string firstname = row["firstname"].ToString();
                    string lastname = row["lastname"].ToString();
                    DateTime dob = Convert.ToDateTime(row["dob"]);
                    int exp = Convert.ToInt32(row["experience"].ToString());
                    string phonenumber = row["phonenumber"].ToString();
                    DateTime startdate = Convert.ToDateTime(row["startdate"]);

                    // Handle nullable enddate
                    DateTime? enddate = row["enddate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["enddate"]) : null;

                    int? bloodId = row["blood_id"] != DBNull.Value ? (int?)Convert.ToInt32(row["blood_id"]) : null; // Handle nullable blood_id
                    bool active = Convert.ToBoolean(row["isactive"]);

                    // Pass the data to the AddTrainer form
                    AddTrainer trainersForm = new AddTrainer();
                    trainersForm.LoadTrainerDetails(trainerId, firstname, lastname, dob, exp, phonenumber, startdate, enddate, bloodId, active);
                    this.Hide(); // Hide the current alltrainers form
                    trainersForm.Show();
                  
                }
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewTrainer.SelectedRows.Count > 0)
            {
                int trainerId = (int)dataGridViewTrainer.SelectedRows[0].Cells[0].Value;
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this trainer?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM trainerstable WHERE trainer_id = " + trainerId;
                        con.setData(query);
                        dataGridViewTrainer.Rows.RemoveAt(dataGridViewTrainer.SelectedRows[0].Index);
                        MessageBox.Show("Trainer deleted successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while deleting the trainer: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a trainer to delete.");
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            AddTrainer trainersForm = new AddTrainer();
            this.Hide(); // Hide the current allmembers form
            trainersForm.Show();
           
        }

        private void dataGridViewTrainer_SelectionChanged(object sender, EventArgs e)
        {
            // Show the Edit button when a row is selected
            if (dataGridViewTrainer.SelectedRows.Count > 0)
            {
                editbtn.Visible = true;
                deletebtn.Visible = true;

                // Store the selected member's ID in the Tag property
                this.Tag = dataGridViewTrainer.SelectedRows[0].Cells[0].Value;

            }
            else
            {
                editbtn.Visible = false;
                deletebtn.Visible = false;
            }
        }

        private void GridTrainers_Load(object sender, EventArgs e)
        {
            // Check if the click is outside the DataGridView
            if (!dataGridViewTrainer.Bounds.Contains(PointToClient(Cursor.Position)))
            {
                editbtn.Visible = false;
                deletebtn.Visible = false;
                this.Tag = null; // Clear the selected trainer ID
            }
        }

        private void GridTrainers_Click(object sender, EventArgs e)
        {
            editbtn.Visible = false;
            deletebtn.Visible = false;
        }
    }
}
