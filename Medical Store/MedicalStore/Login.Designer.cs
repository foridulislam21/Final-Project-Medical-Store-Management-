namespace MedicalStore
{
    partial class Login
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
            this.Txtuser = new MetroFramework.Controls.MetroTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Txtpassword = new MetroFramework.Controls.MetroTextBox();
            this.Btnlogin = new MetroFramework.Controls.MetroButton();
            this.Btncancel = new MetroFramework.Controls.MetroButton();
            this.Txtcheck = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // Txtuser
            // 
            // 
            // 
            // 
            this.Txtuser.CustomButton.Image = null;
            this.Txtuser.CustomButton.Location = new System.Drawing.Point(192, 1);
            this.Txtuser.CustomButton.Name = "";
            this.Txtuser.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.Txtuser.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Txtuser.CustomButton.TabIndex = 1;
            this.Txtuser.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Txtuser.CustomButton.UseSelectable = true;
            this.Txtuser.CustomButton.Visible = false;
            this.Txtuser.DisplayIcon = true;
            this.Txtuser.Icon = global::MedicalStore.Properties.Resources.if_user_male_172625_2;
            this.Txtuser.Lines = new string[0];
            this.Txtuser.Location = new System.Drawing.Point(58, 248);
            this.Txtuser.MaxLength = 32767;
            this.Txtuser.Name = "Txtuser";
            this.Txtuser.PasswordChar = '\0';
            this.Txtuser.PromptText = "Enter Your Username or Email";
            this.Txtuser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Txtuser.SelectedText = "";
            this.Txtuser.SelectionLength = 0;
            this.Txtuser.SelectionStart = 0;
            this.Txtuser.ShortcutsEnabled = true;
            this.Txtuser.Size = new System.Drawing.Size(216, 25);
            this.Txtuser.TabIndex = 1;
            this.Txtuser.UseSelectable = true;
            this.Txtuser.WaterMark = "Enter Your Username or Email";
            this.Txtuser.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Txtuser.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Txtuser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txtuser_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MedicalStore.Properties.Resources.user_account;
            this.pictureBox1.Location = new System.Drawing.Point(97, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Txtpassword
            // 
            // 
            // 
            // 
            this.Txtpassword.CustomButton.Image = null;
            this.Txtpassword.CustomButton.Location = new System.Drawing.Point(192, 1);
            this.Txtpassword.CustomButton.Name = "";
            this.Txtpassword.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.Txtpassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Txtpassword.CustomButton.TabIndex = 1;
            this.Txtpassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Txtpassword.CustomButton.UseSelectable = true;
            this.Txtpassword.CustomButton.Visible = false;
            this.Txtpassword.DisplayIcon = true;
            this.Txtpassword.Icon = global::MedicalStore.Properties.Resources.if_icons_password_1564520;
            this.Txtpassword.Lines = new string[0];
            this.Txtpassword.Location = new System.Drawing.Point(58, 294);
            this.Txtpassword.MaxLength = 32767;
            this.Txtpassword.Name = "Txtpassword";
            this.Txtpassword.PasswordChar = '*';
            this.Txtpassword.PromptText = "Enter Your  Password";
            this.Txtpassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Txtpassword.SelectedText = "";
            this.Txtpassword.SelectionLength = 0;
            this.Txtpassword.SelectionStart = 0;
            this.Txtpassword.ShortcutsEnabled = true;
            this.Txtpassword.Size = new System.Drawing.Size(216, 25);
            this.Txtpassword.TabIndex = 2;
            this.Txtpassword.UseSelectable = true;
            this.Txtpassword.WaterMark = "Enter Your  Password";
            this.Txtpassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Txtpassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Txtpassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txtpassword_KeyPress);
            // 
            // Btnlogin
            // 
            this.Btnlogin.DisplayFocus = true;
            this.Btnlogin.Location = new System.Drawing.Point(74, 361);
            this.Btnlogin.Name = "Btnlogin";
            this.Btnlogin.Size = new System.Drawing.Size(75, 23);
            this.Btnlogin.TabIndex = 3;
            this.Btnlogin.Text = "LOG IN";
            this.Btnlogin.UseSelectable = true;
            this.Btnlogin.Click += new System.EventHandler(this.Btnlogin_Click);
            // 
            // Btncancel
            // 
            this.Btncancel.DisplayFocus = true;
            this.Btncancel.Location = new System.Drawing.Point(178, 361);
            this.Btncancel.Name = "Btncancel";
            this.Btncancel.Size = new System.Drawing.Size(75, 23);
            this.Btncancel.TabIndex = 4;
            this.Btncancel.Text = "CANCEL";
            this.Btncancel.UseSelectable = true;
            this.Btncancel.Click += new System.EventHandler(this.Btncancel_Click);
            // 
            // Txtcheck
            // 
            this.Txtcheck.AutoSize = true;
            this.Txtcheck.Location = new System.Drawing.Point(66, 330);
            this.Txtcheck.Name = "Txtcheck";
            this.Txtcheck.Size = new System.Drawing.Size(95, 17);
            this.Txtcheck.TabIndex = 5;
            this.Txtcheck.Text = "Remember Me";
            this.Txtcheck.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 416);
            this.Controls.Add(this.Txtcheck);
            this.Controls.Add(this.Btncancel);
            this.Controls.Add(this.Btnlogin);
            this.Controls.Add(this.Txtpassword);
            this.Controls.Add(this.Txtuser);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Text = "Medical Store Management";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTextBox Txtuser;
        private MetroFramework.Controls.MetroTextBox Txtpassword;
        private MetroFramework.Controls.MetroButton Btnlogin;
        private MetroFramework.Controls.MetroButton Btncancel;
        private System.Windows.Forms.CheckBox Txtcheck;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

