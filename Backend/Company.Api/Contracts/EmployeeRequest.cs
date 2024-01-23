using Company.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace Company.Api.Contracts;
#nullable disable
public class EmployeeRequest
{
    [Required]
    [MaxLength(EmployeeConstants.DepartmentMaxLength)]
    public string Department { get; set; }

    [Required]
    [MaxLength(EmployeeConstants.FullNameMaxLength)]
    public string FullName { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Salary { get; set; }

    [Required]
    public DateOnly DateOfBirth { get; set; }

    [Required]
    public DateOnly EmploymentDate { get; set; }
}


