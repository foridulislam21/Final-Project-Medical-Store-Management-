namespace MedicalStore.Report_Form
{
    partial class SalesdataReport
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
            this.TxtdateR1 = new System.Windows.Forms.DateTimePicker();
            this.BtnshowR = new MetroFramework.Controls.MetroButton();
            this.BtnCheckdate = new MetroFramework.Controls.MetroRadioButton();
            this.txtyearR = new System.Windows.Forms.DateTimePicker();
            this.Btncheckyear = new MetroFramework.Controls.MetroRadioButton();
            this.TxtdateR2 = new System.Windows.Forms.DateTimePicker();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // TxtdateR1
            // 
            this.TxtdateR1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TxtdateR1.Location = new System.Drawing.Point(391, 31);
            this.TxtdateR1.Name = "TxtdateR1";
            this.TxtdateR1.Size = new System.Drawing.Size(97, 20);
            this.TxtdateR1.TabIndex = 1;
            // 
            // BtnshowR
            // 
            this.BtnshowR.Highlight = true;
            this.BtnshowR.Location = new System.Drawing.Point(747, 31);
            this.BtnshowR.Name = "BtnshowR";
            this.BtnshowR.Size = new System.Drawing.Size(75, 23);
            this.BtnshowR.TabIndex = 2;
            this.BtnshowR.Text = "&Show";
            this.BtnshowR.UseSelectable = true;
            this.BtnshowR.Click += new System.EventHandler(this.BtnshowR_Click);
            // 
            // BtnCheckdate
            // 
            this.BtnCheckdate.AutoSize = true;
            this.BtnCheckdate.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.BtnCheckdate.Location = new System.Drawing.Point(466, 10);
            this.BtnCheckdate.Name = "BtnCheckdate";
            this.BtnCheckdate.Size = new System.Drawing.Size(80, 15);
            this.BtnCheckdate.TabIndex = 3;
            this.BtnCheckdate.Text = "Date Wise";
            this.BtnCheckdate.UseSelectable = true;
            this.BtnCheckdate.CheckedChanged += new System.EventHandler(this.BtnCheckdate_CheckedChanged);
            // 
            // txtyearR
            // 
            this.txtyearR.CustomFormat = "yyyy";
            this.txtyearR.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtyearR.Location = new System.Drawing.Point(650, 31);
            this.txtyearR.Name = "txtyearR";
            this.txtyearR.Size = new System.Drawing.Size(68, 20);
            this.txtyearR.TabIndex = 1;
            // 
            // Btncheckyear
            // 
            this.Btncheckyear.AutoSize = true;
            this.Btncheckyear.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.Btncheckyear.Location = new System.Drawing.Point(650, 10);
            this.Btncheckyear.Name = "Btncheckyear";
            this.Btncheckyear.Size = new System.Drawing.Size(77, 15);
            this.Btncheckyear.TabIndex = 3;
            this.Btncheckyear.Text = "Year Wise";
            this.Btncheckyear.UseSelectable = true;
            this.Btncheckyear.CheckedChanged += new System.EventHandler(this.Btncheckyear_CheckedChanged);
            // 
            // TxtdateR2
            // 
            this.TxtdateR2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TxtdateR2.Location = new System.Drawing.Point(520, 31);
            this.TxtdateR2.Name = "TxtdateR2";
            this.TxtdateR2.Size = new System.Drawing.Size(97, 20);
            this.TxtdateR2.TabIndex = 1;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(494, 36);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(20, 15);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "To";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.DisplayStatusBar = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(23, 63);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1129, 649);
            this.crystalReportViewer1.TabIndex = 5;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // SalesdataReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 735);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.Btncheckyear);
            this.Controls.Add(this.BtnCheckdate);
            this.Controls.Add(this.BtnshowR);
            this.Controls.Add(this.txtyearR);
            this.Controls.Add(this.TxtdateR2);
            this.Controls.Add(this.TxtdateR1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SalesdataReport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker TxtdateR1;
        private MetroFramework.Controls.MetroButton BtnshowR;
        private MetroFramework.Controls.MetroRadioButton BtnCheckdate;
        private System.Windows.Forms.DateTimePicker txtyearR;
        private MetroFramework.Controls.MetroRadioButton Btncheckyear;
        private System.Windows.Forms.DateTimePicker TxtdateR2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}