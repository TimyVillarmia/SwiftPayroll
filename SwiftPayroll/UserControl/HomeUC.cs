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
        public HomeUC(MainForm form)
        {
            InitializeComponent();
            MainForm = form;

        }

        private void SignInBtn_Click(object sender, EventArgs e)
        {
            //MainForm.
        }

  
    }
}
