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
    public partial class SalesdataReport : MetroFramework.Forms.MetroForm
    {
        ReportDocument rd = new ReportDocument();
        SqlConnection con = new SqlConnection
        {
            ConnectionString = @"Data Source=DESKTOP-TNVK8MO\ARIF;Initial Catalog=MedicalStore;Integrated Security=True"
        };
        public int a;
        public SalesdataReport(MedicalStore.AdminForm pa)
        {
            InitializeComponent();
            this.MdiParent = pa;
        }

        private void BtnCheckdate_CheckedChanged(object sender, EventArgs e)
        {
            if (BtnCheckdate.Checked)
            {
                a = 1;
                TxtdateR1.Enabled = true;
                TxtdateR2.Enabled = true;
                txtyearR.Enabled = false;
            }
        }

        private void Btncheckyear_CheckedChanged(object sender, EventArgs e)
        {
            if (Btncheckyear.Checked)
            {
                a = 2;
                TxtdateR1.Enabled = false;
                TxtdateR2.Enabled = false;
                txtyearR.Enabled = true;
            }
        }

        private void BtnshowR_Click(object sender, EventArgs e)
        {
            try
            {
                rd.Load(@"E:\Medical Store\MedicalStore\MedicalStore\MedicalStore\Reports\ProfitDataView.rpt");
                if (a == 1)
                {
                    con.Open();
                    SqlDataAdapter ad = new SqlDataAdapter("select * from Saleinfor where saledate between '" + TxtdateR1.Text + "' and '"+TxtdateR2.Text+"'", con);
                    DataSet dt = new DataSet();
                    ad.Fill(dt, "Saleinfor");
                    rd.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = rd;
                    crystalReportViewer1.Refresh();
                    con.Close();
                }
                if (a == 2)
                {
                    con.Open();
                    SqlDataAdapter ad = new SqlDataAdapter("select * from Saleinfor where saleyear='" + txtyearR.Text + "'", con);
                    DataSet dt = new DataSet();
                    ad.Fill(dt, "Saleinfor");
                    rd.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = rd;
                    crystalReportViewer1.Refresh();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
