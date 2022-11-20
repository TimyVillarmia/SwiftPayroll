﻿using Guna.UI2.WinForms;
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
            SQLiteConnection connection = new SQLiteConnection("Data Source=Accounts.db;Version=3;");

            //Checking whether textboxes are empty or not
            if (UsernameTxt.Text.Trim() == string.Empty && PasswordTxt.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Make sure you correctly fill up the form");

            }
            else
            {
                try
                {
                    string query = "SELECT count(*) FROM Accounts WHERE username = @Username AND password = @Password";
                    connection.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Username", UsernameTxt.Text);
                    cmd.Parameters.AddWithValue("@Password", PasswordTxt.Text);
                    //return The first column of the first row in the result set.
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    // if count = 1 then the account exist ; else account doesn't exist
                    if (count == 1)
                    {

                        //notify
                        MessageBox.Show("Login Successfully");
                        // hide the MainForm
                        ParentForm.Hide();
                        // displaying sencond form "Dashboard"
                        Dashboard dashboard = new Dashboard();
                        dashboard.ShowDialog();
                        //Closing 
                        ParentForm.Close();
                        //close connection 
                

                        // Clear all entries
                        UsernameTxt.Text = "";
                        PasswordTxt.Text = "";




                    }
                    else
                    {
                        //notify
                        MessageBox.Show("Wrong username and password combination");

                    }
                }
                catch
                {
                    MessageBox.Show("Unable to login, please try again later");

                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }

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
    }
    
}
