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
    public partial class Members : Form
    {
        Functions Con;
        // this.MenuStrip = MenuStrip1;
        private DataGridView dataGridView;

        public Members()
        {
            InitializeComponent();
            Con = new Functions();
            ShowMembers();
            GetTrainers();
            GetMemberships();
            MembersList.Columns[0].Visible = false;
            //MembersList.Columns[11].Visible = false;

        }


        private void ShowMembers()
        {
            string Query = " SELECT MembersTable.MembersID, CONCAT(MembersTable.MemberFName ,' ', MembersTable.MemberLName, ' ') AS Member , MembersTable.DOB, MembersTable.JoinDate, MembershipsTable.MembershipType, MembersTable.Phone, MembersTable.Timing, MembersTable.BloodType, MembersTable.Gender, CONCAT(TrainersTable.TrainerFName ,' ', TrainersTable.TrainerLName ,' ') AS Trainer  FROM MembersTable JOIN MembershipsTable ON MembersTable.MembershipID = MembershipsTable.MembershipID JOIN TrainersTable ON MembersTable.TrainersID = TrainersTable.TrainersID ";
            MembersList.DataSource = Con.GetData(Query);
            MembersList.ClearSelection();
        }

        //To get all trainers from table trainers
        private void GetTrainers()
        {
            string Query = "Select TrainersID , TrainerFName +' '+ TrainerLName +' ' as Trainer from TrainersTable";
            Trainer.DisplayMember = Con.GetData(Query).Columns["Trainer"].ToString();
            Trainer.ValueMember = Con.GetData(Query).Columns["TrainersID"].ToString();
            Trainer.DataSource = Con.GetData(Query);
        }

        private void GetMemberships()
        {
            string Query = "Select MembershipID, MembershipType from MembershipsTable";
            MembershipType.DisplayMember = Con.GetData(Query).Columns["MembershipType"].ToString();
            MembershipType.ValueMember = Con.GetData(Query).Columns["MembershipID"].ToString();
            MembershipType.DataSource = Con.GetData(Query);
        }

        private void Reset()
        {
            MemberFName.Text = "";
            MemberLName.Text = "";
            MembershipType.SelectedIndex = -1;
            Phone.Text = "";
            Timing.SelectedIndex = -1;
            BloodType.SelectedIndex = -1;
            Gender.SelectedIndex = -1;
            Trainer.SelectedIndex = -1;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (MemberFName.Text == "" || MemberLName.Text == "" || MembershipType.SelectedIndex == -1 || Phone.Text == "" || Timing.SelectedIndex == -1 || BloodType.SelectedIndex == -1 || Gender.SelectedIndex == -1 || Trainer.SelectedIndex == -1)
                {
                    MessageBox.Show("Please enter the required fields!!");
                }
                else
                {
                    //string FullName = MemberFName.Text +  MemberLName.Text;
                    string MemFName = MemberFName.Text;
                    string MemLName = MemberLName.Text;
                    string BirthDate = DOB.Value.Date.ToString();
                    string JoinedDate = JoinDate.Value.Date.ToString();
                    int Memship = Convert.ToInt32(MembershipType.SelectedValue.ToString());
                    string Number = Phone.Text;
                    string Time = Timing.SelectedItem.ToString();
                    string Blood = BloodType.SelectedItem.ToString();
                    string Gen = Gender.SelectedItem.ToString();
                    string TrainerName = Trainer.SelectedValue.ToString();
                    string Query = "insert into MembersTable values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')";
                    Query = string.Format(Query,MemFName,MemLName, DOB.Value.Date, JoinDate.Value.Date, Memship, Number, Time, Blood, Gen, TrainerName) ;
                    Con.setData(Query);
                    ShowMembers();
                    MessageBox.Show("Member added");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (MemberFName.Text == "" || MemberLName.Text == "" || MembershipType.SelectedIndex == -1 || Phone.Text == "" || Timing.SelectedIndex == -1 || BloodType.SelectedIndex == -1 || Gender.SelectedIndex == -1 || Trainer.SelectedIndex == -1)
                {
                    MessageBox.Show("Please enter the required fields!!");
                }
                else
                {
                    int Key = int.Parse(MembersList.CurrentRow.Cells[0].Value.ToString());
                    string MemFName = MemberFName.Text;
                    string MemLName = MemberLName.Text;
                    string BirthDate = DOB.Value.Date.ToString();
                    string JoinedDate = JoinDate.Value.Date.ToString();
                    string Memship = MembershipType.SelectedValue.ToString();
                    string Number = Phone.Text;
                    string Time = Timing.SelectedItem.ToString();
                    string Blood = BloodType.SelectedItem.ToString();
                    string Gen = Gender.SelectedItem.ToString();
                    string TrainerName = Trainer.SelectedValue.ToString();
                    string Query = "Update MembersTable set MemberFName = '{0}', MemberLName = '{1}', DOB = '{2}', JoinDate = '{3}', MembershipID = '{4}', Phone = '{5}' , Timing = '{6}', BloodType = '{7}', Gender = '{8}' , TrainersID = '{9}' Where MembersID = {10}";
                    Query = string.Format(Query, MemFName, MemLName, DOB.Value.Date, JoinDate.Value.Date, Memship, Number, Time, Blood, Gen, TrainerName, Key);
                    Con.setData(Query);
                    ShowMembers();
                    MessageBox.Show("Member updated");
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
            //if (MembersList.SelectedRows.Count > 0)
            //{
            //    DataGridViewRow selectedRow = MembersList.SelectedRows[0];
            //    int rowIndex = selectedRow.Index;
            //    Reset();

            //    // Assuming your DataGridView is bound to a DataTable
            //    DataTable dataTable = (DataTable)MembersList.DataSource;
            //    Reset();

            //    // Remove the row from the DataTable
            //    dataTable.Rows.RemoveAt(rowIndex);
            //    Reset();

            //    // Optionally, refresh the DataGridView to reflect the changes
            //    MembersList.Refresh();
            //}
            //else
            //{
            //    MessageBox.Show("Please select a row to delete.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            int Key = int.Parse(MembersList.CurrentRow.Cells[0].Value.ToString());
           // Key = dataGridView.CurrentCell.RowIndex;
            dataGridView.Rows.RemoveAt(Key);
        }
       
        private void TrainersLbl_Click(object sender, EventArgs e)
        {
            Trainers Obj = new Trainers();
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

       

        private void trainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trainers Obj = new Trainers();
            Obj.Show();
            this.Hide();
        }

        private void existToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        

        private void InitializeMenu()
        {
            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem viewMenu = new ToolStripMenuItem("View");
            ToolStripMenuItem showGridViewItem = new ToolStripMenuItem("Show GridView on Second Form");
            showGridViewItem.Click += ShowGridViewItem_Click;

            viewMenu.DropDownItems.Add(showGridViewItem);
            menuStrip.Items.Add(viewMenu);

            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;
        }

        private void ShowGridViewItem_Click(object sender, EventArgs e)
        {
            // Open the SecondForm and pass a reference to the DataGridView
            SecondForm secondForm = new SecondForm(dataGridView);
            secondForm.Show();
        }

        private void MembersList_SelectionChanged(object sender, EventArgs e)
        {
           
            DataGridView dtg = new DataGridView();
            dtg = MembersList;
            MemberFName.Text = MembersList.CurrentRow.Cells[1].Value.ToString();
            MemberLName.Text = MembersList.CurrentRow.Cells[1].Value.ToString();
            string[] Members = MembersList.CurrentRow.Cells[1].Value.ToString().Split(' ');
            MemberFName.Text = Members[0];
            MemberLName.Text = Members[1];
            DOB.Text = MembersList.CurrentRow.Cells[2].Value.ToString();
            JoinDate.Text = MembersList.CurrentRow.Cells[3].Value.ToString();
            MembershipType.Text = MembersList.CurrentRow.Cells[4].Value.ToString();
            Phone.Text = MembersList.CurrentRow.Cells[5].Value.ToString(); 
            Timing.Text = MembersList.CurrentRow.Cells[6].Value.ToString();
            BloodType.Text = MembersList.CurrentRow.Cells[7].Value.ToString();
            Gender.Text = MembersList.CurrentRow.Cells[8].Value.ToString();
            Trainer.Text = MembersList.CurrentRow.Cells[9].Value.ToString();

        }   
    }

}

