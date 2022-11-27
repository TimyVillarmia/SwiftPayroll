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
            DatabaseClass db = new DatabaseClass();
            AdminDatabaseTAB selectedEmployee = new AdminDatabaseTAB();

            try
            {
                db.connect.Open();
                // To update existing data in a table, you use SQLite UPDATE statement. 
                string query = "UPDATE Accounts SET username=@Username, password=@Password WHERE employeeID = @SelectedEmployee;";
                //Accessing the "Open" property of SQLiteConnection to "Open" the connection
                SQLiteCommand cmd = new SQLiteCommand(query, db.connect);
                cmd.Parameters.AddWithValue("@SelectedEmployee", selectedEmployee.SelectedEmployee);
                cmd.Parameters.AddWithValue("@Username", UsernameTxt.Text);
                cmd.Parameters.AddWithValue("@Password", PasswordTxt.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Username and Password sucessfully changed");
                this.Close();
            }
            catch
            {

            }
            finally
            {
                db.connect.Close();
                db.connect.Dispose();

            }
        }

        private void AccountInfo_AdminForm_Load(object sender, EventArgs e)
        {
            DatabaseClass db = new DatabaseClass();
            AdminDatabaseTAB selectedEmployee = new AdminDatabaseTAB();

            try
            {
                string query = "SELECT * FROM Accounts WHERE employeeID=@EmployeeID";
                db.connect.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, db.connect);
                cmd.Parameters.AddWithValue("@EmployeeID", selectedEmployee.SelectedEmployee);
                //return The first column of the first row in the result set.
                SQLiteDataReader data = cmd.ExecuteReader();
                data.Read();

                FullnameLbl.Text = $"{data["firstname"]} {data["lastname"]}";
                EmployeeIDLbl.Text = $"{data["employeeID"]}";
                TitleLbl.Text = $"{data["title"]}";
                TypeLbl.Text = $"{data["type"]}";
                DepartmentLbl.Text = $"{data["department"]}";
                EmailLbl.Text = $"{data["email"]}";
                ContactLbl.Text = $"{data["contactnumber"]}";
            }
            catch
            {

            }
            finally
            {
                db.connect.Close();
                db.connect.Dispose();
            }
        }
    }
}
