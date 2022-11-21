using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwiftPayroll
{
    public partial class LoadingScreenForm : Form
    {
        public int PercentNum = 1;
        public LoadingScreenForm()
        {
            InitializeComponent();
        }


        private void LoadingScreenForm_Load(object sender, EventArgs e)
        {
            timer1.Start();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ProgressBar.Increment(1);
            ;
            PercentLbl.Text = $"{PercentNum += 1} %";
            if (ProgressBar.Value == 100)
            {
                timer1.Stop();
                Hide();
                // displaying sencond form "Dashboard"
                Dashboard dashboard = new Dashboard();
                dashboard.ShowDialog();
                //Closing 
                Close();
                //close connection 

            }

        }
    }
}
