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
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

      

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoginUC user = new LoginUC();
            string title ="";

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
                    //SQLiteConnection connection = new SQLiteConnection("Data Source=Accounts.db;Version=3;");
                    using (var connection = new SQLiteConnection(@"Data Source=Database\Accounts.db"))
                    {
                        connection.Open();
                        string query = "SELECT title FROM Accounts WHERE username=@Username";

                        using (var command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Username", user.CurrentUser);
                            //return The first column of the first row in the result set.

                            SQLiteDataReader data = command.ExecuteReader();
                            data.Read();
                            title = $"{data["title"]}";

                            if (title == "Human Resources Manager")
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

                    }
                 
                   
                }
                catch(Exception ex)
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
