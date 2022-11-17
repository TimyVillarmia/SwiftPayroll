namespace SwiftPayroll
{
    partial class LoginUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoginPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.label1 = new System.Windows.Forms.Label();
            this.UsernameTxt = new Guna.UI2.WinForms.Guna2TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.PasswordTxt = new Guna.UI2.WinForms.Guna2TextBox();
            this.SignInBtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.LoginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginPanel
            // 
            this.LoginPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(233)))));
            this.LoginPanel.BorderRadius = 4;
            this.LoginPanel.Controls.Add(this.label2);
            this.LoginPanel.Controls.Add(this.guna2Separator1);
            this.LoginPanel.Controls.Add(this.label1);
            this.LoginPanel.Controls.Add(this.UsernameTxt);
            this.LoginPanel.Controls.Add(this.linkLabel1);
            this.LoginPanel.Controls.Add(this.PasswordTxt);
            this.LoginPanel.Controls.Add(this.guna2PictureBox1);
            this.LoginPanel.Controls.Add(this.SignInBtn);
            this.LoginPanel.Location = new System.Drawing.Point(306, 101);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(397, 477);
            this.LoginPanel.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.label2.Location = new System.Drawing.Point(79, 425);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Don\'t have an account yet? Sign Up";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.guna2Separator1.Location = new System.Drawing.Point(33, 412);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(331, 10);
            this.guna2Separator1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.label1.Location = new System.Drawing.Point(63, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 36);
            this.label1.TabIndex = 8;
            this.label1.Text = "Please enter your username and password\r\n to get sign in to your account";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UsernameTxt
            // 
            this.UsernameTxt.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.UsernameTxt.BorderRadius = 4;
            this.UsernameTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.UsernameTxt.DefaultText = "";
            this.UsernameTxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.UsernameTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.UsernameTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.UsernameTxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.UsernameTxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.UsernameTxt.Font = new System.Drawing.Font("Montserrat", 9.749999F);
            this.UsernameTxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.UsernameTxt.Location = new System.Drawing.Point(33, 220);
            this.UsernameTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UsernameTxt.Name = "UsernameTxt";
            this.UsernameTxt.PasswordChar = '\0';
            this.UsernameTxt.PlaceholderText = "Enter Username";
            this.UsernameTxt.SelectedText = "";
            this.UsernameTxt.Size = new System.Drawing.Size(331, 43);
            this.UsernameTxt.TabIndex = 7;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.linkLabel1.Location = new System.Drawing.Point(245, 318);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(119, 16);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Forgot Password?";
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.PasswordTxt.BorderRadius = 4;
            this.PasswordTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PasswordTxt.DefaultText = "";
            this.PasswordTxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.PasswordTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.PasswordTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PasswordTxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PasswordTxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PasswordTxt.Font = new System.Drawing.Font("Montserrat", 9.749999F);
            this.PasswordTxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PasswordTxt.Location = new System.Drawing.Point(33, 271);
            this.PasswordTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.PasswordChar = '\0';
            this.PasswordTxt.PlaceholderText = "Enter Password";
            this.PasswordTxt.SelectedText = "";
            this.PasswordTxt.Size = new System.Drawing.Size(331, 43);
            this.PasswordTxt.TabIndex = 5;
            // 
            // SignInBtn
            // 
            this.SignInBtn.BorderColor = System.Drawing.Color.Transparent;
            this.SignInBtn.BorderRadius = 4;
            this.SignInBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SignInBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SignInBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SignInBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SignInBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(70)))), ((int)(((byte)(234)))));
            this.SignInBtn.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignInBtn.ForeColor = System.Drawing.Color.White;
            this.SignInBtn.Location = new System.Drawing.Point(33, 347);
            this.SignInBtn.Name = "SignInBtn";
            this.SignInBtn.Size = new System.Drawing.Size(331, 43);
            this.SignInBtn.TabIndex = 3;
            this.SignInBtn.Text = "SIGN IN";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::SwiftPayroll.Properties.Resources.team_5701_1;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(112, 3);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(161, 162);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 4;
            this.guna2PictureBox1.TabStop = false;
            // 
            // LoginUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.LoginPanel);
            this.Name = "LoginUC";
            this.Size = new System.Drawing.Size(1000, 680);
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel LoginPanel;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox UsernameTxt;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Guna.UI2.WinForms.Guna2TextBox PasswordTxt;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Button SignInBtn;
    }
}
