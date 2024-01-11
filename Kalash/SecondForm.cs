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


        private void PrintPreviewItem_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;

            // Optional: Set up the print preview dialog properties
            // printPreviewDialog.Width = 600;
            // printPreviewDialog.Height = 400;

            printPreviewDialog.ShowDialog();
        }

        private void PrintGridItem_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Set the desired width for the printed content
            int printWidth = 800; // Adjust as needed

            // Calculate the scale factor to fit the content within the desired width
            float scale = printWidth / (float)BillsList.Width;

            // Create a new bitmap with the adjusted width
            Bitmap bitmap = new Bitmap((int)(BillsList.Width * scale), (int)(BillsList.Height * scale));
            BillsList.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));

            // Draw the scaled bitmap on the printed page
            e.Graphics.DrawImage(bitmap, new Point(10, 50)); // Adjust the location as needed
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

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Application.Restart();
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

        private void BillsLbl_Click(object sender, EventArgs e)
        {
            Bills Obj = new Bills();
            Obj.Show();
            this.Hide();
        }

        private void PaymentLbl_Click(object sender, EventArgs e)
        {
            Payments Obj = new Payments();
            Obj.Show();
            this.Hide();
        }
    }
}
