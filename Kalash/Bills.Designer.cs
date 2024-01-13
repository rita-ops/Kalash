namespace Kalash
{
    partial class Bills
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bills));
            this.Date = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.Delete = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DateBill = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnallbills = new System.Windows.Forms.Button();
            this.Amount = new System.Windows.Forms.TextBox();
            this.Currency = new System.Windows.Forms.ComboBox();
            this.Member = new System.Windows.Forms.ComboBox();
            this.Currencies = new System.Windows.Forms.Label();
            this.MemberName = new System.Windows.Forms.Label();
            this.Amounts = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MemberShipLbl = new System.Windows.Forms.Label();
            this.MemberLbl = new System.Windows.Forms.Label();
            this.PaymentLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TrainersLbl = new System.Windows.Forms.Label();
            this.Logout = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Date
            // 
            this.Date.Checked = true;
            this.Date.FillColor = System.Drawing.Color.DarkSlateGray;
            this.Date.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Date.Location = new System.Drawing.Point(41, 156);
            this.Date.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.Date.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(159, 29);
            this.Date.TabIndex = 12;
            this.Date.Value = new System.DateTime(2023, 12, 9, 9, 56, 29, 7);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Delete.Location = new System.Drawing.Point(82, 415);
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
            this.Edit.Location = new System.Drawing.Point(125, 364);
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
            this.Save.Location = new System.Drawing.Point(41, 364);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 33);
            this.Save.TabIndex = 8;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(525, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bills List";
            // 
            // DateBill
            // 
            this.DateBill.AutoSize = true;
            this.DateBill.Location = new System.Drawing.Point(38, 140);
            this.DateBill.Name = "DateBill";
            this.DateBill.Size = new System.Drawing.Size(30, 13);
            this.DateBill.TabIndex = 1;
            this.DateBill.Text = "Date";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.btnallbills);
            this.panel3.Controls.Add(this.Amount);
            this.panel3.Controls.Add(this.Currency);
            this.panel3.Controls.Add(this.Member);
            this.panel3.Controls.Add(this.Date);
            this.panel3.Controls.Add(this.Delete);
            this.panel3.Controls.Add(this.Edit);
            this.panel3.Controls.Add(this.Save);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.DateBill);
            this.panel3.Controls.Add(this.Currencies);
            this.panel3.Controls.Add(this.MemberName);
            this.panel3.Controls.Add(this.Amounts);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(169, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1213, 748);
            this.panel3.TabIndex = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(337, 89);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(443, 463);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // btnallbills
            // 
            this.btnallbills.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnallbills.Location = new System.Drawing.Point(924, 120);
            this.btnallbills.Name = "btnallbills";
            this.btnallbills.Size = new System.Drawing.Size(75, 33);
            this.btnallbills.TabIndex = 15;
            this.btnallbills.Text = "View Bills";
            this.btnallbills.UseVisualStyleBackColor = false;
            this.btnallbills.Click += new System.EventHandler(this.btnallbills_Click);
            // 
            // Amount
            // 
            this.Amount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Amount.Location = new System.Drawing.Point(41, 231);
            this.Amount.Name = "Amount";
            this.Amount.Size = new System.Drawing.Size(159, 29);
            this.Amount.TabIndex = 14;
            // 
            // Currency
            // 
            this.Currency.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Currency.FormattingEnabled = true;
            this.Currency.Items.AddRange(new object[] {
            "LBP",
            "$"});
            this.Currency.Location = new System.Drawing.Point(41, 305);
            this.Currency.Name = "Currency";
            this.Currency.Size = new System.Drawing.Size(159, 29);
            this.Currency.TabIndex = 13;
            // 
            // Member
            // 
            this.Member.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Member.FormattingEnabled = true;
            this.Member.Location = new System.Drawing.Point(39, 82);
            this.Member.Name = "Member";
            this.Member.Size = new System.Drawing.Size(159, 29);
            this.Member.TabIndex = 13;
            // 
            // Currencies
            // 
            this.Currencies.AutoSize = true;
            this.Currencies.Location = new System.Drawing.Point(38, 289);
            this.Currencies.Name = "Currencies";
            this.Currencies.Size = new System.Drawing.Size(49, 13);
            this.Currencies.TabIndex = 1;
            this.Currencies.Text = "Currency";
            // 
            // MemberName
            // 
            this.MemberName.AutoSize = true;
            this.MemberName.Location = new System.Drawing.Point(36, 66);
            this.MemberName.Name = "MemberName";
            this.MemberName.Size = new System.Drawing.Size(76, 13);
            this.MemberName.TabIndex = 1;
            this.MemberName.Text = "Member Name";
            // 
            // Amounts
            // 
            this.Amounts.AutoSize = true;
            this.Amounts.Location = new System.Drawing.Point(38, 215);
            this.Amounts.Name = "Amounts";
            this.Amounts.Size = new System.Drawing.Size(43, 13);
            this.Amounts.TabIndex = 1;
            this.Amounts.Text = "Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Bills";
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
            this.MemberLbl.Click += new System.EventHandler(this.MemberLbl_Click);
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(43, 256);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 17);
            this.label13.TabIndex = 0;
            this.label13.Text = "Bills";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.PaymentLbl);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.MemberShipLbl);
            this.panel2.Controls.Add(this.MemberLbl);
            this.panel2.Controls.Add(this.TrainersLbl);
            this.panel2.Location = new System.Drawing.Point(16, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(169, 475);
            this.panel2.TabIndex = 3;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.Logout);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 748);
            this.panel1.TabIndex = 9;
            // 
            // Bills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "Bills";
            this.Text = "Bills";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DateTimePicker Date;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label DateBill;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label MemberName;
        private System.Windows.Forms.Label Amounts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label MemberShipLbl;
        private System.Windows.Forms.Label MemberLbl;
        private System.Windows.Forms.Label PaymentLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label TrainersLbl;
        private System.Windows.Forms.Label Logout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox Member;
        private System.Windows.Forms.TextBox Amount;
        private System.Windows.Forms.ComboBox Currency;
        private System.Windows.Forms.Label Currencies;
        private System.Windows.Forms.Button btnallbills;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}