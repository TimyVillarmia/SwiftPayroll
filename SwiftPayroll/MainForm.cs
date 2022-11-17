using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Guna.UI2.WinForms;

namespace SwiftPayroll
{
    public partial class MainForm : Form
    {

        // Auto-implemented properties
        //creating a property to be able to access it from other classes
        public HomeUC homeUC { get; set; }
        public LoginUC loginUC { get; set; }
        public Guna2Button homeBtn { get; set; }

        public MainForm()
        {
            InitializeComponent();
         
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            homeBtn = HomeBtn;
            
            // Active Button Colors
            HomeBtn.FillColor = Color.FromArgb(98, 70, 234);
            HomeBtn.ForeColor = Color.White;

            //Defaults
            AboutBtn.ForeColor = Color.FromArgb(43, 44, 52);
            TeamBtn.ForeColor = Color.FromArgb(43, 44, 52);

            // Usercontrols as object by instantiateing 
            // and the passing the "this" as parameters
            // "this" refers to "MainForm" Class
            homeUC = new HomeUC(this); 
            loginUC = new LoginUC(this);

            // adding the Usercontrols inside the Panel
            MainPanel.Controls.Add(homeUC);
            MainPanel.Controls.Add(loginUC);


        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            // Active Button Colors
            HomeBtn.FillColor = Color.FromArgb(98, 70, 234);
            HomeBtn.ForeColor = Color.White;
            // Unactive Button Colors
            AboutBtn.FillColor = Color.Transparent;
            AboutBtn.ForeColor = Color.FromArgb(43, 44, 52);
            TeamBtn.FillColor = Color.Transparent;
            TeamBtn.ForeColor = Color.FromArgb(43, 44, 52);

            //Current Usercontrol view
            homeUC.BringToFront();

        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            // Active Button Colors
            AboutBtn.FillColor = Color.FromArgb(98, 70, 234);
            AboutBtn.ForeColor = Color.White;
            // Unactive Button Colors
            HomeBtn.FillColor = Color.Transparent;
            HomeBtn.ForeColor = Color.FromArgb(43, 44, 52);
            TeamBtn.FillColor = Color.Transparent;
            TeamBtn.ForeColor = Color.FromArgb(43, 44, 52);
        }

        private void TeamBtn_Click(object sender, EventArgs e)
        {
            // Active Button Colors
            TeamBtn.FillColor = Color.FromArgb(98, 70, 234);
            TeamBtn.ForeColor = Color.White;
            // Unactive Button Colors
            HomeBtn.FillColor = Color.Transparent;
            HomeBtn.ForeColor = Color.FromArgb(43, 44, 52);
            AboutBtn.FillColor = Color.Transparent;
            AboutBtn.ForeColor = Color.FromArgb(43, 44, 52);
        }

  
    }
}
