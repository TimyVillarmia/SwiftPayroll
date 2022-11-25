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

        private void EmployeeBtn_Click(object sender, EventArgs e)
        {

        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            UserProfile profile = new UserProfile();
            if (!DashBoardPanel.Contains(profile))
            {
                DashBoardPanel.Controls.Add(profile);
            }
            profile.BringToFront();
        }

        private void PayrollBtn_Click(object sender, EventArgs e)
        {
            HRPayrollTAB payroll = new HRPayrollTAB();
            if (!DashBoardPanel.Contains(payroll))
            {
                DashBoardPanel.Controls.Add(payroll);
            }
            payroll.BringToFront();
        }
    }
}
