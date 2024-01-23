namespace Company.Core.Common;
public class RequestParameters
{
    private string _fioTerm;
    private string _departmentTerm;
    public string? FioTerm
    {
        get { return _fioTerm?.Trim(); }
        set { _fioTerm = value == null ? string.Empty : value; }

    }
    public string? DepartmentTerm
    {
        get { return _departmentTerm?.Trim(); }
        set { _departmentTerm = value == null ? string.Empty : value; }

    }
    public int? SalaryCount { get; set; }
    public DateTime? BirthTarget { get; set; }
    public DateTime? employmentDateTarget { get; set; }

    public Column? Column { get; set; }
    public Sort? Sort { get; set; }
}
