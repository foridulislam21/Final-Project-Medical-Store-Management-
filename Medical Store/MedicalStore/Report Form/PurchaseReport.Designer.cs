namespace MedicalStore.Report_Form
{
    partial class PurchaseReport
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.Btnall = new MetroFramework.Controls.MetroRadioButton();
            this.Btndate = new MetroFramework.Controls.MetroRadioButton();
            this.Txtdate = new System.Windows.Forms.DateTimePicker();
            this.Btnshow = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(20, 60);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1193, 733);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Btnall
            // 
            this.Btnall.AutoSize = true;
            this.Btnall.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.Btnall.Location = new System.Drawing.Point(696, 39);
            this.Btnall.Name = "Btnall";
            this.Btnall.Size = new System.Drawing.Size(90, 15);
            this.Btnall.TabIndex = 1;
            this.Btnall.Text = "All Purchase";
            this.Btnall.UseSelectable = true;
            this.Btnall.CheckedChanged += new System.EventHandler(this.Btnall_CheckedChanged);
            // 
            // Btndate
            // 
            this.Btndate.AutoSize = true;
            this.Btndate.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.Btndate.Location = new System.Drawing.Point(560, 39);
            this.Btndate.Name = "Btndate";
            this.Btndate.Size = new System.Drawing.Size(130, 15);
            this.Btndate.TabIndex = 1;
            this.Btndate.Text = "DateWise Purchase";
            this.Btndate.UseSelectable = true;
            this.Btndate.CheckedChanged += new System.EventHandler(this.Btndate_CheckedChanged);
            // 
            // Txtdate
            // 
            this.Txtdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Txtdate.Location = new System.Drawing.Point(560, 63);
            this.Txtdate.Name = "Txtdate";
            this.Txtdate.Size = new System.Drawing.Size(130, 20);
            this.Txtdate.TabIndex = 2;
            // 
            // Btnshow
            // 
            this.Btnshow.Highlight = true;
            this.Btnshow.Location = new System.Drawing.Point(696, 63);
            this.Btnshow.Name = "Btnshow";
            this.Btnshow.Size = new System.Drawing.Size(75, 20);
            this.Btnshow.TabIndex = 3;
            this.Btnshow.Text = "Show";
            this.Btnshow.UseSelectable = true;
            this.Btnshow.Click += new System.EventHandler(this.Btnshow_Click);
            // 
            // PurchaseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 813);
            this.Controls.Add(this.Btnshow);
            this.Controls.Add(this.Txtdate);
            this.Controls.Add(this.Btndate);
            this.Controls.Add(this.Btnall);
            this.Controls.Add(this.crystalReportViewer1);
            this.MaximizeBox = false;
            this.Name = "PurchaseReport";
            this.Load += new System.EventHandler(this.PurchaseReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private MetroFramework.Controls.MetroRadioButton Btnall;
        private MetroFramework.Controls.MetroRadioButton Btndate;
        private System.Windows.Forms.DateTimePicker Txtdate;
        private MetroFramework.Controls.MetroButton Btnshow;
    }
}