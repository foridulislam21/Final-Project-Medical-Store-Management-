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
    public partial class ProductMaster : MetroFramework.Forms.MetroForm
    {
        SqlConnection con = new SqlConnection()
        {
            ConnectionString = @"Data Source=DESKTOP-TNVK8MO\ARIF;Initial Catalog=MedicalStore;Integrated Security=True"
        };
        public ProductMaster(MedicalStore.AdminForm parent)
        {
            InitializeComponent();
            this.MdiParent = parent;
           
        }

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
            if (e.KeyChar == 13)
                txtproductname.Focus(); 
        }

        private void txtproductname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            txtcategory.Focus();
        }

        private void txtcategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Tab)
                txtcompany.Focus();
        }

        private void txtcompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32 || e.KeyChar == 46 ? false : true;
            if (e.KeyChar == (char)Keys.Tab)
                txtgeneric.Focus();
        }

        private void txtgeneric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtpackage.Focus();
        }

        private void txtpackage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Tab)
                txtpurchage.Focus();
        }

        private void txtpurchage_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ||e.KeyChar==46? false : true;
            if (e.KeyChar == 13)
                txtmrp.Focus();
        }

        private void txtmrp_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46 ? false : true;
            if (e.KeyChar == 13)
                txtsale.Focus();

        }

        private void txtsale_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46 ? false : true;
            if (e.KeyChar == 13)
                txtitempack.Focus();
        }

        private void txtitempack_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
            if (e.KeyChar == 13)
                txtpackname.Focus();
        }

        private void txtpackname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Tab)
                txtsubitempack.Focus();
        }

        private void txtsubitempack_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
            if (e.KeyChar == 13)
                txtpackname1.Focus();
        }

        private void txtpackname1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Tab)
                txtquantity.Focus();
        }

        private void txtquantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
            if (e.KeyChar == 13)
                txtorderpoint.Focus();
        }

        private void txtorderpoint_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
            if (e.KeyChar == 13)
                txtmanudate.Focus();
        }

        private void txtmanudate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Tab)
                txtexpired.Focus();
        }

        private void txtexpired_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Tab)
                txtweight.Focus();
        }

        private void txtweight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtrack.Focus();
        }

        private void txtrack_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Tab)
                Btnsave.Focus();
        }
        private void txtitempack_TextChanged(object sender, EventArgs e)
        {
            
            try
            {
                if (txtsale.Text.Length > 0 && txtitempack.Text.Length > 0)
                {
                    txtunitcost.Text = Convert.ToString(Convert.ToDouble(txtsale.Text) / Convert.ToInt32(txtitempack.Text)).ToString();
                    TxtpuritemRate.Text = Convert.ToString(Convert.ToDouble(txtpurchage.Text) / Convert.ToInt32(txtitempack.Text)).ToString();
                    double x,y;
                    double.TryParse(txtunitcost.Text, out x);
                    double.TryParse(TxtpuritemRate.Text, out y);
                    txtunitcost.Text = x.ToString("0.00");
                    TxtpuritemRate.Text = y.ToString("0.00");
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void txtsubitempack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtunitcost.Text.Length>0.0 && txtsubitempack.Text.Length>0)
                {
                    txtsubunitcost.Text = Convert.ToString(Convert.ToDouble(txtunitcost.Text) / Convert.ToInt32(txtsubitempack.Text)).ToString();
                    txttotalsubitem.Text = Convert.ToString(Convert.ToInt32(txtitempack.Text) * Convert.ToInt32(txtsubitempack.Text)).ToString();
                    TxtpurSubitemRate.Text = Convert.ToString(Convert.ToDouble(TxtpuritemRate.Text) / Convert.ToInt32(txtsubitempack.Text)).ToString();
                    double x,y;
                    double.TryParse(txtsubunitcost.Text, out x);
                    double.TryParse(TxtpurSubitemRate.Text, out y);
                    txtsubunitcost.Text = x.ToString("0.00");
                    TxtpurSubitemRate.Text = y.ToString("0.00");
                }
                //if (txtsubitempack.Text.Length == 0)
                //    ResetTextBox();


            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }

        private void txtquantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtitempack.Text) && !string.IsNullOrEmpty(txtquantity.Text))
                {
                    txtquantity1.Text = Convert.ToString(Convert.ToInt32(txtitempack.Text) * Convert.ToDouble(txtquantity.Text)).ToString();
                    txtquantity2.Text = Convert.ToString(Convert.ToInt32(txttotalsubitem.Text) * Convert.ToInt32(txtquantity.Text)).ToString();
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }
        //for reset all text box
        private void ResetTextBox()
        {
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Text = "0.00";
                    else
                        func(control.Controls);
            };
            func(Controls);
        }
        private void ProductMaster_Load(object sender, EventArgs e)
        {
            txtcategory.Text = "";
            txtcompany.Text = "";
            txtpackage.Text= "";
            txtpackname.Text= "";
            txtpackname1.Text= "";
            txtrack.Text= "";
            txtpurchage.Text = "0.0";
            txtsubunitcost.Text = "0.00";
            txtsubitempack.Text = "0";
            txtitempack.Text = "0";
            txttotalsubitem.Text = "0";
            txtquantity.Text = "0";
            txtquantity1.Text = "0";
            txtquantity2.Text = "0";
            txtvat.Text = "0.00";
            txtmrp.Text = "0.00";
            txtsale.Text = "0.00";
            txtdiscount.Text = "0.00";
            txtorderpoint.Text = "0";
            try
            {
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM [Product_Master]",con);
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

            //Company name load in combobox
            txtcompany.Items.Clear();
            try
            {
                
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Supplier_Company FROM Supplier_Master order by Supplier_ID";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    txtcompany.Items.Add(dr["Supplier_Company"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Rack Name Load in Combobox
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT RackName FROM Rack order by Id";
                cmd.ExecuteNonQuery();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    txtrack.Items.Add(dr["RackName"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //load product id
            try
            {
                int a;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"select MAX(ProductID) from Product_Master";
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string val = dr[0].ToString();
                    if (val=="")
                    {
                        txtid.Text = "1";
                    }
                    else
                    {
                        a = Convert.ToInt32(dr[0].ToString());
                        a = a + 1;
                        txtid.Text = a.ToString();
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Btnnew_Click(object sender, EventArgs e)
        {
            try
            {
                txtcategory.Text = "";
                txtcompany.Text = "";
                txtpackage.Text = "";
                txtpackname.Text = "";
                txtpackname1.Text = "";
                txtrack.Text = "";
                txtpurchage.Text = "0.00";
                txtsubunitcost.Text = "0.00";
                txtsubitempack.Text = "0";
                txtitempack.Text = "0";
                txttotalsubitem.Text = "0";
                txtquantity.Text = "0";
                txtquantity1.Text = "0";
                txtquantity2.Text = "0";
                txtvat.Text = "0.00";
                txtmrp.Text = "0.00";
                txtsale.Text = "0.00";
                txtdiscount.Text = "0.00";
                txtorderpoint.Text = "0";

                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM [Product_Master]", con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                int a = (dt.Rows.Count);
                a++;
                txtid.Text = a.ToString();
                txtid.Focus();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btnedit_Click(object sender, EventArgs e)
        {
            
        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "" || txtproductname.Text == "" || txtgeneric.Text == "" || txtpurchage.Text == "" || txtmrp.Text == "" || txtsale.Text == ""||txtcategory.Text=="")
            {
                MessageBox.Show("Please Fill Up Required Mark!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT into [Product_Master] VALUES('" + txtid.Text + "','" + txtcategory.Text + "','" + txtpackage.Text + "','" + txtproductname.Text + "'" +
                        ",'" + txtgeneric.Text + "','" + txtrack.Text + "','" + txtweight.Text + "','" + txtcompany.Text + "','" + txtpurchage.Text + "','" + txtmrp.Text + "','" + txtsale.Text + "'" +
                        ",'" + txtitempack.Text + "','"+txtpackname.Text+"','" + txtunitcost.Text + "','"+TxtpuritemRate.Text+"','" + txtsubitempack.Text + "','"+txtpackname1.Text+"','" + txtsubunitcost.Text + "','"+TxtpurSubitemRate.Text+"','" + txttotalsubitem.Text + "'" +
                        ",'" + txtquantity.Text + "','" + txtdiscount.Text + "','" + txtquantity1.Text + "','" + txtquantity2.Text + "','" + txtorderpoint.Text + "','" + txtmanudate.Text + "','" + txtexpired.Text + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Medicine "+txtproductname.Text,"Successfully Added in Store.",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    

                    SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM [Product_Master]", con);
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
                    txtcategory.Text = "";
                    txtcompany.Text = "";
                    txtpackage.Text = "";
                    txtpackname.Text = "";
                    txtpackname1.Text = "";
                    txtrack.Text = "";
                    txtgeneric.Text = "";
                    txtweight.Text = "";
                    txtid.Text = "";
                    txtproductname.Text = "";
                    //txtunitcost.Text = "0.0";
                    //txtsubunitcost.Text = "0.0";
                    txtrack.Text = "SELECT";
                    txtpurchage.Text = "0.00";
                    txtsubunitcost.Text = "0.00";
                    //txtsubitempack.Text = "0";
                    txtitempack.Text = "0";
                    txttotalsubitem.Text = "0";
                    txtquantity.Text = "0";
                    txtquantity1.Text = "0";
                    txtquantity2.Text = "0";
                    txtvat.Text = "0.00";
                    txtmrp.Text = "0.00";
                    txtsale.Text = "0.00";
                    txtdiscount.Text = "0.00";
                    txtorderpoint.Text = "0";
                }
                //load product id
                try
                {
                    int a;
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"select MAX(ProductID) from Product_Master";
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        string val = dr[0].ToString();
                        if (val == "")
                        {
                            txtid.Text = "1";
                        }
                        else
                        {
                            a = Convert.ToInt32(dr[0].ToString());
                            a = a + 1;
                            txtid.Text = a.ToString();
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
                cmd.CommandText = "SELECT * FROM [Product_Master]";

                DialogResult re = MessageBox.Show("Are you want to Delete this Record!","Message",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (re == DialogResult.No)
                {
                    txtid.Focus();
                }
                else
                {
                    cmd.CommandText = "DELETE FROM [Product_Master] where [ProductID]='" + txtid.Text+"'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Selected Record is Deleted.","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                cmd.CommandText = "SELECT * FROM [Product_Master]";
                cmd.Connection.Close();

                SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM [Product_Master]",con);
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
            
        }

        private void Btncancel_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {

            txtid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtcategory.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtpackage.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtproductname.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtgeneric.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtrack.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txtweight.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            txtcompany.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            txtpurchage.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            txtmrp.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            txtsale.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
            txtitempack.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
            txtpackname.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
            txtsubitempack.Text = dataGridView1.SelectedRows[0].Cells[15].Value.ToString();
            txttotalsubitem.Text = dataGridView1.SelectedRows[0].Cells[19].Value.ToString();
            txtpackname1.Text = dataGridView1.SelectedRows[0].Cells[16].Value.ToString();
            txtquantity.Text = dataGridView1.SelectedRows[0].Cells[20].Value.ToString();
            txtorderpoint.Text = dataGridView1.SelectedRows[0].Cells[24].Value.ToString();
            txtmanudate.Text = dataGridView1.SelectedRows[0].Cells[25].Value.ToString();
            txtexpired.Text = dataGridView1.SelectedRows[0].Cells[26].Value.ToString();

            }
            catch (Exception ex)
            {

            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            //            ID
            //Product Name
            //Generic Name
            try
            {

                con.Open();
                if (comboBox1.Text == "ID")
                {

                    SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM Product_Master WHERE ProductID LIKE'" + txtsearch.Text + "%'", con);
                    DataTable dt = new DataTable();
                    adptr.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.Text == "Product Name")
                {
                    SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM Product_Master WHERE ProductName LIKE'" + txtsearch.Text + "%'", con);
                    DataTable dt = new DataTable();
                    adptr.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.Text == "Generic Name")
                {
                    SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM Product_Master WHERE GenericName LIKE'" + txtsearch.Text + "%'", con);
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
    }
}
