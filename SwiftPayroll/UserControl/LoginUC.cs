using Guna.UI2.WinForms;
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
    public partial class LoginUC : UserControl
    {
        public MainForm MainForm;
        public LoginUC(MainForm form1)
        {
            InitializeComponent();
            MainForm = form1;
        }

        private void SignUpLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.createUC.BringToFront();
        }



        private void SignInBtn_Click(object sender, EventArgs e)
        {
            Database DBObj = new Database();
            //Checking whether textboxes are empty or not
            if (UsernameTxt.Text.Trim() == string.Empty && PasswordTxt.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Make sure you correctly fill up the form");

            }
            else
            {
               
                string query = "SELECT * FROM Accounts WHERE username = @Username AND password = @Password";
                DBObj.OpenConnection();
                SQLiteCommand cmd = new SQLiteCommand(query, DBObj.connection);
                cmd.Parameters.AddWithValue("@Username", UsernameTxt.Text);
                cmd.Parameters.AddWithValue("@Password", PasswordTxt.Text);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    MessageBox.Show("Login Successfully");
                    ParentForm.Hide();
                    Dashboard dashboard = new Dashboard();
                    dashboard.ShowDialog();
                    ParentForm.Close();
                    DBObj.CloseConnection();



                }
                else
                {
                    MessageBox.Show("Wrong username and password combination");

                }

            }
        }

        private void MaskPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (MaskPassword.Checked)
            {
                //
                PasswordTxt.PasswordChar = '\0';
            }
            else
            {
                PasswordTxt.PasswordChar = '•';
            }
        }
    }
    
}
