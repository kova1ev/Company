using Company.Core.Common;
using Company.Core.Domain;

namespace Company.Core.Abstractions;
public interface IEmployeesRepository
{
    Task<IEnumerable<Employee>> Get(SearchParameters searchParameters);
    Task<(bool result, Employee? value)> GetById(Guid id);
    Task<(bool result, Guid value)> Create(Employee employee);
    Task<(bool result, Guid value)> Update(Employee employee);
    Task<(bool result, Guid value)> Delete(Guid id);
}
