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
        public LoginUC CurrentUser = new LoginUC();
        public EmployeeInfo employee;

        public UserProfile()
        {
            InitializeComponent();
        }

        private void UserProfilePic_Click(object sender, EventArgs e)
        {
 
        }


        private void UserProfile_Load(object sender, EventArgs e)
        {

            employee = new EmployeeInfo();

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

                employee.GetInformation(CurrentUser.CurrentUser);

                FullnameLbl.Text = employee.Fullname;
                EmployeeIDLbl.Text = employee.EmployeeID;
                TitleLbl.Text = employee.Title;
                TypeLbl.Text = employee.Type;
                DepartmentLbl.Text = employee.Department;
                EmailLbl.Text = employee.Email;
                ContactLbl.Text = employee.ContactNumber;




                //placeholders
                FirstnameTxt.Text = employee.FirstName;
                LastnameTxt.Text = employee.LastName;
                UsernameTxt.Text = employee.Username;
                PasswordTxt.Text = employee.Password;
                PasswordTxt.PasswordChar = '•';
                SexComboBox.SelectedItem = employee.Sex;
                ContactTxt.Text = employee.ContactNumber;
                EmailTxt.Text = employee.Email;
                AddressTxt.Text = employee.Address;







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

            PasswordTxt.PasswordChar = '•';



            if (FirstnameTxt.Text != string.Empty && LastnameTxt.Text != string.Empty && PasswordTxt.Text != string.Empty && ContactTxt.Text != string.Empty && EmailTxt.Text != string.Empty && AddressTxt.Text != string.Empty)
            {
                try
                {
                    EmployeeInfo employee = new EmployeeInfo();


                    string New_Firstname = FirstnameTxt.Text;
                    string New_Lastname = LastnameTxt.Text;
                    string New_Password = PasswordTxt.Text;
                    string New_Sex = SexComboBox.SelectedItem.ToString();
                    string New_Contact = ContactTxt.Text;
                    string New_Email = EmailTxt.Text;
                    string New_Address = AddressTxt.Text;
    


                    employee.UpdateProfile(New_Firstname,New_Lastname,New_Password,New_Sex,New_Contact,New_Email,New_Address);



                    FullnameLbl.Text = employee.Fullname;
                    EmployeeIDLbl.Text = employee.EmployeeID;
                    TitleLbl.Text = employee.Title;
                    TypeLbl.Text = employee.Type;
                    DepartmentLbl.Text = employee.Department;
                    EmailLbl.Text = employee.Email;
                    ContactLbl.Text = employee.ContactNumber;



                    //lock textbox
                    FirstnameTxt.Enabled = false;
                    LastnameTxt.Enabled = false;
                    UsernameTxt.Enabled = false;
                    PasswordTxt.Enabled = false;
                    SexComboBox.Enabled = false;
                    ContactTxt.Enabled = false;
                    EmailTxt.Enabled = false;
                    AddressTxt.Enabled = false;


                    SaveBtn.Visible = false;
                    EditBtn.Visible = true;



               
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);


                }
              

            }
            else
            {
                MessageBox.Show("Kindly complete the form");


                if (FirstnameTxt.Text == string.Empty)
                {
                    FirstnameTxt.BorderColor = Color.Red;
                }
                if (LastnameTxt.Text == string.Empty)
                {
                    LastnameTxt.BorderColor = Color.Red;
                }
                if (UsernameTxt.Text == string.Empty)
                {
                    UsernameTxt.BorderColor = Color.Red;
                }
                if (PasswordTxt.Text == string.Empty)
                {
                    PasswordTxt.BorderColor = Color.Red;
                }
                if (ContactTxt.Text == string.Empty)
                {
                    ContactTxt.BorderColor = Color.Red;
                }
                if (EmailTxt.Text == string.Empty)
                {
                    EmailTxt.BorderColor = Color.Red;
                }
                if (AddressTxt.Text == string.Empty)
                {
                    AddressTxt.BorderColor = Color.Red;
                }

            }




        }

        private void ProfilePicture_Click(object sender, EventArgs e)
        {

            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                ProfilePicture.Image = new Bitmap(opnfd.FileName);
            }
        }
    }
}
