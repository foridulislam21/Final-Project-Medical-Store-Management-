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
using System.IO;

namespace MedicalStore
{
    public partial class CProductMaster : MetroFramework.Forms.MetroForm
    {
        SqlConnection con = new SqlConnection()
        {
            ConnectionString = @"Data Source=DESKTOP-TNVK8MO\ARIF;Initial Catalog=MedicalStore;Integrated Security=True"
        };
        public CProductMaster(MedicalStore.AdminForm ca)
        {
            InitializeComponent();
            this.MdiParent = ca;
        }

        private void CProductMaster_Load(object sender, EventArgs e)
        {
            //load every company name from chemical supplier master
            CTxtcom.Items.Clear();
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT scompany FROM CSupplier_Master order by Id";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    CTxtcom.Items.Add(dr["scompany"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //load all entry data in datagridview
            try
            {
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter("select * from CProductMaster", con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataTable dt = ds.Tables[0];
                CdataGridView.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //increase the product id every entry done
            try
            {
                int a;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"select MAX(ID) from CProductMaster";
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string val = dr[0].ToString();
                    if (val == "")
                    {
                        CTxtid.Text = "1";
                    }
                    else
                    {
                        a = Convert.ToInt32(dr[0].ToString());
                        a = a + 1;
                        CTxtid.Text = a.ToString();
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btnbrowse_Click(object sender, EventArgs e)
        {
            
        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            //SELECT TOP 1000[ProCode] ,[ProName] ,[PhyState] ,[ComName] ,[Grade] ,[Unit] ,[UnitName] ,[Image] ,[Origin] ,[Purchase] ,[PackageT] ,[MRP]
            //,[SaleRate] ,[PackageS] ,[TUnit] ,[TUnitName] ,[Usage] ,[Tsale] ,[Tpurchase] ,[Vat] ,[Discount] ,[Quantity] ,[RName] ,[RackNo]
            //FROM[dbo].[CProductMaster]
            try
            {
                con.Open();
                int i = 0;
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO CProductMaster VALUES('"+CTxtid.Text+"','"+CTxtname.Text+"','"+CTxtstate.Text+"','"+CTxtcom.Text+"'," +
                    "'"+CTxtgrade.Text+"','"+CTxtUnit.Text+"','"+CTxtUnitType.Text+"',@Image,'"+CTxtorigin.Text+"','"+CTxtpurchase.Text+"','"+CTxtPackT.Text+"'," +
                    "'"+CTxtMRP.Text+"','"+Txtsrate.Text+"','"+CTxtPackS.Text+"','"+CTxtTotal.Text+"','"+CtxtUnitT.Text+"','"+CTxtUsage.Text+ "','"+TxtTs.Text+"'," +
                    "'"+TxtPr.Text+ "','"+CTxtVat.Text+ "','"+CTxtdis.Text+ "','"+CTxtQP.Text+ "','"+CTxtweight.Text+ "','"+CTxtrack.Text+"')";
                MemoryStream mm = new MemoryStream();
                CTxtpic.Image.Save(mm, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = mm.ToArray();
                cmd.Parameters.AddWithValue("@Image", pic);
                i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Chemical " + CTxtname.Text, "Successfully added in Data.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM [CProductMaster]", con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataTable dt = ds.Tables[0];
                CdataGridView.DataSource = dt;
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CTxtid.Text = "";
                CTxtname.Text = "";
                CTxtstate.Text = null;
                CTxtcom.Text = null;
                CTxtgrade.Text = "";
                CTxtUnit.Text = "";
                CTxtUnitType.Text = null;
                CTxtorigin.Text = "";
                CTxtpurchase.Text = "";
                CTxtPackT.Text = "";
                CTxtMRP.Text = "";
                CTxtPackS.Text = "";
                CTxtTotal.Text = "";
                CtxtUnitT.Text = null;
                CTxtUsage.Text = "";
                CTxtVat.Text = "";
                CTxtdis.Text = "";
                CTxtQP.Text = "";
                CTxtweight.Text = "";
                CTxtrack.Text = null;
                Txtsrate.Text = "";
                CTxtpic.Image = null;
                CdataGridView.Refresh();
                
            }
            try
            {
                int a;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"select MAX(ID) from CProductMaster";
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string val = dr[0].ToString();
                    if (val == "")
                    {
                        CTxtid.Text = "1";
                    }
                    else
                    {
                        a = Convert.ToInt32(dr[0].ToString());
                        a = a + 1;
                        CTxtid.Text = a.ToString();
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                int j = 0;
                SqlCommand ad = new SqlCommand("UPDATE CProductMaster SET ID='" + CTxtid.Text + "',ProName='" + CTxtname.Text + "',PhyState='" + CTxtstate.Text + "',ComName='" + CTxtcom.Text + "',Grade='" + CTxtgrade.Text + "'," +
                        "Unit='" + CTxtUnit.Text + "',UnitName='" + CTxtUnitType.Text + "',Image=@Image,Origin='" + CTxtorigin.Text + "',Purchase='" + CTxtpurchase.Text + "',PackageT='" + CTxtPackT.Text + "',MRP='" + CTxtMRP.Text + "'," +
                        "PackageS='" + CTxtPackS.Text + "',TUnit='" + CTxtTotal.Text + "',TUnitName='" + CtxtUnitT.Text + "',Usage='" + CTxtUsage.Text + "',Vat='" + CTxtVat.Text + "',Discount='" + CTxtdis.Text + "',Quantity='" + CTxtQP.Text + "',RName='" + CTxtweight.Text + "',RackNo='" + CTxtrack.Text + "' where ID=" + CTxtid.Text + "", con);

                MemoryStream ms = new MemoryStream();
                CTxtpic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = ms.ToArray();
                ad.Parameters.AddWithValue("@Image", pic);
                j = ad.ExecuteNonQuery();
                if (j > 0)
                {
                    MessageBox.Show("Record Update Successfully!");

                }
                
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CTxtid.Text = "";
                CTxtname.Text = "";
                CTxtstate.Text = null;
                CTxtcom.Text = null;
                CTxtgrade.Text = "";
                CTxtUnit.Text = "";
                CTxtUnitType.Text = null;
                CTxtorigin.Text = "";
                CTxtpurchase.Text = "";
                CTxtPackT.Text = "";
                CTxtMRP.Text = "";
                CTxtPackS.Text = "";
                CTxtTotal.Text = "";
                CtxtUnitT.Text = null;
                CTxtUsage.Text = "";
                CTxtVat.Text = "";
                CTxtdis.Text = "";
                CTxtQP.Text = "";
                CTxtweight.Text = "";
                CTxtrack.Text = null;
                Txtsrate.Text = "";
                CTxtpic.Image = null;
                CdataGridView.RefreshEdit();
                try
                {
                    int a;
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"select MAX(ID) from CProductMaster";
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        string val = dr[0].ToString();
                        if (val == "")
                        {
                            CTxtid.Text = "1";
                        }
                        else
                        {
                            a = Convert.ToInt32(dr[0].ToString());
                            a = a + 1;
                            CTxtid.Text = a.ToString();
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

        }

        private void Btncancel_Click(object sender, EventArgs e)
        {

        }

        private void CdataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            //SELECT TOP 1000[ProCode] ,[ProName] ,[PhyState] ,[ComName] ,[Grade] ,[Unit] ,[UnitName] ,[Image] ,[Origin] ,[Purchase] ,[PackageT] ,[MRP]
            //,[SaleRate] ,[PackageS] ,[TUnit] ,[TUnitName] ,[Usage] ,[Tsale] ,[Tpurchase] ,[Vat] ,[Discount] ,[Quantity] ,[RName] ,[RackNo]
            //FROM[dbo].[CProductMaster]
            try
            {
                CTxtid.Text = CdataGridView.SelectedRows[0].Cells[0].Value.ToString();
                CTxtname.Text = CdataGridView.SelectedRows[0].Cells[1].Value.ToString();
                CTxtstate.Text = CdataGridView.SelectedRows[0].Cells[2].Value.ToString();
                CTxtcom.Text = CdataGridView.SelectedRows[0].Cells[3].Value.ToString();
                CTxtgrade.Text = CdataGridView.SelectedRows[0].Cells[4].Value.ToString();
                CTxtUnit.Text = CdataGridView.SelectedRows[0].Cells[5].Value.ToString();
                CTxtUnitType.Text = CdataGridView.SelectedRows[0].Cells[6].Value.ToString();
                CTxtorigin.Text = CdataGridView.SelectedRows[0].Cells[8].Value.ToString();
                CTxtpurchase.Text = CdataGridView.SelectedRows[0].Cells[9].Value.ToString();
                CTxtPackT.Text = CdataGridView.SelectedRows[0].Cells[10].Value.ToString();
                CTxtMRP.Text = CdataGridView.SelectedRows[0].Cells[11].Value.ToString();
                Txtsrate.Text = CdataGridView.SelectedRows[0].Cells[12].Value.ToString();
                CTxtPackS.Text = CdataGridView.SelectedRows[0].Cells[13].Value.ToString();
                CTxtTotal.Text = CdataGridView.SelectedRows[0].Cells[14].Value.ToString();
                CtxtUnitT.Text = CdataGridView.SelectedRows[0].Cells[15].Value.ToString();
                CTxtUsage.Text = CdataGridView.SelectedRows[0].Cells[16].Value.ToString();
                TxtTs.Text = CdataGridView.SelectedRows[0].Cells[17].Value.ToString();
                TxtPr.Text = CdataGridView.SelectedRows[0].Cells[18].Value.ToString();
                CTxtVat.Text = CdataGridView.SelectedRows[0].Cells[19].Value.ToString();
                CTxtdis.Text = CdataGridView.SelectedRows[0].Cells[20].Value.ToString();
                CTxtQP.Text = CdataGridView.SelectedRows[0].Cells[21].Value.ToString();
                CTxtweight.Text = CdataGridView.SelectedRows[0].Cells[22].Value.ToString();
                CTxtrack.Text = CdataGridView.SelectedRows[0].Cells[23].Value.ToString();
                if (con.State != ConnectionState.Open)
                    con.Open();
                string ad = "select * from CProductMaster where ID='" + CdataGridView.SelectedRows[0].Cells[0].Value.ToString() + "'";

                SqlCommand cmd = new SqlCommand(ad, con);
                SqlDataReader sr = cmd.ExecuteReader();
                sr.Read();
                if (sr.HasRows)
                {
                    byte[] img = (byte[])(sr[7]);
                    if (img == null)
                    {
                        CTxtpic.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        CTxtpic.Image = Image.FromStream(ms);
                    }
                }
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btnnew_Click(object sender, EventArgs e)
        {
            CTxtid.Text = "";
            CTxtname.Text = "";
            CTxtstate.Text = null;
            CTxtcom.Text = null;
            CTxtgrade.Text = "";
            CTxtUnit.Text = "";
            CTxtUnitType.Text = null;
            CTxtorigin.Text = "";
            CTxtpurchase.Text = "";
            CTxtPackT.Text = "";
            CTxtMRP.Text = "";
            CTxtPackS.Text = "";
            CTxtTotal.Text = "";
            CtxtUnitT.Text = null;
            CTxtUsage.Text = "";
            CTxtVat.Text = "";
            CTxtdis.Text = "";
            CTxtQP.Text = "";
            CTxtweight.Text = "";
            CTxtrack.Text = null;
            Txtsrate.Text = "";
            CTxtpic.Image = null;


            CTxtpic.Image = null;
            try
            {
                int a;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"select MAX(ID) from CProductMaster";
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string val = dr[0].ToString();
                    if (val == "")
                    {
                        CTxtid.Text = "1";
                    }
                    else
                    {
                        a = Convert.ToInt32(dr[0].ToString());
                        a = a + 1;
                        CTxtid.Text = a.ToString();
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CTxtpic_Click(object sender, EventArgs e)
        {
            string imLoc = "";
            try
            {
                OpenFileDialog pi = new OpenFileDialog();
                pi.Filter = "JPG Files(*.jpg)|*.jpg|GIF Files(*.gif)|*.gif|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
                pi.Title = "Select Employee Picture";
                if (pi.ShowDialog() == DialogResult.OK)
                {
                    imLoc = pi.FileName.ToString();
                    CTxtpic.ImageLocation = imLoc;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CTxtTotal_TextChanged(object sender, EventArgs e)
        {
            if (CTxtpurchase.Text == "" || CTxtTotal.Text == "")
            {
                TxtTs.Text = "0.00";
                TxtPr.Text = "0.00";

            }
            else
            {
                try
                {
                    TxtTs.Text = Convert.ToString(Convert.ToDouble(Txtsrate.Text) * Convert.ToDouble(CTxtTotal.Text)).ToString();
                    TxtPr.Text = Convert.ToString(Convert.ToDouble(CTxtpurchase.Text) * Convert.ToDouble(CTxtTotal.Text)).ToString();
                }
                catch (Exception ex)
                {
                  //  MessageBox.Show(ex.Message);
                }
            }
        }

        private void Txtserach_TextChanged(object sender, EventArgs e)
        {
            //ID
            //Name
            try
            {

                con.Open();
                if (comboBox1.Text == "ID")
                {

                    SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM CProductMaster WHERE ID LIKE'" + Txtserach.Text + "%'", con);
                    DataTable dt = new DataTable();
                    adptr.Fill(dt);
                    CdataGridView.DataSource = dt;
                }
                else if (comboBox1.Text == "Product Name")
                {
                    SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM CProductMaster WHERE ProName LIKE'" + Txtserach.Text + "%'", con);
                    DataTable dt = new DataTable();
                    adptr.Fill(dt);
                    CdataGridView.DataSource = dt;
                }
               

                con.Close();

            }
            catch (Exception ex)
            {

            }
        }
    }
}
