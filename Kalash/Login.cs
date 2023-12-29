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
    public partial class Login : Form
    {

        Functions Con;
        public Login()
        {
            InitializeComponent();
            Con = new Functions();
        }

        public static int UserId;

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (Username.Text == "" || Password.Text == "")
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
            else
            {
                try
                {
                    string Query = "select * from UsersTable where Username = '{0}' and Password = '{1}'";
                    Query = string.Format(Query, Username.Text, Password.Text);
                    DataTable dt = Con.GetData(Query);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Invalid username");
                    }
                    else
                    {
                        UserId = Convert.ToInt32(dt.Rows[0][0].ToString());
                        Members Obj = new Members();
                        Obj.Show();
                        this.Hide();
                    }

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}


