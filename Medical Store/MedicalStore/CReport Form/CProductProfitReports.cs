using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace MedicalStore.CReport_Form
{
    public partial class CProductProfitReports : MetroFramework.Forms.MetroForm
    {
        ReportDocument rd = new ReportDocument();
        SqlConnection con = new SqlConnection
        {
            ConnectionString = @"Data Source=DESKTOP-TNVK8MO\ARIF;Initial Catalog=MedicalStore;Integrated Security=True"
        };
        public CProductProfitReports(MedicalStore.AdminForm pa)
        {
            InitializeComponent();
            this.MdiParent = pa;
        }

        private void CProductProfitReports_Load(object sender, EventArgs e)
        {
            rd.Load(@"E:\Medical Store\MedicalStore\MedicalStore\MedicalStore\CReports\CrystalReportCProfit.rpt");
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter("select * from Csellinfo", con);
                DataSet dt = new DataSet();
                ad.Fill(dt, "Csellinfo");
                rd.SetDataSource(dt);
                crystalReportViewer1.ReportSource = rd;
                crystalReportViewer1.Refresh();
                con.Close();
            }
    }
}
