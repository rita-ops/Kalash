using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalash
{
    public partial class SecondForm : Form
    {

        Functions Con;
        public SecondForm(DataGridView dataGridView1)
        {
            InitializeComponent();
            Con = new Functions();
            ShowBills();
            BillsList.Columns[4].Visible = false;
            LoadDataAndCalculateTotals();
        }

        private void ShowBills()
        {
            string Query = "SELECT CONCAT(MembersTable.MemberFName ,' ', MembersTable.MemberLName ,' ') AS Member , BillsTable.Date, BillsTable.Amount , BillsTable.Currency, BillsTable.BillId FROM MembersTable INNER JOIN BillsTable ON MembersTable.MembersID = BillsTable.MembersID";
            BillsList.DataSource = Con.GetData(Query);
        }


        private void trainerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SearchTxtBox_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = SearchTxtBox.Text.Trim();
            BindingSource bs = new BindingSource();
            bs.DataSource = BillsList.DataSource;
            bs.Filter = string.Format("Member LIKE '%{0}%'", searchTerm);
            BillsList.DataSource = bs;

            decimal SumD = 0;
            decimal SumLBP = 0;

            foreach (DataGridViewRow row in BillsList.Rows)
            {
                // Replace "PaymentAmount" and "CurrencyType" with the actual column names in your DataGridView
                DataGridViewCell paymentCell = row.Cells["Amount"];
                DataGridViewCell currencyCell = row.Cells["Currency"];

                // Check if the cells are not null and contain valid values
                if (paymentCell.Value != null && currencyCell.Value != null)
                {
                    decimal Amount;
                    if (decimal.TryParse(paymentCell.Value.ToString(), out Amount))
                    {
                        string Currency = currencyCell.Value.ToString();

                        // Convert to dollars and Lebanese pounds based on exchange rates
                        if (Currency == "$")
                        {
                            SumD += Amount;
                        }
                        else if (Currency == "LBP")
                        {
                            SumLBP += Amount;
                        }
                    }
                }
            }

            // Display or use the calculated totals
            LblTotalDol.Text = SumD.ToString();
            LblTotalLBP.Text = SumLBP.ToString();
        }


        private void LoadDataAndCalculateTotals()
        {
            decimal SumD = 0;
            decimal SumLBP = 0;

            foreach (DataGridViewRow row in BillsList.Rows)
            {
                // Replace "PaymentAmount" and "CurrencyType" with the actual column names in your DataGridView
                DataGridViewCell paymentCell = row.Cells["Amount"];
                DataGridViewCell currencyCell = row.Cells["Currency"];

                // Check if the cells are not null and contain valid values
                if (paymentCell.Value != null && currencyCell.Value != null)
                {
                    decimal Amount;
                    if (decimal.TryParse(paymentCell.Value.ToString(), out Amount))
                    {
                        string Currency = currencyCell.Value.ToString();

                        // Convert to dollars and Lebanese pounds based on exchange rates
                        if (Currency == "$")
                        {
                            SumD += Amount;
                        }
                        else if (Currency == "LBP")
                        {
                            SumLBP += Amount;
                        }
                    }
                }
            }

            // Display or use the calculated totals
            LblTotalDol.Text = SumD.ToString();
            LblTotalLBP.Text = SumLBP.ToString();
        }

        private void SecondForm_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}

