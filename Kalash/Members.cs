using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Kalash
{
    public partial class Members : Form
    {
        Functions Con;

        public Members()
        {
            InitializeComponent();
            Con = new Functions();
            ShowMembers();
            GetTrainers();
            GetMemberships();
            dataGridView2.SelectionChanged += dataGridView2_SelectionChanged;
        }

        private void ShowMembers()
        {
            string Query = " SELECT MembersTable.MembersID, MembersTable.MemberFName , MembersTable.MemberLName, MembersTable.DOB, MembersTable.JoinDate, MembershipsTable.MembershipID , MembershipsTable.MembershipType, MembersTable.Phone, MembersTable.Timing, MembersTable.BloodType, MembersTable.Gender,  TrainersTable.TrainersID , TrainersTable.TrainerFName , TrainersTable.TrainerLName   FROM MembersTable JOIN MembershipsTable ON MembersTable.MembershipID = MembershipsTable.MembershipID JOIN TrainersTable ON MembersTable.TrainersID = TrainersTable.TrainersID ";
            dataGridView2.DataSource = Con.GetData(Query);
            dataGridView2.ClearSelection();
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
                    int Key = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
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

        private void PaymentLbl_Click(object sender, EventArgs e)
        {
            Payments Obj = new Payments();
            Obj.Show();
            this.Hide();
        }     

        private void Logout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Members_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kalashDBDataSet8.MembersTable' table. You can move, or remove it, as needed.
            this.membersTableTableAdapter.Fill(this.kalashDBDataSet8.MembersTable);
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                MemberFName.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                MemberLName.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                DOB.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                JoinDate.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                MembershipType.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                Phone.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                Timing.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
                BloodType.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
                Gender.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();
                Trainer.Text = dataGridView2.CurrentRow.Cells[10].Value.ToString();
            }
        }
    }

}

