using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmployeeApp.Models;

using EmployeeApp.Interfaces;
using EmployeeApp.ModelsVM;

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using Syncfusion.Pdf.Grid;
using System.Data;

namespace EmployeeApp.Controllers;

public class HomeController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;

    public HomeController(IEmployeeRepository userRepository)
    {
        _employeeRepository = userRepository;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult EmployeerForm()
    {
        var responce = new EmployeeDetailVM();
        return View(responce);
    }

    public IActionResult SummaryForm(EmployeeDetailVM employeeDetailVM)
    {
        _employeeRepository.AddEmployee(employeeDetailVM);

        return View(employeeDetailVM);
    }
    
    public IActionResult ExportToPDF(EmployeeDetailVM empd)
    {
        //Generate a new PDF document.
        PdfDocument doc = new PdfDocument();
        //Add a page.
        PdfPage page = doc.Pages.Add();
        //Create a PdfGrid.
        //Create PDF graphics for the page.
        PdfGraphics graphics = page.Graphics;

      
        PdfGrid pdfGrid = new PdfGrid();
        //Add values to list
        List<object> data = new List<object>();
        Object row1 = new { FORM = "First Name:", NEW_EMPLOYEE_DETAILS = empd.FirstName };
        Object row2 = new { FORM = "Last Name:", NEW_EMPLOYEE_DETAILS = empd.LastName };
        Object row3 = new { FORM = "Full Address:", NEW_EMPLOYEE_DETAILS = empd.FullAddress };
        Object row4 = new { FORM = "Mailing Address:", NEW_EMPLOYEE_DETAILS = empd.MailingAddress };
        Object row5 = new { FORM = "Phone No:", NEW_EMPLOYEE_DETAILS = empd.PhoneNo };
        Object row6 = new { FORM = "Citizenship Status:", NEW_EMPLOYEE_DETAILS = empd.CitizenshipStatus };
        Object row7 = new { FORM = "Employment Start Dates:", NEW_EMPLOYEE_DETAILS = empd.EmploymentStartDate };
        Object row8 = new { FORM = "Employment Type:", NEW_EMPLOYEE_DETAILS = empd.EmploymentType };
        Object row9  = new { FORM = "Position Title:", NEW_EMPLOYEE_DETAILS = empd.PositionTitle };
        Object row10 = new { FORM = "Emergency Contac tPerson Name:", NEW_EMPLOYEE_DETAILS = empd.EmergencyContactPersonName };
        Object row11 = new { FORM = "Emergency Contact Person Relationship:", NEW_EMPLOYEE_DETAILS = empd.EmergencyContactPersonRelationship };
        Object row12 = new { FORM = "Emergency Contact Person Phone No:", NEW_EMPLOYEE_DETAILS = empd.EmergencyContactPersonPhoneNo };
        Object row13 = new { FORM = "Employees Signature:", NEW_EMPLOYEE_DETAILS = empd.EmployeesSignature };

        data.Add(row1);
        data.Add(row2);
        data.Add(row3);
        data.Add(row4);
        data.Add(row5);
        data.Add(row6);
        data.Add(row7);
        data.Add(row8);
        data.Add(row9);
        data.Add(row10);
        data.Add(row11);
        data.Add(row12);
        data.Add(row13);

        //Add list to IEnumerable
        IEnumerable<object> dataTable = data;
        //Assign data source.
        pdfGrid.DataSource = dataTable;

        //Initialize PdfGridCellStyle and set border color.
        PdfGridCellStyle cellStyle = new PdfGridCellStyle();
        cellStyle.Borders.All = PdfPens.LightGray;
        cellStyle.Borders.Right = PdfPens.White;
        cellStyle.Borders.Left  = PdfPens.White;
        //cellStyle.Borders.Bottom = new PdfPen(new PdfColor(50, 50, 50), 1.0f);
        cellStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12f);
        //cellStyle.CellPadding = new PdfPaddings()
        //cellStyle.TextBrush = new PdfSolidBrush(new PdfColor(131, 130, 136));

        //Initialize PdfGridCellStyle and set header style.
        PdfGridCellStyle headerStyle = new PdfGridCellStyle();
        headerStyle.Borders.All = new PdfPen(new PdfColor(126, 151, 173));
        headerStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
        headerStyle.TextBrush = PdfBrushes.White;
        headerStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14f, PdfFontStyle.Regular);

        PdfGridRow header = pdfGrid.Headers[0];
        for (int i = 0; i < header.Cells.Count; i++)
        {
            if (i == 0 || i == 1)
                header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
            else
                header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
        }
        header.ApplyStyle(headerStyle);
        
        foreach (PdfGridRow row in pdfGrid.Rows)
        {
            row.ApplyStyle(cellStyle);
            for (int i = 0; i < row.Cells.Count; i++)
            {
                //Create and customize the string formats
                PdfGridCell cell = row.Cells[i];
                if (i == 1)
                    cell.StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
                else if (i == 0)
                    cell.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
                else
                    cell.StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);

                if (i > 2)
                {
                    float val = float.MinValue;
                    float.TryParse(cell.Value.ToString(), out val);
                    cell.Value = '$' + val.ToString("0.00");
                }
            }
        }

        pdfGrid.Columns[0].Width = 150;
        //pdfGrid.Columns[1].Width = 200;

        //Draw grid to the page of PDF document.
        pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, 10));
        //Write the PDF document to stream
        MemoryStream stream = new MemoryStream();
        doc.Save(stream);
        //If the position is not set to '0' then the PDF will be empty.
        stream.Position = 0;
        //Close the document.
        doc.Close(true);
        //Defining the ContentType for pdf file.
        string contentType = "application/pdf";
        //Define the file name.
        string fileName = "Output_Form.pdf";
        //Creates a FileContentResult object by using the file contents, content type, and file name.
        return File(stream, contentType, fileName);
    }
 
}
