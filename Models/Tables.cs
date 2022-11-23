using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Models;

public class EmployeeDetail
{
    [Key]
    public int FormID { get; set; }
    [ForeignKey("EmployeeField")]
    public int FieldID { get; set; }
    public string FieldValue { get; set; } = String.Empty;
};

public class EmployeeField
{
    [Key]
    public int FieldID { get; set; }
    public string FieldTitle { get; set; } = String.Empty;
    public string FieldType { get; set; } = String.Empty;
};

