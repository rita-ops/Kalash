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
    public partial class GridMemberships : BaseForm
    {

        Functions Con;
        public GridMemberships()
        {
            InitializeComponent();
            Con = new Functions();
            GetMembersship();
            dataGridViewMembership.Columns[0].Visible = false;
            dataGridViewMembership.Columns[1].HeaderText = "Description";
            dataGridViewMembership.Columns[2].HeaderText = "Cost";
            dataGridViewMembership.Columns[3].HeaderText = "Currency";
            dataGridViewMembership.Columns["Cost"].DefaultCellStyle.Format = "N2";

            // Attach the event handler
            this.Click += new EventHandler(GridMemberships_Load);
            dataGridViewMembership.SelectionChanged += new EventHandler(dataGridViewMembership_SelectionChanged);
        }

        private void GetMembersship()
        {
            string Query = " SELECT membershiptable.membership_id, membershiptable.description, membershiptable.cost, membershiptable.currency FROM membershiptable ";
            dataGridViewMembership.DataSource = Con.GetData(Query);
            dataGridViewMembership.ClearSelection();
        }


        private void GridMemberships_Load(object sender, EventArgs e)
        {
            // Show the Edit button when a row is selected
            if (dataGridViewMembership.SelectedRows.Count > 0)
            {
                editbtn.Visible = true;
                deletebtn.Visible = true;

                // Store the selected user's ID in the Tag property
                this.Tag = dataGridViewMembership.SelectedRows[0].Cells[0].Value;

            }
            else
            {
                editbtn.Visible = false;
                deletebtn.Visible = false;
            }
        }
        private void dataGridViewMembership_SelectionChanged(object sender, EventArgs e)
        {
            // Show the Edit button when a row is selected
            if (dataGridViewMembership.SelectedRows.Count > 0)
            {
                editbtn.Visible = true;
                deletebtn.Visible = true;

                // Store the selected membership's ID in the Tag property
                this.Tag = dataGridViewMembership.SelectedRows[0].Cells[0].Value;

            }
            else
            {
                editbtn.Visible = false;
                deletebtn.Visible = false;
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                int membershipId = (int)this.Tag;
                string query = "SELECT membership_id, description, cost, currency FROM membershiptable WHERE membership_id = " + membershipId;
                DataTable memberData = Con.GetData(query);

                if (memberData.Rows.Count > 0)
                {
                    DataRow row = memberData.Rows[0];
                    string desc = row["description"].ToString();
                    decimal money = Convert.ToDecimal(row["cost"]);
                    dataGridViewMembership.Columns["Cost"].DefaultCellStyle.Format = "N2";
                    string curr = row["currency"].ToString();

                    AddMembership membershipForm = new AddMembership();
                    membershipForm.LoadMembershipDetails(membershipId, desc, money, curr);
                    this.Hide(); // Hide the current AllMemberships form
                    membershipForm.Show();
                 
                }
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewMembership.SelectedRows.Count > 0)
            {
                int membershipId = (int)dataGridViewMembership.SelectedRows[0].Cells[0].Value;
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this membership?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM membershiptable WHERE membership_id = " + membershipId;
                        Con.setData(query);
                        dataGridViewMembership.Rows.RemoveAt(dataGridViewMembership.SelectedRows[0].Index);
                        MessageBox.Show("Membership deleted successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while deleting the membership: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a membership to delete.");
            }
        }

        private void Addnewmembership(object sender, EventArgs e)
        {
            AddMembership membershipForm = new AddMembership();
            this.Hide(); // Hide the current allmemberships form
            membershipForm.Show();
          
        }

        private void GridMemberships_Click(object sender, EventArgs e)
        {
            editbtn.Visible = false;
            deletebtn.Visible = false;
        }
    }
}
