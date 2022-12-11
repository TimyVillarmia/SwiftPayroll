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

        private void EmployeeBtn_Click_1(object sender, EventArgs e)
        {
            HREmployeeTAB employeeTAB = new HREmployeeTAB();
            if (!DashBoardPanel.Contains(employeeTAB))
            {
                DashBoardPanel.Controls.Add(employeeTAB);
            }
            employeeTAB.BringToFront();
        }

        private void HumanResourceVIEW_Load(object sender, EventArgs e)
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

                EmployeeInfo employee = new EmployeeInfo();
                employee.GetInformation(user.CurrentUser);
                UsernameLbl.Text = employee.Username;
                JobTitleLbl.Text = employee.Title;

              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DashBoardPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SideBarPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            DashboardHomeUC dashboard = new DashboardHomeUC();
            if (!DashBoardPanel.Controls.Contains(dashboard))
            {
                DashBoardPanel.Controls.Add(dashboard);
            }
            dashboard.BringToFront();
        }

        private void DashboardBtn_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
