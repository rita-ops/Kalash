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
    public partial class Payments : Form
    {
        Functions Con;
        private DataGridView dataGridView;

        public Payments()
        {
            InitializeComponent();
            Con = new Functions();
            ShowPayments();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        DataTable table = new DataTable();

        private void ShowPayments()
        {
            string Query = "select PaymentsTable.PaymentId,  PaymentsTable.ClientName, PaymentsTable.Date, PaymentsTable.Phone, PaymentsTable.Amount, PaymentsTable.Currency from PaymentsTable";
            dataGridView1.DataSource = Con.GetData(Query);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClientName.SelectedIndex == -1 || Amount.Text == "" || Currency.SelectedIndex == -1)

                {
                    MessageBox.Show("Please enter the required fields!!");
                }
                else
                {
                    string Name = ClientName.SelectedItem.ToString();
                    string PayDate = Date.Value.Date.ToString();
                    string Number = Phone.Text;
                    string Amo = Amount.Text;
                    string Curr = Currency.SelectedItem.ToString();
                    string Query = "insert into PaymentsTable values('{0}','{1}','{2}','{3}','{4}')";
                    Query = string.Format(Query, Name, Date.Value.Date, Number ,Amo, Curr);
                    Con.setData(Query);
                    ShowPayments();
                    MessageBox.Show("Payment Confirmed");   
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {

            if (ClientName.SelectedIndex == -1 || Amount.Text == "" || Currency.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter the required fields!!");
            }
            else
            {
                int Key = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                string Name = ClientName.SelectedItem.ToString();
                string PayDate = Date.Value.Date.ToString();
                string Number = Phone.Text;
                string Amo = Amount.Text;
                string Curr = Currency.SelectedItem.ToString();
                string Query = "update PaymentsTable set ClientName= '{0}' , Date = '{1}', Phone = '{2}', Amount = '{3}' , Currency = '{4}' where PaymentId = {5}";
                Query = string.Format(Query, Name, Date.Value.Date, Number,Amo, Curr, Key);
                Con.setData(Query);
                ShowPayments();
                MessageBox.Show("Payment Updated");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                ClientName.SelectedItem = selectedRow.Cells[1].Value.ToString();
                Date.Text = selectedRow.Cells[2].Value.ToString();
                Phone.Text = selectedRow.Cells[3].Value.ToString();
                Amount.Text = selectedRow.Cells[4].Value.ToString();
                Currency.SelectedItem = selectedRow.Cells[5].Value.ToString();

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

        private void MemberShipLbl_Click(object sender, EventArgs e)
        {
            Memberships Obj = new Memberships();
            Obj.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Bills Obj = new Bills();
            Obj.Show();
            this.Hide();
        }

        private void BillsLbl_Click(object sender, EventArgs e)
        {
            Bills Obj = new Bills();
            Obj.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnviewpayments_Click(object sender, EventArgs e)
        {
            // Open the SecondForm and pass a reference to the DataGridView
            PaymentForm Form = new PaymentForm(dataGridView1);
            Form.Show();
        }
    }
}
