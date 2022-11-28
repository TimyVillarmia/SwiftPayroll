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
    public partial class UserProfile : UserControl
    {
        public UserProfile()
        {
            InitializeComponent();
        }

        private void UserProfilePic_Click(object sender, EventArgs e)
        {
 
        }


        private void UserProfile_Load(object sender, EventArgs e)
        {

            LoginUC CurrentUser = new LoginUC();

            SaveBtn.Visible = false;
            EditBtn.Visible = true;

            //lock textbox

            FirstnameTxt.Enabled = false;
            LastnameTxt.Enabled = false;
            UsernameTxt.Enabled = false;
            PasswordTxt.Enabled = false;
            SexComboBox.Enabled = false;
            ContactTxt.Enabled = false;
            EmailTxt.Enabled = false;
            AddressTxt.Enabled = false;

            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=Database\Accounts.db"))
                {
                    connection.Open();
                    string query = "SELECT * FROM Accounts WHERE username=@Username";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", CurrentUser.CurrentUser);
                        //return The first column of the first row in the result set.
                        SQLiteDataReader data = command.ExecuteReader();
                        data.Read();

                        FullnameLbl.Text = $"{data["firstname"]} {data["lastname"]}";
                        EmployeeIDLbl.Text = $"{data["employeeID"]}";
                        TitleLbl.Text = $"{data["title"]}";
                        TypeLbl.Text = $"{data["type"]}";
                        DepartmentLbl.Text = $"{data["department"]}";
                        EmailLbl.Text = $"{data["email"]}";
                        ContactLbl.Text = $"{data["contactnumber"]}";




                        //placeholders
                        FirstnameTxt.PlaceholderText = $"{data["firstname"]}";
                        LastnameTxt.PlaceholderText = $"{data["lastname"]}";
                        UsernameTxt.PlaceholderText = $"{data["username"]}";
                        PasswordTxt.PlaceholderText = $"{data["password"]}";
                        PasswordTxt.PasswordChar = '•';
                        SexComboBox.SelectedItem = $"{data["sex"]}";
                        ContactTxt.PlaceholderText = $"{data["contactnumber"]}";
                        EmailTxt.PlaceholderText = $"{data["email"]}";
                        AddressTxt.PlaceholderText = $"{data["address"]}";
                    }

                }




     
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
      




   



        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            SaveBtn.Visible = true;
            EditBtn.Visible = false;

            PasswordTxt.PasswordChar = '\0';


            //unlock textbox
            FirstnameTxt.Enabled = true;
            LastnameTxt.Enabled = true;
            UsernameTxt.Enabled = false;
            PasswordTxt.Enabled = true;
            SexComboBox.Enabled = true;
            EmailTxt.Enabled = true;
            ContactTxt.Enabled = true;
            AddressTxt.Enabled = true;


        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {


            SaveBtn.Visible = false;
            EditBtn.Visible = true;
            PasswordTxt.PasswordChar = '•';

            LoginUC CurrentUser = new LoginUC();

            if (FirstnameTxt.Text != string.Empty && LastnameTxt.Text != string.Empty && PasswordTxt.Text != string.Empty && ContactTxt.Text != string.Empty && EmailTxt.Text != string.Empty && AddressTxt.Text != string.Empty)
            {
                try
                {
                    using (var connection = new SQLiteConnection(@"Data Source=Database\Accounts.db"))
                    {
                        connection.Open();
                        string query = "UPDATE Accounts SET sex=@sex,firstname=@first,lastname=@last,password=@password,email=@email,contactnumber=@contact,address=@address WHERE username=@currentuser;";

                        using (var command = new SQLiteCommand(query, connection))
                        {

                            //Set the values for each parameters
                            //cmd.Parameters.AddWithValue("ParameterName", ActualValue) base on VALUES(@Username,@Password,@Email)
                            command.Parameters.AddWithValue("@sex", SexComboBox.SelectedItem);
                            command.Parameters.AddWithValue("@first", FirstnameTxt.Text);
                            command.Parameters.AddWithValue("@last", LastnameTxt.Text);
                            command.Parameters.AddWithValue("@currentuser", CurrentUser.CurrentUser);
                            command.Parameters.AddWithValue("@password", PasswordTxt.Text);
                            command.Parameters.AddWithValue("@email", EmailTxt.Text);
                            command.Parameters.AddWithValue("@contact", ContactTxt.Text);
                            command.Parameters.AddWithValue("@address", AddressTxt.Text);
                            //ExecuteNonQuery - execute The Command
                            command.ExecuteNonQuery();




                            //lock textbox
                            FirstnameTxt.Enabled = false;
                            LastnameTxt.Enabled = false;
                            UsernameTxt.Enabled = false;
                            PasswordTxt.Enabled = false;
                            SexComboBox.Enabled = false;
                            ContactTxt.Enabled = false;
                            EmailTxt.Enabled = false;
                            AddressTxt.Enabled = false;
                        }
                    }


               
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);


                }
              

            }
            else
            {
                MessageBox.Show("Kindly complete the form");

            }




        }
    }
}
