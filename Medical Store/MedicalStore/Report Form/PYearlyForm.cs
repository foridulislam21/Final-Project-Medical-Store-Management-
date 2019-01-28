using CrystalDecisions.CrystalReports.Engine;
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

namespace MedicalStore.Report_Form
{
    public partial class PYearlyForm : MetroFramework.Forms.MetroForm
    {
        ReportDocument rd = new ReportDocument();
        SqlConnection con = new SqlConnection
        {
            ConnectionString = @"Data Source=DESKTOP-TNVK8MO\ARIF;Initial Catalog=MedicalStore;Integrated Security=True"
        };
        public PYearlyForm(MedicalStore.AdminForm pa)
        {
            InitializeComponent();
            this.MdiParent = pa;
        }

        private void PYearlyForm_Load(object sender, EventArgs e)
        {
            rd.Load(@"E:\Medical Store\MedicalStore\MedicalStore\MedicalStore\Reports\CrystalReportYearlyChart.rpt");
            try
            {
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter("select * from SaleInfor", con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                rd.SetDataSource(ds);
                crystalReportViewer1.ReportSource = rd;
                crystalReportViewer1.Refresh();
                con.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
