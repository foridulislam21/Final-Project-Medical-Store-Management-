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
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        public static string passtext;
        SqlConnection con = new SqlConnection
        {
            ConnectionString = @"Data Source=DESKTOP-TNVK8MO\ARIF;Initial Catalog=MedicalStore;Integrated Security=True"
        };
        public Login()
        {
            InitializeComponent();
            int_data();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Txtuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                Txtpassword.Focus();
        }

        private void Txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                Btnlogin.Focus();
        }

        
        private void Btnlogin_Click(object sender, EventArgs e)
        {
                        
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter("select Employee_Name from register_user where email_id='"+Txtuser.Text+"' and password='"+Txtpassword.Text+"'",con);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                if(dt.Rows.Count==1)
                {
                    

                   
                        MessageBox.Show("You have successfully Log In.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    AdminForm af = new AdminForm();
                    passtext = Txtuser.Text;
                        save_data();
                        af.Show();
                                   
                }
                else
                {
                    errorProvider1.SetError(Txtpassword, "Password Incorrect!");
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void Btncancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void int_data()
        {
            if (Properties.Settings.Default.UserName != string.Empty)
            {
                if (Properties.Settings.Default.Rename == "yes")
                {
                    Txtuser.Text = Properties.Settings.Default.UserName;
                    Txtpassword.Text = Properties.Settings.Default.Password;
                    Txtcheck.Checked = true;
                }
                else
                {
                    Txtuser.Text = Properties.Settings.Default.UserName;
                }
            }
        }
        private void save_data()
        {
            if (Txtcheck.Checked)
            {
                Properties.Settings.Default.UserName = Txtuser.Text;
                Properties.Settings.Default.Password = Txtpassword.Text;
                Properties.Settings.Default.Rename = "yes";
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.UserName = Txtuser.Text;
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Rename = "no";
                Properties.Settings.Default.Save();
            }
        }
    }
}
