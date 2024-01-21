using Company.Core.Abstractions;
using Company.Core.Domain;
using Company.Core.Exceptions;
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


    public async Task<IEnumerable<Employee>> Get()
    {
        var entities = await _companyDbContext.Employees.AsNoTracking().ToListAsync();
        var employees = entities.Select(e => EmployeeFromEntity(e)).ToList();

        return employees;
    }

    public async Task<Employee?> GetById(Guid id)
    {
        var entity = await _companyDbContext.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        if (entity == null)
            return null;

        return EmployeeFromEntity(entity);
    }

    public async Task<Guid> Delete(Guid id)
    {
        var result = await _companyDbContext.Employees.AnyAsync(e => e.Id == id);
        if (result == false)
            throw new NotFoundException($"Employee with id '{id}' not found");

        _companyDbContext.Employees.Remove(new EmployeeEntity { Id = id });
        await _companyDbContext.SaveChangesAsync();
        return id;
    }


    public async Task<Guid> Create(Employee employee)
    {
        var entity = EmployeeToEntity(employee);
        await _companyDbContext.Employees.AddAsync(entity);
        await _companyDbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<Guid> Update(Employee employee)
    {
        var result = await _companyDbContext.Employees.AnyAsync(e => e.Id == employee.Id);
        if (result == false)
            throw new NotFoundException($"Employee with id '{employee.Id}' not found");

        var entity = EmployeeToEntity(employee);
        _companyDbContext.Employees.Update(entity);
        await _companyDbContext.SaveChangesAsync();

        return employee.Id;
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

    #endregion

}
