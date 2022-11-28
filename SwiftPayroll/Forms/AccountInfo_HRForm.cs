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
    public partial class AccountInfo_HRForm : Form
    {
        public AccountInfo_HRForm()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            HREmployeeTAB selectedEmployee = new HREmployeeTAB();

            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=Database\Accounts.db"))
                {
                    connection.Open();
                    // To update existing data in a table, you use SQLite UPDATE statement. 
                    string query = "UPDATE Accounts SET title=@Title, type=@Type, department=@Department WHERE employeeID = @SelectedEmployee;";

                    using (var command = new SQLiteCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@SelectedEmployee", selectedEmployee.SelectedEmployee);
                        command.Parameters.AddWithValue("@Title", TitleComboBox.Text);
                        command.Parameters.AddWithValue("@Type", TypeComboBox.Text);
                        command.Parameters.AddWithValue("@Department", DepartmentComboBox.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Information Changed");
                        this.Close();
                    }
                }
           


            }
            catch(Exception ex)
            {
                MessageBox.Show("Unable to update information"+ ex.Message);
            } 
         
        }

        private void AccountInfo_HRForm_Load(object sender, EventArgs e)
        {
            HREmployeeTAB selectedEmployee = new HREmployeeTAB();

            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=Database\Accounts.db"))
                {
                    connection.Open();
                    string query = "SELECT * FROM Accounts WHERE employeeID=@EmployeeID";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", selectedEmployee.SelectedEmployee);
                        //return The first column of the first row in the result set.
                        SQLiteDataReader data = command.ExecuteReader();
                        data.Read();

                        FullnameLbl.Text = $"{data["firstname"]} {data["lastname"]}";
                        EmployeeIDLbl.Text = $"{data["employeeID"]}";
                        TitleComboBox.Text = $"{data["title"]}";
                        TypeComboBox.Text = $"{data["type"]}";
                        DepartmentComboBox.Text = $"{data["department"]}";
                        EmailLbl.Text = $"{data["email"]}";
                        ContactLbl.Text = $"{data["contactnumber"]}";
                    }

                }

       
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unable to load employee's information" + ex.Message);
            }
       
        }
    }
}
