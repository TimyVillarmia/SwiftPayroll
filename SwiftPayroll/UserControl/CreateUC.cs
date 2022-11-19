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
    public partial class CreateUC : UserControl
    {
        public MainForm MainForm;
        public CreateUC(MainForm form1)
        {
            InitializeComponent();
            MainForm = form1;
        }

        private void SignInLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.loginUC.BringToFront();

            // Clear all entries
            EmailTxt.Text = "";
            UsernameTxt.Text = "";
            PasswordTxt.Text = "";
            ConfirmPasswordTxt.Text = "";
            RoleCombo.SelectedItem = null;
            TermsCheck.Checked = false;

        }

        private void MaskPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (MaskPassword.Checked)
            {
                // default value to unmask 
                PasswordTxt.PasswordChar = '\0';
                ConfirmPasswordTxt.PasswordChar = '\0';

            }
            else
            {
                // mask 
                PasswordTxt.PasswordChar = '•';
                ConfirmPasswordTxt.PasswordChar = '•';
            }
        }

        private void CreateAccountBtn_Click(object sender, EventArgs e)
        {
            Database DbObj = new Database();

            //check if data entries exist
            if (EmailTxt.Text.Trim() == string.Empty && UsernameTxt.Text.Trim() == string.Empty && PasswordTxt.Text.Trim() == string.Empty && ConfirmPasswordTxt.Text.Trim() == String.Empty && TermsCheck.Checked == false && PasswordTxt.Text == ConfirmPasswordTxt.Text && TypeComboBox.SelectedIndex == -1 && RoleCombo.SelectedIndex == -1)
            {
                //notify
                MessageBox.Show("Make sure you correctly fill up the form");
            }
            else
            {


                try
                {
                    //Instantiate a UserInto object with the necessary arguments
                    UserInfo user = new UserInfo(UsernameTxt.Text.Trim(), PasswordTxt.Text.Trim(), EmailTxt.Text, RoleCombo.SelectedItem.ToString().Trim(), TypeComboBox.SelectedItem.ToString());
                    // creating a string variable "query" with a "INSERT" Statement
                    string query = "INSERT INTO Accounts(username,password,email,role,type) VALUES(@Username,@Password,@Email,@Role,@Type);";
                    // Calling the OpenConnection method from the Database class to open the connection to a database
                    DbObj.OpenConnection();
                    //instantiating SQLiteCommand object and accepts 2 arguments
                    SQLiteCommand cmd = new SQLiteCommand(query, DbObj.connection);
                    //Set the values for each parameters
                    //cmd.Parameters.AddWithValue("ParameterName", ActualValue) base on VALUES(@Username,@Password,@Email,@Role)
                    cmd.Parameters.AddWithValue("@Username", user.UserName);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Email", user.Email_Address);
                    cmd.Parameters.AddWithValue("@Role", user.Role);
                    cmd.Parameters.AddWithValue("@Type", user.Type);
                    //ExecuteNonQuery - execute The Command
                    cmd.ExecuteNonQuery();
                    // Calling the CloseConnection method from the Database class to close the connection to a database
                    DbObj.CloseConnection();


                    // notify
                    MessageBox.Show("Account successfully created, Please Sign In");



                }
                catch (Exception)
                {
                    //notify
                    MessageBox.Show("Make sure the Username is unique and Email is not currently registed");
                    return;
                }


                // Clear all entries
                EmailTxt.Text = "";
                UsernameTxt.Text = "";
                PasswordTxt.Text = "";
                ConfirmPasswordTxt.Text = "";
                RoleCombo.SelectedItem = null;
                TermsCheck.Checked = false;



            


            }
        }
    }
}
