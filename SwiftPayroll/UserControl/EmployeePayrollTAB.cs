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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Org.BouncyCastle.Crypto.Agreement.Srp;

namespace SwiftPayroll
{
    public partial class EmployeePayrollTAB : UserControl
    {
        string Selected_PayslipDate = "";
        public LoginUC currentuser = new LoginUC();
        public EmployeeInfo employee;



        public EmployeePayrollTAB()
        {
            InitializeComponent();
        }


      

        private void EmployeePayrollTAB_Load(object sender, EventArgs e)
        {


            try
            {
                employee = new EmployeeInfo();
                employee.GetInformation(currentuser.CurrentUser);

                using (var connection = new SQLiteConnection(@"Data Source=Database\PaySlip.db"))
                {
                    connection.Open();
                    string query = "SELECT PayDate, GrossIncome, NetIncome FROM EmployeePaySlip WHERE EmployeeID=@employeeID";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@employeeID", employee.EmployeeID);

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

        
            string paydate = Selected_PayslipDate; 
            string Standard_HourlyRate = "-";
            string Standard_Hours = "-";
            string OT_Rate = "₱45";
            string Absences_Rate = "₱200";



            employee = new EmployeeInfo();



            try
            {
                // For getting data from Accounts.db
                employee.GetInformation(currentuser.CurrentUser);
                // For getting data from PaySlip.db
                employee.GetPaySlip(paydate);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            if (employee.Type == "Full-Time")
            {
                Standard_HourlyRate = "₱150";
                Standard_Hours = "8 hours";

            }
            else if (employee.Type == "Part-Time")
            {
                Standard_HourlyRate = "₱80";
                Standard_Hours = "4 hours";
            }


            // create an instance of SaveFileDialog class
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //Title property is used to set or get the title of the open file dialog.
            saveFileDialog1.Title = "Save PDF";
            // Filter property represents the filter on an open file dialog that is used to filter the type of files to be loaded during the browse option in an open file dialog. 
            saveFileDialog1.Filter = "PDF document (*.pdf)|*.pdf";
            //FileName property represents the file name selected in the open file dialog.
            saveFileDialog1.FileName = $"{paydate}_{employee.EmployeeID}_Payslip";

            //ShowDialog method displays the SaveFileDialog.
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Saves the PDF via a FileStream 
                using (FileStream stream = new FileStream(saveFileDialog1.FileName + ".pdf", FileMode.Create))
                {
                    // Create an instance of the document class which represents the PDF document itself with a page size of letter.  
                    Document document = new Document(PageSize.LETTER);
                    // Create an instance to the PDF file by creating an instance of the PDF   
                    // using the document and the filestrem in the constructor. 
                    PdfWriter.GetInstance(document, stream);
                    //open document to be able to write contents
                    document.Open();

                    //directory for the logo 
                    string relativePathToLogo = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "SWIFTPayroll.png");
                    //logo
                    var logo = iTextSharp.text.Image.GetInstance(relativePathToLogo);


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
                    InfoTable.AddCell($"Name: {employee.Fullname}");
                    InfoTable.AddCell($"Pay Date: {Selected_PayslipDate}");
                    //second row
                    InfoTable.AddCell($"Employee ID: {employee.EmployeeID}");
                    InfoTable.AddCell($"Department: {employee.Department}");
                    //third row
                    InfoTable.AddCell($"Current Position: {employee.Title}");
                    InfoTable.AddCell($"Email: {employee.Email}");
                    //fourth row
                    InfoTable.AddCell($"Type: {employee.Type}");
                    InfoTable.AddCell($"Contact Number: {employee.ContactNumber}");
                    //fifth row
                    InfoTable.AddCell($"Worked Days: {employee.WorkedDay}");
                    InfoTable.AddCell($"Absences: {employee.AbsencesDay}");


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
                    EarningTable.AddCell($"{employee.StandardPay}");
                    //second row
                    EarningTable.AddCell("Overtime");
                    EarningTable.AddCell($"{OT_Rate}");
                    EarningTable.AddCell($"{employee.OvertimeHours}");
                    EarningTable.AddCell($"{employee.OvertimePay}");
                    //third row
                    EarningTable.AddCell("");
                    EarningTable.AddCell("");
                    EarningTable.AddCell("Gross Income: ");
                    EarningTable.AddCell($"{employee.GrossIncome}");


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
                    PdfPCell NetIncomeCell = new PdfPCell(new Phrase($"{employee.NetIncome}"));

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
                    DeductionTable.AddCell($"{employee.SSS}");
                    DeductionTable.AddCell($"{employee.SSS}");
                    //second row
                    DeductionTable.AddCell("PAG-IBIG");
                    DeductionTable.AddCell($"{employee.PagIbig}");
                    DeductionTable.AddCell($"{employee.PagIbig}");
                    //third row
                    DeductionTable.AddCell("PHILHEALTH");
                    DeductionTable.AddCell($"{employee.PhilHealth}");
                    DeductionTable.AddCell($"{employee.PhilHealth}");
                    //fouth row
                    DeductionTable.AddCell("Absences");
                    DeductionTable.AddCell($"{Absences_Rate}");
                    DeductionTable.AddCell($"{employee.AbsencesDeduction}");
                    //fifth row
                    DeductionTable.AddCell("TAX");
                    DeductionTable.AddCell("10%");
                    DeductionTable.AddCell($"{employee.Tax}");
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


            }



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

        private void guna2Panel8_Paint(object sender, PaintEventArgs e)
        {

        }

      
    }
}
