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
    public partial class Bills : Form
    {
        Functions Con;

        public Bills()
        {
            InitializeComponent();
            Con = new Functions();
            ShowBills();
            GetMembers();
            BillsList.Columns[4].Visible = false;
        }

        private void ShowBills()
        {
            string Query = "SELECT CONCAT(MembersTable.MemberFName ,' ', MembersTable.MemberLName ,' ') AS Member , BillsTable.Date, BillsTable.Amount , BillsTable.Currency, BillsTable.BillId FROM MembersTable INNER JOIN BillsTable ON MembersTable.MembersID = BillsTable.MembersID";
            BillsList.DataSource = Con.GetData(Query);
        }

        private void GetMembers()
        {
            string Query = "Select MembersTable.MembersID, MemberFName +' '+ MemberLName +' ' as Member from MembersTable";
            Member.DisplayMember = Con.GetData(Query).Columns["Member"].ToString();
            Member.ValueMember = Con.GetData(Query).Columns["MembersID"].ToString();
            Member.DataSource = Con.GetData(Query);
    
        }

        private void Reset()
        {
            Member.Text = "";
            Amount.Text = "";
        }

    

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Member.SelectedIndex == -1 || Amount.Text == "" || Currency.SelectedIndex == -1)

                {
                    MessageBox.Show("Please enter the required fields!!");
                }
                else
                {
                    //int Agent = Login.UserId; // Receptionist user
                    string Memship = Member.SelectedValue.ToString();
                    string BillDate = Date.Value.Date.ToString();
                    string Amo = Amount.Text;
                    string Curr = Currency.SelectedItem.ToString();
                    string Query = "insert into BillsTable values({0},'{1}','{2}','{3}')";
                    Query = string.Format(Query, Memship, Date.Value.Date, Amo, Curr);
                    Con.setData(Query);
                    ShowBills();
                    MessageBox.Show("Bill confirmed");
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
                if (Member.SelectedIndex == -1 || Amount.Text == "" || Currency.SelectedIndex == -1)
                {
                    MessageBox.Show("Please enter the required fields!!");
                }
                else
                {
                    int Key = int.Parse(BillsList.SelectedRows[0].Cells[4].Value.ToString());
                    //int Agent = Login.UserId; // Receptionist user
                    string Memship = Member.SelectedValue.ToString();
                    string BillDate = Date.Value.Date.ToString();
                    string Amo = Amount.Text;
                    string Curr = Currency.SelectedItem.ToString();
                    string Query = "update BillsTable set MembersID= {0}, Date = '{1}', Amount = '{2}', Currency = '{3}' where BillId = {4}";
                    Query = string.Format(Query, Memship, Date.Value.Date, Amo, Curr, Key);
                    Con.setData(Query);
                    ShowBills();
                    MessageBox.Show("Bill updated");
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
            if (BillsList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = BillsList.SelectedRows[0];
                int rowIndex = selectedRow.Index;
                Reset();

                // Assuming your DataGridView is bound to a DataTable
                DataTable dataTable = (DataTable)BillsList.DataSource;
                Reset();

                // Remove the row from the DataTable
                dataTable.Rows.RemoveAt(rowIndex);
                Reset();

                // Optionally, refresh the DataGridView to reflect the changes
                BillsList.Refresh();
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BillsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Member.Text = BillsList.SelectedCells[0].Value.ToString();
            Date.Text = BillsList.SelectedCells[1].Value.ToString();
            Amount.Text = BillsList.SelectedCells[2].Value.ToString();
            Currency.Text = BillsList.SelectedCells[3].Value.ToString();
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

        private void MemberShipLbl_Click(object sender, EventArgs e)
        {
            Memberships Obj = new Memberships();
            Obj.Show();
            this.Hide();
        }

        private void SearchTxtBox_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = SearchTxtBox.Text.ToLower();
            BindingSource bs = new BindingSource();
            bs.DataSource = BillsList.DataSource;
            bs.Filter = string.Format("Member LIKE '%{0}%'" , searchTerm );
            BillsList.DataSource = bs;

        }

        private void Print_Click(object sender, EventArgs e)
        {

        }

        private void billsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Bills BillsList = new Bills();
            BillsList.Show();
            MemberName.Visible = false;
            Member.Visible = false;
            //this.Hide();
        }

        private void Search_Click(object sender, EventArgs e)
        {

        }

        //private void billsToolStripMenuItem2_Click(object sender, EventArgs e)
        //{
        //    //Bills BillsList = new Bills();
        //    //BillsList.Show();
        //    isBillsListOnly = !isBillsListOnly;
        //    // Get data from the original DataGridView (dataGridView1)
        //    List<DataGridViewRow> rowsToCopy = new List<DataGridViewRow>();

        //    foreach (DataGridViewRow row in BillsList.Rows)
        //    {
        //        if (!row.IsNewRow) // Exclude the new row if present
        //        {
        //            rowsToCopy.Add(row);
        //        }
        //    }

        //    // Open the CopyForm and pass the data
        //    CopyForm copyForm = new CopyForm(rowsToCopy);
        //    copyForm.Show();

        //}


    }

}
