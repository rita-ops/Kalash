namespace Kalash
{
    partial class Members
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Members));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Logout = new System.Windows.Forms.Label();
            this.Edit = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PaymentLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BillsLbl = new System.Windows.Forms.Label();
            this.MemberShipLbl = new System.Windows.Forms.Label();
            this.MemberLbl = new System.Windows.Forms.Label();
            this.TrainersLbl = new System.Windows.Forms.Label();
            this.Phone = new System.Windows.Forms.TextBox();
            this.MemberLName = new System.Windows.Forms.TextBox();
            this.MemberFName = new System.Windows.Forms.TextBox();
            this.MembershipType = new System.Windows.Forms.ComboBox();
            this.BloodType = new System.Windows.Forms.ComboBox();
            this.Gender = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.membersIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memberFNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memberLNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dOBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.joinDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.membershipIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bloodTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trainersIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.membersTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kalashDBDataSet8 = new Kalash.KalashDBDataSet8();
            this.DOB = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.JoinDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.Timing = new System.Windows.Forms.ComboBox();
            this.Trainer = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.membersTableTableAdapter = new Kalash.KalashDBDataSet8TableAdapters.MembersTableTableAdapter();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.membersTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kalashDBDataSet8)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Logout
            // 
            this.Logout.AutoSize = true;
            this.Logout.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logout.ForeColor = System.Drawing.Color.White;
            this.Logout.Location = new System.Drawing.Point(59, 530);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(51, 17);
            this.Logout.TabIndex = 4;
            this.Logout.Text = "Logout";
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // Edit
            // 
            this.Edit.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Edit.Location = new System.Drawing.Point(477, 195);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(75, 33);
            this.Edit.TabIndex = 11;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = false;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Save.Location = new System.Drawing.Point(616, 195);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 33);
            this.Save.TabIndex = 10;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.PaymentLbl);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.BillsLbl);
            this.panel2.Controls.Add(this.MemberShipLbl);
            this.panel2.Controls.Add(this.MemberLbl);
            this.panel2.Controls.Add(this.TrainersLbl);
            this.panel2.Location = new System.Drawing.Point(16, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(169, 475);
            this.panel2.TabIndex = 3;
            // 
            // PaymentLbl
            // 
            this.PaymentLbl.AutoSize = true;
            this.PaymentLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PaymentLbl.Location = new System.Drawing.Point(43, 291);
            this.PaymentLbl.Name = "PaymentLbl";
            this.PaymentLbl.Size = new System.Drawing.Size(68, 17);
            this.PaymentLbl.TabIndex = 2;
            this.PaymentLbl.Text = "Payments";
            this.PaymentLbl.Click += new System.EventHandler(this.PaymentLbl_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(30, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // BillsLbl
            // 
            this.BillsLbl.AutoSize = true;
            this.BillsLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BillsLbl.Location = new System.Drawing.Point(43, 256);
            this.BillsLbl.Name = "BillsLbl";
            this.BillsLbl.Size = new System.Drawing.Size(31, 17);
            this.BillsLbl.TabIndex = 0;
            this.BillsLbl.Text = "Bills";
            this.BillsLbl.Click += new System.EventHandler(this.BillsLbl_Click);
            // 
            // MemberShipLbl
            // 
            this.MemberShipLbl.AutoSize = true;
            this.MemberShipLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemberShipLbl.Location = new System.Drawing.Point(43, 223);
            this.MemberShipLbl.Name = "MemberShipLbl";
            this.MemberShipLbl.Size = new System.Drawing.Size(90, 17);
            this.MemberShipLbl.TabIndex = 0;
            this.MemberShipLbl.Text = "Memberships";
            this.MemberShipLbl.Click += new System.EventHandler(this.MemberShipLbl_Click);
            // 
            // MemberLbl
            // 
            this.MemberLbl.AutoSize = true;
            this.MemberLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemberLbl.Location = new System.Drawing.Point(43, 193);
            this.MemberLbl.Name = "MemberLbl";
            this.MemberLbl.Size = new System.Drawing.Size(65, 17);
            this.MemberLbl.TabIndex = 0;
            this.MemberLbl.Text = "Members";
            // 
            // TrainersLbl
            // 
            this.TrainersLbl.AutoSize = true;
            this.TrainersLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrainersLbl.Location = new System.Drawing.Point(43, 160);
            this.TrainersLbl.Name = "TrainersLbl";
            this.TrainersLbl.Size = new System.Drawing.Size(55, 17);
            this.TrainersLbl.TabIndex = 0;
            this.TrainersLbl.Text = "Trainers";
            this.TrainersLbl.Click += new System.EventHandler(this.TrainersLbl_Click);
            // 
            // Phone
            // 
            this.Phone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Phone.Location = new System.Drawing.Point(39, 146);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(159, 29);
            this.Phone.TabIndex = 5;
            // 
            // MemberLName
            // 
            this.MemberLName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemberLName.Location = new System.Drawing.Point(252, 82);
            this.MemberLName.Name = "MemberLName";
            this.MemberLName.Size = new System.Drawing.Size(159, 29);
            this.MemberLName.TabIndex = 1;
            // 
            // MemberFName
            // 
            this.MemberFName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemberFName.Location = new System.Drawing.Point(39, 82);
            this.MemberFName.Name = "MemberFName";
            this.MemberFName.Size = new System.Drawing.Size(159, 29);
            this.MemberFName.TabIndex = 0;
            // 
            // MembershipType
            // 
            this.MembershipType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MembershipType.FormattingEnabled = true;
            this.MembershipType.Location = new System.Drawing.Point(898, 82);
            this.MembershipType.Name = "MembershipType";
            this.MembershipType.Size = new System.Drawing.Size(159, 29);
            this.MembershipType.TabIndex = 4;
            // 
            // BloodType
            // 
            this.BloodType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BloodType.FormattingEnabled = true;
            this.BloodType.Items.AddRange(new object[] {
            "A+",
            "B+",
            "O+",
            "AB+",
            "A-",
            "B-",
            "O-",
            "AB-"});
            this.BloodType.Location = new System.Drawing.Point(464, 146);
            this.BloodType.Name = "BloodType";
            this.BloodType.Size = new System.Drawing.Size(159, 29);
            this.BloodType.TabIndex = 7;
            // 
            // Gender
            // 
            this.Gender.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gender.FormattingEnabled = true;
            this.Gender.Items.AddRange(new object[] {
            "Female",
            "Male"});
            this.Gender.Location = new System.Drawing.Point(681, 146);
            this.Gender.Name = "Gender";
            this.Gender.Size = new System.Drawing.Size(159, 29);
            this.Gender.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Phone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(541, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Members List";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(249, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Timing";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(678, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Join Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(249, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Last Name";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(36, 66);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "First Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(895, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Membership Type";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(461, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Blood Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(678, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Gender";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Members";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.dataGridView2);
            this.panel3.Controls.Add(this.DOB);
            this.panel3.Controls.Add(this.JoinDate);
            this.panel3.Controls.Add(this.Edit);
            this.panel3.Controls.Add(this.Save);
            this.panel3.Controls.Add(this.Phone);
            this.panel3.Controls.Add(this.MemberLName);
            this.panel3.Controls.Add(this.MemberFName);
            this.panel3.Controls.Add(this.MembershipType);
            this.panel3.Controls.Add(this.Timing);
            this.panel3.Controls.Add(this.BloodType);
            this.panel3.Controls.Add(this.Trainer);
            this.panel3.Controls.Add(this.Gender);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(155, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1213, 744);
            this.panel3.TabIndex = 8;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.membersIDDataGridViewTextBoxColumn,
            this.memberFNameDataGridViewTextBoxColumn,
            this.memberLNameDataGridViewTextBoxColumn,
            this.dOBDataGridViewTextBoxColumn,
            this.joinDateDataGridViewTextBoxColumn,
            this.membershipIDDataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn,
            this.timingDataGridViewTextBoxColumn,
            this.bloodTypeDataGridViewTextBoxColumn,
            this.genderDataGridViewTextBoxColumn,
            this.trainersIDDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.membersTableBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(41, 274);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.RowHeadersWidth = 50;
            this.dataGridView2.RowTemplate.Height = 20;
            this.dataGridView2.RowTemplate.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(1128, 407);
            this.dataGridView2.TabIndex = 12;
            this.dataGridView2.SelectionChanged += new System.EventHandler(this.dataGridView2_SelectionChanged);
            // 
            // membersIDDataGridViewTextBoxColumn
            // 
            this.membersIDDataGridViewTextBoxColumn.DataPropertyName = "MembersID";
            this.membersIDDataGridViewTextBoxColumn.HeaderText = "MembersID";
            this.membersIDDataGridViewTextBoxColumn.Name = "membersIDDataGridViewTextBoxColumn";
            this.membersIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.membersIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // memberFNameDataGridViewTextBoxColumn
            // 
            this.memberFNameDataGridViewTextBoxColumn.DataPropertyName = "MemberFName";
            this.memberFNameDataGridViewTextBoxColumn.HeaderText = "First Name";
            this.memberFNameDataGridViewTextBoxColumn.Name = "memberFNameDataGridViewTextBoxColumn";
            this.memberFNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.memberFNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // memberLNameDataGridViewTextBoxColumn
            // 
            this.memberLNameDataGridViewTextBoxColumn.DataPropertyName = "MemberLName";
            this.memberLNameDataGridViewTextBoxColumn.HeaderText = "Last Name";
            this.memberLNameDataGridViewTextBoxColumn.Name = "memberLNameDataGridViewTextBoxColumn";
            this.memberLNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.memberLNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // dOBDataGridViewTextBoxColumn
            // 
            this.dOBDataGridViewTextBoxColumn.DataPropertyName = "DOB";
            this.dOBDataGridViewTextBoxColumn.HeaderText = "DOB";
            this.dOBDataGridViewTextBoxColumn.Name = "dOBDataGridViewTextBoxColumn";
            this.dOBDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // joinDateDataGridViewTextBoxColumn
            // 
            this.joinDateDataGridViewTextBoxColumn.DataPropertyName = "JoinDate";
            this.joinDateDataGridViewTextBoxColumn.HeaderText = "JoinDate";
            this.joinDateDataGridViewTextBoxColumn.Name = "joinDateDataGridViewTextBoxColumn";
            this.joinDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // membershipIDDataGridViewTextBoxColumn
            // 
            this.membershipIDDataGridViewTextBoxColumn.DataPropertyName = "MembershipID";
            this.membershipIDDataGridViewTextBoxColumn.HeaderText = "Membership Type";
            this.membershipIDDataGridViewTextBoxColumn.Name = "membershipIDDataGridViewTextBoxColumn";
            this.membershipIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.membershipIDDataGridViewTextBoxColumn.Width = 150;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "Phone";
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            this.phoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // timingDataGridViewTextBoxColumn
            // 
            this.timingDataGridViewTextBoxColumn.DataPropertyName = "Timing";
            this.timingDataGridViewTextBoxColumn.HeaderText = "Timing";
            this.timingDataGridViewTextBoxColumn.Name = "timingDataGridViewTextBoxColumn";
            this.timingDataGridViewTextBoxColumn.ReadOnly = true;
            this.timingDataGridViewTextBoxColumn.Width = 50;
            // 
            // bloodTypeDataGridViewTextBoxColumn
            // 
            this.bloodTypeDataGridViewTextBoxColumn.DataPropertyName = "BloodType";
            this.bloodTypeDataGridViewTextBoxColumn.HeaderText = "BloodType";
            this.bloodTypeDataGridViewTextBoxColumn.Name = "bloodTypeDataGridViewTextBoxColumn";
            this.bloodTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.bloodTypeDataGridViewTextBoxColumn.Width = 70;
            // 
            // genderDataGridViewTextBoxColumn
            // 
            this.genderDataGridViewTextBoxColumn.DataPropertyName = "Gender";
            this.genderDataGridViewTextBoxColumn.HeaderText = "Gender";
            this.genderDataGridViewTextBoxColumn.Name = "genderDataGridViewTextBoxColumn";
            this.genderDataGridViewTextBoxColumn.ReadOnly = true;
            this.genderDataGridViewTextBoxColumn.Width = 65;
            // 
            // trainersIDDataGridViewTextBoxColumn
            // 
            this.trainersIDDataGridViewTextBoxColumn.DataPropertyName = "TrainersID";
            this.trainersIDDataGridViewTextBoxColumn.HeaderText = "Trainers";
            this.trainersIDDataGridViewTextBoxColumn.Name = "trainersIDDataGridViewTextBoxColumn";
            this.trainersIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.trainersIDDataGridViewTextBoxColumn.Width = 150;
            // 
            // membersTableBindingSource
            // 
            this.membersTableBindingSource.DataMember = "MembersTable";
            this.membersTableBindingSource.DataSource = this.kalashDBDataSet8;
            // 
            // kalashDBDataSet8
            // 
            this.kalashDBDataSet8.DataSetName = "KalashDBDataSet8";
            this.kalashDBDataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DOB
            // 
            this.DOB.Checked = true;
            this.DOB.FillColor = System.Drawing.Color.DarkSlateGray;
            this.DOB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DOB.Location = new System.Drawing.Point(464, 82);
            this.DOB.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DOB.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DOB.Name = "DOB";
            this.DOB.Size = new System.Drawing.Size(159, 29);
            this.DOB.TabIndex = 2;
            this.DOB.Value = new System.DateTime(2023, 12, 9, 9, 56, 29, 7);
            // 
            // JoinDate
            // 
            this.JoinDate.Checked = true;
            this.JoinDate.FillColor = System.Drawing.Color.DarkSlateGray;
            this.JoinDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.JoinDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.JoinDate.Location = new System.Drawing.Point(681, 82);
            this.JoinDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.JoinDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.JoinDate.Name = "JoinDate";
            this.JoinDate.Size = new System.Drawing.Size(159, 29);
            this.JoinDate.TabIndex = 3;
            this.JoinDate.Value = new System.DateTime(2023, 12, 9, 9, 56, 29, 7);
            // 
            // Timing
            // 
            this.Timing.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Timing.FormattingEnabled = true;
            this.Timing.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.Timing.Location = new System.Drawing.Point(252, 146);
            this.Timing.Name = "Timing";
            this.Timing.Size = new System.Drawing.Size(159, 29);
            this.Timing.TabIndex = 6;
            // 
            // Trainer
            // 
            this.Trainer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Trainer.FormattingEnabled = true;
            this.Trainer.Location = new System.Drawing.Point(898, 146);
            this.Trainer.Name = "Trainer";
            this.Trainer.Size = new System.Drawing.Size(159, 29);
            this.Trainer.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(461, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Date Of Birth";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(895, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Trainer";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.Logout);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 744);
            this.panel1.TabIndex = 7;
            // 
            // membersTableTableAdapter
            // 
            this.membersTableTableAdapter.ClearBeforeFill = true;
            // 
            // Members
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Members";
            this.Text = "Members";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Members_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.membersTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kalashDBDataSet8)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Logout;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label PaymentLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label BillsLbl;
        private System.Windows.Forms.Label MemberShipLbl;
        private System.Windows.Forms.Label MemberLbl;
        private System.Windows.Forms.Label TrainersLbl;
        private System.Windows.Forms.TextBox Phone;
        private System.Windows.Forms.TextBox MemberLName;
        private System.Windows.Forms.TextBox MemberFName;
        private System.Windows.Forms.ComboBox MembershipType;
        private System.Windows.Forms.ComboBox BloodType;
        private System.Windows.Forms.ComboBox Gender;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2DateTimePicker JoinDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker DOB;
        private System.Windows.Forms.ComboBox Trainer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox Timing;
        private System.Windows.Forms.DataGridView dataGridView2;
        private KalashDBDataSet8 kalashDBDataSet8;
        private System.Windows.Forms.BindingSource membersTableBindingSource;
        private KalashDBDataSet8TableAdapters.MembersTableTableAdapter membersTableTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn membersIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memberFNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memberLNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dOBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn joinDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn membershipIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bloodTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trainersIDDataGridViewTextBoxColumn;
    }
}