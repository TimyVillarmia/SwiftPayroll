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
    public partial class HomeUC : UserControl
    {
        public MainForm MainForm;
        public HomeUC()
        {
            InitializeComponent();
        }
        public HomeUC(MainForm form1)
        {
            InitializeComponent();
            MainForm = form1;
            

        }

        private void SignInBtn_Click(object sender, EventArgs e)
        {
            //Current Usercontrol view
            MainForm.loginUC.BringToFront();

            //disposing unuse usercontrols
            /*
            
                INSERT DISPOSE STATEMENT

             */




            // Unactive Button Color
            MainForm.homeBtn.FillColor = Color.Transparent;
            MainForm.homeBtn.ForeColor = Color.FromArgb(43, 44, 52);
        }

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            //Current Usercontrol view
            MainForm.createUC.BringToFront();

            //disposing unuse usercontrols
            /*
            
                INSERT DISPOSE STATEMENT

             */

            // Unactive Button Color
            MainForm.homeBtn.FillColor = Color.Transparent;
            MainForm.homeBtn.ForeColor = Color.FromArgb(43, 44, 52);
        }
    }
}
