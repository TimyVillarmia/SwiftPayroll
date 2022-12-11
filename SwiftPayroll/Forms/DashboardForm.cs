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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SwiftPayroll
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

      

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoginUC user = new LoginUC();
      

            if (user.CurrentUser == "ADMIN")
            {
                AdminVIEW AdminVIEW = new AdminVIEW();
                DashboardFormPanel.Controls.Add(AdminVIEW);
                AdminVIEW.BringToFront();
            }
            else
            {
                try
                {
                    EmployeeInfo employee = new EmployeeInfo();
                    employee.GetInformation(user.CurrentUser);


                    if (employee.Title == "Human Resources Manager")
                    {
                        HumanResourceVIEW HrView = new HumanResourceVIEW();
                        DashboardFormPanel.Controls.Add(HrView);
                        HrView.BringToFront();

                    }
                    else
                    {
                        RegularEmployeeVIEW employeeVIEW = new RegularEmployeeVIEW();
                        DashboardFormPanel.Controls.Add(employeeVIEW);
                        employeeVIEW.BringToFront();
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
          

               
            }
          






            
            



        }

        private void DashboardFormPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
