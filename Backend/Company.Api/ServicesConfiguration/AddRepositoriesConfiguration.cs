using Company.Core.Abstractions;
using Company.Data.Repositories;

namespace Company.Api.ServicesConfiguration;

public static class AddRepositoriesConfiguration
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IEmployeesRepository, EmployeesRepository>();
    }
}
