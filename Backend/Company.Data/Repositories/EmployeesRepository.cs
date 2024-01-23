using Company.Core.Abstractions;
using Company.Core.Common;
using Company.Core.Domain;
using Company.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Company.Data.Repositories;

public class EmployeesRepository : IEmployeesRepository
{
    private readonly CompanyDbContext _companyDbContext;

    public EmployeesRepository(CompanyDbContext companyDbContext)
    {
        _companyDbContext = companyDbContext;
    }


    public async Task<IEnumerable<Employee>> Get(RequestParameters requestParameters)
    {
        var query = _companyDbContext.Employees.AsNoTracking();

        query = Filter(query, requestParameters);
        query = Sorting(query, requestParameters);
        var entity = await query.ToListAsync();

        var employees = entity.Select(e => EmployeeFromEntity(e)).ToList();

        return employees;
    }

    public async Task<(bool, Employee?)> GetById(Guid id)
    {
        var entity = await _companyDbContext.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        if (entity == null)
            return (false, null);

        var employee = EmployeeFromEntity(entity);
        return (true, employee);
    }

    public async Task<(bool, Guid)> Delete(Guid id)
    {
        var result = await _companyDbContext.Employees.AnyAsync(e => e.Id == id);
        if (result == false)
            return (result, id);

        _companyDbContext.Employees.Remove(new EmployeeEntity { Id = id });
        result = await _companyDbContext.SaveChangesAsync() > 0;
        return (result, id);
    }

    public async Task<(bool, Guid)> Create(Employee employee)
    {
        var entity = EmployeeToEntity(employee);
        await _companyDbContext.Employees.AddAsync(entity);
        var result = await _companyDbContext.SaveChangesAsync() > 0;
        return (result, employee.Id);
    }

    public async Task<(bool, Guid)> Update(Employee employee)
    {
        var result = await _companyDbContext.Employees.AnyAsync(e => e.Id == employee.Id);
        if (result == false)
            return (result, employee.Id);

        var entity = EmployeeToEntity(employee);
        _companyDbContext.Employees.Update(entity);
        result = await _companyDbContext.SaveChangesAsync() > 0;

        return (result, employee.Id);
    }


    #region private

    private Employee EmployeeFromEntity(EmployeeEntity entity)
    {
        return new Employee(
            entity.Id,
            entity.Department!,
            entity.FullName!,
            entity.Salary,
            entity.DateOfBirth,
            entity.EmploymentDate);
    }

    private EmployeeEntity EmployeeToEntity(Employee employee)
    {
        return new EmployeeEntity()
        {
            Id = employee.Id,
            FullName = employee.FullName,
            Department = employee.Department,
            Salary = employee.Salary,
            EmploymentDate = employee.EmploymentDate,
            DateOfBirth = employee.DateOfBirth
        };
    }


    private static IQueryable<EmployeeEntity> Filter(IQueryable<EmployeeEntity> query, RequestParameters requestParameters)
    {
        //filtering
        if (string.IsNullOrWhiteSpace(requestParameters.FioTerm) == false)
        {
            query = query.Where(e =>
              EF.Functions.Like(e.FullName!, $"%{requestParameters.FioTerm}%"));
        }
        if (string.IsNullOrWhiteSpace(requestParameters.DepartmentTerm) == false)
        {
            query = query.Where(e =>
            EF.Functions.Like(e.Department!, $"%{requestParameters.DepartmentTerm}%"));
        }
        if (requestParameters.SalaryCount != null)
        {
            query = query.Where(e => e.Salary == requestParameters.SalaryCount);
        }
        if (requestParameters.BirthTarget != null)
        {
            query = query.Where(e => e.DateOfBirth == DateOnly.FromDateTime(requestParameters.BirthTarget.Value));
        }
        if (requestParameters.employmentDateTarget != null)
        {
            query = query.Where(e => e.EmploymentDate == DateOnly.FromDateTime(requestParameters.employmentDateTarget.Value));
        }

        return query;
    }

    private static IQueryable<EmployeeEntity> Sorting(IQueryable<EmployeeEntity> query, RequestParameters requestParameters)
    {
        switch (requestParameters.Column)
        {
            case Column.FullName:
                query = requestParameters.Sort == Sort.Asc ?
                    query.OrderBy(e => e.FullName) :
                    query.OrderByDescending(e => e.FullName);
                break;
            case Column.Department:
                query = requestParameters.Sort == Sort.Asc ?
                    query.OrderBy(e => e.Department) :
                    query.OrderByDescending(e => e.Department);
                break;
            case Column.Salary:
                query = requestParameters.Sort == Sort.Asc ?
                    query.OrderBy(e => e.Salary) :
                    query.OrderByDescending(e => e.Salary);
                break;
            case Column.DateOfBirth:
                query = requestParameters.Sort == Sort.Asc ?
                    query.OrderBy(e => e.DateOfBirth) :
                    query.OrderByDescending(e => e.DateOfBirth);
                break;
            case Column.EmploymentDate:
                query = requestParameters.Sort == Sort.Asc ?
                    query.OrderBy(e => e.EmploymentDate) :
                    query.OrderByDescending(e => e.EmploymentDate);
                break;
            default:
                break;
        }

        return query;
    }

    #endregion

}
