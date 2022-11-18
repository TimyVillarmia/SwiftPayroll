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
    public partial class CreateUC : UserControl
    {
        public MainForm MainForm;
        public CreateUC(MainForm form1)
        {
            InitializeComponent();
            MainForm = form1;
        }

        private void SignInLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.loginUC.BringToFront();
        }
    }
}
