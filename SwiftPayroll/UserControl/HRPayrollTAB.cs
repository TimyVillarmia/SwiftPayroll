using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwiftPayroll
{
    public partial class HRPayrollTAB : UserControl
    {
        private static string employee;

        public string SelectedEmployeID
        {
            get { return employee; }
            set { employee = value; }
        }
        public HRPayrollTAB()
        {
            InitializeComponent();
        }

        private void HREmployees_Load(object sender, EventArgs e)
        {
            using (var connection = new SQLiteConnection(@"Data Source=Database\Accounts.db"))
            {
                connection.Open();
                string query = "SELECT employeeID, firstname, lastname, status, title, type FROM Accounts";

                using (var adapter = new SQLiteDataAdapter(query, connection))
                {
                    DataSet dset = new DataSet();
                    adapter.Fill(dset);
                    DataGridView.DataSource = dset.Tables[0];
                }
            }

 




        }

        private void ViewBtn_Click(object sender, EventArgs e)
        {
            


            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=Database\Accounts.db"))
                {
                    connection.Open();
                    string query = "SELECT * FROM Accounts WHERE employeeID=@EmployeeID";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", EmployeeIDTxt.Text);
                        //return The first column of the first row in the result set.
                        using (SQLiteDataReader data = command.ExecuteReader())
                        {

                            data.Read();
                            employee = EmployeeIDTxt.Text;

                            if (EmployeeIDTxt.Text == $"{data["employeeID"]}")
                            {
                          
                                UserInfoView payslip = new UserInfoView();
                                payslip.ShowDialog();
                           

                            }
                        }
                    }
                }

              
                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Employee ID not found");
            }
         



        }

        private void EmployeeIDTxt_TextChanged(object sender, EventArgs e)
        {
            using (var connection = new SQLiteConnection(@"Data Source=Database\Accounts.db"))
            {
                connection.Open();
                string query = "SELECT employeeID, firstname, lastname, status, title, type FROM Accounts WHERE employeeID LIKE @EmployeeID || '%'";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", EmployeeIDTxt.Text);
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dset = new DataTable();
                        adapter.Fill(dset);
                        DataGridView.DataSource = dset;

                    }
                  

                }
            }

          
         

        }
    }
}
