namespace Kalash
{
    partial class Report_Payments
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.PaymentsTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.KalashDBDataSet1 = new Kalash.KalashDBDataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PaymentsTableTableAdapter = new Kalash.KalashDBDataSet1TableAdapters.PaymentsTableTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt1 = new System.Windows.Forms.TextBox();
            this.Txt2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentsTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KalashDBDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // PaymentsTableBindingSource
            // 
            this.PaymentsTableBindingSource.DataMember = "PaymentsTable";
            this.PaymentsTableBindingSource.DataSource = this.KalashDBDataSet1;
            // 
            // KalashDBDataSet1
            // 
            this.KalashDBDataSet1.DataSetName = "KalashDBDataSet1";
            this.KalashDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.PaymentsTableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Kalash.Report-Payment.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(23, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(890, 388);
            this.reportViewer1.TabIndex = 0;
            // 
            // PaymentsTableTableAdapter
            // 
            this.PaymentsTableTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(516, 415);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total";
            // 
            // Txt1
            // 
            this.Txt1.Location = new System.Drawing.Point(553, 411);
            this.Txt1.Name = "Txt1";
            this.Txt1.Size = new System.Drawing.Size(100, 20);
            this.Txt1.TabIndex = 3;
            // 
            // Txt2
            // 
            this.Txt2.Location = new System.Drawing.Point(739, 412);
            this.Txt2.Name = "Txt2";
            this.Txt2.Size = new System.Drawing.Size(100, 20);
            this.Txt2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(659, 414);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "$";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(845, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "LBP";
            // 
            // Report_Payments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 467);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt2);
            this.Controls.Add(this.Txt1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report_Payments";
            this.Text = "Report_Payments";
            this.Load += new System.EventHandler(this.Report_Payments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PaymentsTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KalashDBDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PaymentsTableBindingSource;
        private KalashDBDataSet1 KalashDBDataSet1;
        private KalashDBDataSet1TableAdapters.PaymentsTableTableAdapter PaymentsTableTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt1;
        private System.Windows.Forms.TextBox Txt2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}