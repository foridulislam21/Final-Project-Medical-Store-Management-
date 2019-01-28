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

namespace MedicalStore
{
    public partial class Purchaseform : MetroFramework.Forms.MetroForm
    {
        SqlConnection con = new SqlConnection
        {
            ConnectionString = @"Data Source=DESKTOP-TNVK8MO\ARIF;Initial Catalog=MedicalStore;Integrated Security=True"
        };
        public Purchaseform(MedicalStore.AdminForm ad)
        {
            InitializeComponent();
            this.MdiParent = ad;
        }

        private void Purchaseform_Load(object sender, EventArgs e)
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
                cmd.CommandText = "SELECT Supplier_Name FROM Supplier_Master order by Supplier_ID";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    TxtSuppliername.Items.Add(dr["Supplier_Name"].ToString());
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
                cmd.CommandText = "SELECT ProductName FROM Product_Master order by ProductID";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Txtproductname.Items.Add(dr["ProductName"].ToString());
                }
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
                cmd.CommandText = "select Max (Purchase_ID) from Purchase";
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
                dataGridView1.Rows.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TxtSuppliername_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46 ? false : true;
        }

        private void TxtSuppliername_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Supplier_Master where Supplier_Name='" + TxtSuppliername.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string com = (string)dr["Supplier_Company"].ToString();
                TxtsupplierCom.Text = com;
  
            }


            con.Close();
        }

        private void Txtproductname_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Product_Master where ProductName='" + Txtproductname.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string id = (string)dr["ProductID"].ToString();
                Txtproductid.Text = id;
                TxtproID.Text = id;

                string cat = (string)dr["Category"].ToString();
                Txtcategory.Text = cat;

                string cur = (string)dr["Quantity"].ToString();
                Txtcurrentstock.Text = cur;                

                string mrp = (string)dr["MRPRate"].ToString();
                Txtmrp.Text = mrp;

                string sale = (string)dr["SaleRate"].ToString();
                Txtsale.Text = sale;

                string unit = (string)dr["UnitName"].ToString();
                Txtunitname.Text = unit;

                string pur = (string)dr["PurchageRate"].ToString();
                Txtpurchage.Text = pur;

                string ite = (string)dr["Items"].ToString();
                Txthitems.Text = ite;

                string subite = (string)dr["SubItems"].ToString();
                Txthsuitems.Text = subite;
                //,[TotalItems] ,[SubTotalItems] ,[ReOrder] ,[Manufacture] ,[ExpiredDate] FROM [dbo].[Product_Master]
                string ti = (string)dr["TotalItems"].ToString();
                Txttotali.Text = ti;

                string st = (string)dr["SubTotalItems"].ToString();
                Txtsubtotali.Text = st;

                //string co = (string)dr["CompanyName"].ToString();
                //TxtsupplierCom.Text = co;
            }


            con.Close();
        }

        private void Txtproductname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 ? false : true;
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
            if (Txtquantity.Text=="")
            {
                Txtprice.Text = "";
            }
            try
            {
                Txtprice.Text = Convert.ToString(Convert.ToDouble(Txtpurchage.Text) * Convert.ToInt32(Txtquantity.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

                Txttottal.Text = "0.00";
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    Txttottal.Text = Convert.ToString(double.Parse(Txttottal.Text) + double.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString()));
                }
                double x;
                double.TryParse(Txttottal.Text, out x);
                Txttottal.Text = x.ToString("0.00");
                if (Txtunitname.Text == "BOX")
                {
                    int a, b, c, d, p, q, em = 0, f = 0, g = 0, m = 0, n = 0;
                    a = int.Parse(Txtcurrentstock.Text);//Quantity of Total items
                    b = int.Parse(Txtquantity.Text);//Quantity of Purchase items
                    c = int.Parse(Txthitems.Text);//No. of Unit in a Box
                    d = int.Parse(Txthsuitems.Text);//No. of subunits in a STRIP
                    p = int.Parse(Txttotali.Text);
                    q = int.Parse(Txtsubtotali.Text);
                    //Boxes Items
                    em = a+b;
                    m = b * c;
                    n = m * d;

                    f = p + m;
                    //Items in Number
                    g = q + n;
                    //SELECT TOP 1000 [ProductID] ,[Category] ,[UnitName] ,[ProductName] ,[GenericName] ,[RackNo] ,[Weight] ,[CompanyName] ,[PurchageRate] ,
                    //[MRPRate] ,[SaleRate] ,[Items] ,[Unit1] ,[ItemsUnit] ,[SubItems] ,[Unit2] ,[SubItemsUnit] ,[SubItemPack] ,[Quantity] ,[Discount] ,[TotalItems] ,
                    //[SubTotalItems] ,[ReOrder] ,[Manufacture] ,[ExpiredDate] FROM [dbo].[Product_Master]
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE Product_Master SET [Quantity]='" + em + "',[TotalItems]='" + f + "',[SubTotalItems]='" + g + "' where [ProductID]='" + Txtproductid.Text + "'";
                    cmd.ExecuteNonQuery();
                   // MessageBox.Show("Record is successfully updated", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Problem Found");
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
                Txtpurchage.Text="";
                Txtsale.Text = "";

            }
        }

        private void Txttottal_TextChanged(object sender, EventArgs e)
        {
            Txttottal1.Text=Txttottal.Text ;
        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            //SELECT TOP 1000[Purchage_ID] ,[Supplier_Name] ,[Supplier_Company] ,[Purchage_Date] ,[Product_ID] ,[Product_Name] ,[Category] ,[UnitName] ,
            //[Purchage_Rate] ,[MRP_Rate] ,[Sale_Rate] ,[Quantity] ,[Price] ,[Total_Price] ,[Payment] ,[Remark] FROM[dbo].[Purchase]
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"insert into Purchase (Purchase_ID, Supplier_Name, Supplier_Company, Purchage_Date, Product_ID, Product_Name, Category, UnitName,
                    Purchage_Rate, MRP_Rate, Sale_Rate, Quantity, Price, Total_Price, Payment, Remark)VALUES(@Purchase_ID, @Supplier_Name, @Supplier_Company, @Purchage_Date, @Product_ID, @Product_Name, @Category, @UnitName,
                    @Purchage_Rate, @MRP_Rate, @Sale_Rate, @Quantity, @Price, @Total_Price, @Payment, @Remark)", con);
                    cmd.Parameters.AddWithValue("@Supplier_Name", TxtSuppliername.Text);
                    cmd.Parameters.AddWithValue("@Supplier_Company", TxtsupplierCom.Text);
                    cmd.Parameters.AddWithValue("@Purchage_Date", Txtsupplierdate.Text);
                    cmd.Parameters.AddWithValue("@Purchase_ID", dataGridView1.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@Product_Name", dataGridView1.Rows[i].Cells[1].Value);
                    cmd.Parameters.AddWithValue("@Category", dataGridView1.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@UnitName", dataGridView1.Rows[i].Cells[3].Value);
                    cmd.Parameters.AddWithValue("@Purchage_Rate", dataGridView1.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("@MRP_Rate", dataGridView1.Rows[i].Cells[5].Value);
                    cmd.Parameters.AddWithValue("@Sale_Rate", dataGridView1.Rows[i].Cells[6].Value);
                    cmd.Parameters.AddWithValue("@Quantity", dataGridView1.Rows[i].Cells[7].Value);
                    cmd.Parameters.AddWithValue("@Price", dataGridView1.Rows[i].Cells[8].Value);
                    cmd.Parameters.AddWithValue("@Product_ID", TxtproID.Text);
                    cmd.Parameters.AddWithValue("@Total_Price", Txttottal.Text);
                    cmd.Parameters.AddWithValue("@Payment", Txtpayment.Text);
                    cmd.Parameters.AddWithValue("@Remark", Txtremark.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Purchase Successfully","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
                TxtproID.Text = "";
            }
            try
            {
                int a;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select Max (Purchase_ID) from Purchase";
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
              //  dataGridView1.Rows.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Txttimer.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
}
