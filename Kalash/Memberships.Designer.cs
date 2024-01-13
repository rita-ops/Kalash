namespace Kalash
{
    partial class Memberships
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Memberships));
            this.Delete = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PaymentLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BillsLbl = new System.Windows.Forms.Label();
            this.MemberShipLbl = new System.Windows.Forms.Label();
            this.MemberLbl = new System.Windows.Forms.Label();
            this.TrainersLbl = new System.Windows.Forms.Label();
            this.Logout = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.membershipIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.membershipTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.membershipsTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kalashDBDataSet9 = new Kalash.KalashDBDataSet9();
            this.Description = new System.Windows.Forms.TextBox();
            this.Cost = new System.Windows.Forms.TextBox();
            this.MembershipType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.membershipsTableTableAdapter = new Kalash.KalashDBDataSet9TableAdapters.MembershipsTableTableAdapter();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.membershipsTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kalashDBDataSet9)).BeginInit();
            this.SuspendLayout();
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Delete.Location = new System.Drawing.Point(938, 147);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 33);
            this.Delete.TabIndex = 8;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Edit
            // 
            this.Edit.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Edit.Location = new System.Drawing.Point(165, 147);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(75, 33);
            this.Edit.TabIndex = 8;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = false;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Save.Location = new System.Drawing.Point(563, 147);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 33);
            this.Save.TabIndex = 8;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.Logout);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 751);
            this.panel1.TabIndex = 9;
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
            this.MemberLbl.Click += new System.EventHandler(this.MemberLbl_Click);
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
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.Delete);
            this.panel3.Controls.Add(this.Edit);
            this.panel3.Controls.Add(this.Save);
            this.panel3.Controls.Add(this.Description);
            this.panel3.Controls.Add(this.Cost);
            this.panel3.Controls.Add(this.MembershipType);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(170, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1213, 751);
            this.panel3.TabIndex = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.membershipIDDataGridViewTextBoxColumn,
            this.membershipTypeDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.costDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.membershipsTableBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(107, 241);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.RowTemplate.Height = 20;
            this.dataGridView1.Size = new System.Drawing.Size(942, 356);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // membershipIDDataGridViewTextBoxColumn
            // 
            this.membershipIDDataGridViewTextBoxColumn.DataPropertyName = "MembershipID";
            this.membershipIDDataGridViewTextBoxColumn.HeaderText = "MembershipID";
            this.membershipIDDataGridViewTextBoxColumn.Name = "membershipIDDataGridViewTextBoxColumn";
            this.membershipIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // membershipTypeDataGridViewTextBoxColumn
            // 
            this.membershipTypeDataGridViewTextBoxColumn.DataPropertyName = "MembershipType";
            this.membershipTypeDataGridViewTextBoxColumn.HeaderText = "MembershipType";
            this.membershipTypeDataGridViewTextBoxColumn.Name = "membershipTypeDataGridViewTextBoxColumn";
            this.membershipTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.membershipTypeDataGridViewTextBoxColumn.Width = 300;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Width = 400;
            // 
            // costDataGridViewTextBoxColumn
            // 
            this.costDataGridViewTextBoxColumn.DataPropertyName = "Cost";
            this.costDataGridViewTextBoxColumn.HeaderText = "Cost";
            this.costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            this.costDataGridViewTextBoxColumn.ReadOnly = true;
            this.costDataGridViewTextBoxColumn.Width = 200;
            // 
            // membershipsTableBindingSource
            // 
            this.membershipsTableBindingSource.DataMember = "MembershipsTable";
            this.membershipsTableBindingSource.DataSource = this.kalashDBDataSet9;
            // 
            // kalashDBDataSet9
            // 
            this.kalashDBDataSet9.DataSetName = "KalashDBDataSet9";
            this.kalashDBDataSet9.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Description
            // 
            this.Description.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description.Location = new System.Drawing.Point(471, 82);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(258, 29);
            this.Description.TabIndex = 3;
            // 
            // Cost
            // 
            this.Cost.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cost.Location = new System.Drawing.Point(900, 82);
            this.Cost.Name = "Cost";
            this.Cost.Size = new System.Drawing.Size(159, 29);
            this.Cost.TabIndex = 3;
            // 
            // MembershipType
            // 
            this.MembershipType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MembershipType.FormattingEnabled = true;
            this.MembershipType.Items.AddRange(new object[] {
            "Basic Membership",
            "Premium Membership",
            "24-Hour Access Membership",
            "Family Memberships",
            "Student Memberships"});
            this.MembershipType.Location = new System.Drawing.Point(41, 82);
            this.MembershipType.Name = "MembershipType";
            this.MembershipType.Size = new System.Drawing.Size(186, 29);
            this.MembershipType.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(535, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Memberships List";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(468, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Description";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(36, 66);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Membership Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(897, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Cost";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Memberships";
            // 
            // membershipsTableTableAdapter
            // 
            this.membershipsTableTableAdapter.ClearBeforeFill = true;
            // 
            // Memberships
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "Memberships";
            this.Text = "Memberships";
            this.Load += new System.EventHandler(this.Memberships_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.membershipsTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kalashDBDataSet9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label PaymentLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label BillsLbl;
        private System.Windows.Forms.Label MemberShipLbl;
        private System.Windows.Forms.Label MemberLbl;
        private System.Windows.Forms.Label TrainersLbl;
        private System.Windows.Forms.Label Logout;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox Description;
        private System.Windows.Forms.TextBox Cost;
        private System.Windows.Forms.ComboBox MembershipType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private KalashDBDataSet9 kalashDBDataSet9;
        private System.Windows.Forms.BindingSource membershipsTableBindingSource;
        private KalashDBDataSet9TableAdapters.MembershipsTableTableAdapter membershipsTableTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn membershipIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn membershipTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
    }
}