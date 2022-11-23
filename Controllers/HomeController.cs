using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmployeeApp.Models;

using EmployeeApp.Interfaces;
//using EmployeeApp.Models;
using EmployeeApp.ModelsVM;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

namespace EmployeeApp.Controllers;

public class HomeController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;

    public HomeController(IEmployeeRepository userRepository)
    {
        _employeeRepository = userRepository;
    }

    public IActionResult EmployeerForm()
    {
        var responce = new EmployeeDetailVM();
        return View(responce);
    }

    public IActionResult SummaryForm(EmployeeDetailVM employeeDetailVM)
    {
        //if (!ModelState.IsValid) return View(employeeDetailVM);

        _employeeRepository.AddEmployee(employeeDetailVM);

        return View(employeeDetailVM);
    }

    //public IActionResult DownloadPDF(EmployeeDetailVM employeeDetailVM)
    //{
    //    return View(employeeDetailVM);
    //}

    public IActionResult ExportToPDF()
    {
        //Initialize the HTML to PDF converter with the Blink rendering engine. 
        Syncfusion.HtmlConverter.HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

        BlinkConverterSettings settings = new BlinkConverterSettings();
        settings.ViewPortSize = new Syncfusion.Drawing.Size(1440, 0);

        //Assign Blink settings to HTML converter.
        htmlConverter.ConverterSettings = settings;

        //Get the current URL.
        string url = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetEncodedUrl(HttpContext.Request);

        url = url.Substring(0, url.LastIndexOf('/')) + "/SummaryForm";

        //Convert URL to PDF.
        Syncfusion.Pdf.PdfDocument document = htmlConverter.Convert(url);
        MemoryStream stream = new MemoryStream();
        document.Save(stream);
        return File(stream.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf, "MVC_view_to_PDF.pdf");
    }

}

