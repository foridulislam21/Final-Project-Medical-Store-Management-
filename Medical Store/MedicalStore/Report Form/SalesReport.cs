using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace MedicalStore.Report_Form
{
    public partial class SalesReport : MetroFramework.Forms.MetroForm
    {
        ReportDocument rs = new ReportDocument();
        public SalesReport(string invoice)
        {
            InitializeComponent();
            Txtinvoice.Text = invoice;
        }

        private void SalesReport_Load(object sender, EventArgs e)
        {
            try
            {
                rs.Load(@"E:\Medical Store\MedicalStore\MedicalStore\MedicalStore\Reports\CrystalSales.rpt");
                SqlConnection con = new SqlConnection
                {
                    ConnectionString = @"Data Source=DESKTOP-TNVK8MO\ARIF;Initial Catalog=MedicalStore;Integrated Security=True"
                };
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter("select * from Saleinfor where InvoiceNo='"+ Txtinvoice.Text+"'",con);
                //ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet dt = new DataSet();
                ad.Fill(dt, "Saleinfor");
                rs.SetDataSource(dt);
                crystalReportViewer1.ReportSource = rs;
                crystalReportViewer1.Refresh();
                con.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            
        }
    }
}
