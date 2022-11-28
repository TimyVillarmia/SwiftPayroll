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
    public partial class AccountInfo_AdminForm : Form
    {
        public AccountInfo_AdminForm()
        {
            InitializeComponent();
        }

        private void ViewBtn_Click(object sender, EventArgs e)
        {
            AdminDatabaseTAB selectedEmployee = new AdminDatabaseTAB();


            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=Database\Accounts.db"))
                {
                    connection.Open();
                    // To update existing data in a table, you use SQLite UPDATE statement. 
                    string query = "UPDATE Accounts SET username=@Username, password=@Password WHERE employeeID = @SelectedEmployee;";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SelectedEmployee", selectedEmployee.SelectedEmployee);
                        command.Parameters.AddWithValue("@Username", UsernameTxt.Text);
                        command.Parameters.AddWithValue("@Password", PasswordTxt.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Username and Password sucessfully changed");
                        this.Close();
                       
                    }
                }

        
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }

        private void AccountInfo_AdminForm_Load(object sender, EventArgs e)
        {
            AdminDatabaseTAB selectedEmployee = new AdminDatabaseTAB();

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
                        using (SQLiteDataReader data = command.ExecuteReader())
                        {
                            data.Read();

                            FullnameLbl.Text = $"{data["firstname"]} {data["lastname"]}";
                            EmployeeIDLbl.Text = $"{data["employeeID"]}";
                            TitleLbl.Text = $"{data["title"]}";
                            TypeLbl.Text = $"{data["type"]}";
                            DepartmentLbl.Text = $"{data["department"]}";
                            EmailLbl.Text = $"{data["email"]}";
                            ContactLbl.Text = $"{data["contactnumber"]}";
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
}
