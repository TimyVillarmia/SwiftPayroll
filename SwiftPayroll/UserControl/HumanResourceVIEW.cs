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
    public partial class HumanResourceVIEW : UserControl
    {
        public HumanResourceVIEW()
        {
            InitializeComponent();
        }

        private void SignOutBtn_Click(object sender, EventArgs e)
        {
            ParentForm.Hide();
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
            ParentForm.Close();
        }

        private void EmployeeBtn_Click(object sender, EventArgs e)
        {

        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            UserProfile profile = new UserProfile();
            if (!DashBoardPanel.Contains(profile))
            {
                DashBoardPanel.Controls.Add(profile);
            }
            profile.BringToFront();
        }

        private void PayrollBtn_Click(object sender, EventArgs e)
        {
            HRPayrollTAB payroll = new HRPayrollTAB();
            if (!DashBoardPanel.Contains(payroll))
            {
                DashBoardPanel.Controls.Add(payroll);
            }
            payroll.BringToFront();
        }

        private void EmployeeBtn_Click_1(object sender, EventArgs e)
        {
            HREmployeeTAB employeeTAB = new HREmployeeTAB();
            if (!DashBoardPanel.Contains(employeeTAB))
            {
                DashBoardPanel.Controls.Add(employeeTAB);
            }
            employeeTAB.BringToFront();
        }

        private void HumanResourceVIEW_Load(object sender, EventArgs e)
        {
            LoginUC user = new LoginUC();
            DatabaseClass db = new DatabaseClass();

            string query = "SELECT * FROM Accounts WHERE username=@Username";
            db.connect.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, db.connect);
            cmd.Parameters.AddWithValue("@Username", user.CurrentUser);
            //return The first column of the first row in the result set.
            SQLiteDataReader data = cmd.ExecuteReader();
            data.Read();


            UsernameLbl.Text = $"{data["firstname"]} {data["lastname"]}";
            JobTitleLbl.Text = $"{data["title"]}";
        }
    }
}
