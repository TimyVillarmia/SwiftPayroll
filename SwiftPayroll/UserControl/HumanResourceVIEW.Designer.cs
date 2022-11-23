﻿namespace SwiftPayroll
{
    partial class HumanResourceVIEW
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
            this.DashBoardPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.SideBarPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.PayrollBtn = new Guna.UI2.WinForms.Guna2Button();
            this.ProfileBtn = new Guna.UI2.WinForms.Guna2Button();
            this.DashboardBtn = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.JobTitleLbl = new System.Windows.Forms.Label();
            this.UsernameLbl = new System.Windows.Forms.Label();
            this.EmployeeBtn = new Guna.UI2.WinForms.Guna2Button();
            this.UserProfilePic = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.SignOutBtn = new Guna.UI2.WinForms.Guna2Button();
            this.SideBarPanel.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserProfilePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DashBoardPanel
            // 
            this.DashBoardPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.DashBoardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DashBoardPanel.Location = new System.Drawing.Point(216, 0);
            this.DashBoardPanel.Name = "DashBoardPanel";
            this.DashBoardPanel.Size = new System.Drawing.Size(784, 800);
            this.DashBoardPanel.TabIndex = 5;
            // 
            // SideBarPanel
            // 
            this.SideBarPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.SideBarPanel.Controls.Add(this.guna2Panel1);
            this.SideBarPanel.Controls.Add(this.label3);
            this.SideBarPanel.Controls.Add(this.JobTitleLbl);
            this.SideBarPanel.Controls.Add(this.UsernameLbl);
            this.SideBarPanel.Controls.Add(this.UserProfilePic);
            this.SideBarPanel.Controls.Add(this.guna2PictureBox1);
            this.SideBarPanel.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.SideBarPanel.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.SideBarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SideBarPanel.Location = new System.Drawing.Point(0, 0);
            this.SideBarPanel.Name = "SideBarPanel";
            this.SideBarPanel.Size = new System.Drawing.Size(216, 800);
            this.SideBarPanel.TabIndex = 4;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.guna2Panel1.Controls.Add(this.SignOutBtn);
            this.guna2Panel1.Controls.Add(this.EmployeeBtn);
            this.guna2Panel1.Controls.Add(this.PayrollBtn);
            this.guna2Panel1.Controls.Add(this.ProfileBtn);
            this.guna2Panel1.Controls.Add(this.DashboardBtn);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.guna2Panel1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 347);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(216, 453);
            this.guna2Panel1.TabIndex = 13;
            // 
            // PayrollBtn
            // 
            this.PayrollBtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.PayrollBtn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(70)))), ((int)(((byte)(234)))));
            this.PayrollBtn.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.PayrollBtn.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.PayrollBtn.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.PayrollBtn.CustomImages.CheckedImage = global::SwiftPayroll.Properties.Resources.Payroll___Active;
            this.PayrollBtn.CustomImages.Image = global::SwiftPayroll.Properties.Resources.Payroll___Default;
            this.PayrollBtn.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.PayrollBtn.CustomImages.ImageOffset = new System.Drawing.Point(15, 0);
            this.PayrollBtn.CustomImages.ImageSize = new System.Drawing.Size(35, 35);
            this.PayrollBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.PayrollBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.PayrollBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.PayrollBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.PayrollBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.PayrollBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.PayrollBtn.Font = new System.Drawing.Font("Montserrat SemiBold", 14.25F, System.Drawing.FontStyle.Bold);
            this.PayrollBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.PayrollBtn.Location = new System.Drawing.Point(0, 90);
            this.PayrollBtn.Name = "PayrollBtn";
            this.PayrollBtn.Size = new System.Drawing.Size(216, 45);
            this.PayrollBtn.TabIndex = 4;
            this.PayrollBtn.Text = "Payroll";
            this.PayrollBtn.TextOffset = new System.Drawing.Point(-5, 0);
            // 
            // ProfileBtn
            // 
            this.ProfileBtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.ProfileBtn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(70)))), ((int)(((byte)(234)))));
            this.ProfileBtn.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.ProfileBtn.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.ProfileBtn.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.ProfileBtn.CustomImages.CheckedImage = global::SwiftPayroll.Properties.Resources.Profile___Active;
            this.ProfileBtn.CustomImages.Image = global::SwiftPayroll.Properties.Resources.Profile___Default;
            this.ProfileBtn.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ProfileBtn.CustomImages.ImageOffset = new System.Drawing.Point(15, 0);
            this.ProfileBtn.CustomImages.ImageSize = new System.Drawing.Size(35, 35);
            this.ProfileBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ProfileBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ProfileBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ProfileBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ProfileBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProfileBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.ProfileBtn.Font = new System.Drawing.Font("Montserrat SemiBold", 14.25F, System.Drawing.FontStyle.Bold);
            this.ProfileBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.ProfileBtn.Location = new System.Drawing.Point(0, 45);
            this.ProfileBtn.Name = "ProfileBtn";
            this.ProfileBtn.Size = new System.Drawing.Size(216, 45);
            this.ProfileBtn.TabIndex = 3;
            this.ProfileBtn.Text = "Profile";
            this.ProfileBtn.TextOffset = new System.Drawing.Point(-8, 0);
            // 
            // DashboardBtn
            // 
            this.DashboardBtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.DashboardBtn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(70)))), ((int)(((byte)(234)))));
            this.DashboardBtn.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.DashboardBtn.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.DashboardBtn.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.DashboardBtn.CustomImages.CheckedImage = global::SwiftPayroll.Properties.Resources.Dashboard___Active;
            this.DashboardBtn.CustomImages.Image = global::SwiftPayroll.Properties.Resources.Dashboard___Default;
            this.DashboardBtn.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.DashboardBtn.CustomImages.ImageOffset = new System.Drawing.Point(15, 0);
            this.DashboardBtn.CustomImages.ImageSize = new System.Drawing.Size(35, 35);
            this.DashboardBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.DashboardBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.DashboardBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.DashboardBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.DashboardBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.DashboardBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.DashboardBtn.Font = new System.Drawing.Font("Montserrat SemiBold", 14.25F, System.Drawing.FontStyle.Bold);
            this.DashboardBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.DashboardBtn.Location = new System.Drawing.Point(0, 0);
            this.DashboardBtn.Name = "DashboardBtn";
            this.DashboardBtn.Size = new System.Drawing.Size(216, 45);
            this.DashboardBtn.TabIndex = 2;
            this.DashboardBtn.Text = "Dashboard";
            this.DashboardBtn.TextOffset = new System.Drawing.Point(15, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(122)))), ((int)(((byte)(138)))));
            this.label3.Location = new System.Drawing.Point(23, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "General";
            // 
            // JobTitleLbl
            // 
            this.JobTitleLbl.AutoSize = true;
            this.JobTitleLbl.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JobTitleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(122)))), ((int)(((byte)(138)))));
            this.JobTitleLbl.Location = new System.Drawing.Point(50, 276);
            this.JobTitleLbl.Name = "JobTitleLbl";
            this.JobTitleLbl.Size = new System.Drawing.Size(109, 15);
            this.JobTitleLbl.TabIndex = 10;
            this.JobTitleLbl.Text = "Software Engineer";
            // 
            // UsernameLbl
            // 
            this.UsernameLbl.AutoSize = true;
            this.UsernameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.UsernameLbl.Location = new System.Drawing.Point(62, 256);
            this.UsernameLbl.Name = "UsernameLbl";
            this.UsernameLbl.Size = new System.Drawing.Size(86, 20);
            this.UsernameLbl.TabIndex = 9;
            this.UsernameLbl.Text = "John Doe";
            // 
            // EmployeeBtn
            // 
            this.EmployeeBtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.EmployeeBtn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(70)))), ((int)(((byte)(234)))));
            this.EmployeeBtn.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.EmployeeBtn.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.EmployeeBtn.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.EmployeeBtn.CustomImages.CheckedImage = global::SwiftPayroll.Properties.Resources.Employee___Active;
            this.EmployeeBtn.CustomImages.Image = global::SwiftPayroll.Properties.Resources.Employees____Default;
            this.EmployeeBtn.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.EmployeeBtn.CustomImages.ImageOffset = new System.Drawing.Point(15, 0);
            this.EmployeeBtn.CustomImages.ImageSize = new System.Drawing.Size(35, 35);
            this.EmployeeBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.EmployeeBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.EmployeeBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.EmployeeBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.EmployeeBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.EmployeeBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.EmployeeBtn.Font = new System.Drawing.Font("Montserrat SemiBold", 14.25F, System.Drawing.FontStyle.Bold);
            this.EmployeeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.EmployeeBtn.Location = new System.Drawing.Point(0, 135);
            this.EmployeeBtn.Name = "EmployeeBtn";
            this.EmployeeBtn.Size = new System.Drawing.Size(216, 45);
            this.EmployeeBtn.TabIndex = 5;
            this.EmployeeBtn.Text = "Employees";
            this.EmployeeBtn.TextOffset = new System.Drawing.Point(15, 0);
            // 
            // UserProfilePic
            // 
            this.UserProfilePic.BackColor = System.Drawing.Color.DimGray;
            this.UserProfilePic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserProfilePic.ImageRotate = 0F;
            this.UserProfilePic.Location = new System.Drawing.Point(46, 127);
            this.UserProfilePic.Name = "UserProfilePic";
            this.UserProfilePic.Size = new System.Drawing.Size(120, 120);
            this.UserProfilePic.TabIndex = 8;
            this.UserProfilePic.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::SwiftPayroll.Properties.Resources.SWIFTPayroll;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(22, 57);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(173, 24);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 7;
            this.guna2PictureBox1.TabStop = false;
            // 
            // SignOutBtn
            // 
            this.SignOutBtn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(70)))), ((int)(((byte)(234)))));
            this.SignOutBtn.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.SignOutBtn.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.SignOutBtn.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.SignOutBtn.CustomImages.CheckedImage = global::SwiftPayroll.Properties.Resources.Payroll___Active;
            this.SignOutBtn.CustomImages.Image = global::SwiftPayroll.Properties.Resources.SignOut;
            this.SignOutBtn.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.SignOutBtn.CustomImages.ImageOffset = new System.Drawing.Point(15, 0);
            this.SignOutBtn.CustomImages.ImageSize = new System.Drawing.Size(30, 30);
            this.SignOutBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SignOutBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SignOutBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SignOutBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SignOutBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SignOutBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.SignOutBtn.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignOutBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.SignOutBtn.Location = new System.Drawing.Point(0, 408);
            this.SignOutBtn.Name = "SignOutBtn";
            this.SignOutBtn.Size = new System.Drawing.Size(216, 45);
            this.SignOutBtn.TabIndex = 6;
            this.SignOutBtn.Text = "Sign Out";
            this.SignOutBtn.TextOffset = new System.Drawing.Point(-5, 0);
            this.SignOutBtn.Click += new System.EventHandler(this.SignOutBtn_Click);
            // 
            // HumanResourceVIEW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.Controls.Add(this.DashBoardPanel);
            this.Controls.Add(this.SideBarPanel);
            this.Name = "HumanResourceVIEW";
            this.Size = new System.Drawing.Size(1000, 800);
            this.SideBarPanel.ResumeLayout(false);
            this.SideBarPanel.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserProfilePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel DashBoardPanel;
        private Guna.UI2.WinForms.Guna2Panel SideBarPanel;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button PayrollBtn;
        private Guna.UI2.WinForms.Guna2Button ProfileBtn;
        private Guna.UI2.WinForms.Guna2Button DashboardBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label JobTitleLbl;
        private System.Windows.Forms.Label UsernameLbl;
        private Guna.UI2.WinForms.Guna2PictureBox UserProfilePic;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Button EmployeeBtn;
        private Guna.UI2.WinForms.Guna2Button SignOutBtn;
    }
}
