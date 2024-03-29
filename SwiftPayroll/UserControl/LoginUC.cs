﻿using Guna.UI2.WinForms;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;


namespace SwiftPayroll
{
    public partial class LoginUC : UserControl
    {
        //declare variables
        public MainForm MainForm;
        private static string currentuser;
        public string CurrentUser
        {
            get { return currentuser; }
            set { currentuser = value; }
        }

        int seconds = 60; 
        int attempt = 3;
        public LoginUC(MainForm form1)
        {
            InitializeComponent();
            MainForm = form1;
        }

        public LoginUC()
        {

        }

        private void SignUpLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.createUC.BringToFront();

            //disposing unuse usercontrols
            /*
            
                INSERT DISPOSE STATEMENT

             */


            // Clear all entries
            UsernameTxt.Text = "";
            PasswordTxt.Text = "";
        }






        private void SignInBtn_Click(object sender, EventArgs e)
        {
            //SQLiteConnection connection = new SQLiteConnection(@"Data Source=Database\Accounts.db") 
            // check login attempts
            // if attempt != 0 - authenticate
            // if attempt == 0 - login lock for 60 seconds
            if (attempt != 0)
            {
                //check if textboxes are not empty
                if (UsernameTxt.Text.Trim() == string.Empty && PasswordTxt.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Make sure you correctly fill up the form");

                }
                // admin authentication
                if (UsernameTxt.Text == "ADMIN" && PasswordTxt.Text == "ADMIN")
                {
                    currentuser = UsernameTxt.Text;
                    //notify
                    MessageBox.Show("Login Successfully");
                    // hide the MainForm
                    ParentForm.Hide();
                    // displaying sencond form "loading screen form"
                    LoadingScreenForm loading = new LoadingScreenForm();
                    loading.ShowDialog();
                    //Closing 
                    ParentForm.Close();
                    //close connection 

                }
                else // non-admin authentication
                {

                    try
                    {

                        EmployeeInfo employee = new EmployeeInfo();

                        //call the login method from EmployeeInfo class
                        // Login(argument 1, argument 2)
                        if (employee.Login(UsernameTxt.Text.Trim(), PasswordTxt.Text.Trim()) == 1)
                        {
                            currentuser = UsernameTxt.Text;

                            //notify
                            MessageBox.Show("Login Successfully");
                            // hide the MainForm
                            ParentForm.Hide();

                            // displaying sencond form "loading screen form"
                            LoadingScreenForm loading = new LoadingScreenForm();
                            loading.ShowDialog();
                            //Closing 
                            ParentForm.Close();




                            //// Clear all entries
                            UsernameTxt.Text = "";
                            PasswordTxt.Text = "";

                        }
                        else
                        {
                            //notify
                            attempt -= 1;
                            MessageBox.Show($"Wrong username and password combination. {attempt} Attempts left");
                        }

              
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                

                }
            }
            else
            {
                //Start timer if attempts = 0
                timer1.Start();
   
            }


        }

     
    
  

        private void MaskPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (MaskPassword.Checked)
            {
                // default value to unmask
                PasswordTxt.PasswordChar = '\0';
            }
            else
            {
                //mask
                PasswordTxt.PasswordChar = '•';
            }
        }

        private void ForgotLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.recoveryUC.BringToFront();

            // Clear all entries
            UsernameTxt.Text = "";
            PasswordTxt.Text = "";
        }


        


        private void LoginUC_Load(object sender, EventArgs e)
        {

            label1.Visible = false;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds -= 1; // decrement by 1
            if (seconds != 0)
            {
                label1.Visible = true; // show timer text
                label2.Visible = false; // hide default text
                SignInBtn.Enabled = false; //unclickable button
                loginPicBox.Image = SwiftPayroll.Properties.Resources.locked; // change photo to lock
                label1.Text = $"Too many failed login attempts\r\n Please try again after {seconds}"; // timer text
                label1.ForeColor = Color.Red; // change to red forecolor

            }
            else
            {

                label1.Visible = false; //hide timer text
                label2.Visible = true; // show default text
                SignInBtn.Enabled = true; //clickable button
                loginPicBox.Image = SwiftPayroll.Properties.Resources.profile; // change to default photo
                timer1.Stop(); //stop timer if it reaches to 0
                seconds = 60; // reset to 60 seconds
                attempt = 3; // reset to 3 attempts
            }
        }


    }

  
    
}
