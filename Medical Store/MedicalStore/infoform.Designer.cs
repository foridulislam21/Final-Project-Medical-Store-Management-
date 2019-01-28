namespace MedicalStore
{
    partial class infoform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.professionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtgender = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picEmp = new System.Windows.Forms.PictureBox();
            this.BtnBrowse = new MetroFramework.Controls.MetroButton();
            this.Btncancel = new MetroFramework.Controls.MetroButton();
            this.Btndelete = new MetroFramework.Controls.MetroButton();
            this.Btnmodify = new MetroFramework.Controls.MetroButton();
            this.Btnsave = new MetroFramework.Controls.MetroButton();
            this.Btnadduser = new MetroFramework.Controls.MetroButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtsearch = new MetroFramework.Controls.MetroTextBox();
            this.txtphone = new System.Windows.Forms.TextBox();
            this.txtprofession = new MetroFramework.Controls.MetroComboBox();
            this.btncalender = new MetroFramework.Controls.MetroDateTime();
            this.txtuserid = new MetroFramework.Controls.MetroTextBox();
            this.btnget = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtaddress = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtmobile = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtemail = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtnick = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtname = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.informationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.professionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEmp)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.informationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // professionBindingSource
            // 
            this.professionBindingSource.DataSource = typeof(MedicalStore.profession);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Controls.Add(this.txtgender);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.Btncancel);
            this.groupBox1.Controls.Add(this.Btndelete);
            this.groupBox1.Controls.Add(this.Btnmodify);
            this.groupBox1.Controls.Add(this.Btnsave);
            this.groupBox1.Controls.Add(this.Btnadduser);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtphone);
            this.groupBox1.Controls.Add(this.txtprofession);
            this.groupBox1.Controls.Add(this.btncalender);
            this.groupBox1.Controls.Add(this.txtuserid);
            this.groupBox1.Controls.Add(this.btnget);
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Controls.Add(this.txtaddress);
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.Controls.Add(this.txtmobile);
            this.groupBox1.Controls.Add(this.metroLabel3);
            this.groupBox1.Controls.Add(this.txtemail);
            this.groupBox1.Controls.Add(this.metroLabel4);
            this.groupBox1.Controls.Add(this.txtnick);
            this.groupBox1.Controls.Add(this.metroLabel5);
            this.groupBox1.Controls.Add(this.txtname);
            this.groupBox1.Controls.Add(this.metroLabel6);
            this.groupBox1.Controls.Add(this.metroLabel7);
            this.groupBox1.Controls.Add(this.metroLabel10);
            this.groupBox1.Controls.Add(this.metroLabel8);
            this.groupBox1.Controls.Add(this.metroLabel9);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.groupBox1.Location = new System.Drawing.Point(26, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1139, 671);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employee Information";
            // 
            // txtgender
            // 
            this.txtgender.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtgender.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtgender.FormattingEnabled = true;
            this.txtgender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.txtgender.Location = new System.Drawing.Point(155, 229);
            this.txtgender.Name = "txtgender";
            this.txtgender.Size = new System.Drawing.Size(121, 26);
            this.txtgender.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.picEmp);
            this.panel1.Controls.Add(this.BtnBrowse);
            this.panel1.Location = new System.Drawing.Point(604, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(169, 183);
            this.panel1.TabIndex = 10;
            // 
            // picEmp
            // 
            this.picEmp.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.picEmp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picEmp.Location = new System.Drawing.Point(16, 11);
            this.picEmp.Name = "picEmp";
            this.picEmp.Size = new System.Drawing.Size(138, 141);
            this.picEmp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEmp.TabIndex = 37;
            this.picEmp.TabStop = false;
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.Highlight = true;
            this.BtnBrowse.Location = new System.Drawing.Point(16, 157);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(75, 23);
            this.BtnBrowse.TabIndex = 0;
            this.BtnBrowse.Text = "&Browse";
            this.BtnBrowse.UseSelectable = true;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // Btncancel
            // 
            this.Btncancel.Highlight = true;
            this.Btncancel.Location = new System.Drawing.Point(1034, 629);
            this.Btncancel.Name = "Btncancel";
            this.Btncancel.Size = new System.Drawing.Size(75, 23);
            this.Btncancel.TabIndex = 36;
            this.Btncancel.Text = "&Cancel";
            this.Btncancel.UseSelectable = true;
            this.Btncancel.Click += new System.EventHandler(this.Btncancel_Click);
            // 
            // Btndelete
            // 
            this.Btndelete.Highlight = true;
            this.Btndelete.Location = new System.Drawing.Point(953, 629);
            this.Btndelete.Name = "Btndelete";
            this.Btndelete.Size = new System.Drawing.Size(75, 23);
            this.Btndelete.TabIndex = 36;
            this.Btndelete.Text = "&Delete";
            this.Btndelete.UseSelectable = true;
            this.Btndelete.Click += new System.EventHandler(this.Btndelete_Click);
            // 
            // Btnmodify
            // 
            this.Btnmodify.Highlight = true;
            this.Btnmodify.Location = new System.Drawing.Point(872, 629);
            this.Btnmodify.Name = "Btnmodify";
            this.Btnmodify.Size = new System.Drawing.Size(75, 23);
            this.Btnmodify.TabIndex = 36;
            this.Btnmodify.Text = "&Modify";
            this.Btnmodify.UseSelectable = true;
            this.Btnmodify.Click += new System.EventHandler(this.Btnmodify_Click);
            // 
            // Btnsave
            // 
            this.Btnsave.Highlight = true;
            this.Btnsave.Location = new System.Drawing.Point(791, 629);
            this.Btnsave.Name = "Btnsave";
            this.Btnsave.Size = new System.Drawing.Size(75, 23);
            this.Btnsave.TabIndex = 11;
            this.Btnsave.Text = "&Save";
            this.Btnsave.UseSelectable = true;
            this.Btnsave.Click += new System.EventHandler(this.Btnsave_Click);
            // 
            // Btnadduser
            // 
            this.Btnadduser.Highlight = true;
            this.Btnadduser.Location = new System.Drawing.Point(710, 629);
            this.Btnadduser.Name = "Btnadduser";
            this.Btnadduser.Size = new System.Drawing.Size(75, 23);
            this.Btnadduser.TabIndex = 36;
            this.Btnadduser.Text = "&Add New";
            this.Btnadduser.UseSelectable = true;
            this.Btnadduser.Click += new System.EventHandler(this.Btnadduser_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.PeachPuff;
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.txtsearch);
            this.groupBox2.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.groupBox2.Location = new System.Drawing.Point(6, 398);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1127, 212);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Employee Details";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ID",
            "Name"});
            this.comboBox1.Location = new System.Drawing.Point(22, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 26);
            this.comboBox1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 75);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1115, 130);
            this.dataGridView1.TabIndex = 32;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError_1);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // txtsearch
            // 
            this.txtsearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtsearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            // 
            // 
            // 
            this.txtsearch.CustomButton.Image = null;
            this.txtsearch.CustomButton.Location = new System.Drawing.Point(277, 1);
            this.txtsearch.CustomButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtsearch.CustomButton.Name = "";
            this.txtsearch.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtsearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtsearch.CustomButton.TabIndex = 1;
            this.txtsearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtsearch.CustomButton.UseSelectable = true;
            this.txtsearch.CustomButton.Visible = false;
            this.txtsearch.DisplayIcon = true;
            this.txtsearch.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtsearch.Lines = new string[0];
            this.txtsearch.Location = new System.Drawing.Point(149, 31);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtsearch.MaxLength = 32767;
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.PasswordChar = '\0';
            this.txtsearch.PromptText = "Search Employee";
            this.txtsearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtsearch.SelectedText = "";
            this.txtsearch.SelectionLength = 0;
            this.txtsearch.SelectionStart = 0;
            this.txtsearch.ShortcutsEnabled = true;
            this.txtsearch.Size = new System.Drawing.Size(305, 29);
            this.txtsearch.TabIndex = 1;
            this.txtsearch.UseSelectable = true;
            this.txtsearch.WaterMark = "Search Employee";
            this.txtsearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtsearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // txtphone
            // 
            this.txtphone.AutoCompleteCustomSource.AddRange(new string[] {
            "N/A"});
            this.txtphone.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtphone.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtphone.BackColor = System.Drawing.Color.White;
            this.txtphone.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtphone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtphone.Location = new System.Drawing.Point(155, 333);
            this.txtphone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtphone.Multiline = true;
            this.txtphone.Name = "txtphone";
            this.txtphone.Size = new System.Drawing.Size(233, 28);
            this.txtphone.TabIndex = 6;
            // 
            // txtprofession
            // 
            this.txtprofession.DisplayFocus = true;
            this.txtprofession.FormattingEnabled = true;
            this.txtprofession.ItemHeight = 23;
            this.txtprofession.Items.AddRange(new object[] {
            "Admin",
            "Storekeeper"});
            this.txtprofession.Location = new System.Drawing.Point(604, 273);
            this.txtprofession.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtprofession.Name = "txtprofession";
            this.txtprofession.Size = new System.Drawing.Size(262, 29);
            this.txtprofession.TabIndex = 8;
            this.txtprofession.UseSelectable = true;
            // 
            // btncalender
            // 
            this.btncalender.Location = new System.Drawing.Point(155, 278);
            this.btncalender.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btncalender.MinimumSize = new System.Drawing.Size(0, 29);
            this.btncalender.Name = "btncalender";
            this.btncalender.Size = new System.Drawing.Size(233, 29);
            this.btncalender.TabIndex = 5;
            // 
            // txtuserid
            // 
            // 
            // 
            // 
            this.txtuserid.CustomButton.Image = null;
            this.txtuserid.CustomButton.Location = new System.Drawing.Point(110, 2);
            this.txtuserid.CustomButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtuserid.CustomButton.Name = "";
            this.txtuserid.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtuserid.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtuserid.CustomButton.TabIndex = 1;
            this.txtuserid.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtuserid.CustomButton.UseSelectable = true;
            this.txtuserid.CustomButton.Visible = false;
            this.txtuserid.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtuserid.Lines = new string[0];
            this.txtuserid.Location = new System.Drawing.Point(155, 36);
            this.txtuserid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtuserid.MaxLength = 32767;
            this.txtuserid.Multiline = true;
            this.txtuserid.Name = "txtuserid";
            this.txtuserid.PasswordChar = '\0';
            this.txtuserid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtuserid.SelectedText = "";
            this.txtuserid.SelectionLength = 0;
            this.txtuserid.SelectionStart = 0;
            this.txtuserid.ShortcutsEnabled = true;
            this.txtuserid.Size = new System.Drawing.Size(136, 28);
            this.txtuserid.TabIndex = 0;
            this.txtuserid.UseSelectable = true;
            this.txtuserid.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtuserid.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnget
            // 
            this.btnget.Location = new System.Drawing.Point(308, 36);
            this.btnget.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnget.Name = "btnget";
            this.btnget.Size = new System.Drawing.Size(87, 28);
            this.btnget.TabIndex = 34;
            this.btnget.Text = "Get";
            this.btnget.UseSelectable = true;
            this.btnget.Click += new System.EventHandler(this.btnget_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(47, 36);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(62, 19);
            this.metroLabel1.TabIndex = 23;
            this.metroLabel1.Text = "User ID :";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // txtaddress
            // 
            // 
            // 
            // 
            this.txtaddress.CustomButton.Image = null;
            this.txtaddress.CustomButton.Location = new System.Drawing.Point(371, 1);
            this.txtaddress.CustomButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtaddress.CustomButton.Name = "";
            this.txtaddress.CustomButton.Size = new System.Drawing.Size(63, 63);
            this.txtaddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtaddress.CustomButton.TabIndex = 1;
            this.txtaddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtaddress.CustomButton.UseSelectable = true;
            this.txtaddress.CustomButton.Visible = false;
            this.txtaddress.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtaddress.Lines = new string[0];
            this.txtaddress.Location = new System.Drawing.Point(604, 326);
            this.txtaddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtaddress.MaxLength = 32767;
            this.txtaddress.Multiline = true;
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.PasswordChar = '\0';
            this.txtaddress.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtaddress.SelectedText = "";
            this.txtaddress.SelectionLength = 0;
            this.txtaddress.SelectionStart = 0;
            this.txtaddress.ShortcutsEnabled = true;
            this.txtaddress.Size = new System.Drawing.Size(435, 65);
            this.txtaddress.TabIndex = 9;
            this.txtaddress.UseSelectable = true;
            this.txtaddress.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtaddress.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(47, 85);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(77, 19);
            this.metroLabel2.TabIndex = 13;
            this.metroLabel2.Text = "Full Name :";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // txtmobile
            // 
            // 
            // 
            // 
            this.txtmobile.CustomButton.Image = null;
            this.txtmobile.CustomButton.Location = new System.Drawing.Point(207, 2);
            this.txtmobile.CustomButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtmobile.CustomButton.Name = "";
            this.txtmobile.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtmobile.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtmobile.CustomButton.TabIndex = 1;
            this.txtmobile.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtmobile.CustomButton.UseSelectable = true;
            this.txtmobile.CustomButton.Visible = false;
            this.txtmobile.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtmobile.Lines = new string[0];
            this.txtmobile.Location = new System.Drawing.Point(604, 229);
            this.txtmobile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtmobile.MaxLength = 32767;
            this.txtmobile.Name = "txtmobile";
            this.txtmobile.PasswordChar = '\0';
            this.txtmobile.PromptText = "Example: 017XXXXXXXX";
            this.txtmobile.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtmobile.SelectedText = "";
            this.txtmobile.SelectionLength = 0;
            this.txtmobile.SelectionStart = 0;
            this.txtmobile.ShortcutsEnabled = true;
            this.txtmobile.Size = new System.Drawing.Size(233, 28);
            this.txtmobile.TabIndex = 7;
            this.txtmobile.UseSelectable = true;
            this.txtmobile.WaterMark = "Example: 017XXXXXXXX";
            this.txtmobile.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtmobile.WaterMarkFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(47, 135);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(82, 19);
            this.metroLabel3.TabIndex = 20;
            this.metroLabel3.Text = "Nick Name :";
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // txtemail
            // 
            // 
            // 
            // 
            this.txtemail.CustomButton.Image = null;
            this.txtemail.CustomButton.Location = new System.Drawing.Point(214, 2);
            this.txtemail.CustomButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtemail.CustomButton.Name = "";
            this.txtemail.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtemail.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtemail.CustomButton.TabIndex = 1;
            this.txtemail.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtemail.CustomButton.UseSelectable = true;
            this.txtemail.CustomButton.Visible = false;
            this.txtemail.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtemail.Lines = new string[0];
            this.txtemail.Location = new System.Drawing.Point(155, 180);
            this.txtemail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtemail.MaxLength = 32767;
            this.txtemail.Name = "txtemail";
            this.txtemail.PasswordChar = '\0';
            this.txtemail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtemail.SelectedText = "";
            this.txtemail.SelectionLength = 0;
            this.txtemail.SelectionStart = 0;
            this.txtemail.ShortcutsEnabled = true;
            this.txtemail.Size = new System.Drawing.Size(240, 28);
            this.txtemail.TabIndex = 3;
            this.txtemail.UseSelectable = true;
            this.txtemail.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtemail.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(47, 184);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(66, 19);
            this.metroLabel4.TabIndex = 19;
            this.metroLabel4.Text = "Email ID :";
            this.metroLabel4.UseCustomBackColor = true;
            // 
            // txtnick
            // 
            // 
            // 
            // 
            this.txtnick.CustomButton.Image = null;
            this.txtnick.CustomButton.Location = new System.Drawing.Point(110, 2);
            this.txtnick.CustomButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtnick.CustomButton.Name = "";
            this.txtnick.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtnick.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtnick.CustomButton.TabIndex = 1;
            this.txtnick.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtnick.CustomButton.UseSelectable = true;
            this.txtnick.CustomButton.Visible = false;
            this.txtnick.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtnick.Lines = new string[0];
            this.txtnick.Location = new System.Drawing.Point(155, 131);
            this.txtnick.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtnick.MaxLength = 32767;
            this.txtnick.Name = "txtnick";
            this.txtnick.PasswordChar = '\0';
            this.txtnick.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtnick.SelectedText = "";
            this.txtnick.SelectionLength = 0;
            this.txtnick.SelectionStart = 0;
            this.txtnick.ShortcutsEnabled = true;
            this.txtnick.Size = new System.Drawing.Size(136, 28);
            this.txtnick.TabIndex = 2;
            this.txtnick.UseSelectable = true;
            this.txtnick.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtnick.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(47, 233);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(61, 19);
            this.metroLabel5.TabIndex = 17;
            this.metroLabel5.Text = "Gender :";
            this.metroLabel5.UseCustomBackColor = true;
            // 
            // txtname
            // 
            // 
            // 
            // 
            this.txtname.CustomButton.Image = null;
            this.txtname.CustomButton.Location = new System.Drawing.Point(214, 2);
            this.txtname.CustomButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtname.CustomButton.Name = "";
            this.txtname.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtname.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtname.CustomButton.TabIndex = 1;
            this.txtname.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtname.CustomButton.UseSelectable = true;
            this.txtname.CustomButton.Visible = false;
            this.txtname.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtname.Lines = new string[0];
            this.txtname.Location = new System.Drawing.Point(155, 81);
            this.txtname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtname.MaxLength = 32767;
            this.txtname.Name = "txtname";
            this.txtname.PasswordChar = '\0';
            this.txtname.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtname.SelectedText = "";
            this.txtname.SelectionLength = 0;
            this.txtname.SelectionStart = 0;
            this.txtname.ShortcutsEnabled = true;
            this.txtname.Size = new System.Drawing.Size(240, 28);
            this.txtname.TabIndex = 1;
            this.txtname.UseSelectable = true;
            this.txtname.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtname.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(47, 285);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(94, 19);
            this.metroLabel6.TabIndex = 16;
            this.metroLabel6.Text = "Date of Birth :";
            this.metroLabel6.UseCustomBackColor = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel7.Location = new System.Drawing.Point(47, 334);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(80, 19);
            this.metroLabel7.TabIndex = 15;
            this.metroLabel7.Text = "Phone No. :";
            this.metroLabel7.UseCustomBackColor = true;
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel10.Location = new System.Drawing.Point(501, 331);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(65, 19);
            this.metroLabel10.TabIndex = 14;
            this.metroLabel10.Text = "Address :";
            this.metroLabel10.UseCustomBackColor = true;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel8.Location = new System.Drawing.Point(501, 233);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(83, 19);
            this.metroLabel8.TabIndex = 21;
            this.metroLabel8.Text = "Mobile No. :";
            this.metroLabel8.UseCustomBackColor = true;
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel9.Location = new System.Drawing.Point(501, 282);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(79, 19);
            this.metroLabel9.TabIndex = 22;
            this.metroLabel9.Text = "Profession :";
            this.metroLabel9.UseCustomBackColor = true;
            // 
            // informationBindingSource
            // 
            this.informationBindingSource.DataSource = typeof(MedicalStore.information);
            // 
            // infoform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 774);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "infoform";
            this.Padding = new System.Windows.Forms.Padding(23, 73, 23, 24);
            this.Text = "Employee Information";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.infoform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.professionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picEmp)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.informationBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource professionBindingSource;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtphone;
        private MetroFramework.Controls.MetroTextBox txtsearch;
        private MetroFramework.Controls.MetroComboBox txtprofession;
        private MetroFramework.Controls.MetroDateTime btncalender;
        private MetroFramework.Controls.MetroTextBox txtuserid;
        private MetroFramework.Controls.MetroButton btnget;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtaddress;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtmobile;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtemail;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtnick;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox txtname;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroButton Btncancel;
        private MetroFramework.Controls.MetroButton Btndelete;
        private MetroFramework.Controls.MetroButton Btnmodify;
        private MetroFramework.Controls.MetroButton Btnsave;
        private MetroFramework.Controls.MetroButton Btnadduser;
        private System.Windows.Forms.PictureBox picEmp;
        private MetroFramework.Controls.MetroButton BtnBrowse;
        private System.Windows.Forms.BindingSource informationBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox txtgender;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}