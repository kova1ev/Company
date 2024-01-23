namespace Company.Data.Entity;
public class EmployeeEntity
{
    public Guid Id { get; set; }
    public string? Department { get; set; }
    public string? FullName { get; set; }
    public int Salary { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public DateOnly EmploymentDate { get; set; }
}
