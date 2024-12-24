using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalash
{
    public partial class AddMember : BaseForm
    {

        Functions Con;

        //private Form parentForm;
        private GridMembers _allMembersForm;

        public AddMember(GridMembers allMembersForm)
        {
            InitializeComponent();
            Con = new Functions();
            GetMemberships();
            GetBloodtype();
            editbtn.Visible = false;
            _allMembersForm = allMembersForm;

            // Register KeyPress event handlers
            firstname.KeyPress += firstname_KeyPress;
            lastname.KeyPress += lastname_KeyPress;

        }

        //Capitalize firstname , lastname
        private string Capitalize(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }


        //Get MembershipType
        private void GetMemberships()
        {
            string Query = "Select membership_id, description from membershiptable";
            DataTable dt = Con.GetData(Query);

            // Create a new row with the default text
            DataRow newRow = dt.NewRow();
            newRow["membership_id"] = 0; // Set an ID for the default option
            newRow["description"] = "Select a membership";
            dt.Rows.InsertAt(newRow, 0); // Insert at the top of the DataTable

            description.DisplayMember = "description";
            description.ValueMember = "membership_id";
            description.DataSource = dt;
        }

        //Get BloodType
        private void GetBloodtype()
        {
            string Query = "Select blood_id, type from bloodtable";
            DataTable dt = Con.GetData(Query);

            // Create a new row with the default text
            DataRow newRow = dt.NewRow();
            newRow["blood_id"] = 0; // Set an ID for the default option
            newRow["type"] = "Select blood type";
            dt.Rows.InsertAt(newRow, 0); // Insert at the top of the DataTable

            type.DisplayMember = "type";
            type.ValueMember = "blood_id";
            type.DataSource = dt;
        }

        //Reset function to empty fields
        private void Reset()
        {
            firstname.Text = string.Empty;
            lastname.Text = string.Empty;
            phonenumber.Text = string.Empty;
            description.SelectedIndex = 0; // Reset membership selection
            type.SelectedIndex = 0; // Reset blood type selection
            isactive.Checked = false;
        }

        public void LoadMemberDetails(int memberId, string firstname, string lastname, DateTime dob, DateTime joindate, string phonenumber, int membershipId, int? bloodId, bool isActive)
        {
            this.firstname.Text = firstname;
            this.lastname.Text = lastname;
            this.dob.Value = dob;
            this.joindate.Value = joindate;
            this.phonenumber.Text = phonenumber;
            this.description.SelectedValue = membershipId;
            this.isactive.Checked = isActive;


            if (bloodId.HasValue)
            {
                type.SelectedValue = bloodId.Value;
            }
            else
            {
                type.SelectedIndex = 0; // Or handle accordingly
            }

            // Set a flag indicating editing mode
            this.Tag = memberId; // Store the member ID in the Tag property
            addbtn.Visible = false;
            editbtn.Visible = true;
        }

        private void savebtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (firstname.Text == "" || lastname.Text == "" || phonenumber.Text == "" || description.SelectedIndex == -1)
                {
                    MessageBox.Show("Fill required fields");
                    return;
                }

                if (DateTime.TryParse(dob.Text, out DateTime memberDOB))
                {
                    if (memberDOB > DateTime.Now || memberDOB == DateTime.Now.Date)
                    {
                        MessageBox.Show("Please enter a date of birth less than the current date!");
                        return;
                    }

                    int memberAge = DateTime.Now.Year - memberDOB.Year;
                    if (memberDOB > DateTime.Now.AddYears(-memberAge)) memberAge--;

                    if (memberAge < 3)
                    {
                        MessageBox.Show("Member must be at least 3 years old!");
                        return;
                    }

                    if (joindate.Value > DateTime.Now)
                    {
                        MessageBox.Show("Join date should be less than or equal to the current date.");
                        return;
                    }

                    string number = phonenumber.Text.Trim();
                    if (!Regex.IsMatch(number, @"^(03|70|71|76|81)-\d{6}$"))
                    {
                        MessageBox.Show("Phone number should start with the correct code like '03', or '71' and have exactly 6 digits after the hyphen.");
                        return;
                    }

                    // Trim and capitalize first and last names
                    string fname = Capitalize(firstname.Text.Trim());
                    string lname = Capitalize(lastname.Text.Trim());
                    string date = dob.Value.Date.ToString("yyyy-MM-dd");
                    string jdate = joindate.Value.Date.ToString("yyyy-MM-dd");
                    string Number = phonenumber.Text.Trim();
                    int memship = Convert.ToInt32(description.SelectedValue.ToString());
                    int? bloodtype = type.SelectedValue.ToString() != "0" ? (int?)Convert.ToInt32(type.SelectedValue.ToString()) : null;
                    bool active = isactive.Checked;

                    string Query = "INSERT INTO memberstable (firstname, lastname, dob, joindate, phonenumber, membership_id, blood_id, isactive) " +
                                   "VALUES ('{0}','{1}','{2}','{3}','{4}',{5},{6},'{7}')";
                    Query = string.Format(Query, fname, lname, date, jdate, Number, memship, bloodtype.HasValue ? bloodtype.ToString() : "NULL", active ? 1 : 0);
                    Con.setData(Query);
                    MessageBox.Show("Member added");
                    Reset();

                    // Redirect to allmembers form
                    GridMembers allmembersForm = new GridMembers();
                    this.Hide();
                    allmembersForm.Show();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void editbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (firstname.Text == "" || lastname.Text == "" || phonenumber.Text == "" || description.SelectedIndex == -1)
                {
                    MessageBox.Show("Fill required fields");
                    return;
                }

                if (DateTime.TryParse(dob.Text, out DateTime memberDOB))
                {
                    if (memberDOB > DateTime.Now || memberDOB == DateTime.Now.Date)
                    {
                        MessageBox.Show("Please enter a date of birth less than the current date.");
                        return;
                    }

                    int memberAge = DateTime.Now.Year - memberDOB.Year;
                    if (memberDOB > DateTime.Now.AddYears(-memberAge)) memberAge--;

                    if (memberAge < 3)
                    {
                        MessageBox.Show("Member must be at least 3 years old!");
                        return;
                    }

                    if (joindate.Value > DateTime.Now.Date)
                    {
                        MessageBox.Show("Join date should be less than or equal to the current date.");
                        return;
                    }

                    string number = phonenumber.Text.Trim();
                    if (!Regex.IsMatch(number, @"^(01|03|04|05|06|07|08|09|71|76|81)-\d{6}$"))
                    {
                        MessageBox.Show("Phone number should start with correct code like '01', '03', or '71' and have exactly 6 digits after the hyphen.");
                        return;
                    }

                    // Trim and capitalize first and last names
                    string fname = Capitalize(firstname.Text.Trim());
                    string lname = Capitalize(lastname.Text.Trim());

                    string date = dob.Value.Date.ToString("yyyy-MM-dd");
                    string jdate = joindate.Value.Date.ToString("yyyy-MM-dd");
                    string Number = phonenumber.Text.Trim();
                    int memship = Convert.ToInt32(description.SelectedValue.ToString());
                    int? bloodtype = type.SelectedValue.ToString() != "0" ? (int?)Convert.ToInt32(type.SelectedValue.ToString()) : null;
                    bool active = isactive.Checked;
                    int memberId = (int)this.Tag;

                    string Query = @"UPDATE memberstable 
                 SET firstname = '{0}', lastname = '{1}', dob = '{2}', joindate = '{3}', phonenumber = '{4}', membership_id = {5}, blood_id = {6}, isactive = '{7}' 
                 WHERE member_id = {8}";
                    Query = string.Format(Query, fname, lname, date, jdate, Number, memship, bloodtype.HasValue ? bloodtype.ToString() : "NULL", active ? 1 : 0, memberId);
                    Con.setData(Query);
                    MessageBox.Show("Member updated");
                    Reset();

                    // Redirect to allmembers form
                    GridMembers allmembersForm = new GridMembers();
                    this.Hide();
                    allmembersForm.Show();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void firstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow backspace to delete characters
            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }

            // Allow only letters and hyphen
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true; // Ignore any other character
            }

            // Allow hyphen only if it's not at the beginning or after another hyphen
            if (e.KeyChar == '-' && (firstname.Text.Length == 0 || firstname.Text.Contains("-") || !char.IsLetter(firstname.Text[firstname.Text.Length - 1])))
            {
                e.Handled = true; // Ignore if hyphen is at the start or after another hyphen
            }
        }

        private void lastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow backspace to delete characters
            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }

            // Allow only letters and hyphen
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true; // Ignore any other character
            }

            // Allow hyphen only if it's not at the beginning or after another hyphen
            if (e.KeyChar == '-' && (lastname.Text.Length == 0 || lastname.Text.Contains("-") || !char.IsLetter(lastname.Text[lastname.Text.Length - 1])))
            {
                e.Handled = true; // Ignore if hyphen is at the start or after another hyphen
            }
        }

    }
}
