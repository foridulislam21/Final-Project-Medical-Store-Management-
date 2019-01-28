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
    public partial class CSell : MetroFramework.Forms.MetroForm
    {
        SqlConnection con = new SqlConnection()
        {
            ConnectionString = @"Data Source=DESKTOP-TNVK8MO\ARIF;Initial Catalog=MedicalStore;Integrated Security=True"

        };
       // private readonly object TxtGeneric;

        public CSell(MedicalStore.AdminForm pa)
        {
            InitializeComponent();
            this.MdiParent = pa;
            
        }

        private void CSell_Load(object sender, EventArgs e)
        {
            Txtcashier.Text = AdminForm.passtext;

            this.ActiveControl = Txtcon;
        
            Txttime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
            //Auto create Invoice ID
            try
            {
                int a;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT MAX (Id) from Csellinfo";
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string val = dr[0].ToString();
                    if (val == "")
                    {
                        Txtinvoice.Text = "1";
                    }
                    else
                    {
                        a = Convert.ToInt32(dr[0].ToString());
                        a = a + 1;
                        Txtinvoice.Text = a.ToString();
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //get organization purshase price
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT DISTINCT Orname FROM Csellinfo";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Txtcon.Items.Add(dr["Orname"].ToString());
                }
                con.Close();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT DISTINCT ProName FROM CProductMaster";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Txtproductname.Items.Add(dr["ProName"].ToString());
                }
                con.Close();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            float total;
            total = float.Parse(Txttotalp.Text);
            DialogResult re = MessageBox.Show("Chemical " + Txtproductname.Text + " Added to Cart.", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (re == DialogResult.OK)
            {
                try
                {
                    int row1 = 0;
                    dataGridView.Rows.Add();
                    row1 = dataGridView.Rows.Count - 1;
                    dataGridView["invoiceid", row1].Value = Txtinvoice.Text;
                    dataGridView["categoryname", row1].Value = Txtcategory.Text;
                    dataGridView["productname", row1].Value = Txtproductname.Text;
                    dataGridView["unit", row1].Value = Txtunit.Text;
                    dataGridView["currentstock", row1].Value = Txtcurrent.Text;
                    dataGridView["mrprate", row1].Value = Txtmrp.Text;
                    dataGridView["salerate", row1].Value = Txtsale.Text;
                    dataGridView["quantity", row1].Value = Txtquantity.Text;
                    dataGridView["price", row1].Value = Txtprice.Text;
                    dataGridView["PurchagePrice", row1].Value = Txtpurchase.Text;
                    dataGridView["productids", row1].Value = Txtproductid.Text;
                    dataGridView["RackID", row1].Value = Txtrack.Text;

                    Txttamount.Text = "0.00";
                    Txtptotal.Text = "0.00";
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        Txttamount.Text = Convert.ToString(double.Parse(Txttamount.Text) + double.Parse(dataGridView.Rows[i].Cells[9].Value.ToString()));
                        Txtptotal.Text = Convert.ToString(double.Parse(Txtptotal.Text) + double.Parse(dataGridView.Rows[i].Cells[10].Value.ToString()));
                    }
                    double x, y;
                    double.TryParse(Txttamount.Text, out x);
                    double.TryParse(Txtptotal.Text, out y);
                    Txttamount.Text = x.ToString("0.00");
                    Txtptotal.Text = y.ToString("0.00");
                    if (total >= 2000.00)
                    {
                        Txtdiscount.Text = "5";
                    }
                    else if (total < 2000.00)
                    {
                        Txtdiscount.Text = "0";
                    }
                    Txtproductname.Focus();
                    //SELECT TOP 1000[ProCode] ,[ProName] ,[PhyState] ,[ComName] ,[Grade] ,[Unit] ,[UnitName] ,[Image] ,
                    //[Origin] ,[Purchase] ,[PackageT] ,[MRP] ,[SaleRate] ,[PackageS] ,[TUnit] ,[TUnitName] ,[Usage] ,[Tsale] 
                    //,[Tpurchase] ,[Vat] ,[Discount] ,[Quantity] ,[RName] ,[RackNo] FROM[dbo].[CProductMaster]
                    double a;
                    a = double.Parse(Txtcurrent.Text);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE CProductMaster SET TUnit='" + a + "' where ID='" + Txtproductid.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                finally
                {
                    Txtproductname.Text = "";
                    Txtcategory.Text = "";
                    Txtcurrent.Text = "";
                    Txtunit.Text = "";
                    Txtrack.Text = "";
                    Txtmrp.Text = "";
                    Txtsale.Text = "";
                    Txtprice.Text = "";
                    Txtquantity.Text = "";
                    Txtproductid.Text = "";
                    Txtmirror.Text = "";
                    TxtqMirror.Text = "";
                    Txtcurrent.Clear();
                    Txtdiscount.Refresh();
                }
            }
            else
            {
                Txtproductname.Text = "";
                Txtcategory.Text = "";
                Txtcurrent.Text = "";
                Txtunit.Text = "";
                Txtrack.Text = "";
                Txtmrp.Text = "";
                Txtsale.Text = "";
                Txtprice.Text = "";
                Txtquantity.Text = "";
                Txtproductid.Text = "";
                Txtmirror.Text = "";
                TxtqMirror.Text="";
            }
            
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            

            try
            {
                int delete = dataGridView.CurrentCell.RowIndex;
                dataGridView.Rows.RemoveAt(delete);
                double a, b, c = 0;
                a = double.Parse(Txtcurrent.Text);
                b = double.Parse(TxtqMirror.Text);
                c = (double)a + (double)b;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE CProductMaster SET [TUnit]='" + c + "' where [ID]='" + Txtproductid.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Chemical " + Txtproductname.Text + " Deleted From List!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //cmd.Connection.Close();
                con.Close();
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                Txtproductname.Text = "";
                Txtcategory.Text = "";
                Txtcurrent.Text = "";
                Txtunit.Text = "";
                Txtrack.Text = "";
                Txtmrp.Text = "";
                Txtsale.Text = "";
                Txtprice.Text = "";
                Txtquantity.Text = "";
                Txtproductid.Text = "";
                Txtmirror.Text = "";
                TxtqMirror.Text = "";
            }
        }

        private void BtnsubmitS_Click(object sender, EventArgs e)
        {
            //SELECT TOP 1000[Id] ,[Orname] ,[saleyear] ,[saledate] ,[saletime] ,[serialno] ,[InvoiceNo] ,[categoryname] ,[productname] ,[unit] ,
            //[salerate] ,[quantity] ,[Price] ,[PurchagePrice] ,[TotalPurPrice] ,[totalrate] ,[discount] ,[vat] ,[servicetax] ,[paidby] ,[remark] 
            //,[withtax] ,[lessamount] ,[lesstotal] ,[cashpaid] ,[changeAmount] FROM[dbo].[Csellinfo]
            try
            {
                for(int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"insert into Csellinfo (Orname,saleyear,saledate,saletime,serialno,InvoiceNo,categoryname,productname,unit,salerate,
                quantity,Price,PurchagePrice,TotalPurPrice,totalrate,discount,vat,servicetax,paidby,remark,withtax,lessamount,lesstotal,cashpaid,changeAmount)VALUES(@Orname,@saleyear,@saledate,@saletime,@serialno,@InvoiceNo,@categoryname,@productname,@unit,@salerate,
                @quantity,@Price,@PurchagePrice,@TotalPurPrice,@totalrate,@discount,@vat,@servicetax,@paidby,@remark,@withtax,@lessamount,@lesstotal,@cashpaid,@changeAmount)", con);
                    cmd.Parameters.AddWithValue("@Orname", Txtcon.Text);
                    cmd.Parameters.AddWithValue("@saleyear", Txtyear.Text);
                    cmd.Parameters.AddWithValue("@saledate", Txtdate.Text);
                    cmd.Parameters.AddWithValue("@saletime", Txttime.Text);
                    cmd.Parameters.AddWithValue("@serialno", dataGridView.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@InvoiceNo", dataGridView.Rows[i].Cells[1].Value);
                    cmd.Parameters.AddWithValue("@categoryname", dataGridView.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@productname", dataGridView.Rows[i].Cells[3].Value);
                    cmd.Parameters.AddWithValue("@unit", dataGridView.Rows[i].Cells[8].Value);
                    cmd.Parameters.AddWithValue("@salerate", dataGridView.Rows[i].Cells[6].Value);
                    cmd.Parameters.AddWithValue("@quantity", dataGridView.Rows[i].Cells[7].Value);
                    cmd.Parameters.AddWithValue("@Price", dataGridView.Rows[i].Cells[9].Value);
                    cmd.Parameters.AddWithValue("@PurchagePrice", dataGridView.Rows[i].Cells[10].Value);
                    cmd.Parameters.AddWithValue("@TotalPurPrice", Txtptotal.Text);
                    cmd.Parameters.AddWithValue("@totalrate", Txttamount.Text);
                    cmd.Parameters.AddWithValue("@discount", Txtdiscount1.Text);
                    cmd.Parameters.AddWithValue("@vat", Txtvat1.Text);
                    cmd.Parameters.AddWithValue("@servicetax", Txttax1.Text);
                    cmd.Parameters.AddWithValue("@paidby", TxtpaymentS.Text);
                    cmd.Parameters.AddWithValue("@remark", TxtremarkS.Text);
                    cmd.Parameters.AddWithValue("@withtax", Txtwtamount.Text);
                    cmd.Parameters.AddWithValue("@lessamount", Txtless.Text);
                    cmd.Parameters.AddWithValue("@lesstotal", txtlessamount.Text);
                    cmd.Parameters.AddWithValue("@cashpaid", Txtgiven.Text);
                    cmd.Parameters.AddWithValue("@changeAmount", txtremain.Text);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                DialogResult re = MessageBox.Show("Do you want to print Invoice!", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (re == DialogResult.Yes)
                {
                    CReport_Form.CSales sc = new CReport_Form.CSales(Txtinvoice.Text);
                    sc.Show();
                }
                else
                {
                    this.Show();
                }
                dataGridView.Rows.Clear();
                Txtcon.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Txttamount.Text = "0.00";
                Txtwtamount.Text = "0.00";
                Txtdiscount.Text = "0.00";
                Txttax.Text = "0.00";
                Txtvat.Text = "0.00";
                Txtless.Text = "0.00";
                txtlessamount.Text = "0.00";
                Txtgiven.Text = "0.00";
                txtremain.Text = "0.00";
                TxtpaymentS.Text = "";
                TxtremarkS.Text = "";
                Txtcon.Text = "";
                Txtcon.Refresh();
                
            }
            //Auto create Invoice ID
            try
            {
                int a;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT MAX (Id) from Csellinfo";
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string val = dr[0].ToString();
                    if (val == "")
                    {
                        Txtinvoice.Text = "1";
                    }
                    else
                    {
                        a = Convert.ToInt32(dr[0].ToString());
                        a = a + 1;
                        Txtinvoice.Text = a.ToString();
                    }
                }
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Txtquantity_TextChanged(object sender, EventArgs e)
        {
            if (Txtquantity.Text == "")
            {
                Txtprice.Text = "0.00";
                Txtpurchase.Text = "0.00";
                Txtcurrent.Text = Txtmirror.Text;
            }
            try
            {
                float q;
                q = float.Parse(Txtquantity.Text);
                Txtprice.Text = Convert.ToString(Convert.ToDouble(Txtsale.Text) * Convert.ToDouble(Txtquantity.Text)).ToString();
                Txtcurrent.Text = Convert.ToString(Convert.ToDouble(Txtcurrent.Text) - Convert.ToDouble(Txtquantity.Text)).ToString();
                Txtpurchase.Text = Convert.ToString(Convert.ToDouble(Txtprate.Text) * Convert.ToDouble(Txtquantity.Text)).ToString();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void Txtproductname_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SELECT TOP 1000[ProCode] ,[ProName] ,[PhyState] ,[ComName] ,[Grade] ,[Unit] ,[UnitName] ,[Image] ,
            //[Origin] ,[Purchase] ,[PackageT] ,[MRP] ,[SaleRate] ,[PackageS] ,[TUnit] ,[TUnitName] ,[Usage] ,[Tsale] 
            //,[Tpurchase] ,[Vat] ,[Discount] ,[Quantity] ,[RName] ,[RackNo] FROM[dbo].[CProductMaster]
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
                Txtcurrent.Text = cur;
                Txtmirror.Text = cur;

                string rack = (string)dr["RackNo"].ToString();
                Txtrack.Text = rack;

                string unit = (string)dr["TUnitName"].ToString();
                Txtunit.Text = unit;

                string mrp = (string)dr["MRP"].ToString();
                Txtmrp.Text = mrp;

                string sale = (string)dr["SaleRate"].ToString();
                Txtsale.Text = sale;

                string pur = (string)dr["Purchase"].ToString();
                Txtprate.Text = pur;
            }
            Txtdiscount.Text = "";

            con.Close();
        }

        private void Txttamount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Txtwtamount.Text=Txttamount.Text;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Txttime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void Txtless_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtlessamount.Text = Convert.ToDouble(Convert.ToDouble(Txtwtamount.Text) - Convert.ToDouble(Txtless.Text)).ToString();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void Txtgiven_TextChanged(object sender, EventArgs e)
        {
            double given = 0, re;
            if (Txtgiven.Text == "")
            {
                txtremain.Text = "0.00";
            }
            try
            {

                given = double.Parse(Txtgiven.Text);
                re = given - double.Parse(txtlessamount.Text);
                txtremain.Text = re.ToString("0.00");


            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView.Rows[e.RowIndex].Cells["productid"].Value = (e.RowIndex + 1).ToString();
        }

        private void Txtdiscount_TextChanged(object sender, EventArgs e)
        {
            double total = 0, discount, givendis, saleprice = 0;
            if (Txtdiscount.Text == "")
            {
                Txtwtamount.Text = Txttamount.Text;
                Txtdiscount1.Text = null;
            }
            try
            {
                total = double.Parse(Txttamount.Text);
                discount = double.Parse(Txtdiscount.Text);
                givendis = total * (discount / 100);
                saleprice = total - givendis;
                Txtdiscount1.Text = givendis.ToString("#.##");
                Txtwtamount.Text = saleprice.ToString("#.##");

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void CSell_Activated(object sender, EventArgs e)
        {
            //Txtproductname.Items.Clear();
        }

        private void Txtcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter("select * from Csellinfo where Orname='" + Txtcon.Text + "'", con);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            double sum = 0;
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
            }
            Txttotalp.Text = sum.ToString();
        }

        private void dataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            try
            {
                Txtproductname.Text = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
                Txtproductid.Text = dataGridView.SelectedRows[0].Cells[11].Value.ToString();
                Txtcategory.Text= dataGridView.SelectedRows[0].Cells[2].Value.ToString();
                //Txtcurrent.Text = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
                Txtrack.Text = dataGridView.SelectedRows[0].Cells[12].Value.ToString();
                Txtunit.Text= dataGridView.SelectedRows[0].Cells[8].Value.ToString();
                Txtcurrent.Text= dataGridView.SelectedRows[0].Cells[4].Value.ToString();
                Txtmrp.Text= dataGridView.SelectedRows[0].Cells[5].Value.ToString();
                Txtsale.Text= dataGridView.SelectedRows[0].Cells[6].Value.ToString();
                TxtqMirror.Text= dataGridView.SelectedRows[0].Cells[7].Value.ToString();
                Txtprice.Text= dataGridView.SelectedRows[0].Cells[9].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
