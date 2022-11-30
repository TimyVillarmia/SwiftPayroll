using System;
using System.IO;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Drawing.Printing;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using System.Reflection;
using System.Data;
using iTextSharp.text.pdf.parser.clipper;

namespace SwiftPayroll
{
    public partial class UserInfoView : Form
    {
        string JobType = "";
        //constant values
        readonly double PartTime_DailyIncome = 4 * 80;
        readonly double FullTime_DailyIncome = 8 * 150;
        readonly double OTRATE = 45;
        readonly double ABSENT_RATE = 200;

        //variables
        double FullTime_MonthlyIncome = 0;
        double PartTime_MonthlyIncome = 0;
        double TotalOvertime = 0;
        double SSS = 0;
        double PAGIBIG = 0;
        double PHILHEALTH = 0;
        double NumofAbsent = 0;

        public UserInfoView()
        {
            InitializeComponent();
        }

        private void UserInfoView_Load(object sender, EventArgs e)
        {
            TimerCount.Start();
            HRPayrollTAB employee = new HRPayrollTAB();

            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=Database\Accounts.db"))
                {
                    connection.Open();
                    string query = "SELECT * FROM Accounts WHERE employeeID=@EmployeeID";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employee.SelectedEmployeeID);
                        //returns an object that can iterate over the entire result set.
                        using (SQLiteDataReader data = command.ExecuteReader())
                        {
                            data.Read();

                            FullnameLbl.Text = $"{data["firstname"]} {data["lastname"]}";
                            EmployeeIDLbl.Text = $"{data["employeeID"]}";
                            TitleLbl.Text = $"{data["title"]}";
                            JobType = $"{data["type"]}";
                            TypeLbl.Text = JobType;
                            DepartmentLbl.Text = $"{data["department"]}";
                            EmailLbl.Text = $"{data["email"]}";
                            ContactLbl.Text = $"{data["contactnumber"]}";

                            //placeholders
                            if (JobType == "Full-Time")
                            {
                                HourlyRateLbl.Text = "₱150";
                                HourLbl.Text = "8 hrs";

                            }
                            else
                            {
                                HourlyRateLbl.Text = "₱80";
                                HourLbl.Text = "4 hrs";
                            }
                        }
                            
                    }

                }

              

            }
            catch(Exception ex)
            {
                MessageBox.Show("Unable to load employee's information" + ex.Message);
            }
      

        }

        private void DaysTxt_TextChanged(object sender, EventArgs e)
        {
          
            if (JobType == "Full-Time")
            {
                if(DaysTxt.Text != string.Empty)
                {
                    FullTime_MonthlyIncome = Convert.ToInt32(DaysTxt.Text) * FullTime_DailyIncome;
                    IncomeLbl.Text = String.Format("₱{0:n}", FullTime_MonthlyIncome);
                }
                else
                {
                    FullTime_MonthlyIncome = 0 * FullTime_DailyIncome;
                    IncomeLbl.Text = String.Format("₱{0:n}", FullTime_MonthlyIncome);
                }
                


            }
            else
            {
                if (DaysTxt.Text != string.Empty)
                {
                    PartTime_MonthlyIncome = Convert.ToInt32(DaysTxt.Text) * PartTime_DailyIncome;
                    IncomeLbl.Text = String.Format("₱{0:n}", PartTime_MonthlyIncome);
                }
                else
                {
                    PartTime_MonthlyIncome = 0 * PartTime_DailyIncome;
                    IncomeLbl.Text = String.Format("₱{0:n}", PartTime_MonthlyIncome);
                }
                    
            }
           
        }

        private void OvertimeTxt_TextChanged(object sender, EventArgs e)
        {
            if (OvertimeTxt.Text != string.Empty)
            {
                OvertimeRateLbl.Text = $"₱{OTRATE}";        
                OTHourLbl.Text =  $"{OvertimeTxt.Text} hrs";
                TotalOvertime = Convert.ToInt32(OvertimeTxt.Text) * OTRATE;

                OvertimeIncomeLbl.Text = String.Format("₱{0:n}", TotalOvertime);
            }
            else
            {
                OvertimeRateLbl.Text = $"₱{OTRATE}";
                OTHourLbl.Text = OvertimeTxt.Text;
                TotalOvertime = 0 * OTRATE;
                        
                OvertimeIncomeLbl.Text = String.Format("₱{0:n}", TotalOvertime);
            } 

         
        }

        private void AbsentTxt_TextChanged(object sender, EventArgs e)
        {
            if (AbsentTxt.Text != string.Empty)
            {
                NumofAbsent = Convert.ToInt32(AbsentTxt.Text);
                AbsentLbl1.Text = String.Format("₱{0:n}", ABSENT_RATE * NumofAbsent);
                AbsentLbl.Text = $"₱{ABSENT_RATE}";
            }
            else
            {
              
                AbsentLbl1.Text = String.Format("₱{0:n}", ABSENT_RATE * 0);
                AbsentLbl.Text = $"₱{ABSENT_RATE}";
            }

  
         
        }



        private void TimerCount_Tick(object sender, EventArgs e)
        {
            //calculations
            double GrossIncome = FullTime_MonthlyIncome+ PartTime_MonthlyIncome + TotalOvertime;
            double TaxTotal = GrossIncome * .1;
            double TotalAbsent = ABSENT_RATE * NumofAbsent;
            double TotalDeduction = SSS+ PAGIBIG + PHILHEALTH + TotalAbsent + TaxTotal;
            double NetIncome = GrossIncome - TotalDeduction;

            //displaying
            GrossIncomeLbl.Text = String.Format("₱{0:n}", GrossIncome);
            TaxLbl.Text = String.Format("₱{0:n}", TaxTotal);
            DeductionsLBL.Text = String.Format("₱{0:n}", TotalDeduction);
            NetIncomeLbl.Text = String.Format("₱{0:n}", NetIncome);

        }


        

        private void GeneratePayBtn_Click(object sender, EventArgs e)
        {



            HRPayrollTAB employee = new HRPayrollTAB();
            //selected date
            string date = $"{PayDate.Value.Date.Day}-{PayDate.Value.Date.Month}-{PayDate.Value.Date.Year}";



            if (DaysTxt.Text == string.Empty)
            {
                MessageBox.Show("Please input Worked days");

            }
            else
            {
               


                try
                {
                    int count;
                   

                    using (var connection = new SQLiteConnection(@"Data Source=Database\PaySlip.db"))
                    {
                        connection.Open();
                        //return a number on how many "selected date" is in the PayDate Column base on the employeeID and selected date of the user
                        // 0 = selected date does not exist in the db
                        // 1 = selected date exist in the db
                        string query = "SELECT count(PayDate) FROM EmployeePaySlip Where EmployeeID=@employeeID AND PayDate=@paydate;";

                        using (var command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@employeeID", employee.SelectedEmployeeID);
                            command.Parameters.AddWithValue("@paydate", date);

                            count = Convert.ToInt32(command.ExecuteScalar());


                        }


                    }

                    MessageBox.Show($"{count}");

                    // 0 = selected date does not exist in the db then insert the payslip informatio to the db
                    // 1 = selected date exist in the db then update the payslip informatio to the db
                    if (count == 0)
                    {
                        InsertPaySlipToDatabase();


                    }
                    else
                    {
                        UpdateExistingPaySlip();

                    }


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
             






            }







        }

        private void UpdateExistingPaySlip()
        {
            HRPayrollTAB employee = new HRPayrollTAB();
            //selected date
            string date = $"{PayDate.Value.Date.Day}-{PayDate.Value.Date.Month}-{PayDate.Value.Date.Year}";
            DialogResult dialogResult = MessageBox.Show($"{date} Payslip already exist \n Do you want to update the payslip's information?  ", "", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {

                    using (var connection = new SQLiteConnection(@"Data Source=Database\PaySlip.db"))
                    {
                        // To update existing data in a table, you use SQLite UPDATE statement. 
                        string query = "UPDATE EmployeePaySlip SET WorkedDay=@workedday, AbsencesDay=@absencesday, StandardPay=@standardpay, OvertimeHours=@overtimehours, OvertimePay=@overtimepay, GrossIncome=@grossincome, SSS=@sss, PagIbig=@pagibig, PhilHealth=@philhealth, AbsencesDeduction=@absencesdeduction, Tax=@tax, NetIncome=@netincome WHERE PayDate=@date AND EmployeeID=@employeeID;";
                        connection.Open();


                        using (var command = new SQLiteCommand(query, connection))
                        {
                            //Set the values for each parameters
                            command.Parameters.AddWithValue("@employeeID", employee.SelectedEmployeeID);
                            command.Parameters.AddWithValue("@date", date);
                            command.Parameters.AddWithValue("@workedday", DaysTxt.Text);
                            command.Parameters.AddWithValue("@absencesday", AbsentTxt.Text);
                            command.Parameters.AddWithValue("@standardpay", IncomeLbl.Text);
                            command.Parameters.AddWithValue("@overtimehours", OTHourLbl.Text);
                            command.Parameters.AddWithValue("@overtimepay", OvertimeIncomeLbl.Text);
                            command.Parameters.AddWithValue("@grossincome", GrossIncomeLbl.Text);
                            command.Parameters.AddWithValue("@sss", SSSLbl1.Text);
                            command.Parameters.AddWithValue("@pagibig", PagibigLbl1.Text);
                            command.Parameters.AddWithValue("@philhealth", PhilHealthLbl1.Text);
                            command.Parameters.AddWithValue("@absencesdeduction", AbsentLbl1.Text);
                            command.Parameters.AddWithValue("@tax", TaxLbl.Text);
                            command.Parameters.AddWithValue("@netincome", NetIncomeLbl.Text);

                            command.ExecuteNonQuery();

                            MessageBox.Show("Payslip updated successfully");
                            TimerCount.Stop();
                            this.Close();

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void InsertPaySlipToDatabase()
        {
            try
            {

                HRPayrollTAB employee = new HRPayrollTAB();
                //selected date
                string date = $"{PayDate.Value.Date.Day}-{PayDate.Value.Date.Month}-{PayDate.Value.Date.Year}";

                using (var connection = new SQLiteConnection(@"Data Source=Database\PaySlip.db"))
                {

                    connection.Open();
                    string query = "INSERT INTO EmployeePaySlip(EmployeeID,PayDate,WorkedDay, AbsencesDay, StandardPay, OvertimeHours, OvertimePay, GrossIncome, SSS, PagIbig, PhilHealth, AbsencesDeduction, Tax, NetIncome) VALUES(@employeeid, @date, @workedday, @absencesday, @standardpay, @overtimehours, @overtimepay, @grossincome, @sss, @pagibig, @philhealth, @absencesdeduction, @tax, @netincome);";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        //Set the values for each parameters
                        //cmd.Parameters.AddWithValue("ParameterName", ActualValue) base on VALUES(@Username,@Password,@Email)
                        command.Parameters.AddWithValue("@employeeid", employee.SelectedEmployeeID);
                        command.Parameters.AddWithValue("@date", date);
                        command.Parameters.AddWithValue("@workedday", DaysTxt.Text);
                        command.Parameters.AddWithValue("@absencesday", AbsentTxt.Text);
                        command.Parameters.AddWithValue("@standardpay", IncomeLbl.Text);
                        command.Parameters.AddWithValue("@overtimehours", OTHourLbl.Text);
                        command.Parameters.AddWithValue("@overtimepay", OvertimeIncomeLbl.Text);
                        command.Parameters.AddWithValue("@grossincome", GrossIncomeLbl.Text);
                        command.Parameters.AddWithValue("@sss", SSSLbl1.Text);
                        command.Parameters.AddWithValue("@pagibig", PagibigLbl1.Text);
                        command.Parameters.AddWithValue("@philhealth", PhilHealthLbl1.Text);
                        command.Parameters.AddWithValue("@absencesdeduction", AbsentLbl1.Text);
                        command.Parameters.AddWithValue("@tax", TaxLbl.Text);
                        command.Parameters.AddWithValue("@netincome", NetIncomeLbl.Text);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Payslip generated successfully");
                        TimerCount.Stop();
                        this.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DaysTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void OvertimeTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AbsentTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SSSBox_Click(object sender, EventArgs e)
        {
            if (SSSBox.Checked == true)
            {
                SSS = 100;
                SSSLbl1.Text = $"₱{SSS}";
            }
            else
            {
                SSS = 0;
                SSSLbl1.Text = $"₱{SSS}";

            }
        }

        private void PagIbigBox_Click(object sender, EventArgs e)
        {
            if (PagIbigBox.Checked == true)
            {
                PAGIBIG = 200;
                PagibigLbl1.Text = $"₱{PAGIBIG}";
            }
            else
            {
                PAGIBIG = 0;
                PagibigLbl1.Text = $"₱{PAGIBIG}";


            }
        }

        private void PhilHealthBox_Click(object sender, EventArgs e)
        {
            if (PhilHealthBox.Checked == true)
            {
                PHILHEALTH = 300;
                PhilHealthLbl1.Text = $"₱{PHILHEALTH}";
            }
            else
            {

                PHILHEALTH = 0;
                PhilHealthLbl1.Text = $"₱{PHILHEALTH}";

            }
        }

        private void PayDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void PayslipPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
