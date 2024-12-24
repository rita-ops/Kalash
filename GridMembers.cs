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
    public partial class GridMembers : BaseForm
    {

        Functions con;
       
        public GridMembers()
        {
            InitializeComponent();
            con = new Functions();
            GetMembers();
            dataGridViewMember.Columns[0].Visible = false;
            dataGridViewMember.Columns[1].HeaderText = "Member Name";
            dataGridViewMember.Columns[2].HeaderText = "Date of Birth";
            dataGridViewMember.Columns[3].HeaderText = "Join Date";
            dataGridViewMember.Columns[4].Visible = false;
            dataGridViewMember.Columns[5].HeaderText = "Membership";
            dataGridViewMember.Columns[6].HeaderText = "Phone Number";
            dataGridViewMember.Columns[7].Visible = false;
            dataGridViewMember.Columns[8].HeaderText = "Blood Type";
            dataGridViewMember.Columns[9].HeaderText = "Active";

            // Attach the event handler
            this.Click += new EventHandler(GridMembers_Load);
            dataGridViewMember.SelectionChanged += new EventHandler(dataGridViewMember_SelectionChanged);
        }

        private void GetMembers()
        {
            string Query = "SELECT  memberstable.member_id, CONCAT(memberstable.firstname, ' ', memberstable.lastname, ' ') AS Member, memberstable.dob, memberstable.joindate, membershiptable.membership_id,  membershiptable.description,memberstable.phonenumber,bloodtable.blood_id, bloodtable.type, memberstable.isactive FROM memberstable  JOIN  membershiptable ON memberstable.membership_id = membershiptable.membership_id LEFT JOIN bloodtable ON memberstable.blood_id = bloodtable.blood_id";
            dataGridViewMember.DataSource = con.GetData(Query);
            dataGridViewMember.ClearSelection();
        }

        private void dataGridViewMember_SelectionChanged(object sender, EventArgs e)
        {
            // Show the Edit and Delete buttons if a row is selected
            if (dataGridViewMember.SelectedRows.Count > 0)
            {
                editbtn.Visible = true;
                deletebtn.Visible = true;
                this.Tag = dataGridViewMember.SelectedRows[0].Cells[0].Value;
            }
            else
            {
                editbtn.Visible = false;
                deletebtn.Visible = false;
                this.Tag = null;
            }
        }

        private void GridMembers_Load(object sender, EventArgs e)
        {
            // Check if the click is outside the DataGridView
            if (!dataGridViewMember.Bounds.Contains(PointToClient(Cursor.Position)))
            {
                editbtn.Visible = false;
                deletebtn.Visible = false;
                this.Tag = null; // Clear the selected trainer ID
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                int memberId = (int)this.Tag;
                string query = "SELECT member_id, firstname, lastname, dob, joindate, phonenumber, membership_id, blood_id, isactive FROM memberstable WHERE member_id = " + memberId;
                DataTable memberData = con.GetData(query);

                if (memberData.Rows.Count > 0)
                {
                    DataRow row = memberData.Rows[0];
                    string firstname = row["firstname"].ToString();
                    string lastname = row["lastname"].ToString();
                    DateTime dob = Convert.ToDateTime(row["dob"]);
                    DateTime joindate = Convert.ToDateTime(row["joindate"]);
                    string phonenumber = row["phonenumber"].ToString();
                    int membershipId = Convert.ToInt32(row["membership_id"]);
                    int? bloodId = row["blood_id"] != DBNull.Value ? Convert.ToInt32(row["blood_id"]) : (int?)null; // Handle nullable blood_id
                    bool active = Convert.ToBoolean(row["isactive"]);

                    AddMember membersForm = new AddMember(this);
                    membersForm.LoadMemberDetails(memberId, firstname, lastname, dob, joindate, phonenumber, membershipId, bloodId, active);
                    this.Hide(); // Hide the current allmembers form
                    membersForm.Show();
                }
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewMember.SelectedRows.Count > 0)
            {
                int memberId = (int)dataGridViewMember.SelectedRows[0].Cells[0].Value;
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this member?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM memberstable WHERE member_id = " + memberId;
                        con.setData(query);
                        dataGridViewMember.Rows.RemoveAt(dataGridViewMember.SelectedRows[0].Index);
                        MessageBox.Show("Member deleted successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while deleting the member: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a member to delete.");
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            AddMember membersForm = new AddMember(this);
            this.Hide(); // Hide the current allmembers form
            membersForm.Show();
          
        }

        private void GridMembers_Click(object sender, EventArgs e)
        {
            editbtn.Visible = false;
            deletebtn.Visible = false;
        }
    }
}
