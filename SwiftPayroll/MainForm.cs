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


namespace SwiftPayroll
{
    public partial class MainForm : Form
    {
        public static MainForm form;

        public MainForm()
        {
            InitializeComponent();
            form = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Active Button Colors
            HomeBtn.FillColor = Color.FromArgb(98, 70, 234);
            HomeBtn.ForeColor = Color.White;

            //Defaults
            AboutBtn.ForeColor = Color.FromArgb(43, 44, 52);
            TeamBtn.ForeColor = Color.FromArgb(43, 44, 52);

            HomeUC home = new HomeUC(form);

            MainPanel.Controls.Add(home);


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
