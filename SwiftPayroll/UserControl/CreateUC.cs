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
using static System.Net.WebRequestMethods;

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

        public string GenerateEmployeeID()
        {
           
            string month, year, EmployeeID;
            string min, sec;
            month = DateTime.Now.Month.ToString();
            year = DateTime.Now.Year.ToString();

            min = DateTime.Now.Minute.ToString();
            sec = DateTime.Now.Second.ToString();

            return EmployeeID = year + "-" + month + min + sec;
        }

        private void CreateAccountBtn_Click(object sender, EventArgs e)
        {
            //Instantiate SQLiteConnect object which is used for opening connection to the database
            DatabaseClass db = new DatabaseClass();
            //SQLiteConnection connection = new SQLiteConnection("Data Source=Accounts.db;Version=3;");


            //check if data entries exist
            if (FirstNameTxt.Text== string.Empty && LastNameTxt.Text == string.Empty && EmailTxt.Text == string.Empty && UsernameTxt.Text == string.Empty && PasswordTxt.Text == string.Empty && ConfirmPasswordTxt.Text == string.Empty)
            {
                //notify
                MessageBox.Show("Make sure you correctly fill up the form");
            }
            if (PasswordTxt.Text != ConfirmPasswordTxt.Text)
            {

                MessageBox.Show("Passwords are not identical");
            }
            if(TermsCheck.Checked == false)
            {
                MessageBox.Show("Don't forget to check the Terms and Privacy Policy");

            }
            else
            {

                try
                {


                    UserInfo user = new UserInfo(GenerateEmployeeID(), FirstNameTxt.Text.Trim(), LastNameTxt.Text.Trim(), "", UsernameTxt.Text.Trim(), PasswordTxt.Text.Trim(), EmailTxt.Text.Trim(), "", "", "");
                    // creating a string variable "query" with a "INSERT" Statement
                    string query = "INSERT INTO Accounts(employeeID,firstname,lastname,username,password,email) VALUES(@employeeid,@first,@last,@username,@password,@email);";
                    
                    //Accessing the "Open" property of SQLiteConnection to "Open" the connection
                    db.connect.Open();
                    //instantiating SQLiteCommand object and accepts 2 arguments
                    SQLiteCommand cmd = new SQLiteCommand(query, db.connect);
                    //Set the values for each parameters
                    //cmd.Parameters.AddWithValue("ParameterName", ActualValue) base on VALUES(@Username,@Password,@Email)
                    cmd.Parameters.AddWithValue("@employeeid", user.EmployeeID);
                    cmd.Parameters.AddWithValue("@first", user.FirstName);
                    cmd.Parameters.AddWithValue("@last", user.LastName);
                    cmd.Parameters.AddWithValue("@username", user.UserName);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@email", user.Email_Address);
                    //ExecuteNonQuery - execute The Command
                    cmd.ExecuteNonQuery();
                    //Accessing the "Close" property of SQLiteConnection to "Close" the connection


                    // notify
                    MessageBox.Show("Account successfully created, Please Sign In");

                    // Clear all entries
                    FirstNameTxt.Text = "";
                    LastNameTxt.Text = "";
                    EmailTxt.Text = "";
                    UsernameTxt.Text = "";
                    PasswordTxt.Text = "";
                    ConfirmPasswordTxt.Text = "";


                }
                catch (Exception)
                {
                    //notify
                    MessageBox.Show("Make sure the Username is unique and Email is not currently registed");
                }
                finally
                {
                    db.connect.Close();
                    db.connect.Dispose();

  

                }

           


            }

      






        }
    }
}
