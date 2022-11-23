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
    public partial class HumanResourceVIEW : UserControl
    {
        public HumanResourceVIEW()
        {
            InitializeComponent();
        }

        private void SignOutBtn_Click(object sender, EventArgs e)
        {
            ParentForm.Hide();
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
            ParentForm.Close();
        }
    }
}
