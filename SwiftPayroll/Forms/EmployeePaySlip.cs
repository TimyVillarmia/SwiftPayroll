using System;
using System.IO;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SQLite;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            DatabaseClass db = new DatabaseClass();

            try
            {
                

                string query = "SELECT * FROM Accounts WHERE employeeID=@EmployeeID";
                db.connect.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, db.connect);
                cmd.Parameters.AddWithValue("@EmployeeID", employee.SelectedEmployeID);
                //return The first column of the first row in the result set.
                SQLiteDataReader data = cmd.ExecuteReader();
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
            catch(Exception ex)
            {
                MessageBox.Show("Unexpected error occured!");
            }
            finally
            {
                db.connect.Close();
                db.connect.Dispose();
            }

        }

        private void DaysTxt_TextChanged(object sender, EventArgs e)
        {
          
            if (JobType == "Full-Time")
            {
                if(DaysTxt.Text != string.Empty)
                {
                    FullTime_MonthlyIncome = Convert.ToInt32(DaysTxt.Text) * FullTime_DailyIncome;
                    IncomeLbl.Text = String.Format("{0:n}", FullTime_MonthlyIncome);
                }
                else
                {
                    FullTime_MonthlyIncome = 0 * FullTime_DailyIncome;
                    IncomeLbl.Text = String.Format("{0:n}", FullTime_MonthlyIncome);
                }
                


            }
            else
            {
                if (DaysTxt.Text != string.Empty)
                {
                    PartTime_MonthlyIncome = Convert.ToInt32(DaysTxt.Text) * PartTime_DailyIncome;
                    IncomeLbl.Text = String.Format("{0:n}", PartTime_MonthlyIncome);
                }
                else
                {
                    PartTime_MonthlyIncome = 0 * PartTime_DailyIncome;
                    IncomeLbl.Text = String.Format("{0:n}", PartTime_MonthlyIncome);
                }
                    
            }
           
        }

        private void OvertimeTxt_TextChanged(object sender, EventArgs e)
        {
            if (OvertimeTxt.Text != string.Empty)
            {
                OvertimeRateLbl.Text = $"₱{OTRATE}";
                OTHourLbl.Text = OvertimeTxt.Text;
                TotalOvertime = Convert.ToInt32(OvertimeTxt.Text) * OTRATE;

                OvertimeIncomeLbl.Text = String.Format("{0:n}", TotalOvertime);
            }
            else
            {
                OvertimeRateLbl.Text = $"₱{OTRATE}";
                OTHourLbl.Text = OvertimeTxt.Text;
                TotalOvertime = 0 * OTRATE;

                OvertimeIncomeLbl.Text = String.Format("{0:n}", TotalOvertime);
            } 

         
        }

        private void AbsentTxt_TextChanged(object sender, EventArgs e)
        {
            if (AbsentTxt.Text != string.Empty)
            {
                NumofAbsent = Convert.ToInt32(AbsentTxt.Text);
                AbsentLbl1.Text = String.Format("{0:n}", ABSENT_RATE * NumofAbsent);
                AbsentLbl.Text = $"₱{ABSENT_RATE}";
            }
            else
            {
              
                AbsentLbl1.Text = String.Format("{0:n}", ABSENT_RATE * 0);
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
            GrossIncomeLbl.Text = String.Format("{0:n}", GrossIncome);
            TaxLbl.Text = String.Format("{0:n}", TaxTotal);
            DeductionsLBL.Text = String.Format("{0:n}", TotalDeduction);
            NetIncomeLbl.Text = String.Format("{0:n}", NetIncome);

        }

        public string GenerateFileName()
        {

            string month, year;
        
            month = DateTime.Now.Month.ToString();
            year = DateTime.Now.Year.ToString();



            return  year + "-" + month;
        }


        private void GeneratePayBtn_Click(object sender, EventArgs e)
        {
            TimerCount.Stop();
            Document doc = new Document();
            //string file_name = $"{GenerateFileName()}_PayslipReport.pdf";
            PdfWriter.GetInstance(doc, new FileStream("test.pdf", FileMode.Create));
            doc.Open();
            Paragraph pl = new Paragraph("Hello");
            doc.Add(pl);
            doc.Close();

          

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
    }
}
