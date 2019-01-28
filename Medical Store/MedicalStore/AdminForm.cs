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
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace MedicalStore
{
    public partial class AdminForm : MetroFramework.Forms.MetroForm
    {
        public static string passtext;

        private bool isCollapsed;

        private int childFormNumber = 0;

        SqlConnection con = new SqlConnection
        {
            ConnectionString = @"Data Source=DESKTOP-TNVK8MO\ARIF;Initial Catalog=MedicalStore;Integrated Security=True"
        };

        public AdminForm()
        {
            InitializeComponent();
        }
        //private int imag = 1;
        
        //private void Loadimag()
        //{
        //    if (imag == 5)
        //    {
        //        imag = 1;
        //    }
        //    TxtSlidePic.ImageLocation = string.Format(@"Images\{0}.jpg",imag);
        //    imag++;
        //}

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();

        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
    //        toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }
        

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            toolStripStatusLabel.Text = "All Program Close";
        }

        private void productMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductMaster pm = new ProductMaster(this)
            {
                MdiParent = this
            };
            pm.Show();
            toolStripStatusLabel.Text = "Open Product Master";
            
            
        }

        private void currentStockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Report_Form.ProductReport pr = new Report_Form.ProductReport(this);
            pr.MdiParent = this;
            pr.Show();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            Txtnick.Enabled = false;
            Txtemail.Enabled = false;
            Txtphone.Enabled = false;
            Txtmobile.Enabled = false;
            Txtgender.Enabled = false;
            Txtaage.Enabled = false;
            Txtaddress.Enabled = false;

            ProfileBox.Hide();

            Txtid.Text = Login.passtext;
            ////chart view in main
            //try
            //{
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("select * from Saleinfor",con);
            //    SqlDataReader rd = cmd.ExecuteReader();
            //    Series sr = new Series();
            //    while (rd.Read())
            //    {
            //        chart1.Series[0].Points.AddY(rd.GetInt32(23));
            //    }
            //    con.Close();
                
            //}
            //catch (Exception)
            //{

            //}
            toolStripStatusLabel.BackColor = Color.LightBlue;
            timer.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
            Txtpanel.Hide();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                string ad = "select * from information where email_id='" +Txtid.Text+ "'";

                SqlCommand cmd = new SqlCommand(ad, con);
                SqlDataReader sr = cmd.ExecuteReader();
                while (sr.Read())
                {
                    string va2 = sr[1].ToString();
                    TxtShowName.Text = Convert.ToString(sr[1].ToString());
                    label1.Text = Convert.ToString(sr[1].ToString());

                    string val = sr[8].ToString();
                    Txtuser.Text = Convert.ToString(sr[8].ToString());
                    label2.Text = Convert.ToString(sr[8].ToString());

                    string val3 = sr[0].ToString();
                    label3.Text = Convert.ToString(sr[0].ToString());

                    Txtnick.Text = Convert.ToString(sr[2].ToString());
                    Txtemail.Text = Convert.ToString(sr[3].ToString());
                   Txtgender.Text = Convert.ToString(sr[4].ToString());
                    Txtaage.Text = Convert.ToString(sr[5].ToString());
                    Txtphone.Text = Convert.ToString(sr[6].ToString());
                    Txtmobile.Text = Convert.ToString(sr[7].ToString());
                    Txtaddress.Text = Convert.ToString(sr[9].ToString());

                    if (sr.HasRows)
                    {
                        byte[] img = (byte[])(sr[10]);
                        if (img == null)
                        {
                            circularPictureBox2.Image = null;
                            circularPictureBox3.Image = null;
                            circularPictureBox4.Image = null;
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            circularPictureBox2.Image = Image.FromStream(ms);
                            circularPictureBox3.Image = Image.FromStream(ms);
                            circularPictureBox4.Image = Image.FromStream(ms);
                        }
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (Txtuser.Text == "Admin")
                {
                    employeeToolStripMenuItem.Enabled = true;
                    EmployeeRegisterToolStripMenuItem.Enabled = true;
                }
                else
                {
                    employeeToolStripMenuItem.Enabled = false;
                    EmployeeRegisterToolStripMenuItem.Enabled = false;
                }
            }

        }

        private void AdminForm_Move(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.ShowBalloonTip(1000, "Important Notice", "Click to see more information.", ToolTipIcon.Info);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult re= MessageBox.Show("Do you want to Logout!", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (re == DialogResult.No)
            {
                this.Show();
            }
            else
            {
                Application.Exit();
            }
            
        }

        private void supplierInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report_Form.SupplierReports sr = new Report_Form.SupplierReports(this)
            {
                MdiParent = this
            };
            sr.Show();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Saleform sf = new Saleform(this)
            {
              
                MdiParent = this
            };
            passtext = TxtShowName.Text;
            //chart1.Hide();
            sf.Show();
        }

        private void rackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rack rc = new Rack(this)
            {
                MdiParent = this
            };
            rc.Show();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoform inf = new infoform(this)
            {
                MdiParent = this
            };
            inf.Show();
        }

        private void salesDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report_Form.SalesdataReport sr = new Report_Form.SalesdataReport(this)
            {
                MdiParent = this
            };
            sr.Show();

        }

        private void purchasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchaseform pf = new Purchaseform(this)
            {
                MdiParent = this
            };
            pf.Show();
        }

        private void purchaseInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report_Form.PurchaseReport pr = new Report_Form.PurchaseReport(this)
            {
                MdiParent = this
            };
            pr.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //Loadimag();
        }

        private void EmployeeRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register re = new Register(this)
            {
                MdiParent = this
            };
            re.Show();
        }

        private void supplierMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierMaster sp = new SupplierMaster(this)
            {
                MdiParent = this
            };
            sp.Show();
        }

        private void productMasterToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CProductMaster pr = new CProductMaster(this)
            {
                MdiParent=this
            };
            pr.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CReport_Form.CProductReport pr = new CReport_Form.CProductReport(this)
            {
                MdiParent=this
            };
            pr.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            CReport_Form.CProductProfitReports pp = new CReport_Form.CProductProfitReports(this)
            {
                MdiParent = this
            };
            pp.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            CReport_Form.CPurchaseForm pc = new CReport_Form.CPurchaseForm(this)
            {
                MdiParent=this
            };
            pc.Show();
        }

        private void saleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CSell cp = new CSell(this)
            {
                MdiParent=this
            };
            passtext = TxtShowName.Text;
            cp.Show();
        }

        private void TxtShowEmail_Click(object sender, EventArgs e)
        {
            Txtpanel.Show();
        }

        private void Txtpanel_Paint(object sender, PaintEventArgs e)
        {
 //           Txtpanel.Hide();
        }

        private void ProfilePic_Click(object sender, EventArgs e)
        {
            Txtpanel.Hide();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("Do you want to Logout!", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (re == DialogResult.No)
            {
                this.Show();
                Txtpanel.Hide();
            }
            else
            {
                Application.Exit();
            }

        }

        private void TxtProfile_Click(object sender, EventArgs e)
        {
            ProfileBox.Show();
            Txtpanel.Hide();
        }

        private void purchaseMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChemicalForm cf = new ChemicalForm(this)
            {
                MdiParent = this
            };
            cf.Show();
        }

        private void circularPictureBox2_Click(object sender, EventArgs e)
        {
            Txtpanel.Hide();
            ProfileBox.Hide();
        }

        private void AdminForm_Click(object sender, EventArgs e)
        {
            Txtpanel.Hide();
            ProfileBox.Hide();
        }

        private void dalilySalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report_Form.PDailyBar mm = new Report_Form.PDailyBar(this)
            {
                MdiParent=this
            };
            mm.Show();
        }

        private void weeklySalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report_Form.PMonthlyForm mn = new Report_Form.PMonthlyForm(this)
            {
                MdiParent = this
            };
            mn.Show();
        }

        private void yearlySalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report_Form.PYearlyForm ym = new Report_Form.PYearlyForm(this)
            {
                MdiParent = this
            };
            ym.Show();
        }

        private void ProfileBox_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                button1.Image = Properties.Resources.iconfinder_collapse2_308968;
                metroPanel1.Height += 10;
                if(metroPanel1.Size==metroPanel1.MaximumSize)
                {
                    timer3.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                button1.Image = Properties.Resources.iconfinder_expand2_308964;
                metroPanel1.Height -= 10;
                if (metroPanel1.Size == metroPanel1.MinimumSize)
                {
                    timer3.Stop();
                    isCollapsed = true;
                }
            }
            Txtnick.Enabled = true;
            Txtphone.Enabled = true;
            Txtmobile.Enabled = true;
            Txtaddress.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter aa = new SqlDataAdapter("update information set nickname='" + Txtnick.Text + "',phone_no='"+Txtphone.Text+"',mobile_no='"+Txtmobile.Text+"',address='"+Txtaddress.Text+"' where user_id='"+label3.Text+"'", con);
                DataTable dd = new DataTable();
                aa.Fill(dd);
                MessageBox.Show("Profile Update Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

            }
        }

        private void Btncreate_Click(object sender, EventArgs e)
        {
            SqlDataAdapter ad = new SqlDataAdapter("select COUNT(*) from register_user where email_id='"+Txtemail.Text+"' AND password='" + Txtold.Text + "'", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            errorProvider1.Clear();
            if (dt.Rows[0][0].ToString()=="1") 
            {
                if (Txtnew.Text == Txtconfirm.Text)
                {
                    SqlDataAdapter dd = new SqlDataAdapter("update register_user set password='" + Txtnew.Text + "'", con);
                    DataTable ds = new DataTable();
                    dd.Fill(ds);
                    MessageBox.Show("Password Change...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Txtold.Clear();
                    Txtnew.Clear();
                    Txtconfirm.Clear();
                }
                else
                {
                    errorProvider1.SetError(Txtconfirm, "Password not matched!");
                }
            }
            else
            {
                errorProvider1.SetError(Txtold, "Incorrect Password");
            }
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            Txtold.Clear();
            Txtnew.Clear();
            Txtconfirm.Clear();
        }

        private void supplierMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CSupplierMaster sm = new CSupplierMaster(this)
            {
                MdiParent=this
            };
            sm.Show();
        }
    }
}
