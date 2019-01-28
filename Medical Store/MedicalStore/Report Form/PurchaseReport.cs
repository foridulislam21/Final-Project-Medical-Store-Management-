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
    public partial class PurchaseReport : MetroFramework.Forms.MetroForm
    {
        ReportDocument rd = new ReportDocument();
        SqlConnection con = new SqlConnection
        {
            ConnectionString = @"Data Source=DESKTOP-TNVK8MO\ARIF;Initial Catalog=MedicalStore;Integrated Security=True"
        };
        public int a;
        public PurchaseReport(MedicalStore.AdminForm af)
        {
            InitializeComponent();
            this.MdiParent = af;
        }

        private void Btndate_CheckedChanged(object sender, EventArgs e)
        {
            if (Btndate.Checked)
            {
                a = 1;
                // Btndate.Enabled = true;
                Txtdate.Enabled = true;
            }
        }

        private void Btnall_CheckedChanged(object sender, EventArgs e)
        {
            if (Btnall.Checked)
            {
                a = 2;
                // Btndate.Enabled = false;
                Txtdate.Enabled = false;
            }
        }

        private void PurchaseReport_Load(object sender, EventArgs e)
        {

        }

        private void Btnshow_Click(object sender, EventArgs e)
        {
            
            try
            {
                rd.Load(@"E:\Medical Store\MedicalStore\MedicalStore\MedicalStore\Reports\PurchaseCrystalReport.rpt");
                if (a == 1)
                {
                    con.Open();
                    SqlDataAdapter ad = new SqlDataAdapter("select * from Purchase where Purchage_Date='" + Txtdate.Text + "'", con);
                    DataSet dt = new DataSet();
                    ad.Fill(dt, "Purchase");
                    rd.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = rd;
                    crystalReportViewer1.Refresh();
                    con.Close();

                }
                else if (a == 2)
                {
                    con.Open();
                    SqlDataAdapter ad = new SqlDataAdapter("select * from Purchase",con);
                    DataSet dt = new DataSet();
                    ad.Fill(dt, "Purchase");
                    rd.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = rd;
                    crystalReportViewer1.Refresh();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
