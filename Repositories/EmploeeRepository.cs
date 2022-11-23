using System;
using System.Threading.Tasks;
using static System.Console;
using System.Linq;
using System.Globalization;

using EmployeeApp.Interfaces;
using EmployeeApp.Models;
using EmployeeApp.ModelsVM;
using EmployeeApp.Data;

namespace EmployeeApp.Repositories;

public class EmployeeRepository : IEmployeeRepository
{

    private readonly AppDBContext _context;

    public EmployeeRepository(AppDBContext contex) //(AppDBContext context)
    {
        _context = contex;
    }

    public bool AddEmployee(EmployeeDetailVM edvm)
    {
        AddField(1,  edvm.FirstName);
        AddField(2,  edvm.LastName);
        AddField(3,  edvm.FullAddress);
        AddField(4,  edvm.MailingAddress);
        AddField(5,  edvm.PhoneNo);
        AddField(6,  edvm.CitizenshipStatus);
        AddField(7,  edvm.EmploymentStartDate);
        AddField(8,  edvm.EmploymentType);
        AddField(9,  edvm.PositionTitle);
        AddField(10, edvm.EmergencyContactPersonName);
        AddField(11, edvm.EmergencyContactPersonRelationship);
        AddField(12, edvm.EmergencyContactPersonPhoneNo);
        AddField(13, edvm.EmployeesSignature);

        _context.SaveChanges();
        return true;
    }

    //public bool CreatePDFReport(EmployeeDetailVM edvm)
    //{
    //    return true;
    //}

    private void AddField(int FieldID, string value)
    {
        EmployeeDetail ed = new EmployeeDetail();
        ed.FieldID = FieldID;
        ed.FieldValue = value;
        _context.Employee_Details.Add(ed);
    }
}

    

