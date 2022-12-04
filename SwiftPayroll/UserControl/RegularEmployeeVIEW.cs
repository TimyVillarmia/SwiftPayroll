using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwiftPayroll
{
    public partial class RegularEmployeeVIEW : UserControl
    {

     
        public RegularEmployeeVIEW()
        {
            InitializeComponent();
        }

        private void RegularEmployeeVIEW_Load(object sender, EventArgs e)
        {
            LoginUC user = new LoginUC();
          
            try
            {
                DashboardHomeUC dashboard = new DashboardHomeUC();
                if (!DashBoardPanel.Controls.Contains(dashboard))
                {
                    DashBoardPanel.Controls.Add(dashboard);
                }
                dashboard.BringToFront();

                EmployeeInfo employee = new EmployeeInfo(user.CurrentUser);
                employee.GetInformation();
                UsernameLbl.Text = employee.Username;
                JobTitleLbl.Text = employee.Title;

     
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SignOutBtn_Click(object sender, EventArgs e)
        {
            ParentForm.Hide();
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
            ParentForm.Close();
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            UserProfile profile = new UserProfile();
            if (!DashBoardPanel.Controls.Contains(profile))
            {
                DashBoardPanel.Controls.Add(profile);
            }
            profile.BringToFront();
        }

        private void PayrollBtn_Click(object sender, EventArgs e)
        {
            EmployeePayrollTAB employeePayroll = new EmployeePayrollTAB();
            if (!DashBoardPanel.Controls.Contains(employeePayroll))
            {
                DashBoardPanel.Controls.Add(employeePayroll);
            }
            employeePayroll.BringToFront();
        }

        private void SideBarPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            DashboardHomeUC  dashboard = new DashboardHomeUC();
            if (!DashBoardPanel.Controls.Contains(dashboard))
            {
                DashBoardPanel.Controls.Add(dashboard);
            }
            dashboard.BringToFront();
        }
    }
}
