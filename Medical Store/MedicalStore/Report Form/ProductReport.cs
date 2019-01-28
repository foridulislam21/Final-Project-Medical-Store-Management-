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

namespace MedicalStore.Report_Form
{
    public partial class ProductReport : MetroFramework.Forms.MetroForm
    {
        ReportDocument cp = new ReportDocument();
        public ProductReport(MedicalStore.AdminForm parrent)
        {
            InitializeComponent();
            this.MdiParent = parrent;
        }

        private void ProductReport_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection
                {
                    ConnectionString = @"Data Source=DESKTOP-TNVK8MO\ARIF;Initial Catalog=MedicalStore;Integrated Security=True"
                };
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter("GetProduct",con);
                DataSet ds = new DataSet();
                ad.Fill(ds,"Product_Master");
                con.Close();

                cp.Load(@"E:\Medical Store\MedicalStore\MedicalStore\MedicalStore\Reports\CrystalProductReport.rpt");
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
