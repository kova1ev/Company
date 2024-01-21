using Company.Core.Domain;

namespace Company.Core.Abstractions;
public interface IEmployeesRepository
{
    Task<Guid> Create(Employee employee);
    Task<Guid> Delete(Guid id);
    Task<IEnumerable<Employee>> Get();
    Task<Employee?> GetById(Guid id);
    Task<Guid> Update(Employee employee);
}
