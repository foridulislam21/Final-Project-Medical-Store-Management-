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

namespace MedicalStore
{
    public partial class Rack : MetroFramework.Forms.MetroForm
    {
        SqlConnection con = new SqlConnection
        {
            ConnectionString = @"Data Source=DESKTOP-TNVK8MO\ARIF;Initial Catalog=MedicalStore;Integrated Security=True"
        };
        public Rack(MedicalStore.AdminForm pa)
        {
            InitializeComponent();
            this.MdiParent = pa;
        }

        private void Txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
            if (e.KeyChar == (char)13)
                TxtRack.Focus();
        }

        private void TxtRack_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                Txtinfo.Focus();
        }

        private void Txtinfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                Btbsave.Focus();
        }

        private void Btbnew_Click(object sender, EventArgs e)
        {
            try
            {
                Txtid.Text = "";
                Txtinfo.Text = "";
                TxtRack.Text = "";
                
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM Rack", con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataTable dt = ds.Tables[0];
                int a = (dt.Rows.Count);
                a++;
                Txtid.Text = a.ToString();
                Txtid.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtbModify_Click(object sender, EventArgs e)
        {

        }

        private void Btbsave_Click(object sender, EventArgs e)
        {
            if (Txtid.Text == ""||TxtRack.Text=="")
            {
                MessageBox.Show("Please Enter Required Information!","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                   
                    con.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT into Rack VALUES('"+Txtid.Text+"','"+TxtRack.Text+"','"+Txtinfo.Text+"')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record is successfully Added", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmd.Connection.Close();
                    con.Close();

                    //SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM Rack",con);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Btbdelete_Click(object sender, EventArgs e)
        {

        }
    }
}
