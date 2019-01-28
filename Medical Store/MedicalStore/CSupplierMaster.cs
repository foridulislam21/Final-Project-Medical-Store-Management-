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
using System.Text.RegularExpressions;

namespace MedicalStore
{
    public partial class CSupplierMaster : MetroFramework.Forms.MetroForm
    {
        SqlConnection con = new SqlConnection
        {
            ConnectionString = @"Data Source=DESKTOP-TNVK8MO\ARIF;Initial Catalog=MedicalStore;Integrated Security=True"

        };
        public CSupplierMaster(MedicalStore.AdminForm pa)
        {
            InitializeComponent();
            this.MdiParent = pa;
        }

        private void Txtsupplierid_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;

        }

        private void Txtsuppliername_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32 || e.KeyChar == 46 ||e.KeyChar==13 ? false : true;

        }

        private void Txtsuppliercom_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32 || e.KeyChar == 46 ? false : true;

        }
        private void TxtSupplierEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Txtsuppliermob.Focus();
        }
        private void Txtsuppliermob_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
            if (e.KeyChar == 13)
                Txtsupplierphone.Focus();
        }

        private void Txtsupplierphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
            if (e.KeyChar == 13)
                Txtsuppliecity.Focus();

        }

        private void Txtsuppliecity_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Txtsupplieraddress_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TxtSupplierEmail_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(TxtSupplierEmail.Text, pattern))
            {
                errorProvider1.Clear();
                pictureBox4.Image = Properties.Resources.if_001_06_9653;
            }
            else
            {
                MessageBox.Show("Email Not Correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(this.TxtSupplierEmail, "Please Provide Valid Mail Address");
                pictureBox4.Image = null;
                return;
            }
        }

        private void Txtsuppliermob_Leave(object sender, EventArgs e)
        {
            string pattern = "^[0-9]{11}$";
            if (Regex.IsMatch(Txtsuppliermob.Text, pattern))
            {
                errorProvider1.Clear();
                pictureBox5.Image = Properties.Resources.if_001_06_9653;
            }
            else
            {
                MessageBox.Show("Mobile No. Not Correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(this.Txtsuppliermob, "Please Provide Valid Mobile No.");
                pictureBox5.Image = null;
                return;
            }
        }


        private void BtnNew_Click(object sender, EventArgs e)
        {
            Txtsupplierid.Text = "";
            Txtsuppliername.Text = "";
            Txtsuppliercom.Text = "";
            TxtSupplierEmail.Text = "";
            Txtsuppliermob.Text = "";
            Txtsupplierphone.Text = "";
            Txtsuppliecity.Text = "";
            Txtsupplieraddress.Text = "";
            //groupBox1.Enabled = true;

            try
            {

                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter("SELECT * from CSupplier_Master", con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                int b = (dt.Rows.Count);
                b++;
                Txtsupplierid.Text = b.ToString();
                Txtsupplierid.Focus();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE [CSupplier_Master] SET id='" + Txtsupplierid.Text + "',sname='" + Txtsuppliername.Text + "',scompany='" + Txtsuppliercom.Text + "',semail='" + TxtSupplierEmail.Text + "',smobile='" + Txtsuppliermob.Text + "',sphone='" + Txtsupplierphone.Text + "',scity='" + Txtsuppliecity.Text + "',saddress='" + Txtsupplieraddress.Text + "'" +
                    "WHERE id='" + Txtsupplierid.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record is successfully Updated", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd.Connection.Close();

                SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM [CSupplier_Master]", con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Txtsupplierid.Text = "";
                Txtsuppliername.Text = "";
                Txtsuppliercom.Text = "";
                TxtSupplierEmail.Text = "";
                Txtsuppliermob.Text = "";
                Txtsupplierphone.Text = "";
                Txtsuppliecity.Text = "";
                Txtsupplieraddress.Text = "";

                pictureBox4.Image = null;
                pictureBox5.Image = null;
                pictureBox6.Image = null;

                //groupBox1.Enabled = false;
                con.Close();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Txtsupplierid.Text == "" || Txtsuppliername.Text == "" || Txtsuppliercom.Text == "" || Txtsuppliermob.Text == "")
            {
                MessageBox.Show("Please Enter Required Information", "Informed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {


                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT into CSupplier_Master VALUES('" + Txtsupplierid.Text + "','" + Txtsuppliername.Text + "','" + Txtsuppliercom.Text + "','" + TxtSupplierEmail.Text + "','" + Txtsuppliermob.Text + "','" + Txtsupplierphone.Text + "','" + Txtsuppliecity.Text + "','" + Txtsupplieraddress.Text + "')";

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record is successfully Added", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmd.Connection.Close();

                    SqlDataAdapter ad = new SqlDataAdapter("SELECT * from CSupplier_Master", con);
                    DataSet ds = new DataSet();
                    ad.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    dataGridView1.DataSource = dt;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Txtsupplierid.Text = "";
                    Txtsuppliername.Text = "";
                    Txtsuppliercom.Text = "";
                    TxtSupplierEmail.Text = "";
                    Txtsuppliermob.Text = "";
                    Txtsupplierphone.Text = "";
                    Txtsuppliecity.Text = "";
                    Txtsupplieraddress.Text = "";
                    Txtsuppliername.Focus();
                    pictureBox4.Image = null;
                    pictureBox5.Image = null;
                    pictureBox6.Image = null;

                    //groupBox1.Enabled = false;
                    con.Close();
                }
            }
            //load perchase id
            try
            {
                int a;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select Max (Id) from CSupplier_Master";
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string val = dr[0].ToString();
                    if (val == "")
                    {
                        Txtsupplierid.Text = "1";
                    }
                    else
                    {
                        a = Convert.ToInt32(dr[0].ToString());
                        a = a + 1;
                        Txtsupplierid.Text = a.ToString();
                    }
                    con.Close();
                }
             //   dataGridView1.Rows.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [CSupplier_Master]";

                DialogResult re = MessageBox.Show("Do you want to delete this Record!", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (re == DialogResult.No)
                {
                    Txtsupplierid.Focus();
                }
                else
                {
                    cmd.CommandText = "DELETE FROM CSupplier_Master WHERE  [Id]='" + Txtsupplierid.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Selected record is DELETED", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                cmd.CommandText = "SELECT * FROM [CSupplier_Master]";
                cmd.Connection.Close();

                SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM [CSupplier_Master]", con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Txtsupplierid.Text = "";
                Txtsuppliername.Text = "";
                Txtsuppliercom.Text = "";
                TxtSupplierEmail.Text = "";
                Txtsuppliermob.Text = "";
                Txtsupplierphone.Text = "";
                Txtsuppliecity.Text = "";
                Txtsupplieraddress.Text = "";
                Txtsuppliername.Focus();
                pictureBox4.Image = null;
                pictureBox5.Image = null;
                pictureBox6.Image = null;

                groupBox1.Enabled = true;
                con.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Txtsupplierid.Text = "";
            Txtsuppliername.Text = "";
            Txtsuppliercom.Text = "";
            TxtSupplierEmail.Text = "";
            Txtsuppliermob.Text = "";
            Txtsupplierphone.Text = "";
            Txtsuppliecity.Text = "";
            Txtsupplieraddress.Text = "";
            Txtsuppliername.Focus();
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;

            groupBox1.Enabled = true;
            //load perchase id
            try
            {
                int a;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select Max (Id) from CSupplier_Master";
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string val = dr[0].ToString();
                    if (val == "")
                    {
                        Txtsupplierid.Text = "1";
                    }
                    else
                    {
                        a = Convert.ToInt32(dr[0].ToString());
                        a = a + 1;
                        Txtsupplierid.Text = a.ToString();
                    }
                    con.Close();
                }
                //dataGridView1.Rows.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Txtsupplierid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            Txtsuppliername.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            Txtsuppliercom.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            TxtSupplierEmail.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            Txtsuppliermob.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            Txtsupplierphone.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            Txtsuppliecity.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            Txtsupplieraddress.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void Txtsupplierserch_TextChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                if (comboBox1.Text == "ID")
                {

                    SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM CSupplier_Master WHERE id LIKE'" + Txtsupplierserch.Text + "%'", con);
                    DataTable dt = new DataTable();
                    adptr.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.Text == "Name")
                {
                    SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM CSupplier_Master WHERE sname LIKE'" + Txtsupplierserch.Text + "%'", con);
                    DataTable dt = new DataTable();
                    adptr.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.Text == "Company")
                {
                    SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM CSupplier_Master WHERE scompany LIKE'" + Txtsupplierserch.Text + "%'", con);
                    DataTable dt = new DataTable();
                    adptr.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                con.Close();

            }
            catch (Exception ex)
            {

            }
        }

        private void CSupplierMaster_Load(object sender, EventArgs e)
        {
            Txtsupplierid.Text = "";
            Txtsuppliername.Text = "";
            Txtsuppliercom.Text = "";
            TxtSupplierEmail.Text = "";
            Txtsuppliermob.Text = "";
            Txtsupplierphone.Text = "";
            Txtsupplieraddress.Text = "";
            Txtsuppliername.Focus();
            //groupBox1.Enabled = false;
            //metroPanel2.Enabled = true;


            try
            {

                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter("SELECT * from CSupplier_Master", con);
                DataTable ds = new DataTable();
                ad.Fill(ds);
                dataGridView1.DataSource = ds;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //load perchase id
            try
            {
                int a;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select Max (Id) from CSupplier_Master";
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string val = dr[0].ToString();
                    if (val == "")
                    {
                        Txtsupplierid.Text = "1";
                    }
                    else
                    {
                        a = Convert.ToInt32(dr[0].ToString());
                        a = a + 1;
                        Txtsupplierid.Text = a.ToString();
                    }
                    con.Close();
                }
                //dataGridView1.Rows.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
