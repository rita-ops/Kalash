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
    public partial class AddTrainer : BaseForm
    {
        Functions con;

        //private Form parentForm;
        //private GridTrainers _allTrainersForm;
       // private GridTrainers allTrainersForm;

        public AddTrainer()
        {
            InitializeComponent();
            con = new Functions();
            GetBloodtype();
            editbtn.Visible = false;
            // _allTrainersForm = allTrainersForm;

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

        //Get BloodType
        private void GetBloodtype()
        {
            string Query = "Select blood_id, type from bloodtable";
            DataTable dt = con.GetData(Query);

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
            type.SelectedIndex = 0; // Reset blood type selection
            isactive.Checked = false;
        }


        public void LoadTrainerDetails(int trainerId, string firstname, string lastname, DateTime dob, int exp, string phonenumber, DateTime startdate, DateTime? endDate, int? bloodId, bool isActive)
        {
            this.firstname.Text = firstname;
            this.lastname.Text = lastname;
            this.dob.Value = dob;
            this.experience.SelectedItem = exp.ToString();
            this.phonenumber.Text = phonenumber;
            this.startdate.Value = startdate;
            this.isactive.Checked = isActive;

            // Handle nullable endDate
            if (endDate.HasValue)
            {
                enddate.Value = enddate.Value;
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
                enddate.Enabled = false;
            }


            if (bloodId.HasValue)
            {
                type.SelectedValue = bloodId.Value;
            }
            else
            {
                type.SelectedIndex = 0; // Or handle accordingly
            }

            // Set a flag indicating editing mode
            this.Tag = trainerId; // Store the trainer ID in the Tag property
            addbtn.Visible = false;
            editbtn.Visible = true;
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (firstname.Text == "" || lastname.Text == "" || experience.SelectedIndex == -1 || phonenumber.Text == "" || type.SelectedIndex == -1)
                {
                    MessageBox.Show("Fill required fields");
                    return;
                }

                if (DateTime.TryParse(dob.Text, out DateTime TrainerDOB))
                {
                    if (TrainerDOB >= DateTime.Now.Date)
                    {
                        MessageBox.Show("Please enter a date of birth less than the current date.");
                        return;
                    }

                    int trainerAge = DateTime.Now.Year - TrainerDOB.Year;
                    if (TrainerDOB > DateTime.Now.AddYears(-trainerAge)) trainerAge--;
                    if (trainerAge < 18)
                    {
                        MessageBox.Show("Trainer must be at least 18 years old!");
                        return;
                    }

                    if (startdate.Value > DateTime.Now.Date)
                    {
                        MessageBox.Show("Start date should be less than or equal to the current date.");
                        return;
                    }

                    if (startdate.Value <= TrainerDOB)
                    {
                        MessageBox.Show("Start date should be greater than the date of birth.");
                        return;
                    }

                    // Check if the start date is at least 18 years after the dob
                    if (startdate.Value < TrainerDOB.AddYears(18))
                    {
                        MessageBox.Show("Start date should be at least 18 years after the date of birth.");
                        return;
                    }

                    // Declare endDateValue as nullable
                    string endDateValue = null;

                    if (checkBox1.Checked)
                    {
                        // If checkbox is checked, get the selected date and validate it
                        endDateValue = enddate.Value.Date.ToString("yyyy-MM-dd");

                        if (enddate.Value > DateTime.Now.Date)
                        {
                            MessageBox.Show("End date should be less than or equal to the current date.");
                            return;
                        }
                    }
                    // If checkbox is not checked, endDateValue remains null

                    string number = phonenumber.Text.Trim();
                    if (!Regex.IsMatch(number, @"^(01|03|04|05|06|07|08|09|71|76|81)-\d{6}$"))
                    {
                        MessageBox.Show("Phone number should start with correct code like '01', '03', or '71' and have exactly 6 digits after the hyphen.");
                        return;
                    }
                    else
                    {
                        // Trim and capitalize first and last names
                        string fname = Capitalize(firstname.Text.Trim());
                        string lname = Capitalize(lastname.Text.Trim());
                        int exp = Convert.ToInt32(experience.SelectedItem.ToString());
                        string Number = phonenumber.Text.Trim();
                        int? bloodtype = type.SelectedValue.ToString() != "0" ? (int?)Convert.ToInt32(type.SelectedValue.ToString()) : null;
                        bool active = isactive.Checked;

                        string Query = @"INSERT INTO trainerstable (firstname, lastname, dob, experience, phonenumber, startdate, enddate, blood_id, isactive) 
VALUES ('{0}', '{1}', '{2}', {3}, '{4}', '{5}', {6}, {7}, '{8}')";
                        Query = string.Format(Query, fname, lname, TrainerDOB.ToString("yyyy-MM-dd"), exp, Number, startdate.Value.Date.ToString("yyyy-MM-dd"),
                            endDateValue != null ? $"'{endDateValue}'" : "NULL", bloodtype.HasValue ? bloodtype.ToString() : "NULL", active ? "TRUE" : "FALSE");

                        con.setData(Query);
                        MessageBox.Show("Trainer added");

                        // Redirect to alltrainers form
                        GridTrainers alltrainersForm = new GridTrainers();
                        this.Hide();
                        alltrainersForm.Show();
                       
                    }
                }
                else
                {
                    MessageBox.Show("Invalid date of birth.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }



        private void editbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (firstname.Text == "" || lastname.Text == "" || experience.SelectedIndex == -1 || phonenumber.Text == "" || type.SelectedIndex == -1)
                {
                    MessageBox.Show("Fill required fields");
                    return;
                }

                if (DateTime.TryParse(dob.Text, out DateTime TrainerDOB))
                {
                    if (TrainerDOB >= DateTime.Now.Date)
                    {
                        MessageBox.Show("Please enter a date of birth less than the current date.");
                        return;
                    }

                    int trainerAge = DateTime.Now.Year - TrainerDOB.Year;
                    if (TrainerDOB > DateTime.Now.AddYears(-trainerAge)) trainerAge--;
                    if (trainerAge < 18)
                    {
                        MessageBox.Show("Trainer must be at least 18 years old!");
                        return;
                    }

                    if (startdate.Value > DateTime.Now.Date)
                    {
                        MessageBox.Show("Start date should be less than or equal to the current date.");
                        return;
                    }

                    if (startdate.Value <= TrainerDOB)
                    {
                        MessageBox.Show("Start date should be greater than the date of birth.");
                        return;
                    }

                    // Check if the start date is at least 18 years after the dob
                    if (startdate.Value < TrainerDOB.AddYears(18))
                    {
                        MessageBox.Show("Start date should be at least 18 years after the date of birth.");
                        return;
                    }

                    // Handle nullable end date based on checkbox
                    string endDateValue = null;
                    if (checkBox1.Checked)
                    {
                        if (enddate.Value > DateTime.Now.Date)
                        {
                            MessageBox.Show("End date should be less than or equal to the current date.");
                            return;
                        }
                        endDateValue = enddate.Value.Date.ToString("yyyy-MM-dd");
                    }

                    // Validate phone number format
                    string number = phonenumber.Text.Trim();
                    if (!Regex.IsMatch(number, @"^(01|03|04|05|06|07|08|09|71|76|81)-\d{6}$"))
                    {
                        MessageBox.Show("Phone number should start with correct code like '01', '03', or '71' and have exactly 6 digits after the hyphen.");
                        return;
                    }

                    // Prepare data for update
                    string fname = Capitalize(firstname.Text.Trim());
                    string lname = Capitalize(lastname.Text.Trim());
                    int exp = Convert.ToInt32(experience.SelectedItem.ToString());
                    string Number = phonenumber.Text.Trim();

                    // Safely handle nullable blood type
                    int? bloodtype = type.SelectedValue != null && type.SelectedValue.ToString() != "0" ? (int?)Convert.ToInt32(type.SelectedValue.ToString()) : null;
                    bool active = isactive.Checked;

                    // Check if trainerId is valid
                    if (this.Tag == null || !(this.Tag is int))
                    {
                        MessageBox.Show("Invalid trainer ID.");
                        return;
                    }

                    int trainerId = (int)this.Tag;

                    // Construct SQL query
                    string Query = @"UPDATE trainerstable 
                             SET firstname = '{0}', lastname = '{1}', dob = '{2}', experience = {3}, phonenumber = '{4}', startdate = '{5}', enddate = {6}, blood_id = {7}, isactive = '{8}' 
                             WHERE trainer_id = {9}";

                    // Format the query, handling nullable enddate and blood_id
                    Query = string.Format(Query, fname, lname, TrainerDOB.ToString("yyyy-MM-dd"), exp, Number, startdate.Value.Date.ToString("yyyy-MM-dd"),
                                          endDateValue != null ? $"'{endDateValue}'" : "NULL",
                                          bloodtype.HasValue ? bloodtype.ToString() : "NULL",
                                          active ? "TRUE" : "FALSE", trainerId);

                    // Execute query to update trainer information
                    con.setData(Query);

                    MessageBox.Show("Trainer updated successfully.");
                    Reset();

                    // Redirect to alltrainers form
                    GridTrainers alltrainersForm = new GridTrainers();
                    this.Hide();
                    alltrainersForm.Show();
                 
                }
                else
                {
                    MessageBox.Show("Invalid date of birth.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Enable the enddate picker when the checkbox is checked
                enddate.Enabled = true;
            }
            else
            {
                // Disable the enddate picker when the checkbox is unchecked
                enddate.Enabled = false;
                enddate.Value = DateTime.Now; // Reset to today's date or any other date
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
