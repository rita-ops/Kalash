namespace Kalash
{
    partial class Payments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Payments));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnviewpayments = new System.Windows.Forms.Button();
            this.ClientName = new System.Windows.Forms.ComboBox();
            this.Edit = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.paymentIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentsTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Phone = new System.Windows.Forms.TextBox();
            this.Amount = new System.Windows.Forms.TextBox();
            this.Currency = new System.Windows.Forms.ComboBox();
            this.Date = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.DateBill = new System.Windows.Forms.Label();
            this.Currencies = new System.Windows.Forms.Label();
            this.MemberName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Amounts = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PaymentLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BillsLbl = new System.Windows.Forms.Label();
            this.MemberShipLbl = new System.Windows.Forms.Label();
            this.MemberLbl = new System.Windows.Forms.Label();
            this.TrainersLbl = new System.Windows.Forms.Label();
            this.Logout = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentsTableBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btnviewpayments);
            this.panel3.Controls.Add(this.ClientName);
            this.panel3.Controls.Add(this.Edit);
            this.panel3.Controls.Add(this.Save);
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.Phone);
            this.panel3.Controls.Add(this.Amount);
            this.panel3.Controls.Add(this.Currency);
            this.panel3.Controls.Add(this.Date);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.DateBill);
            this.panel3.Controls.Add(this.Currencies);
            this.panel3.Controls.Add(this.MemberName);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.Amounts);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(169, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1213, 749);
            this.panel3.TabIndex = 15;
            // 
            // btnviewpayments
            // 
            this.btnviewpayments.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnviewpayments.Location = new System.Drawing.Point(1063, 18);
            this.btnviewpayments.Name = "btnviewpayments";
            this.btnviewpayments.Size = new System.Drawing.Size(75, 36);
            this.btnviewpayments.TabIndex = 18;
            this.btnviewpayments.Text = "View Payments";
            this.btnviewpayments.UseVisualStyleBackColor = false;
            this.btnviewpayments.Click += new System.EventHandler(this.btnviewpayments_Click);
            // 
            // ClientName
            // 
            this.ClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientName.FormattingEnabled = true;
            this.ClientName.Items.AddRange(new object[] {
            "EDL",
            "Internet",
            "Moteur",
            "Rent",
            "Salaries",
            "Water",
            "AAAA"});
            this.ClientName.Location = new System.Drawing.Point(39, 83);
            this.ClientName.Name = "ClientName";
            this.ClientName.Size = new System.Drawing.Size(157, 28);
            this.ClientName.TabIndex = 17;
            // 
            // Edit
            // 
            this.Edit.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Edit.Location = new System.Drawing.Point(449, 133);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(75, 36);
            this.Edit.TabIndex = 16;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = false;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Save.Location = new System.Drawing.Point(622, 133);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 36);
            this.Save.TabIndex = 16;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.paymentIdDataGridViewTextBoxColumn,
            this.clientNameDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.currencyDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.paymentsTableBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(41, 211);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1085, 469);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // paymentIdDataGridViewTextBoxColumn
            // 
            this.paymentIdDataGridViewTextBoxColumn.DataPropertyName = "PaymentId";
            this.paymentIdDataGridViewTextBoxColumn.HeaderText = "PaymentId";
            this.paymentIdDataGridViewTextBoxColumn.Name = "paymentIdDataGridViewTextBoxColumn";
            this.paymentIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.paymentIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // clientNameDataGridViewTextBoxColumn
            // 
            this.clientNameDataGridViewTextBoxColumn.DataPropertyName = "ClientName";
            this.clientNameDataGridViewTextBoxColumn.HeaderText = "Client Name";
            this.clientNameDataGridViewTextBoxColumn.Name = "clientNameDataGridViewTextBoxColumn";
            this.clientNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.clientNameDataGridViewTextBoxColumn.Width = 210;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateDataGridViewTextBoxColumn.Width = 210;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "Phone";
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            this.phoneDataGridViewTextBoxColumn.ReadOnly = true;
            this.phoneDataGridViewTextBoxColumn.Width = 210;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountDataGridViewTextBoxColumn.Width = 210;
            // 
            // currencyDataGridViewTextBoxColumn
            // 
            this.currencyDataGridViewTextBoxColumn.DataPropertyName = "Currency";
            this.currencyDataGridViewTextBoxColumn.HeaderText = "Currency";
            this.currencyDataGridViewTextBoxColumn.Name = "currencyDataGridViewTextBoxColumn";
            this.currencyDataGridViewTextBoxColumn.ReadOnly = true;
            this.currencyDataGridViewTextBoxColumn.Width = 210;
            // 
            // paymentsTableBindingSource
            // 
            this.paymentsTableBindingSource.DataMember = "PaymentsTable";
            this.paymentsTableBindingSource.DataSource = typeof(Kalash.KalashDBDataSet);
            // 
            // Phone
            // 
            this.Phone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Phone.Location = new System.Drawing.Point(489, 82);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(159, 29);
            this.Phone.TabIndex = 14;
            // 
            // Amount
            // 
            this.Amount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Amount.Location = new System.Drawing.Point(741, 82);
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
            this.Currency.Location = new System.Drawing.Point(988, 82);
            this.Currency.Name = "Currency";
            this.Currency.Size = new System.Drawing.Size(159, 29);
            this.Currency.TabIndex = 13;
            // 
            // Date
            // 
            this.Date.Checked = true;
            this.Date.FillColor = System.Drawing.Color.DarkSlateGray;
            this.Date.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Date.Location = new System.Drawing.Point(282, 82);
            this.Date.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.Date.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(159, 29);
            this.Date.TabIndex = 12;
            this.Date.Value = new System.DateTime(2023, 12, 9, 9, 56, 29, 7);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(547, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Payments List";
            // 
            // DateBill
            // 
            this.DateBill.AutoSize = true;
            this.DateBill.Location = new System.Drawing.Point(279, 66);
            this.DateBill.Name = "DateBill";
            this.DateBill.Size = new System.Drawing.Size(30, 13);
            this.DateBill.TabIndex = 1;
            this.DateBill.Text = "Date";
            // 
            // Currencies
            // 
            this.Currencies.AutoSize = true;
            this.Currencies.Location = new System.Drawing.Point(985, 66);
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
            this.MemberName.Size = new System.Drawing.Size(35, 13);
            this.MemberName.TabIndex = 1;
            this.MemberName.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(486, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Phone";
            // 
            // Amounts
            // 
            this.Amounts.AutoSize = true;
            this.Amounts.Location = new System.Drawing.Point(738, 66);
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
            this.label1.Size = new System.Drawing.Size(192, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Payments";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.Logout);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 749);
            this.panel1.TabIndex = 14;
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
            // Payments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Payments";
            this.Text = "Payments";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentsTableBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox Phone;
        private System.Windows.Forms.TextBox Amount;
        private System.Windows.Forms.ComboBox Currency;
        private Guna.UI2.WinForms.Guna2DateTimePicker Date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label DateBill;
        private System.Windows.Forms.Label Currencies;
        private System.Windows.Forms.Label MemberName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Amounts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label PaymentLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label BillsLbl;
        private System.Windows.Forms.Label MemberShipLbl;
        private System.Windows.Forms.Label MemberLbl;
        private System.Windows.Forms.Label TrainersLbl;
        private System.Windows.Forms.Label Logout;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource paymentsTableBindingSource;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.ComboBox ClientName;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button btnviewpayments;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currencyDataGridViewTextBoxColumn;
    }
}