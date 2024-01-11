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
    public partial class Report_Payments : Form
    {

        public string LblTotalDol { get; private set; }
        public string LblTotalLBP { get; private set; }


   
        public Report_Payments(DataGridView dataGridView1)
        {
            InitializeComponent();
        }

        private void Report_Payments_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'KalashDBDataSet1.PaymentsTable' table. You can move, or remove it, as needed.
            this.PaymentsTableTableAdapter.Fill(this.KalashDBDataSet1.PaymentsTable);

            // Access the value of the textbox from the original form
            string valueFromOriginalForm = LblTotalDol;
            string valueFromOriginalForm1 = LblTotalLBP;
            string valueFromOriginalForm2 = Txt1.Text;
            string valueFromOriginalForm3 = Txt2.Text;
               

            // Use the value as needed
            // For example, set it to a label in the new form
            //label1.Text = valueFromOriginalForm;
            //label2.Text = valueFromOriginalForm1;
            this.reportViewer1.RefreshReport();
        }

    }
}
