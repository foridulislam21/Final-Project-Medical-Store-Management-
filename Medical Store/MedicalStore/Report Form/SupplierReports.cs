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

namespace MedicalStore.Report_Form
{
    public partial class SupplierReports : MetroFramework.Forms.MetroForm
    {
        ReportDocument cp = new ReportDocument();
        public SupplierReports(MedicalStore.AdminForm p)
        {
            InitializeComponent();
            this.MdiParent = p;
        }

        private void SupplierReports_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection
                {
                    ConnectionString = @"Data Source=DESKTOP-TNVK8MO\ARIF;Initial Catalog=MedicalStore;Integrated Security=True"
                };
                SqlDataAdapter ad = new SqlDataAdapter("GetSupplier", con);
                ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                ad.Fill(ds, "Supplier_Master");
                con.Close();


                cp.Load(@"E:\Medical Store\MedicalStore\MedicalStore\MedicalStore\Reports\CrystalSupplierReport.rpt");
                cp.SetDataSource(ds);
                crystalReportViewer1.ReportSource = cp;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
