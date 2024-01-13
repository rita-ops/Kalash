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
    public partial class Memberships : Form
    {
        Functions Con;
        public Memberships()
        {
            InitializeComponent();
            Con = new Functions();
            ShowMemberships();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void ShowMemberships()
        {
           string Query = "Select MembershipID, MembershipType, Description, Cost from MembershipsTable";
           dataGridView1.DataSource = Con.GetData(Query);
           dataGridView1.ClearSelection();
        }

        private void Reset()
        {
            MembershipType.SelectedIndex = -1;
            Description.Text = "";
            Cost.Text = "";
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (MembershipType.SelectedIndex == -1 || Description.Text == "" || Cost.Text == "")
                {
                    MessageBox.Show("Please fill required fields!!");
                }
                else
                {
                    string Memshiptype = MembershipType.Text;
                    string Desc = Description.Text;
                    string Cos = Cost.Text;
                    string Query = "Insert into MembershipsTable Values('{0}','{1}','{2}')";
                    Query = string.Format(Query, Memshiptype, Desc, Cos);
                    Con.setData(Query);
                    ShowMemberships();
                    MessageBox.Show("Membership Added");
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
                if (MembershipType.Text == "" || Description.Text == "" || Cost.Text == "")
                {
                    MessageBox.Show("Please enter the required fields!!");
                }
                else
                {
                    int Key = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    string Memshiptype = MembershipType.Text;
                    string Desc = Description.Text;
                    string Cos = Cost.Text;   
                    string Query = "Update MembershipsTable set MembershipType = '{0}', Description = '{1}', Cost = '{2}' Where MembershipID = {3}";
                    Query = string.Format(Query, Memshiptype, Desc, Cos, Key);
                    Con.setData(Query);
                    ShowMemberships();
                    MessageBox.Show("Membership updated");
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
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            //    int membershipID = Convert.ToInt32(selectedRow.Cells["MembershipID"].Value);

            //    // Delete from the DataTable
            //    DataRow rowToDelete = dataTable.Rows.Find(membershipID);
            //    if (rowToDelete != null)
            //    {
            //        dataTable.Rows.Remove(rowToDelete);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please select a row to delete.");
            //}
        }


        private void TrainersLbl_Click(object sender, EventArgs e)
        {
            Trainers Obj = new Trainers();
            Obj.Show();
            this.Hide();
        }

        private void MemberLbl_Click(object sender, EventArgs e)
        {
            Members Obj = new Members();
            Obj.Show();
            this.Hide();
        }

        private void BillsLbl_Click(object sender, EventArgs e)
        {
            Bills Obj = new Bills();
            Obj.Show();
            this.Hide();
        }

        private void Memberships_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kalashDBDataSet9.MembershipsTable' table. You can move, or remove it, as needed.
            this.membershipsTableTableAdapter.Fill(this.kalashDBDataSet9.MembershipsTable);

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                MembershipType.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                Description.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                Cost.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
        }
    }
}
