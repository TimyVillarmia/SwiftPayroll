using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwiftPayroll
{
    public partial class EmployeePayrollTAB : UserControl
    {
        string Selected_PayslipDate = "";
        public EmployeePayrollTAB()
        {
            InitializeComponent();
        }


        private string GetEmployeeID()
        {
            LoginUC currentuser = new LoginUC();
            string EmployeeID = "";

            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=Database\Accounts.db"))
                {
                    connection.Open();
                    string query = "SELECT employeeID FROM Accounts WHERE username=@Username";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", currentuser.CurrentUser);


                        using (SQLiteDataReader data = command.ExecuteReader())
                        {
                            data.Read();
                            EmployeeID = $"{data["employeeID"]}";

                        }

                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return EmployeeID;

        }

        private void EmployeePayrollTAB_Load(object sender, EventArgs e)
        {

            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=Database\PaySlip.db"))
                {
                    connection.Open();
                    string query = "SELECT PayDate, GrossIncome, NetIncome FROM EmployeePaySlip WHERE EmployeeID=@employeeID";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@employeeID", GetEmployeeID());

                        using (var adapter = new SQLiteDataAdapter(command))
                        {
                            DataSet dset = new DataSet();
                            adapter.Fill(dset);
                            DataGridView.DataSource = dset.Tables[0];
                        }

                    }

                }


                //adding the Print Payslip button
                DataGridViewButtonColumn PrintBtn = new DataGridViewButtonColumn();
                PrintBtn.Name = "Print";
                PrintBtn.Text = "Print";
                PrintBtn.UseColumnTextForButtonValue = true;
                DataGridView.Columns.Add(PrintBtn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





        }

        //method for creating PDF
        public void GeneratePDFReports()
        {

        
            string Fullname = "-";
            string paydate = Selected_PayslipDate;
            string employeeID = "-";
            string Department = "-";
            string JobTitle = "-";
            string Email = "-";
            string Type = "-";
            string ContactNumber = "-";
            string WorkedDay = "-";
            string AbsencesDay = "-";
            string Standard_HourlyRate = "-";
            string Standard_Hours = "-";
            string Standard_Income= "-";
            string OT_Rate = "₱45";
            string OT_Hours = "-";
            string OT_Income = "-";
            string SSS = "-";
            string PagIbig = "-";
            string PhilHealth = "-";
            string Absences_Rate = "₱200";
            string Absences_Total = "-";
            string Tax = "-";
            string GrossIncome = "-";
            string NetIncome = "-";



            LoginUC currentuser = new LoginUC();


            /*
                For getting data from Accounts.db
             
             */
            using (var connection = new SQLiteConnection(@"Data Source=Database\Accounts.db"))
            {
                connection.Open();
                string query = "SELECT * FROM Accounts WHERE username=@Username";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", currentuser.CurrentUser);

                    // returns an object that can iterate over the entire result set.
                    using (SQLiteDataReader data = command.ExecuteReader())
                    {

                        data.Read();


                        // All the necessary employee's information
                        Fullname = $"Name: {data["firstname"]} {data["lastname"]}";
                        employeeID = $"{data["employeeID"]}";
                        Department = $"{data["department"]}";
                        JobTitle = $"{data["title"]}";
                        Email = $"{data["email"]}";
                        Type = $"{data["type"]}";
                        ContactNumber = $"{data["contactnumber"]}";

                        if(Type == "Full-Time")
                        {
                            Standard_HourlyRate = "₱150";
                            Standard_Hours = "8 hours";

                        }
                        else if(Type == "Part-Time")
                        {
                            Standard_HourlyRate = "₱80";
                            Standard_Hours = "4 hours";
                        }

                    }

                }


            }

            /*
                For getting data from PaySlip.db

            */
            using (var connection = new SQLiteConnection(@"Data Source=Database\PaySlip.db"))
            {
                connection.Open();
                string query = "SELECT * FROM EmployeePaySlip WHERE EmployeeID=@employeeID AND PayDate=@paydate;";
                using (var command = new SQLiteCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@employeeID", employeeID);
                    command.Parameters.AddWithValue("@paydate", paydate);

                    using (SQLiteDataReader data = command.ExecuteReader())
                    {
                        data.Read();

                        WorkedDay = $"{data["WorkedDay"]}";
                        AbsencesDay = $"{data["AbsencesDay"]}";
                        Standard_Income = $"{data["StandardPay"]}";
                        OT_Hours = $"{data["OvertimeHours"]}";
                        OT_Income = $"{data["OvertimePay"]}";
                        GrossIncome = $"{data["GrossIncome"]}";
                        SSS = $"{data["SSS"]}";
                        PagIbig = $"{data["PagIbig"]}";
                        PhilHealth = $"{data["PhilHealth"]}";
                        Absences_Total = $"{data["AbsencesDeduction"]}";
                        Tax = $"{data["Tax"]}";
                        NetIncome = $"{data["NetIncome"]}";

                    }
                }

               
            }



            //change this to your absolute path
            //directory output folder for pdf
            string directory = @"D:\New folder\OOP - Final Project\SwiftPayroll\SwiftPayroll\PayslipReports\";
            //directory for the logo 
            string relativePathToLogo = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "SWIFTPayroll.png");
            //logo
            var logo = iTextSharp.text.Image.GetInstance(relativePathToLogo);

            //creating new pdf with a page size of letter
            var document = new Document(PageSize.LETTER);
            //pdf with a file name Day-Month-Year_employeeID_Payslip.Pdf
            PdfWriter.GetInstance(document, new FileStream(directory + $"/{paydate}_{employeeID}_Payslip.pdf", FileMode.Create));
            //open document to be able to write contents
            document.Open();


            /*

               Table for the Employee's Information

            */

            //creating a new table
            PdfPTable InfoTable = new PdfPTable(2);

            //default cell properties
            InfoTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            InfoTable.DefaultCell.PaddingTop = 5;
            InfoTable.DefaultCell.PaddingBottom = 5;
            InfoTable.WidthPercentage = 100;
            InfoTable.SpacingBefore = 20f;

            //customized cell properties
            PdfPCell cell = new PdfPCell(new Phrase("Employee Information"));
            cell.PaddingBottom = 5;
            cell.Colspan = 2;
            //cell.HorizontalAlignment 0=Left, 1=Centre, 2=Right
            cell.HorizontalAlignment = 1;
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            cell.BackgroundColor = new BaseColor(237, 241, 253);

            //adding the individual cell to the table

            //add customized cell to the table
            InfoTable.AddCell(cell);
            //default cells
            //first row
            InfoTable.AddCell($"Name: {Fullname}");
            InfoTable.AddCell($"Pay Date: {paydate}");
            //second row
            InfoTable.AddCell($"Employee ID: {employeeID}");
            InfoTable.AddCell($"Department: {Department}");
            //third row
            InfoTable.AddCell($"Current Position: {JobTitle}");
            InfoTable.AddCell($"Email: {Email}");
            //fourth row
            InfoTable.AddCell($"Type: {Type}");
            InfoTable.AddCell($"Contact Number: {ContactNumber}");
            //fifth row
            InfoTable.AddCell($"Worked Days: {WorkedDay}");
            InfoTable.AddCell($"Absences: {AbsencesDay}");


            /*

              Table for the Earnings

            */

            PdfPTable EarningTable = new PdfPTable(4);
            //default cell properties
            EarningTable.DefaultCell.PaddingTop = 5;
            EarningTable.DefaultCell.PaddingBottom = 5;
            EarningTable.WidthPercentage = 100;
            EarningTable.SpacingBefore = 20f;
            EarningTable.DefaultCell.HorizontalAlignment = 1;

            //Column Headers
            PdfPCell EarningHeader = new PdfPCell(new Phrase("EARNINGS"));
            PdfPCell Rate_Header = new PdfPCell(new Phrase("RATE"));
            PdfPCell Hours_Header = new PdfPCell(new Phrase("HOURS"));
            PdfPCell Current_Header = new PdfPCell(new Phrase("CURRENT"));

            //Column Headers

            //Earnings Header Properties
            EarningHeader.PaddingBottom = 5;
            //cell.HorizontalAlignment 0=Left, 1=Centre, 2=Right
            EarningHeader.HorizontalAlignment = 1;
            EarningHeader.BackgroundColor = new BaseColor(237, 241, 253);

            //Rate Header Properties
            Rate_Header.PaddingBottom = 5;
            //cell.HorizontalAlignment 0=Left, 1=Centre, 2=Right
            Rate_Header.HorizontalAlignment = 1;
            Rate_Header.BackgroundColor = new BaseColor(237, 241, 253);

            //Hours Header Properties
            Hours_Header.PaddingBottom = 5;
            //cell.HorizontalAlignment 0=Left, 1=Centre, 2=Right
            Hours_Header.HorizontalAlignment = 1;
            Hours_Header.BackgroundColor = new BaseColor(237, 241, 253);

            //Current Header Properties
            Current_Header.PaddingBottom = 5;
            //cell.HorizontalAlignment 0=Left, 1=Centre, 2=Right
            Current_Header.HorizontalAlignment = 1;
            Current_Header.BackgroundColor = new BaseColor(237, 241, 253);

            //adding the individual cell to the table
            //Headers
            EarningTable.AddCell(EarningHeader);
            EarningTable.AddCell(Rate_Header);
            EarningTable.AddCell(Hours_Header);
            EarningTable.AddCell(Current_Header);
            //first row
            EarningTable.AddCell("Standard Pay");
            EarningTable.AddCell($"{Standard_HourlyRate}");
            EarningTable.AddCell($"{Standard_Hours}");
            EarningTable.AddCell($"{Standard_Income}");
            //second row
            EarningTable.AddCell("Overtime");
            EarningTable.AddCell($"{OT_Rate}");
            EarningTable.AddCell($"{OT_Hours}");
            EarningTable.AddCell($"{OT_Income}");
            //third row
            EarningTable.AddCell("");
            EarningTable.AddCell("");
            EarningTable.AddCell("Gross Income: ");
            EarningTable.AddCell($"{GrossIncome}");


            /*

                Table for the Deductions

            */
            PdfPTable DeductionTable = new PdfPTable(3);
            //default cell properties
            DeductionTable.DefaultCell.PaddingTop = 5;
            DeductionTable.DefaultCell.PaddingBottom = 5;
            DeductionTable.WidthPercentage = 100;
            DeductionTable.SpacingBefore = 20f;
            DeductionTable.DefaultCell.HorizontalAlignment = 1;

            //Column Headers
            PdfPCell Deduction_Header = new PdfPCell(new Phrase("DEDUCTIONS"));
            PdfPCell Blank_Header = new PdfPCell(new Phrase("RATE"));
            PdfPCell Current1_Header = new PdfPCell(new Phrase("CURRENT"));
            //Final Row
            PdfPCell NetRow = new PdfPCell(new Phrase("Net Income: "));
            PdfPCell NetIncomeCell = new PdfPCell(new Phrase($"{NetIncome}"));

            //Column Headers

            //Deduction Header Properties
            Deduction_Header.PaddingBottom = 5;
            //cell.HorizontalAlignment 0=Left, 1=Centre, 2=Right
            Deduction_Header.HorizontalAlignment = 1;
            Deduction_Header.BackgroundColor = new BaseColor(237, 241, 253);

            //Blank Header Propertiess
            Blank_Header.PaddingBottom = 5;
            //cell.HorizontalAlignment 0=Left, 1=Centre, 2=Right
            Blank_Header.HorizontalAlignment = 1;
            Blank_Header.BackgroundColor = new BaseColor(237, 241, 253);

            //Current1 Header Properties
            Current1_Header.PaddingBottom = 5;
            //cell.HorizontalAlignment 0=Left, 1=Centre, 2=Right
            Current1_Header.HorizontalAlignment = 1;
            Current1_Header.BackgroundColor = new BaseColor(237, 241, 253);

            //Final Row Properties
            NetRow.PaddingBottom = 5;
            NetRow.Colspan = 2;
            //cell.HorizontalAlignment 0=Left, 1=Centre, 2=Right
            NetRow.HorizontalAlignment = 2;
            NetRow.Border = iTextSharp.text.Rectangle.NO_BORDER;

            //Net Income Cell Properties
            NetIncomeCell.PaddingBottom = 5;
            //cell.HorizontalAlignment 0=Left, 1=Centre, 2=Right
            NetIncomeCell.HorizontalAlignment = 1;
            NetIncomeCell.Border = iTextSharp.text.Rectangle.NO_BORDER;


            //Headers
            DeductionTable.AddCell(Deduction_Header);
            DeductionTable.AddCell(Blank_Header);
            DeductionTable.AddCell(Current1_Header);
            //first row
            DeductionTable.AddCell("SSS");
            DeductionTable.AddCell($"{SSS}");
            DeductionTable.AddCell($"{SSS}");
            //second row
            DeductionTable.AddCell("PAG-IBIG");
            DeductionTable.AddCell($"{PagIbig}");
            DeductionTable.AddCell($"{PagIbig}");
            //third row
            DeductionTable.AddCell("PHILHEALTH");
            DeductionTable.AddCell($"{PhilHealth}");
            DeductionTable.AddCell($"{PhilHealth}");
            //fouth row
            DeductionTable.AddCell("Absences");
            DeductionTable.AddCell($"{Absences_Rate}");
            DeductionTable.AddCell($"{Absences_Total}");
            //fifth row
            DeductionTable.AddCell("TAX");
            DeductionTable.AddCell("10%");
            DeductionTable.AddCell($"{Tax}");
            //final row
            DeductionTable.AddCell(NetRow);
            //Net Income Cell
            DeductionTable.AddCell(NetIncomeCell);


            //adding contents           
            document.Add(logo);
            document.Add(InfoTable);
            document.Add(EarningTable);
            document.Add(DeductionTable);

            document.Close();

        }


        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView.Columns[e.ColumnIndex].Name == "Print")
            {
                Selected_PayslipDate = DataGridView.Rows[e.RowIndex].Cells["PayDate"].Value.ToString();

                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to print the payslip  ", "", MessageBoxButtons.YesNo);

                if(dialogResult == DialogResult.Yes)
                {
                    GeneratePDFReports();
                }
             
            }
        }

       
    }
}
