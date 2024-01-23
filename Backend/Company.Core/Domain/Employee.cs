namespace Company.Core.Domain;

public class Employee
{
    public Employee(Guid id, string department, string fullName, int salary, DateOnly dateOfBirth, DateOnly employmentDate)
    {
        Id = id;
        Department = department;
        FullName = fullName;
        Salary = salary;
        DateOfBirth = dateOfBirth;
        EmploymentDate = employmentDate;
    }

    public Guid Id { get; }
    public string Department { get; }
    public string FullName { get; }
    public int Salary { get; }
    public DateOnly DateOfBirth { get; }
    public DateOnly EmploymentDate { get; }
}
