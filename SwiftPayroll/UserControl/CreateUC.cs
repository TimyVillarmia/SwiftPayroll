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
           
            string month, year;
            string min, sec;
            month = DateTime.Now.Month.ToString();
            year = DateTime.Now.Year.ToString();

            min = DateTime.Now.Minute.ToString();
            sec = DateTime.Now.Second.ToString();

            return year + "-" + month + min + sec;
        }

        private void CreateAccountBtn_Click(object sender, EventArgs e)
        {



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
                    EmployeeInfo employee = new EmployeeInfo();


                    employee.Register(FirstNameTxt.Text.Trim(), LastNameTxt.Text.Trim(), UsernameTxt.Text.Trim(), PasswordTxt.Text.Trim(), EmailTxt.Text.Trim(), TitleComboBox.SelectedItem.ToString());
                    

                    // Clear all entries
                    FirstNameTxt.Text = "";
                    LastNameTxt.Text = "";
                    EmailTxt.Text = "";
                    UsernameTxt.Text = "";
                    PasswordTxt.Text = "";
                    ConfirmPasswordTxt.Text = "";
                    TitleComboBox.SelectedIndex = -1;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //notify
                    MessageBox.Show("Make sure the Username is unique and Email is not currently registed");
                }
             
           


            }

      






        }
    }
}
