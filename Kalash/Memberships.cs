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
    public partial class Memberships : Form
    {
        Functions Con;
        public Memberships()
        {
            InitializeComponent();
            Con = new Functions();
            ShowMemberships();
        }

        private void ShowMemberships()
        {
            string Query = "Select MembershipType, Description, Cost from MembershipsTable";
            //string Query = "Select * from MembershipsTable";
            MembershipsList.DataSource = Con.GetData(Query);
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

        int Key = 0;
        private void Edit_Click(object sender, EventArgs e)
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
                    string Query = "Update MembershipsTable set MembershipType = '{0}', Description = '{1}', Cost = '{2}' where MembershipID = {3}";
                    Query = string.Format(Query, Memshiptype, Desc, Cos, Key);
                    Con.setData(Query);
                    ShowMemberships();
                    MessageBox.Show("Membership Updated");
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
                    MessageBox.Show("Please select a membership!!");
                }
                else
                {
                    string Query = "delete from MembershipsTable where MembershipID  ={0}";
                    Query = string.Format(Query, Key);
                    Con.setData(Query);
                    ShowMemberships();
                    MessageBox.Show("Membership deleted");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void MembershipsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MembershipType.Text = MembershipsList.SelectedRows[0].Cells[1].Value.ToString();
            Description.Text = MembershipsList.SelectedRows[0].Cells[2].Value.ToString();
            Cost.Text = MembershipsList.SelectedRows[0].Cells[3].Value.ToString();
            
            if (MembershipType.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(MembershipsList.SelectedRows[0].Cells[0].Value.ToString());
            }
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
    }
}
