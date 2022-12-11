using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SwiftPayroll
{


    public class EmployeeInfo
    {
        //Employee Infomation
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Fullname
        {
            get { return FirstName + " " + LastName; }
            set { FirstName = value; }
        }
        public string Sex { get; set; }
        public string Status { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Department { get; set; }

       // Employee's Payslip Information
       public string PayDate { get; set; }
       public string WorkedDay { get; set; }
       public string AbsencesDay { get; set; }
       public string StandardPay { get; set; }
       public string OvertimeHours { get; set; }
       public string OvertimePay { get; set; }
       public string GrossIncome { get; set; }
       public string SSS { get; set; }
       public string PagIbig { get; set; }
       public string PhilHealth { get; set; }
       public string AbsencesDeduction { get; set; }
       public string Tax { get; set; }
       public string NetIncome { get; set; }


        public EmployeeInfo()
        {

        }

      



        //method for getting all the personal information of an employee
        public void GetInformation(string username)
        {
            using (var connection = new SQLiteConnection(@"Data Source=Database\Accounts.db"))
            {
                connection.Open();
                string query = "SELECT * FROM Accounts WHERE username=@Username;";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    SQLiteDataReader data = command.ExecuteReader();
                    data.Read();

                    EmployeeID = $"{data["employeeID"]}";
                    FirstName = $"{data["firstname"]}";
                    LastName = $"{data["lastname"]}";
                    Sex = $"{data["sex"]}";
                    Status = $"{data["status"]}";
                    Username = $"{data["username"]}";
                    Password = $"{data["password"]}";
                    Email = $"{data["email"]}";
                    ContactNumber = $"{data["contactnumber"]}";
                    Address = $"{data["address"]}";
                    Title = $"{data["title"]}";
                    Type = $"{data["type"]}";
                    Department = $"{data["department"]}";


                    data.Close();
                
                }

            }
        }

       
        //method for logging in
        public int Login(string username, string password)
        {
            using (var connection = new SQLiteConnection(@"Data Source=Database\Accounts.db"))
            {
                connection.Open();
                string query = "SELECT count(*) FROM Accounts WHERE username = @Username AND password = @Password";

                using (var command = new SQLiteCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    //if count = 1 then the account exist; else account doesn't exist
                    return count;

                }


            }
        }
        //method for generating employee ID 
        public string GenerateEmployeeID()
        {

            string month, year;
            string min, sec;
            month = DateTime.Now.Month.ToString();
            year = DateTime.Now.Year.ToString();

            min = DateTime.Now.Minute.ToString();
            sec = DateTime.Now.Second.ToString();

            return EmployeeID = year + "-" + month + min + sec;
        }

        //method for registering an account
        public void Register(string firstname, string lastname, string username, string password, string email, string title)
        {
            using (var connection = new SQLiteConnection(@"Data Source=Database\Accounts.db"))
            {
                connection.Open();

                string query = "INSERT INTO Accounts(employeeID,firstname,lastname,username,password,email,title) VALUES(@employeeid,@first,@last,@username,@password,@email,@title);";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@employeeid", GenerateEmployeeID());
                    command.Parameters.AddWithValue("@first", firstname);
                    command.Parameters.AddWithValue("@last", lastname);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@title", title);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Account successfully created, Please Sign In");

                }
            }
        }

        //method for recovering an account
        public void RecoverAccount(string email,string password)
        {
            using (var connection = new SQLiteConnection(@"Data Source=Database\Accounts.db"))
            {
                connection.Open();
                string query = "UPDATE Accounts SET password=@Password WHERE email = @Email;";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Account successfully reset, Please Sign In");

              

                }
            }
        }


        //method for updating employee's personal information
        public void UpdateProfile(string firstname, string lastname, string password, string sex, string contact, string email, string address)
        {
            using (var connection = new SQLiteConnection(@"Data Source=Database\Accounts.db"))
            {
                connection.Open();
                string query = "UPDATE Accounts SET sex=@sex,firstname=@first,lastname=@last,password=@password,email=@email,contactnumber=@contact,address=@address WHERE username=@currentuser;";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sex", sex);
                    command.Parameters.AddWithValue("@first", firstname);
                    command.Parameters.AddWithValue("@last", lastname);
                    command.Parameters.AddWithValue("@currentuser", Username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@contact", contact);
                    command.Parameters.AddWithValue("@address", address);
                    command.ExecuteNonQuery();


               
                }
            }
        }

        //method for getting payslip  of an employee
        public void GetPaySlip(string paydate)
        {
            using (var connection = new SQLiteConnection(@"Data Source=Database\PaySlip.db"))
            {
                connection.Open();
                string query = "SELECT * FROM EmployeePaySlip WHERE EmployeeID=@employeeID AND PayDate=@paydate;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@employeeID", EmployeeID);
                    command.Parameters.AddWithValue("@paydate", paydate);

                    using (SQLiteDataReader data = command.ExecuteReader())
                    {
                        data.Read();

                        WorkedDay = $"{data["WorkedDay"]}";
                        AbsencesDay = $"{data["AbsencesDay"]}";
                        StandardPay = $"{data["StandardPay"]}";
                        OvertimeHours = $"{data["OvertimeHours"]}";
                        OvertimePay = $"{data["OvertimePay"]}";
                        GrossIncome = $"{data["GrossIncome"]}";
                        SSS = $"{data["SSS"]}";
                        PagIbig = $"{data["PagIbig"]}";
                        PhilHealth = $"{data["PhilHealth"]}";
                        AbsencesDeduction = $"{data["AbsencesDeduction"]}";
                        Tax = $"{data["Tax"]}";
                        NetIncome = $"{data["NetIncome"]}";

                       
                    }
                }


            }
        }







    }
}

