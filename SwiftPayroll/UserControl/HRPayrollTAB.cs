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
            DatabaseClass db = new DatabaseClass();
            //SQLiteConnection connection = new SQLiteConnection("Data Source=Accounts.db;Version=3;");
            db.connect.Open();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT employeeID, firstname, lastname, status, title, type FROM Accounts", db.connect);
            DataSet dset = new DataSet();
            adapter.Fill(dset);
            DataGridView.DataSource = dset.Tables[0];
            db.connect.Close();
            db.connect.Dispose();



        }

        private void ViewBtn_Click(object sender, EventArgs e)
        {
            

            DatabaseClass db = new DatabaseClass();

            try
            {
                string query = "SELECT * FROM Accounts WHERE employeeID=@EmployeeID";
                db.connect.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, db.connect);
                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeIDTxt.Text);
                //return The first column of the first row in the result set.
                SQLiteDataReader data = cmd.ExecuteReader();
                data.Read();
                employee = EmployeeIDTxt.Text;

                if (EmployeeIDTxt.Text == $"{data["employeeID"]}")
                {

                    UserInfoView payslip = new UserInfoView();
                    payslip.ShowDialog();

                }
                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Employee ID not found");
            }
            finally
            {
                db.connect.Close();
                db.connect.Dispose();
            }


        }

        private void EmployeeIDTxt_TextChanged(object sender, EventArgs e)
        {
            DatabaseClass db = new DatabaseClass();
            //SQLiteConnection connection = new SQLiteConnection("Data Source=Accounts.db;Version=3;");

            db.connect.Open();

            string query = "SELECT employeeID, firstname, lastname, status, title, type FROM Accounts WHERE employeeID LIKE @EmployeeID || '%'";
            SQLiteCommand command = new SQLiteCommand(query, db.connect);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            command.Parameters.AddWithValue("@EmployeeID", EmployeeIDTxt.Text);
            DataTable dset = new DataTable();
            adapter.Fill(dset);
            DataGridView.DataSource = dset;
            db.connect.Close();
            db.connect.Dispose();

        }
    }
}
