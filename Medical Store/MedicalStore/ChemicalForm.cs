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
    public partial class ChemicalForm : MetroFramework.Forms.MetroForm
    {
        SqlConnection con = new SqlConnection
        {
            ConnectionString = @"Data Source=DESKTOP-TNVK8MO\ARIF;Initial Catalog=MedicalStore;Integrated Security=True"
        };
        public ChemicalForm(MedicalStore.AdminForm ca)
        {
            InitializeComponent();
            this.MdiParent = ca;
        }

        private void ChemicalForm_Load(object sender, EventArgs e)
        {
            Txttimer.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
            //get supplier name
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT sname FROM CSupplier_Master order by Id";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    TxtSuppliername.Items.Add(dr["sname"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //get product name
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT ProName FROM CProductMaster order by ID";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Txtproductname.Items.Add(dr["ProName"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                int a;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select Max (Id) from CPurchase";
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string val = dr[0].ToString();
                    if (val == "")
                    {
                        TxtpurchageID.Text = "1";
                    }
                    else
                    {
                        a = Convert.ToInt32(dr[0].ToString());
                        a = a + 1;
                        TxtpurchageID.Text = a.ToString();
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

        private void Txtproductname_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from CProductMaster where ProName='" + Txtproductname.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string id = (string)dr["ID"].ToString();
                Txtproductid.Text = id;

                string cat = (string)dr["PhyState"].ToString();
                Txtcategory.Text = cat;

                string cur = (string)dr["TUnit"].ToString();
                Txtcurrentstock.Text = cur;
                Txtcurstock.Text = cur;

                string mrp = (string)dr["MRP"].ToString();
                Txtmrp.Text = mrp;

                string sale = (string)dr["SaleRate"].ToString();
                Txtsale.Text = sale;

                string unit = (string)dr["UnitName"].ToString();
                Txtunitname.Text = unit;

                string pur = (string)dr["Purchase"].ToString();
                Txtpurchage.Text = pur;
                                
            }


            con.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Txttimer.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void Btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                //add text item in datagridview
                int row1 = 0;
                dataGridView1.Rows.Add();
                row1 = dataGridView1.Rows.Count - 1;
                dataGridView1["Purchase_ID", row1].Value = TxtpurchageID.Text;
                dataGridView1["Product_Name", row1].Value = Txtproductname.Text;
                dataGridView1["Category_Name", row1].Value = Txtcategory.Text;
                dataGridView1["Unit_Name", row1].Value = Txtunitname.Text;
                dataGridView1["Purchase_Rate", row1].Value = Txtpurchage.Text;
                dataGridView1["MRP_Rate", row1].Value = Txtmrp.Text;
                dataGridView1["Sale_Rate", row1].Value = Txtsale.Text;
                dataGridView1["Quantity", row1].Value = Txtquantity.Text;
                dataGridView1["Price", row1].Value = Txtprice.Text;
                dataGridView1["CurrentStock", row1].Value = Txtcurrentstock.Text;
                dataGridView1["ProductID", row1].Value = Txtproductid.Text;

                Txttottal.Text = "0.00";
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    Txttottal.Text = Convert.ToString(double.Parse(Txttottal.Text) + double.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString()));
                }
                double x;
                double.TryParse(Txttottal.Text, out x);
                Txttottal.Text = x.ToString("0.00");
                
                    long a, b, c=0;
                    a = long.Parse(Txtcurstock.Text);//Quantity of Total items
                    b = long.Parse(Txtquantity.Text);//Quantity of Purchase items

                    c = a + b;
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE CProductMaster SET [TUnit]='"+c+"' where [ID]='" + Txtproductid.Text + "'";
                    cmd.ExecuteNonQuery();
                MessageBox.Show("Product " + Txtproductname.Text + " Added To Cart!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Problem Found");
            }
            finally
            {
                Txtproductname.Text = "";
                Txtcategory.Text = "";
                Txtunitname.Text = "";
                Txtcurrentstock.Text = "";
                Txtproductid.Text = "";
                Txtquantity.Text = "";
                Txtprice.Text = "";
                Txtmrp.Text = "";
                Txtpurchage.Text = "";
                Txtsale.Text = "";
                Txtcurrentstock.Clear();
                Txtquant.Text = "";
                Txtcurstock.Text = "";

            }
        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            //SELECT TOP 1000[Id] ,[SupName] ,[SupCom] ,[PurDate] ,[ProName] ,[Category] ,[UnitName] ,[PurRate] ,[MRP] ,[SaleRate] ,[Quantity] 
            //,[Price] ,[TotalP] ,[Payment] ,[Remark] FROM[dbo].[CPurchase]
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"insert into CPurchase (Purchase_ID, Supplier_Name, Supplier_Company, Purchage_Date, Product_ID, Product_Name, Category, UnitName,
                    Purchage_Rate, MRP_Rate, Sale_Rate, Quantity, Price, Total_Price, Payment, Remark)VALUES(@Purchase_ID, @Supplier_Name, @Supplier_Company, @Purchage_Date, @Product_ID, @Product_Name, @Category, @UnitName,
                    @Purchage_Rate, @MRP_Rate, @Sale_Rate, @Quantity, @Price, @Total_Price, @Payment, @Remark)", con);

                    cmd.Parameters.AddWithValue("@Supplier_Name", TxtSuppliername.Text);
                    cmd.Parameters.AddWithValue("@Supplier_Company", TxtsupplierCom.Text);
                    cmd.Parameters.AddWithValue("@Purchage_Date", Txtsupplierdate.Text);
                    cmd.Parameters.AddWithValue("@Purchase_ID", dataGridView1.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@Product_Name", dataGridView1.Rows[i].Cells[1].Value);
                    cmd.Parameters.AddWithValue("@Category", dataGridView1.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@UnitName", dataGridView1.Rows[i].Cells[3].Value);
                    cmd.Parameters.AddWithValue("@Purchage_Rate", dataGridView1.Rows[i].Cells[5].Value);
                    cmd.Parameters.AddWithValue("@MRP_Rate", dataGridView1.Rows[i].Cells[6].Value);
                    cmd.Parameters.AddWithValue("@Sale_Rate", dataGridView1.Rows[i].Cells[7].Value);
                    cmd.Parameters.AddWithValue("@Quantity", dataGridView1.Rows[i].Cells[8].Value);
                    cmd.Parameters.AddWithValue("@Price", dataGridView1.Rows[i].Cells[9].Value);
                    cmd.Parameters.AddWithValue("@Product_ID", dataGridView1.Rows[i].Cells[10].Value);
                    cmd.Parameters.AddWithValue("@Total_Price", Txttottal.Text);
                    cmd.Parameters.AddWithValue("@Payment", Txtpayment.Text);
                    cmd.Parameters.AddWithValue("@Remark", Txtremark.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Purchase Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dataGridView1.Rows.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                TxtpurchageID.Text = "";
                TxtSuppliername.Text = "";
                TxtsupplierCom.Text = "";
                Txtsupplierdate.Text = "";
                Txtremark.Text = "";
                Txtpayment.Text = "";
                Txttottal.Text = "";
                Txttottal1.Text = "";
                //TxtproID.Text = "";
            }
            try
            {
                int a;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select Max (Id) from CPurchase";
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string val = dr[0].ToString();
                    if (val == "")
                    {
                        TxtpurchageID.Text = "1";
                    }
                    else
                    {
                        a = Convert.ToInt32(dr[0].ToString());
                        a = a + 1;
                        TxtpurchageID.Text = a.ToString();
                    }
                    con.Close();
                }
               // dataGridView1.Rows.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int row = 0;
            row = dataGridView1.Rows.Count - 1;
            dataGridView1["Purchase_ID", row].Value = TxtpurchageID.Text;
            dataGridView1.Refresh();
        }

        private void Txtquantity_TextChanged(object sender, EventArgs e)
        {
            if (Txtquantity.Text == "")
            {
                Txtprice.Text = "";
                Txtcurrentstock.Text = Txtcurstock.Text;
            }
            try
            {
                Txtprice.Text = Convert.ToString(Convert.ToDouble(Txtpurchage.Text) * Convert.ToDouble(Txtquantity.Text)).ToString();
                Txtcurrentstock.Text = Convert.ToString(Convert.ToDouble(Txtcurstock.Text) + Convert.ToDouble(Txtquantity.Text)).ToString();
            }
            catch (Exception ex)
            {
    //            MessageBox.Show(ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int delete = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(delete);
                double a, b, c = 0;
                a = double.Parse(Txtcurrentstock.Text);
                b = double.Parse(Txtquant.Text);
                c = a - b;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE CProductMaster SET TUnit='"+c+"' where [ProCode]='" + Txtproductid.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product " + Txtproductname.Text + " Deleted From List.", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Txtproductname.Text = "";
                Txtcategory.Text = "";
                Txtunitname.Text = "";
                Txtproductid.Text = "";
                Txtquantity.Text = "";
                Txtprice.Text = "";
                Txtmrp.Text = "";
                Txtpurchage.Text = "";
                Txtsale.Text = "";
                Txtcurrentstock.Clear();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Txtproductname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                Txtcategory.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                Txtunitname.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                Txtcurrentstock.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                Txtproductid.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                Txtquant.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                Txtprice.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                Txtmrp.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                Txtpurchage.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                Txtsale.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void TxtSuppliername_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from CSupplier_Master where sname='" + TxtSuppliername.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string id = (string)dr["scompany"].ToString();
                TxtsupplierCom.Text = id;

            }


            con.Close();
        }
    }
}
