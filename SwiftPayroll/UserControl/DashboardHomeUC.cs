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
    public partial class DashboardHomeUC : UserControl
    {
        public DashboardHomeUC()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void employeeInfoBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void DashboardHomeUC_Load(object sender, EventArgs e)
        {
            LoginUC user = new LoginUC();

            EmployeeInfo employee = new EmployeeInfo();
            employee.GetInformation(user.CurrentUser);
            GreetingsLbl.Text = $"Hello {employee.Fullname}";
        }
    }
}
