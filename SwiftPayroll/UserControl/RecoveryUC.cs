using MimeKit;
using System;
using System.Data.SQLite;

using System.Windows.Forms;
using MailKit.Net.Smtp;
using SwiftPayroll.Properties;


namespace SwiftPayroll
{
    public partial class RecoveryUC : UserControl
    {
        public string OTP;
        public MainForm MainForm;

        public RecoveryUC(MainForm form1)
        {
            InitializeComponent();
            MainForm = form1;
        }

        private void BackLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.loginUC.BringToFront();

            // Clear all entries
            EmailTxt.Text = "";
            OTPTxt.Text = "";
            PasswordTxt.Text = "";
            ConfirmPasswordTxt.Text = "";
        }

        private string GenerateOTP()
        {
            //OTP generator
            string otp_char = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            OTP = "";
            Random rnd = new Random();

            for (int i = 0; i < 6; i++)
            {

                var random_char = otp_char[rnd.Next(1, otp_char.Length)];
                OTP += random_char;

            }
            return OTP;

        }

        private void OTPBtn_Click(object sender, EventArgs e)
        {
            Database DBObj = new Database();
            string query = "SELECT count(*) FROM Accounts WHERE email = @Email";
            DBObj.OpenConnection();
            SQLiteCommand cmd = new SQLiteCommand(query, DBObj.connection);
            cmd.Parameters.AddWithValue("@Email", EmailTxt.Text);
            //return The first column of the first row in the result set.
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            
            if (count == 1)
            {
                string msg = GenerateOTP();
                string senderEmail, senderPass, receiverEmail;
                receiverEmail = EmailTxt.Text;
                senderEmail = "timyvillarmia10@gmail.com";
                senderPass = "pyuzbklnkwwwwozg";  //Gmail's App Password Change this to your Gmail's App Password

                MimeMessage message = new MimeMessage(); // Creating object for Message
                message.From.Add(new MailboxAddress("SwiftPayroll - OTP", senderEmail)); //Sender's information
                message.To.Add(MailboxAddress.Parse(receiverEmail)); //Receiver's Information

                message.Subject = "One-Time-Password"; //Email's Subject

                //Email's Body
                message.Body = new TextPart("plain") //Plain text
                {
                    Text = msg  //MSG = OTP
                };

                SmtpClient client = new SmtpClient(); // allows sending of e-mail notifications using a SMTP server

                try
                {
                    client.Connect("smtp.gmail.com", 465, true); //Gmail's smtp server, PORT: 465
                    client.Authenticate(senderEmail, senderPass); //Login sender's email and password
                    client.Send(message); //
                    MessageBox.Show("Kindly check your email and don't forget to check your SPAM folders");
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to generate OTP, please try again");
                    return;
                }
                finally
                {
                    client.Disconnect(true); // always Disconnect the service.
                    client.Dispose(); //Releases all resource used by the MailService object.
                }
            }
            else
            {
                MessageBox.Show("Email is not registered");

            }

        }

        private void RecoverBtn_Click(object sender, EventArgs e)
        {
            Database DBObj = new Database();

            //Guard Clause Technique

            if (EmailTxt.Text == string.Empty && PasswordTxt.Text == string.Empty && ConfirmPasswordTxt.Text == string.Empty && OTPTxt.Text == string.Empty)
            {
                MessageBox.Show("Make sure you correctly fill up the form");
            }
            if (OTPTxt.Text != OTP)
            {
                MessageBox.Show("Invalid OTP");

            }
            if (PasswordTxt.Text != ConfirmPasswordTxt.Text)
            {
                MessageBox.Show("Passwords are not identical");
            }
            else
            {
                try
                {
                    // To update existing data in a table, you use SQLite UPDATE statement. 
                    string query = "UPDATE Accounts SET password=@Password WHERE email = @Email";
                    DBObj.OpenConnection();
                    SQLiteCommand cmd = new SQLiteCommand(query, DBObj.connection);
                    cmd.Parameters.AddWithValue("@Email", EmailTxt.Text);
                    cmd.Parameters.AddWithValue("@Password", PasswordTxt.Text);
                    cmd.ExecuteNonQuery();
                    DBObj.CloseConnection();
                    DBObj.connection.Dispose();
                    MessageBox.Show("Account successfully reset, Please Sign In");

                    // Clear all entries
                    EmailTxt.Text = "";
                    OTPTxt.Text = "";
                    PasswordTxt.Text = "";
                    ConfirmPasswordTxt.Text = "";

                }
                catch (Exception)
                {
                    //notify
                    MessageBox.Show("Unable to reset your password, please try again");
                    return;
                }

            }

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
    }
}
