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
    public partial class Register : MetroFramework.Forms.MetroForm
    {
        SqlConnection con = new SqlConnection
        {
            ConnectionString = @"Data Source=DESKTOP-TNVK8MO\ARIF;Initial Catalog=MedicalStore;Integrated Security=True"
        };
        public Register(MedicalStore.AdminForm ad)
        {
            InitializeComponent();
            this.MdiParent = ad;
        }

        private void Register_Load(object sender, EventArgs e)
        {
            txtuserid.Text = "";
            txtname.Text = "";
            txtpassword.Text = "";
            txtemail.Text = "";
            txtremark.Text = "";
            Txtdepartment.Text = "";

            metroPanel.Enabled = false;

            try
            {              
                con.Open();
                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM register_user", con);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btnnew_Click(object sender, EventArgs e)
        {
            metroPanel.Enabled = true;
            txtuserid.Text = "";
            txtname.Text = "";
            txtpassword.Text = "";
            txtemail.Text = "";
            txtremark.Text = "";

            con.Open();

            SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM register_user", con);
            DataSet ds = new DataSet();
            adptr.Fill(ds);
            DataTable dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            int b = (dt.Rows.Count);
            b++;
            txtuserid.Text = b.ToString();
            con.Close();
        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                //SELECT TOP 1000[user_id] ,[Employee_Name] ,[email_id] ,[password] ,[deparment] ,[remarks] FROM[dbo].[register_user]
                con.Open();
                //insert query  
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO register_user VALUES('" + txtuserid.Text + "','" + txtname.Text + "','" + txtemail.Text + "','" + txtpassword.Text + "','"+Txtdepartment.Text+"','" + txtremark.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show(this, "Record is succesfully added", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cmd.Connection.Close();

                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM register_user", con);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                con.Close();


            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message, "Please enter your right information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                txtuserid.Text = "";
                txtname.Text = "";
                txtpassword.Text = "";
                txtemail.Text = "";
                txtremark.Text = "";
                Txtdepartment.Text = null;
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                pictureBox3.Image = null;
                pictureBox4.Image = null;
                pictureBox5.Image = null;
                metroPanel.Enabled = false;
            }
        }

        private void Btnupdate_Click(object sender, EventArgs e)
        {
            //updatre data
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE register_user set user_id='" + txtuserid.Text + "',username='" + txtname.Text + "',password='" + txtpassword.Text + "',email_id='" + txtemail.Text + "',remarks='" + txtremark.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record is successfully updated", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd.Connection.Close();

                SqlDataAdapter ad = new SqlDataAdapter("SELECT * from register_user", con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Please Try Again !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtuserid.Text = "";
                txtname.Text = "";
                txtpassword.Text = "";
                txtemail.Text = "";
                txtremark.Text = "";
                Txtdepartment.Text = null;
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                pictureBox3.Image = null;
                pictureBox4.Image = null;
                pictureBox5.Image = null;
                metroPanel.Enabled = false;
            }
        }

        private void Btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from register_user";
                DialogResult result = MessageBox.Show("do you want to delete this record", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    txtuserid.Focus();
                }
                else
                {
                    cmd.CommandText = "DELETE from register_user WHERE user_id='" + txtuserid.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Selected record is delete", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cmd.CommandText = "select * from register_user";
                cmd.Connection.Close();

                SqlDataAdapter ad = new SqlDataAdapter("select * from register_user", con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txtuserid.Text = "";
                txtname.Text = "";
                txtpassword.Text = "";
                txtemail.Text = "";
                txtremark.Text = "";
                Txtdepartment.Text = "";
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                pictureBox3.Image = null;
                pictureBox4.Image = null;
                pictureBox5.Image = null;
                metroPanel.Enabled = false;
            }
        }

        private void Btncancel_Click(object sender, EventArgs e)
        {
            metroPanel.Enabled = false;
            txtuserid.Text = "";
            txtname.Text = "";
            txtpassword.Text = "";
            txtemail.Text = "";
            txtremark.Text = "";
            Txtdepartment.Text = "";
            
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtuserid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtpassword.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtemail.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            Txtdepartment.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtremark.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            metroPanel.Enabled = true;
        }

        private void txtemail_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txtemail.Text, pattern))
            {

                errorProvider1.Clear();
                pictureBox3.Image = Properties.Resources.if_001_06_9653;
            }
            else
            {
                MessageBox.Show("Email Not Correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(this.txtemail, "Please Provide Valid Mail Address");
                return;
            }
        }

        private void txtuserid_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
            if (e.KeyChar == 13 || e.KeyChar == 11)
            {
                txtname.Focus();
                pictureBox1.Image = Properties.Resources.if_001_06_9653;
            }
            else if (e.KeyChar == 8)
            {
                pictureBox1.Image = null;
            }
        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32 || e.KeyChar == 46 ? false : true;
            if (e.KeyChar == 13 || e.KeyChar == 11)
            {
                txtpassword.Focus();
                pictureBox2.Image = Properties.Resources.if_001_06_9653;
            }
            else if (e.KeyChar == 8)
            {
                pictureBox2.Image = null;
            }
        }

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 || e.KeyChar == 9)
            {
                txtemail.Focus();

            }
            else if (e.KeyChar == 8)
            {
                pictureBox3.Image = null;
            }
        }

        private void txtemail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 || e.KeyChar == 9)
            {
                txtremark.Focus();
                pictureBox4.Image = Properties.Resources.if_001_06_9653;
            }
            else if (e.KeyChar == 8)
            {
                pictureBox4.Image = null;
            }
        }

        private void txtremark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 || e.KeyChar == 11)
            {
                Btnsave.Focus();
                pictureBox5.Image = Properties.Resources.if_001_06_9653;
            }
            else if (e.KeyChar == 8)
            {
                pictureBox5.Image = null;
            }
        }

        private void txtuserid_Click(object sender, EventArgs e)
        {

        }
    }
}
