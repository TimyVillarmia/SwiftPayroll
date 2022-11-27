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
    public partial class HREmployeeTAB : UserControl
    {
        private static string employee;
        public string SelectedEmployee
        {
            get { return employee; }
            set { employee = value; }
        }

        public HREmployeeTAB()
        {
            InitializeComponent();
        }

        private void HREmployeeTAB_Load(object sender, EventArgs e)
        {
            DatabaseClass db = new DatabaseClass();
            //SQLiteConnection connection = new SQLiteConnection("Data Source=Accounts.db;Version=3;");
            db.connect.Open();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT employeeID, firstname, lastname, sex, status, title, type, department FROM Accounts", db.connect);
            DataSet dset = new DataSet();
            adapter.Fill(dset);
            DataGridView.DataSource = dset.Tables[0];


            //adding the Edit button
            DataGridViewButtonColumn EditBtn = new DataGridViewButtonColumn();
            EditBtn.Name = "Edit";
            EditBtn.Text = "Edit";
            EditBtn.UseColumnTextForButtonValue = true;
            DataGridView.Columns.Add(EditBtn);

            //adding the Delete button
            DataGridViewButtonColumn DeleteBtn = new DataGridViewButtonColumn();
            DeleteBtn.Name = "Delete";
            DeleteBtn.Text = "Delete";
            DeleteBtn.UseColumnTextForButtonValue = true;
            DataGridView.Columns.Add(DeleteBtn);


            db.connect.Close();
            db.connect.Dispose();
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DatabaseClass db = new DatabaseClass();
            AccountInfo_HRForm info_form = new AccountInfo_HRForm();



            try
            {
                db.connect.Open();
                //check user's choice Edit or Delete
                if (DataGridView.Columns[e.ColumnIndex].Name == "Edit")
                {
                    string Selected_EmployeeID = DataGridView.Rows[e.RowIndex].Cells["EmployeeID"].Value.ToString();
                    SelectedEmployee = Selected_EmployeeID;
                    info_form.ShowDialog();

                }
                else if (DataGridView.Columns[e.ColumnIndex].Name == "Delete")
                { 
                    // get user's dialog result ? Yes or NO
                    DialogResult dialogResult = MessageBox.Show("Are you sure to delete", "", MessageBoxButtons.YesNo);

                    // if User chooses YES
                    if (dialogResult == DialogResult.Yes)
                    {
                        //sqlite command DELETE 
                        string query = "DELETE FROM Accounts WHERE employeeID=@Selected_employee";
                        //get the value of first cell(in the Column Employee ID) of the selected row 
                        string Selected_EmployeeID = DataGridView.Rows[e.RowIndex].Cells["EmployeeID"].Value.ToString();
                        //remove the selected row from the datagrid view
                        DataGridView.Rows.Remove(DataGridView.Rows[e.RowIndex]);
                        //then remove the selected row from the database file
                        SQLiteCommand cmd = new SQLiteCommand(query, db.connect);
                        cmd.Parameters.AddWithValue("@Selected_employee", Selected_EmployeeID);
                        cmd.ExecuteNonQuery();
                    }


                }
            }
            catch
            {
                MessageBox.Show("Unable to delete/edit, please connect the admins");

            }
            finally
            {
                db.connect.Close();
                db.connect.Dispose();


            }
        }
    }
}
