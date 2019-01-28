using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MedicalStore
{
    public partial class Saleform : MetroFramework.Forms.MetroForm
    {
        SqlConnection con = new SqlConnection
        {
            ConnectionString = @"Data Source=DESKTOP-TNVK8MO\ARIF;Initial Catalog=MedicalStore;Integrated Security=True"
        };

        public Saleform(MedicalStore.AdminForm pa)
        {
            InitializeComponent();
            this.MdiParent = pa;

        }
        public int c;
        private void timer1_Tick(object sender, EventArgs e)
        {
            TxttimerS.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void Saleform_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'medicalStoreDataSet.Customer_Information' table. You can move, or remove it, as needed.
            //this.customer_InformationTableAdapter.Fill(this.medicalStoreDataSet.Customer_Information);

            TxttimerS.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();

            TxtDayofweek.Text = DateTime.Now.DayOfWeek.ToString();
            timer2.Start();

            TxtMonth.Text = DateTime.Today.ToString("MMMM");
            timer3.Start();

            //SqlCommand cmd = new SqlCommand("select ProductName from Product_Master",con);
            //con.Open();
            //SqlDataReader dr = cmd.ExecuteReader();
            //AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            //while (dr.Read())
            //{
            //    col.Add(dr.GetString(0));
            //}
            //Txtproductname.AutoCompleteCustomSource = col;
            //con.Close();

            Txtsaler.Text = AdminForm.passtext;

            //get product name
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT DISTINCT GenericName FROM Product_Master";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    //Txtproductname.Items.Add(dr["ProductName"].ToString());
                    TxtGeneric.Items.Add(dr["GenericName"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Load Customer Information
            //try
            //{
            //    con.Open();
            //    SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM Customer_Information", con);
            //    DataSet ds = new DataSet();
            //    adptr.Fill(ds);
            //    DataTable dt = ds.Tables[0];
            //    dataGridView2.DataSource = dt;
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //Get Customer Name
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT DISTINCT CPhoneNo FROM Saleinfor";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    TxtcustomerS.Items.Add(dr["CPhoneNo"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Generate new invoice no
            //SELECT TOP 1000 [InvoiceNo] ,[CustomerName] ,[saleyear] ,[saledate] ,[saletime] ,[serialno] ,[categoryname] ,[productname] ,[unit] ,[salerate] 
            //,[quantity] ,[Price] ,[totalrate] ,[discount] ,[vat] ,[servicetax] ,[paidby] ,[remark] ,[withtax] ,[lessamount] ,[lesstotal] ,[cashpaid] ,
            //[changeAmount] FROM [dbo].[Saleinfo]
            try
            {
                int a;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select Max (InvoiceNo) from Saleinfor";
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string val = dr[0].ToString();
                    if (val == "")
                    {
                        Txtinvoiceno.Text = "1";
                    }
                    else
                    {
                        a = Convert.ToInt32(dr[0].ToString());
                        a = a + 1;
                        Txtinvoiceno.Text = a.ToString();
                    }
                    con.Close();
                }
               //dataGridView.Rows.Clear();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void metroTextBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void Txtmobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void Txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar==32 || e.KeyChar==46 ? false : true;
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int row = 0;
            row = dataGridView.Rows.Count - 1;
            dataGridView["invoiceid", row].Value = Txtinvoiceno.Text;
            dataGridView.Refresh();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            float total;
            total = float.Parse(Txttotalp.Text);
            try
            {
                //add text item in datagridview
                int row1 = 0;
                dataGridView.Rows.Add();
                row1 = dataGridView.Rows.Count - 1;
                dataGridView["invoiceid", row1].Value = Txtinvoiceno.Text;
                dataGridView["categoryname", row1].Value = Txtcategory.Text;
                dataGridView["productname", row1].Value = Txtproductname.Text;
                dataGridView["unit", row1].Value = Txtunit.Text;
                dataGridView["currentstock", row1].Value = Txtcurrent.Text;
                dataGridView["mrprate", row1].Value = Txtmrp.Text;
                dataGridView["salerate", row1].Value = Txtsale.Text;
                dataGridView["quantity", row1].Value = Txtquantity.Text;
                dataGridView["price", row1].Value = Txtprice.Text;
                dataGridView["PurchagePrice",row1].Value = TxtPriceRate.Text;
                dataGridView["productids", row1].Value = Txtproductid.Text;
                dataGridView["RackID", row1].Value = Txtrack.Text;
                
                Txttotal.Text = "0.00";
                TxtpurTotal.Text = "0.00";
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    Txttotal.Text = Convert.ToString(double.Parse(Txttotal.Text) + double.Parse(dataGridView.Rows[i].Cells[9].Value.ToString()));
                    TxtpurTotal.Text = Convert.ToString(double.Parse(TxtpurTotal.Text) + double.Parse(dataGridView.Rows[i].Cells[10].Value.ToString()));
                }
                double x,y;
                double.TryParse(Txttotal.Text, out x);
                double.TryParse(TxtpurTotal.Text, out y);
                Txttotal.Text = x.ToString("0.00");
                TxtpurTotal.Text = y.ToString("0.00");
                if (total>=2000.00)
                {
                    Txtdiscount.Text = "5";
                }
                else if (total < 2000.00)
                {
                    Txtdiscount.Text = "0";
                }
                DateTime txts = TxtdateS.Value.Date;
                DateTime txte = TxtExpiredate.Value.Date;

                TimeSpan ts = txte - txts;

                if (Txtunit.Text == "BOX")
                {
                    int a, b, c, d, em = 0, f = 0, g = 0;
                    float q,p=0;
                    a = int.Parse(Txtcurrent.Text);//Quantity of Total items
                    b = int.Parse(Txtquantity.Text);//Quantity of Purchase items
                    c = int.Parse(Txthitems.Text);//No. of Unit in a Box
                    d = int.Parse(Txthsuitems.Text);//No. of subunits in a Box
                    q = int.Parse(TxtpurchageRate.Text);
                    //purchage items rate
                    p = q * b;
                    
                    //Boxes Items
                    em = a ;
                    if (em < 10)
                    {
                        MessageBox.Show("Medicine " + Txtproductname.Text + " low of Stocks", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                        
                    else if (em<0)
                    {
                        DialogResult re = MessageBox.Show("Medicine " + Txtproductname.Text + "out of stocks!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (re == DialogResult.OK)
                        {
                            this.Show();
                        }
                    }
                    else
                    {
                        //Strip Items
                        f = em * c;
                        //Items in Number
                        g = f * d;
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE Product_Master SET [Quantity]='" + em + "',[TotalItems]='" + f + "',[SubTotalItems]='" + g + "' where [ProductID]='" + Txtproductid.Text + "'";
                        cmd.ExecuteNonQuery();



                        MessageBox.Show("Medicine " + Txtproductname.Text + " Expired at " + ts.TotalDays.ToString() + " Days!", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                    }
                    
                    
                }
                else if (Txtunit.Text == "STRIP")
                {
                    int a, b, c, d, em = 0, f = 0, g = 0, h = 0, i = 0;
                    a = int.Parse(Txtcurrent.Text);
                    b = int.Parse(Txtquantity.Text);
                    c = int.Parse(Txthitems.Text);
                    d = int.Parse(Txthsuitems.Text);


                    em = a;
                    f = em * d;
                    g = em / c;
                    h = em % c;
                    i = g + h;
                    if (i < 10)
                        MessageBox.Show("Medicine " + Txtproductname.Text + " low of Stocks", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //txtre.Text = i.ToString();
                    //txtresub.Text = em.ToString();
                    //txtretot.Text = f.ToString();
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE Product_Master SET [Quantity]='" + i + "',[TotalItems]='" + em + "',[SubTotalItems]='" + f + "' where [ProductID]='" + Txtproductid.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Medicine " + Txtproductname.Text + " Expired at " + ts.TotalDays.ToString() + " Days!", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                else if (Txtunit.Text=="NUMBER")
                {
                    int a, b, c, d, em = 0, f = 0, g = 0, h = 0, i = 0;
                    a = int.Parse(Txtcurrent.Text);
                    b = int.Parse(Txtquantity.Text);
                    c = int.Parse(Txthitems.Text);
                    d = int.Parse(Txthsuitems.Text);

                    if (b<d)
                    {
                        int p = 1;
                        em = a;
                        f = em / d;
                        g = f + p;
                        h = g / c;
                        if (h < 10)
                            MessageBox.Show("Medicine " + Txtproductname.Text + " low of Stocks", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //txtre.Text = h.ToString();
                        //txtresub.Text = g.ToString();
                        //txtretot.Text = em.ToString();
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE Product_Master SET [Quantity]='" + h + "',[TotalItems]='" + g + "',[SubTotalItems]='" + em + "' where [ProductID]='" + Txtproductid.Text + "'";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Medicine " + Txtproductname.Text + " Expired at " + ts.TotalDays.ToString() + " Days!", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                    }
                    else if(b>d)
                    {
                        int p = 1;
                        em = a;
                        f = em / d;
                        g = f + p;
                        h = g / c;
                        if (h < 10)
                            MessageBox.Show("Out of Stocks", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //txtre.Text = h.ToString();
                        //txtresub.Text = g.ToString();
                        //txtretot.Text = em.ToString();
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE Product_Master SET [Quantity]='" + h + "',[TotalItems]='" + g + "',[SubTotalItems]='" + em + "' where [ProductID]='" + Txtproductid.Text + "'";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Medicine " + Txtproductname.Text + " Expired at " + ts.TotalDays.ToString() + " Days!", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                STxtcompany.Text = "";
                TxtGeneric.Text = "";

            }

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView.Rows[e.RowIndex].Cells["productid"].Value = (e.RowIndex + 1).ToString();
        }

        private void Txtproductname_Enter(object sender, EventArgs e)
        {

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

                    string cat = (string)dr["Category"].ToString();
                    Txtcategory.Text = cat;

                    string cur = (string)dr["Quantity"].ToString();
                    Txtcurrent.Text = cur;
                    Txtmirror.Text = cur;

                    string rack = (string)dr["RackNo"].ToString();
                    Txtrack.Text = rack;

                    string mrp = (string)dr["MRPRate"].ToString();
                    Txtmrp.Text = mrp;

                    string sale = (string)dr["SaleRate"].ToString();
                    Txtsale.Text = sale;

                    string ite = (string)dr["Items"].ToString();
                    Txthitems.Text = ite;

                    string subite = (string)dr["SubItems"].ToString();
                    Txthsuitems.Text = subite;

                    string subitem = (string)dr["SubItemPack"].ToString();
                    Txthsubitempack.Text = subitem;

                    string totite = (string)dr["TotalItems"].ToString();
                    Txthtotalitems.Text = totite;

                    string subitetot = (string)dr["SubTotalItems"].ToString();
                    Txthsubtotalitems.Text = subitetot;

                    string pur = (string)dr["PurchageRate"].ToString();
                    TxtpurchageRate.Text = pur;

                    string expd = (string)dr["ExpiredDate"].ToString();
                    TxtExpiredate.Text = expd;

                    string com = (string)dr["CompanyName"].ToString();
                    STxtcompany.Text = com;
                }

                con.Close();          
            

        }

        private void Txtunit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Txtunit.Text=="BOX")
            {
                SqlCommand cmd = new SqlCommand("select * from Product_Master where ProductID='"+Txtproductid.Text+"'",con);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string cur = (string)dr["Quantity"].ToString();
                    Txtcurrent.Text = cur;
                    Txtmirror.Text = cur;


                    string mrp = (string)dr["MRPRate"].ToString();
                    Txtmrp.Text = mrp;

                    string sale = (string)dr["SaleRate"].ToString();
                    Txtsale.Text = sale;

                    string pur = (string)dr["PurchageRate"].ToString();
                    TxtpurchageRate.Text = pur;
                }
            }
            else if (Txtunit.Text=="STRIP")
            {
                SqlCommand cmd = new SqlCommand("select * from Product_Master where ProductID='" + Txtproductid.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string tot = (string)dr["TotalItems"].ToString();
                    Txtcurrent.Text = tot;
                    Txtmirror.Text = tot;

                    string mrp = (string)dr["ItemsUnit"].ToString();
                    Txtmrp.Text = mrp;

                    string mr = (string)dr["ItemsUnit"].ToString();
                    Txtsale.Text = mr;

                    string pur = (string)dr["PurItemsUnit"].ToString();
                    TxtpurchageRate.Text = pur;
                }
            }
            else if (Txtunit.Text == "NUMBER")
            {
                SqlCommand cmd = new SqlCommand("select * from Product_Master where ProductID='"+Txtproductid.Text+"'",con);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string subt = (string)dr["SubTotalItems"].ToString();
                    Txtcurrent.Text = subt;
                    Txtmirror.Text = subt;

                    string mrp = (string)dr["SubItemsUnit"].ToString();
                    Txtmrp.Text = mrp;

                    string sale = (string)dr["SubItemsUnit"].ToString();
                    Txtsale.Text = sale;

                    string pur = (string)dr["SubPurItemsUnit"].ToString();
                    TxtpurchageRate.Text = pur;
                }
            }
            con.Close();


        }

        private void Txtquantity_TextChanged(object sender, EventArgs e)
        {
            if (Txtquantity.Text == "")
            {
                TxtPriceRate.Text = "";
                Txtprice.Text = "";
                Txtcurrent.Text = Txtmirror.Text;
            }
            try
            {
                Txtprice.Text = Convert.ToString(Convert.ToDouble(Txtsale.Text) * Convert.ToInt32(Txtquantity.Text)).ToString();
                Txtcurrent.Text = Convert.ToString(Convert.ToInt32(Txtcurrent.Text) - Convert.ToInt32(Txtquantity.Text)).ToString();
                TxtPriceRate.Text = Convert.ToString(Convert.ToDouble(TxtpurchageRate.Text)*Convert.ToInt32(Txtquantity.Text)).ToString();
            }
            catch
            {

            }
            
        }

        private void Txtdiscount_TextChanged(object sender, EventArgs e)
        {
            double total = 0, discount, givendis, saleprice = 0;
            if (Txtdiscount.Text == "")
            {
                Txttotal1.Text = Txttotal.Text;
                Txtdiscount1.Text = null;
            }
            try
            {
            total = double.Parse(Txttotal.Text);
            discount = double.Parse(Txtdiscount.Text);
            givendis = total * (discount / 100);
            saleprice = total - givendis;
            Txtdiscount1.Text = givendis.ToString("#.##");
            Txttotal1.Text = saleprice.ToString("#.##");
                
            }
            catch(Exception ex)
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
                re = given- double.Parse(txtlessamount.Text);
                txtremain.Text = re.ToString("0.00");
                

            }
            catch
            {

            }
        }

        private void Txttotal_TextChanged(object sender, EventArgs e)
        {
            
            Txttotal1.Text = Txttotal.Text;
        }

        private void Txtless_TextChanged(object sender, EventArgs e)
        {
            if (Txtless.Text == "")
            {
                txtlessamount.Text = "0.00";
            }

            try
            {
                 
                    txtlessamount.Text = Convert.ToString(Convert.ToDouble(Txttotal1.Text) - Convert.ToDouble(Txtless.Text)).ToString();
                
            }
            catch
            {

            }
            
        }

        

        private void BtnsubmitS_Click(object sender, EventArgs e)
        {
            //SELECT TOP 1000[CustomerName] ,[saleyear] ,[saledate] ,[saletime] ,[InvoiceNo] ,[serialno] ,[categoryname] ,[productname] ,[unit] ,[salerate] ,
            //[quantity] ,[Price] ,[totalrate] ,[discount] ,[vat] ,[servicetax] ,[paidby] ,[remark] ,[withtax] ,[lessamount] ,[lesstotal] ,[cashpaid] 
            //,[changeAmount]FROM[dbo].[Saleinfor] ,[PurchagePrice] ,[TotalPurPrice]       
            try
            {
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"insert into Saleinfor (CPhoneNo,saleyear,saledate,saletime,serialno,InvoiceNo,categoryname,productname,unit,salerate,
                quantity,Price,PurchagePrice,TotalPurPrice,totalrate,discount,vat,servicetax,paidby,remark,withtax,lessamount,lesstotal,cashpaid,changeAmount,day,month,saler)VALUES(@CPhoneNo,@saleyear,@saledate,@saletime,@serialno,@InvoiceNo,@categoryname,@productname,@unit,@salerate,
                @quantity,@Price,@PurchagePrice,@TotalPurPrice,@totalrate,@discount,@vat,@servicetax,@paidby,@remark,@withtax,@lessamount,@lesstotal,@cashpaid,@changeAmount,@day,@month,@saler)", con);
                    cmd.Parameters.AddWithValue("@CPhoneNo", TxtcustomerS.Text);
                    cmd.Parameters.AddWithValue("@saleyear", TxtyearS.Text);
                    cmd.Parameters.AddWithValue("@saledate", TxtdateS.Text);
                    cmd.Parameters.AddWithValue("@saletime", TxttimerS.Text);
                    cmd.Parameters.AddWithValue("@serialno", dataGridView.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@InvoiceNo", dataGridView.Rows[i].Cells[1].Value);
                    cmd.Parameters.AddWithValue("@categoryname", dataGridView.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@productname", dataGridView.Rows[i].Cells[3].Value);
                    cmd.Parameters.AddWithValue("@unit", dataGridView.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("@salerate", dataGridView.Rows[i].Cells[7].Value);
                    cmd.Parameters.AddWithValue("@quantity", dataGridView.Rows[i].Cells[8].Value);
                    cmd.Parameters.AddWithValue("@Price", dataGridView.Rows[i].Cells[9].Value);
                    cmd.Parameters.AddWithValue("@PurchagePrice", dataGridView.Rows[i].Cells[10].Value);
                    cmd.Parameters.AddWithValue("@TotalPurPrice", TxtpurTotal.Text);
                    cmd.Parameters.AddWithValue("@totalrate", Txttotal.Text);
                    cmd.Parameters.AddWithValue("@discount", Txtdiscount1.Text);
                    cmd.Parameters.AddWithValue("@vat", Txtvat1.Text);
                    cmd.Parameters.AddWithValue("@servicetax", Txttax1.Text);
                    cmd.Parameters.AddWithValue("@paidby", TxtpaymentS.Text);
                    cmd.Parameters.AddWithValue("@remark", TxtremarkS.Text);
                    cmd.Parameters.AddWithValue("@withtax", Txttotal1.Text);
                    cmd.Parameters.AddWithValue("@lessamount", Txtless.Text);
                    cmd.Parameters.AddWithValue("@lesstotal", txtlessamount.Text);
                    cmd.Parameters.AddWithValue("@cashpaid", Txtgiven.Text);
                    cmd.Parameters.AddWithValue("@changeAmount", txtremain.Text);
                    cmd.Parameters.AddWithValue("@day", TxtDayofweek.Text);
                    cmd.Parameters.AddWithValue("@month", TxtMonth.Text);
                    cmd.Parameters.AddWithValue("@saler", Txtsaler.Text);

                    cmd.ExecuteNonQuery();                    
                    con.Close();
                    
                }
                DialogResult re = MessageBox.Show("Do you want to print Invoice!", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (re == DialogResult.Yes)
                {
                    Report_Form.SalesReport sr = new Report_Form.SalesReport(Txtinvoiceno.Text);
                    sr.Show();
                }
                else
                {
                    this.Show();
                }               
                dataGridView.Rows.Clear();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Txttotal.Text = "";
                Txttotal1.Text = "";
                Txtdiscount.Text = "";
                Txttax.Text = "";
                Txtvat.Text = "";
                Txtless.Text = "";
                txtlessamount.Text = "";
                Txtgiven.Text = "";
                txtremain.Text = "";
                TxtpaymentS.Text = "";
                TxtremarkS.Text = "";
                TxtcustomerS.Text = "";
                Txttotalp.Text = "0";
                TxtpaymentS.Text = "";

            }
            try
            {
                int a;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select Max (InvoiceNo) from Saleinfor";
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string val = dr[0].ToString();
                    if (val == "")
                    {
                        Txtinvoiceno.Text = "1";
                    }
                    else
                    {
                        a = Convert.ToInt32(dr[0].ToString());
                        a = a + 1;
                        Txtinvoiceno.Text = a.ToString();
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtncancelS_Click(object sender, EventArgs e)
        {
            Txtdiscount.Text = "";
            Txtvat.Text = "";
            Txttax.Text = "";
            Txtless.Text = "";
            Txtgiven.Text = "";
            TxtpaymentS.Text = "";
            TxtremarkS.Text = "";
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                int delete = dataGridView.CurrentCell.RowIndex;
                dataGridView.Rows.RemoveAt(delete);
                if (txtre.Text == "BOX")
                {
                    int a, b, c, d,q,r, em = 0, f = 0, g = 0,n=0,m=0;
                    
                    a = int.Parse(Txtmirror.Text);//Quantity of Total items
                    b = int.Parse(txtup.Text);//Quantity of Purchase items
                    c = int.Parse(Txthitems.Text);//No. of Unit in a Box
                    d = int.Parse(Txthsuitems.Text);//No. of subunits in a Box
                    q = int.Parse(Txthtotalitems.Text);
                    r = int.Parse(Txthsubtotalitems.Text);
                    
                    //Boxes Items
                    em = a + b;//purchage+available
                    n = a * c;//purchage*unit in a box
                    f = n + q;
                    //Items in Number
                    m = n * d;
                    g = m + r;
                    //txtre.Text = em.ToString();
                    //txtresub.Text = f.ToString();
                    //txtretot.Text = g.ToString();
                    //SELECT TOP 1000 [ProductID] ,[Category] ,[UnitName] ,[ProductName] ,[GenericName] ,[RackNo] ,[Weight] ,[CompanyName] ,[PurchageRate] ,
                    //[MRPRate] ,[SaleRate] ,[Items] ,[Unit1] ,[ItemsUnit] ,[SubItems] ,[Unit2] ,[SubItemsUnit] ,[SubItemPack] ,[Quantity] ,[Discount] ,[TotalItems] ,
                    //[SubTotalItems] ,[ReOrder] ,[Manufacture] ,[ExpiredDate] FROM [dbo].[Product_Master]
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE Product_Master SET [Quantity]='" + em + "',[TotalItems]='" + f + "',[SubTotalItems]='" + g + "' where [ProductID]='" + Txtproductid.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product " + Txtproductname.Text + " Deleted From List.", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                else if (txtre.Text == "STRIP")
                {
                    int a, b, c, d, em = 0, f = 0, g = 0, h = 0, m = 0;
                    a = int.Parse(Txtmirror.Text);//Quantity of Total items
                    b = int.Parse(txtup.Text);//Quantity of Purchase items
                    c = int.Parse(Txthitems.Text);
                    d = int.Parse(Txthsuitems.Text);


                    em = a + b;
                    f = em * d;
                    g = em / c;
                    h = em % c;
                    m = g + h;
                    //if (i < 10)
                    //    MessageBox.Show("Out of Stocks", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //txtre.Text = m.ToString();
                    //txtresub.Text = em.ToString();
                    //txtretot.Text = f.ToString();
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE Product_Master SET [Quantity]='" + m + "',[TotalItems]='" + em + "',[SubTotalItems]='" + f + "' where [ProductID]='" + Txtproductid.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product " + Txtproductname.Text + " Deleted From List.", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                else if (txtre.Text == "NUMBER")
                {
                    int a, b, c, d, em = 0, f = 0, g = 0, h = 0;
                    a = int.Parse(Txtmirror.Text);//Quantity of Total items
                    b = int.Parse(txtup.Text);//Quantity of Purchase items
                    c = int.Parse(Txthitems.Text);
                    d = int.Parse(Txthsuitems.Text);

                    if (b < d)
                    {
                        int p = 1;
                        em = a+b;
                        f = em / d;
                        g = f + p;
                        h = g / c;
                        
                        //txtre.Text = h.ToString();
                        //txtresub.Text = g.ToString();
                        //txtretot.Text = em.ToString();
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE Product_Master SET [Quantity]='" + h + "',[TotalItems]='" + g + "',[SubTotalItems]='" + em + "' where [ProductID]='" + Txtproductid.Text + "'";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Product " + Txtproductname.Text + " Deleted From List.", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                    }
                    else if (b > d)
                    {
                        int p = 1;
                        em = a+b;
                        f = em / d;
                        g = f + p;
                        h = g / c;
                        
                        txtre.Text = h.ToString();
                        txtresub.Text = g.ToString();
                        txtretot.Text = em.ToString();
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE Product_Master SET [Quantity]='" + h + "',[TotalItems]='" + g + "',[SubTotalItems]='" + em + "' where [ProductID]='" + Txtproductid.Text + "'";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Product " + Txtproductname.Text + " Deleted From List.", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                txtup.Text = "";
            }
        }

        private void dataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Txtproductname.Text = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
                Txtcategory.Text = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
                Txtrack.Text = dataGridView.SelectedRows[0].Cells[12].Value.ToString();
                Txtunit.Text = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
                
                txtre.Text = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
                Txtmirror.Text = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
                Txtmrp.Text = dataGridView.SelectedRows[0].Cells[6].Value.ToString();
                Txtsale.Text = dataGridView.SelectedRows[0].Cells[7].Value.ToString();
                txtup.Text = dataGridView.SelectedRows[0].Cells[8].Value.ToString();
                Txtprice.Text = dataGridView.SelectedRows[0].Cells[9].Value.ToString();
                Txtproductid.Text = dataGridView.SelectedRows[0].Cells[11].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndelete_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Txtdiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void Txtvat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void Txttax_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void Txtless_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46 ? false : true;
        }

        private void Txtgiven_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46 ? false : true;
        }

        private void Txtquantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void Txtproductname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void TxtcustomerS_SelectedIndexChanged(object sender, EventArgs e)
        {       
            try
            {
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter("select * from Saleinfor where CPhoneNo='" + TxtcustomerS.Text + "'", con);
               
                DataTable dt = new DataTable();
                ad.Fill(dt); 
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            double sum = 0;
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
            }
            Txttotalp.Text = sum.ToString();

        }

        private void TxtcustomerS_TextChanged(object sender, EventArgs e)
        {
            if (TxtcustomerS.Text == "Others")
            {
                Txttotalp.Text = "0";
            }
        }

        private void BtncheckName_CheckedChanged(object sender, EventArgs e)
        {
            if (BtncheckName.Checked)
            {
                c = 1;
                TxtGeneric.Enabled = false;
                TxtGeneric.Text = null;
                //Txtproductname.Text = "";
            }
        }

        private void BtncheckGeneric_CheckedChanged(object sender, EventArgs e)
        {
            if (BtncheckGeneric.Checked)
            {
                c = 2;
                TxtGeneric.Enabled = true;
                Txtproductname.Items.Clear();
                con.Close();
            }
        }

        private void BtncheckName_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT DISTINCT ProductName FROM Product_Master";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Txtproductname.Items.Add(dr["ProductName"].ToString());
                    //TxtGeneric.Items.Add(dr["GenericName"].ToString());
                }
                con.Close();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtncheckGeneric_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT DISTINCT ProductName FROM Product_Master where GenericName='" + TxtGeneric.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Txtproductname.Items.Add(dr["ProductName"].ToString());
                    //TxtGeneric.Items.Add(dr["GenericName"].ToString());
                }
                con.Close();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TxtGeneric_Enter(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT DISTINCT ProductName FROM Product_Master where GenericName='" + TxtGeneric.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Txtproductname.Items.Add(dr["ProductName"].ToString());
                    //TxtGeneric.Items.Add(dr["GenericName"].ToString());
                }
                con.Close();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TxtcustomerS_Click(object sender, EventArgs e)
        {
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            TxtDayofweek.Text = DateTime.Now.DayOfWeek.ToString();
            timer2.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            TxtMonth.Text = DateTime.Today.ToString("MMMMM");
            timer3.Start();
        }
    }
}
