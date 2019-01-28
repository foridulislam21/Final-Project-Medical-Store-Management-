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
    public partial class CProductReport : MetroFramework.Forms.MetroForm
    {
        ReportDocument cp = new ReportDocument();
        public CProductReport(MedicalStore.AdminForm pa)
        {
            InitializeComponent();
            this.MdiParent = pa;
        }

        private void CProductReport_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection
                {
                    ConnectionString = @"Data Source=DESKTOP-TNVK8MO\ARIF;Initial Catalog=MedicalStore;Integrated Security=True"
                };
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter("Select * From CProductMaster", con);
                DataSet ds = new DataSet();
                ad.Fill(ds, "CProductMaster");
                con.Close();

                cp.Load(@"E:\Medical Store\MedicalStore\MedicalStore\MedicalStore\CReports\CrystalReportProductinfo.rpt");
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
