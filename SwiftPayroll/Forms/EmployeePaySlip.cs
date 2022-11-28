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
                        command.Parameters.AddWithValue("@EmployeeID", employee.SelectedEmployeID);
                        //return The first column of the first row in the result set.
                        SQLiteDataReader data = command.ExecuteReader();
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

       
        // method for creating PDF
        //private void GeneratePDFReports()
        //{
            
        //    DatabaseClass db = new DatabaseClass();
        //    HRPayrollTAB employee = new HRPayrollTAB();

        //    string query = "SELECT * FROM Accounts WHERE employeeID=@EmployeeID";
        //    db.connect.Open();
        //    SQLiteCommand cmd = new SQLiteCommand(query, db.connect);
        //    cmd.Parameters.AddWithValue("@EmployeeID", employee.SelectedEmployeID);
        //    // returns an object that can iterate over the entire result set.
        //    SQLiteDataReader data = cmd.ExecuteReader();
        //    data.Read();


        //    //change this to your absolute path
        //    //directory output folder for pdf
        //    string directory = @"D:\New folder\OOP - Final Project\SwiftPayroll\SwiftPayroll\PayslipReports\";
        //    //directory for the logo 
        //    string relativePathToLogo = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "SWIFTPayroll.png");

        //    // All the necessary employee's information
        //    //get the date, format Day/Month/Year
        //    string date = $"{PayDate.Value.Date.Day}-{PayDate.Value.Date.Month}-{PayDate.Value.Date.Year}";
        //    string Fullname = $"Name: {data["firstname"]} {data["lastname"]}";
        //    string employeeID = $"{data["employeeID"]}";
        //    string Department = $"{data["department"]}";
        //    string JobTitle = $"{data["title"]}";
        //    string Email = $"{data["email"]}";
        //    string Type = $"{data["type"]}";
        //    string ContactNumber = $"{data["contactnumber"]}";

        //    //logo
        //    var logo = iTextSharp.text.Image.GetInstance(relativePathToLogo);


        //    //creating new pdf with a page size of letter
        //    var document = new Document(PageSize.LETTER);
        //    //pdf with a file name Day-Month-Year_employeeID_Payslip.Pdf
        //    PdfWriter.GetInstance(document, new FileStream(directory + $"/{date}_{employeeID}_Payslip.pdf", FileMode.Create));
        //    //open document to be able to write contents
        //    document.Open();


        //    /*

        //      Table for the Employee's Information

        //   */

        //    //creating a new table
        //    PdfPTable InfoTable = new PdfPTable(2);

        //    //default cell properties
        //    InfoTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //    InfoTable.DefaultCell.PaddingTop = 5;
        //    InfoTable.DefaultCell.PaddingBottom = 5;
        //    InfoTable.WidthPercentage = 100;
        //    InfoTable.SpacingBefore = 20f;

        //    //customized cell properties
        //    PdfPCell cell = new PdfPCell(new Phrase("Employee Information"));
        //    cell.PaddingBottom = 5;
        //    cell.Colspan = 2;
        //    //cell.HorizontalAlignment 0=Left, 1=Centre, 2=Right
        //    cell.HorizontalAlignment = 1;
        //    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //    cell.BackgroundColor = new BaseColor(237, 241, 253);

        //    //adding the individual cell to the table

        //    //add customized cell to the table
        //    InfoTable.AddCell(cell);
        //    //default cells
        //    //first row
        //    InfoTable.AddCell($"Name: {Fullname}");
        //    InfoTable.AddCell($"Pay Date: {date}");
        //    //second row
        //    InfoTable.AddCell($"Employee ID: {employeeID}");
        //    InfoTable.AddCell($"Department: {Department}");
        //    //third row
        //    InfoTable.AddCell($"Current Position: {JobTitle}");
        //    InfoTable.AddCell($"Email: {Email}");
        //    //fourth row
        //    InfoTable.AddCell($"Type: {Type}");
        //    InfoTable.AddCell($"Contact Number: {ContactNumber}");
        //    //fifth row
        //    InfoTable.AddCell($"Worked Days: {DaysTxt.Text}");
        //    InfoTable.AddCell($"Absences: {AbsentTxt.Text}");



        //    /*

        //        Table for the Earnings

        //    */

        //    PdfPTable EarningTable = new PdfPTable(4);
        //    //default cell properties
        //    EarningTable.DefaultCell.PaddingTop = 5;
        //    EarningTable.DefaultCell.PaddingBottom = 5;
        //    EarningTable.WidthPercentage = 100;
        //    EarningTable.SpacingBefore = 20f;
        //    EarningTable.DefaultCell.HorizontalAlignment = 1;

        //    //Column Headers
        //    PdfPCell EarningHeader = new PdfPCell(new Phrase("EARNINGS"));
        //    PdfPCell Rate_Header = new PdfPCell(new Phrase("RATE"));
        //    PdfPCell Hours_Header = new PdfPCell(new Phrase("HOURS"));
        //    PdfPCell Current_Header = new PdfPCell(new Phrase("CURRENT"));

        //    //Column Headers

        //    //Earnings Header Properties
        //    EarningHeader.PaddingBottom = 5;
        //    //cell.HorizontalAlignment 0=Left, 1=Centre, 2=Right
        //    EarningHeader.HorizontalAlignment = 1;
        //    EarningHeader.BackgroundColor = new BaseColor(237, 241, 253);

        //    //Rate Header Properties
        //    Rate_Header.PaddingBottom = 5;
        //    //cell.HorizontalAlignment 0=Left, 1=Centre, 2=Right
        //    Rate_Header.HorizontalAlignment = 1;
        //    Rate_Header.BackgroundColor = new BaseColor(237, 241, 253);

        //    //Hours Header Properties
        //    Hours_Header.PaddingBottom = 5;
        //    //cell.HorizontalAlignment 0=Left, 1=Centre, 2=Right
        //    Hours_Header.HorizontalAlignment = 1;
        //    Hours_Header.BackgroundColor = new BaseColor(237, 241, 253);

        //    //Current Header Properties
        //    Current_Header.PaddingBottom = 5;
        //    //cell.HorizontalAlignment 0=Left, 1=Centre, 2=Right
        //    Current_Header.HorizontalAlignment = 1;
        //    Current_Header.BackgroundColor = new BaseColor(237, 241, 253);

        //    //adding the individual cell to the table
        //    //Headers
        //    EarningTable.AddCell(EarningHeader);
        //    EarningTable.AddCell(Rate_Header);
        //    EarningTable.AddCell(Hours_Header);
        //    EarningTable.AddCell(Current_Header);
        //    //first row
        //    EarningTable.AddCell("Standard Pay");
        //    EarningTable.AddCell($"₱{HourlyRateLbl.Text}");
        //    EarningTable.AddCell($"{HourLbl.Text}");
        //    EarningTable.AddCell($"₱ {IncomeLbl.Text}");
        //    //second row
        //    EarningTable.AddCell("Overtime");
        //    EarningTable.AddCell($"₱{OvertimeRateLbl.Text}");
        //    EarningTable.AddCell($"{OTHourLbl.Text}");
        //    EarningTable.AddCell($"₱ {OvertimeIncomeLbl.Text}");              
        //    //third row
        //    EarningTable.AddCell("");
        //    EarningTable.AddCell("");
        //    EarningTable.AddCell("Gross Income: ");
        //    EarningTable.AddCell($"₱{GrossIncomeLbl.Text}");


        //    /*

        //        Table for the Deductions

        //    */
        //    PdfPTable DeductionTable = new PdfPTable(3);
        //    //default cell properties
        //    DeductionTable.DefaultCell.PaddingTop = 5;
        //    DeductionTable.DefaultCell.PaddingBottom = 5;
        //    DeductionTable.WidthPercentage = 100;
        //    DeductionTable.SpacingBefore = 20f;
        //    DeductionTable.DefaultCell.HorizontalAlignment = 1;

        //    //Column Headers
        //    PdfPCell Deduction_Header = new PdfPCell(new Phrase("DEDUCTIONS"));
        //    PdfPCell Blank_Header = new PdfPCell(new Phrase("RATE"));
        //    PdfPCell Current1_Header = new PdfPCell(new Phrase("CURRENT"));
        //    //Final Row
        //    PdfPCell NetRow = new PdfPCell(new Phrase("Net Income: "));
        //    PdfPCell NetIncome = new PdfPCell(new Phrase($"{NetIncomeLbl.Text}"));

        //    //Column Headers

        //    //Deduction Header Properties
        //    Deduction_Header.PaddingBottom = 5;
        //    //cell.HorizontalAlignment 0=Left, 1=Centre, 2=Right
        //    Deduction_Header.HorizontalAlignment = 1;
        //    Deduction_Header.BackgroundColor = new BaseColor(237, 241, 253);

        //    //Blank Header Propertiess
        //    Blank_Header.PaddingBottom = 5;
        //    //cell.HorizontalAlignment 0=Left, 1=Centre, 2=Right
        //    Blank_Header.HorizontalAlignment = 1;
        //    Blank_Header.BackgroundColor = new BaseColor(237, 241, 253);

        //    //Current1 Header Properties
        //    Current1_Header.PaddingBottom = 5;
        //    //cell.HorizontalAlignment 0=Left, 1=Centre, 2=Right
        //    Current1_Header.HorizontalAlignment = 1;
        //    Current1_Header.BackgroundColor = new BaseColor(237, 241, 253);

        //    //Final Row Properties
        //    NetRow.PaddingBottom = 5;
        //    NetRow.Colspan = 2;
        //    //cell.HorizontalAlignment 0=Left, 1=Centre, 2=Right
        //    NetRow.HorizontalAlignment = 2;
        //    NetRow.Border = iTextSharp.text.Rectangle.NO_BORDER;

        //    //Net Income Cell Properties
        //    NetIncome.PaddingBottom = 5;
        //    //cell.HorizontalAlignment 0=Left, 1=Centre, 2=Right
        //    NetIncome.HorizontalAlignment = 1;
        //    NetIncome.Border = iTextSharp.text.Rectangle.NO_BORDER;


        //    //Headers
        //    DeductionTable.AddCell(Deduction_Header);
        //    DeductionTable.AddCell(Blank_Header);
        //    DeductionTable.AddCell(Current1_Header);
        //    //first row
        //    DeductionTable.AddCell("SSS");
        //    DeductionTable.AddCell($"₱{SSSLbl1.Text}");
        //    DeductionTable.AddCell($"₱{SSSLbl1.Text}");
        //    //second row
        //    DeductionTable.AddCell("PAG-IBIG");
        //    DeductionTable.AddCell($"₱{PagibigLbl1.Text}");
        //    DeductionTable.AddCell($"₱{PagibigLbl1.Text}");
        //    //third row
        //    DeductionTable.AddCell("PHILHEALTH");
        //    DeductionTable.AddCell($"₱{PhilHealthLbl1.Text}");
        //    DeductionTable.AddCell($"₱{PhilHealthLbl1.Text}");
        //    //fouth row
        //    DeductionTable.AddCell("Absences");
        //    DeductionTable.AddCell($"₱{ABSENT_RATE}");
        //    DeductionTable.AddCell($"₱{ABSENT_RATE * NumofAbsent}");
        //    //fifth row
        //    DeductionTable.AddCell("TAX");
        //    DeductionTable.AddCell("10%");
        //    DeductionTable.AddCell($"{TaxLbl.Text}");
        //    //final row
        //    DeductionTable.AddCell(NetRow);
        //    //Net Income Cell
        //    DeductionTable.AddCell(NetIncome);
            

        //    //adding contents           
        //    document.Add(logo);
        //    document.Add(InfoTable);
        //    document.Add(EarningTable);
        //    document.Add(DeductionTable);



         
        //    document.Close();
        //}


        private void GeneratePayBtn_Click(object sender, EventArgs e)
        {
           
            //GeneratePDFReports();
           

            HRPayrollTAB employee = new HRPayrollTAB();
            string date = $"{PayDate.Value.Date.Day}-{PayDate.Value.Date.Month}-{PayDate.Value.Date.Year}";

        

            if (DaysTxt.Text == string.Empty)
            {
                MessageBox.Show("Make sure you correctly fill up the form");

            }
            else
            {
                TimerCount.Stop();

                try
                {
                    using (var connection = new SQLiteConnection(@"Data Source=Database\Accounts.db"))
                    {
                        connection.Open();
                        string query = "INSERT INTO EmployeePaySlip(EmployeeID,PayDate,WorkedDay, AbsencesDay, StandardPay, OvertimeHours, OvertimePay, GrossIncome, SSS, PagIbig, PhilHealth, AbsencesDeduction, Tax, NetIncome) VALUES(@employeeid, @date, @workedday, @absencesday, @standardpay, @overtimehours, @overtimepay, @grossincome, @sss, @pagibig, @philhealth, @absencesdeduction, @tax, @netincome);";

                        using (var command = new SQLiteCommand(query, connection))
                        {
                            //Set the values for each parameters
                            //cmd.Parameters.AddWithValue("ParameterName", ActualValue) base on VALUES(@Username,@Password,@Email)
                            command.Parameters.AddWithValue("@employeeid", employee.SelectedEmployeID);
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
                            //Accessing the "Close" property of SQLiteConnection to "Close" the connection

                            MessageBox.Show("Payslip generated successfully");
                            this.Close();
                        }
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to generate payslip, please try again " +ex.Message);
                }
       


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
    }
}
