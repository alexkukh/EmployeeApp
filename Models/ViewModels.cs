using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EmployeeApp.Data;
using EmployeeApp.Models;

namespace EmployeeApp.ModelsVM;

public class EmployeeDetailVM
{
    //  [Display(Name = "Email Address")]
    //  [Required(ErrorMessage ="Email Address is required")]
    //public string UserEmail { get; set; } = String.Empty;
    //  [Required]
    //  [DataType(DataType.Password)]
    //public string Password { get; set; } = String.Empty;

    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string FullAddress { get; set; } = String.Empty;
    public string MailingAddress { get; set; } = String.Empty;
    public string PhoneNo { get; set; } = String.Empty;
    public string CitizenshipStatus { get; set; } = String.Empty;
    public string EmploymentStartDate { get; set; } = String.Empty;
    public string EmploymentType { get; set; } = String.Empty;
    public string PositionTitle { get; set; } = String.Empty;
    public string EmergencyContactPersonName { get; set; } = String.Empty;
    public string EmergencyContactPersonRelationship { get; set; } = String.Empty;
    public string EmergencyContactPersonPhoneNo { get; set; } = String.Empty;
    public string EmployeesSignature { get; set; } = String.Empty;
}

