using System.Drawing;

namespace SwiftPayroll
{
    partial class MainForm
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
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.MainPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.LOGO = new Guna.UI2.WinForms.Guna2PictureBox();
            this.HomeBtn = new Guna.UI2.WinForms.Guna2Button();
            this.AboutBtn = new Guna.UI2.WinForms.Guna2Button();
            this.TeamBtn = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.LOGO)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 8;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.Location = new System.Drawing.Point(943, 12);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 4;
            // 
            // MainPanel
            // 
            this.MainPanel.BorderRadius = 8;
            this.MainPanel.Location = new System.Drawing.Point(-1, 119);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1000, 680);
            this.MainPanel.TabIndex = 5;
            // 
            // LOGO
            // 
            this.LOGO.Image = global::SwiftPayroll.Properties.Resources.SWIFTPayroll;
            this.LOGO.ImageRotate = 0F;
            this.LOGO.Location = new System.Drawing.Point(45, 49);
            this.LOGO.Name = "LOGO";
            this.LOGO.Size = new System.Drawing.Size(224, 32);
            this.LOGO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.LOGO.TabIndex = 0;
            this.LOGO.TabStop = false;
            // 
            // HomeBtn
            // 
            this.HomeBtn.BorderRadius = 8;
            this.HomeBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.HomeBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.HomeBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.HomeBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.HomeBtn.FillColor = System.Drawing.Color.Transparent;
            this.HomeBtn.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Bold);
            this.HomeBtn.ForeColor = System.Drawing.Color.Black;
            this.HomeBtn.Location = new System.Drawing.Point(481, 49);
            this.HomeBtn.Name = "HomeBtn";
            this.HomeBtn.Size = new System.Drawing.Size(148, 45);
            this.HomeBtn.TabIndex = 1;
            this.HomeBtn.Text = "HOME";
            this.HomeBtn.Click += new System.EventHandler(this.HomeBtn_Click);
            // 
            // AboutBtn
            // 
            this.AboutBtn.BorderRadius = 8;
            this.AboutBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AboutBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AboutBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AboutBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AboutBtn.FillColor = System.Drawing.Color.Transparent;
            this.AboutBtn.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Bold);
            this.AboutBtn.ForeColor = System.Drawing.Color.Black;
            this.AboutBtn.Location = new System.Drawing.Point(635, 49);
            this.AboutBtn.Name = "AboutBtn";
            this.AboutBtn.Size = new System.Drawing.Size(148, 45);
            this.AboutBtn.TabIndex = 2;
            this.AboutBtn.Text = "ABOUT";
            this.AboutBtn.Click += new System.EventHandler(this.AboutBtn_Click);
            // 
            // TeamBtn
            // 
            this.TeamBtn.BorderRadius = 8;
            this.TeamBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.TeamBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.TeamBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.TeamBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.TeamBtn.FillColor = System.Drawing.Color.Transparent;
            this.TeamBtn.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Bold);
            this.TeamBtn.ForeColor = System.Drawing.Color.Black;
            this.TeamBtn.Location = new System.Drawing.Point(789, 49);
            this.TeamBtn.Name = "TeamBtn";
            this.TeamBtn.Size = new System.Drawing.Size(148, 45);
            this.TeamBtn.TabIndex = 3;
            this.TeamBtn.Text = "THE TEAM";
            this.TeamBtn.Click += new System.EventHandler(this.TeamBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1000, 800);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.TeamBtn);
            this.Controls.Add(this.AboutBtn);
            this.Controls.Add(this.HomeBtn);
            this.Controls.Add(this.LOGO);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "t";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOGO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel MainPanel;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2Button TeamBtn;
        private Guna.UI2.WinForms.Guna2Button AboutBtn;
        private Guna.UI2.WinForms.Guna2Button HomeBtn;
        private Guna.UI2.WinForms.Guna2PictureBox LOGO;
    }
}

