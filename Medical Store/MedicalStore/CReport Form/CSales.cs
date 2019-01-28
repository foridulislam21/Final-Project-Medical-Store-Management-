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
    public partial class CSales : MetroFramework.Forms.MetroForm
    {
        ReportDocument rs = new ReportDocument();
        public CSales(string invoice)
        {
            InitializeComponent();
            Txtinvoice.Text = invoice;
        }

        private void CSales_Load(object sender, EventArgs e)
        {
            try
            {
                rs.Load(@"E:\Medical Store\MedicalStore\MedicalStore\MedicalStore\CReports\CrystalReportCSales.rpt");
                SqlConnection con = new SqlConnection
                {
                    ConnectionString = @"Data Source=DESKTOP-TNVK8MO\ARIF;Initial Catalog=MedicalStore;Integrated Security=True"
                };
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter("select * from Csellinfo where InvoiceNo='" + Txtinvoice.Text + "'", con);
                //ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet dt = new DataSet();
                ad.Fill(dt, "Csellinfo");
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
