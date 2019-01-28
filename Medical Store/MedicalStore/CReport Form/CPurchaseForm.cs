using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace MedicalStore.CReport_Form
{
    public partial class CPurchaseForm : MetroFramework.Forms.MetroForm
    {
        ReportDocument cp = new ReportDocument();
        public CPurchaseForm(MedicalStore.AdminForm ca)
        {
            InitializeComponent();
            this.MdiParent = ca;
        }

        private void CPurchaseForm_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection
                {
                    ConnectionString = @"Data Source=DESKTOP-TNVK8MO\ARIF;Initial Catalog=MedicalStore;Integrated Security=True"
                };
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter("Select * From CPurchase", con);
                DataSet ds = new DataSet();
                ad.Fill(ds, "CPurchase");
                con.Close();

                cp.Load(@"E:\Medical Store\MedicalStore\MedicalStore\MedicalStore\CReports\PurchaseReport.rpt");
                cp.SetDataSource(ds);
                crystalReportViewer1.ReportSource = cp;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
