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
            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=Database\Accounts.db"))
                {
                    connection.Open();
                    string query = "SELECT employeeID, firstname, lastname, sex, status, title, type, department FROM Accounts";

                    using (var adapter = new SQLiteDataAdapter(query, connection))
                    {
                        DataSet dset = new DataSet();
                        adapter.Fill(dset);
                        DataGridView.DataSource = dset.Tables[0];

                    }

                }


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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load employees " + ex.Message);
            }


        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AccountInfo_HRForm info_form = new AccountInfo_HRForm();



            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=Database\Accounts.db"))
                {
                    connection.Open();
                    string query = "DELETE FROM Accounts WHERE employeeID=@Selected_employee";


                    using (var command = new SQLiteCommand(query, connection))
                    {
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
                                //get the value of first cell(in the Column Employee ID) of the selected row 
                                string Selected_EmployeeID = DataGridView.Rows[e.RowIndex].Cells["EmployeeID"].Value.ToString();
                                //remove the selected row from the datagrid view
                                DataGridView.Rows.Remove(DataGridView.Rows[e.RowIndex]);
                                //then remove the selected row from the database file
                                command.Parameters.AddWithValue("@Selected_employee", Selected_EmployeeID);
                                command.ExecuteNonQuery();
                            }


                        }
                    }

                     
                }

            
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unable to delete/edit, please connect the admins" + ex.Message);

            }
           
        }
    }
}
