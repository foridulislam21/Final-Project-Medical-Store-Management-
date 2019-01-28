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
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing.Imaging;

namespace MedicalStore
{
    public partial class infoform : MetroFramework.Forms.MetroForm
    {
        SqlConnection con = new SqlConnection
        {
            ConnectionString = @"Data Source=DESKTOP-TNVK8MO\ARIF;Initial Catalog=MedicalStore;Integrated Security=True"
        };
        string imLoc = "";
        public infoform(MedicalStore.AdminForm ad)
        {
            InitializeComponent();
            this.MdiParent = ad;
            //txtemail.Text = userinfo;
        }

        private void infoform_Load(object sender, EventArgs e)
        {
            txtuserid.Text = "";
            txtname.Text = "";
            txtnick.Text = "";
            txtemail.Text = "";
            txtgender.Text = "";
            btncalender.Text = "";
            txtphone.Text = "";
            txtmobile.Text = "";
            txtprofession.Text = "";
            txtaddress.Text = "";
            //txtprofession.DisplayMember = "position";
            //txtprofession.ValueMember = "profession_id";
            //using (AdminEntities db = new AdminEntities())
            //{
            //    txtprofession.DataSource = db.professions.ToList();
            //}
            try
            {
                con.Open();
                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM information", con);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btnadduser_Click(object sender, EventArgs e)
        {
            txtuserid.Text = "";
            txtname.Text = "";
            txtnick.Text = "";
            txtemail.Text = "";
            txtgender.Text = "";
            btncalender.Text = "";
            txtphone.Text = "";
            txtmobile.Text = "";
            txtprofession.Text = "";
            txtaddress.Text = "";
            picEmp.Image = null;

            con.Open();

            SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM information", con);
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
            if (txtuserid.Text == "" || txtgender.Text == "" || txtphone.Text == "" || txtprofession.Text == ""|| txtaddress.Text=="")
            {
                MessageBox.Show("Please Enter Required Information", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    con.Open();

                    byte[] img = null;
                    FileStream fs = new FileStream(imLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);

                    //insert query  
                    SqlCommand cmd = new SqlCommand();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO information VALUES('" + txtuserid.Text + "','" + txtname.Text + "','" + txtnick.Text + "','" + txtemail.Text + "','" + txtgender.Text + "','" + btncalender.Text + "','" + txtphone.Text + "','" + txtmobile.Text + "','" + txtprofession.Text + "','" + txtaddress.Text + "',@img)";
                    cmd.Parameters.Add(new SqlParameter("@img", img));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Record is succesfully added", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    cmd.Connection.Close();

                    SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM information", con);
                    DataSet ds = new DataSet();
                    adptr.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    dataGridView1.DataSource = dt;


                }
                catch (Exception s)
                {
                    MessageBox.Show(s.Message, "Please enter your right information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    txtuserid.Text = "";
                    txtname.Text = "";
                    txtnick.Text = "";
                    txtemail.Text = "";
                    txtgender.Text = "";
                    btncalender.Text = "";
                    txtphone.Text = "";
                    txtmobile.Text = "";
                    txtprofession.Text = "";
                    txtaddress.Text = "";
                    picEmp.Image = null;
                }
            }
        }

        private void Btnmodify_Click(object sender, EventArgs e)
        {
            //update query  
            try
            {
                con.Open();         
                int j = 0;
                SqlCommand ad = new SqlCommand("UPDATE information SET name ='" + txtname.Text + "', nickname ='" + txtnick.Text + "', email_id ='" + txtemail.Text + "', gender ='" + txtgender.Text + "', age ='" + btncalender.Text + "', phone_no ='" + txtphone.Text + "',Image=@Image, mobile_no ='" + txtmobile.Text + "', profession ='" + txtprofession.Text + "', address ='" + txtaddress.Text + "' WHERE user_id = '" + txtuserid.Text + "'",con);

                MemoryStream ms = new MemoryStream();
                picEmp.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = ms.ToArray();
                ad.Parameters.AddWithValue("@Image", pic);
                j = ad.ExecuteNonQuery();
                if (j > 0)
                {
                    MessageBox.Show("Record Update Successfully!");

                }
                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM information", con);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;

            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
            finally
            {
                txtuserid.Text = "";
                txtname.Text = "";
                txtnick.Text = "";
                txtemail.Text = "";
                txtgender.Text = "";
                btncalender.Text = "";
                txtphone.Text = "";
                txtmobile.Text = "";
                txtprofession.Text = "";
                txtaddress.Text = "";
                picEmp.Image = null;
            }
        }

        private void Btndelete_Click(object sender, EventArgs e)
        {
            //delete query 
            try
            {
                con.Open();

                //delete query  
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [information]";
                DialogResult result = MessageBox.Show(this, "Do you really want to delete this record", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    txtuserid.Focus();
                }
                else
                {
                    cmd.CommandText = "DELETE FROM [information] WHERE user_id= '" + txtuserid.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Selected Record is deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                cmd.CommandText = "select * from [information]";

                con.Close();
                cmd.Connection.Close();

                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM information", con);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
            finally
            {
                txtuserid.Text = "";
                txtname.Text = "";
                txtnick.Text = "";
                txtemail.Text = "";
                txtgender.Text = "";
                btncalender.Text = "";
                txtphone.Text = "";
                txtmobile.Text = "";
                txtprofession.Text = "";
                txtaddress.Text = "";
                picEmp.Image = null;
            }
        }

        private void Btncancel_Click(object sender, EventArgs e)
        {
            txtuserid.Text = "";
            txtname.Text = "";
            txtnick.Text = "";
            txtemail.Text = "";
            txtgender.Text = "";
            btncalender.Text = "";
            txtphone.Text = "";
            txtmobile.Text = "";
            txtprofession.Text = "";
            txtaddress.Text = "";
            picEmp.Image = null;
        }

        private void btnget_Click(object sender, EventArgs e)
        {
            txtname.Enabled = false;
            txtemail.Enabled = false;
            try
            {
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter("SELECT * from register_user where user_id='" + txtuserid.Text + "'", con);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                txtuserid.Text = dt.Rows[0][0].ToString();
                txtname.Text = dt.Rows[0][1].ToString();
                txtemail.Text = dt.Rows[0][2].ToString();
                con.Close();

            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                if (comboBox1.Text == "ID")
                {
                    SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM information WHERE user_id LIKE'" + txtsearch.Text + "%'", con);
                    DataTable dt = new DataTable();
                    adptr.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.Text == "Name")
                {
                    SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM information WHERE name LIKE'" + txtsearch.Text + "%'", con);
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

        private void Btnhome_Click(object sender, EventArgs e)
        {
            //this.Close();
            //MainMenu nn = new MainMenu();
            //nn.Show();

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ////if(txtuserid==txtuserid)
            ////{
            ////    MessageBox.Show("Please Clear All TextBox!","Informed",MessageBoxButtons.OK,MessageBoxIcon.Information);
            ////}
            //try
            //{
            //    txtuserid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            //    txtname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            //    txtnick.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            //    txtemail.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            //    txtgender.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            //    btncalender.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            //    txtphone.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            //    txtmobile.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            //    txtprofession.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            //    txtaddress.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            //    txtuserid.Enabled = false;
            //    txtname.Enabled = false;
            //    txtemail.Enabled = false;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Please Clear All TextBox!", "Informed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void txtmobile_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9]{11})$";
            if (Regex.IsMatch(txtmobile.Text, pattern))
            {
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(this.txtmobile,"Enter Valid Mobile No.!");
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog pi = new OpenFileDialog();
                pi.Filter = "JPG Files(*.jpg)|*.jpg|GIF Files(*.gif)|*.gif|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
                pi.Title = "Select Employee Picture";
                if (pi.ShowDialog()==DialogResult.OK)
                {
                    imLoc = pi.FileName.ToString();
                    picEmp.ImageLocation = imLoc;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
            
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {

                txtuserid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtnick.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtemail.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txtgender.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                btncalender.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                txtphone.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                txtmobile.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                txtprofession.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                txtaddress.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                if (con.State != ConnectionState.Open)
                    con.Open();
                string ad = "select * from information where user_id='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'";

                SqlCommand cmd = new SqlCommand(ad, con);
                SqlDataReader sr = cmd.ExecuteReader();
                sr.Read();
                if (sr.HasRows)
                {
                    byte[] img = (byte[])(sr[10]);
                    if (img == null)
                    {
                        picEmp.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        picEmp.Image = Image.FromStream(ms);
                    }
                }
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //MemoryStream ms = new MemoryStream();
            //Image img = (Image)dataGridView1.CurrentRow.Cells["Image"].Value;
            //img.Save(ms, ImageFormat.Jpeg);
            //picEmp.Image = Image.FromStream(ms);
        }

        private void Btnshow_Click(object sender, EventArgs e)
        {
            try
            {
                
                if(con.State!=ConnectionState.Open)
                    con.Open();
                string ad = "select * from information where user_id='" + txtuserid.Text + "'";
            
                SqlCommand cmd = new SqlCommand(ad,con);
                SqlDataReader sr = cmd.ExecuteReader();
                sr.Read();
                if (sr.HasRows)
                {
                    byte[] img = (byte[])(sr[10]);
                    if (img == null)
                    {
                        picEmp.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        picEmp.Image = Image.FromStream(ms);
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
