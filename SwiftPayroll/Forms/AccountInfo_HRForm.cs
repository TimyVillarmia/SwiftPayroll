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
            DatabaseClass db = new DatabaseClass();
            HREmployeeTAB selectedEmployee = new HREmployeeTAB();

            try
            {
                db.connect.Open();
                // To update existing data in a table, you use SQLite UPDATE statement. 
                string query = "UPDATE Accounts SET title=@Title, type=@Type, department=@Department WHERE employeeID = @SelectedEmployee;";
                //Accessing the "Open" property of SQLiteConnection to "Open" the connection
                SQLiteCommand cmd = new SQLiteCommand(query, db.connect);
                cmd.Parameters.AddWithValue("@SelectedEmployee", selectedEmployee.SelectedEmployee);
                cmd.Parameters.AddWithValue("@Title", TitleComboBox.Text);
                cmd.Parameters.AddWithValue("@Type", TypeComboBox.Text);
                cmd.Parameters.AddWithValue("@Department", DepartmentComboBox.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Information Changed");
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

        private void AccountInfo_HRForm_Load(object sender, EventArgs e)
        {
            DatabaseClass db = new DatabaseClass();
            HREmployeeTAB selectedEmployee = new HREmployeeTAB();

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
                TitleComboBox.Text = $"{data["title"]}";
                TypeComboBox.Text = $"{data["type"]}";
                DepartmentComboBox.Text = $"{data["department"]}";
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
