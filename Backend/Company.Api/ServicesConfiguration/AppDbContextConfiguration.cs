using Company.Data;
using Microsoft.EntityFrameworkCore;

namespace Company.Api.ServicesConfiguration;

public static class AppDbContextConfiguration
{
    public static void AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CompanyDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("sqlserver"),
                a => a.UseDateOnlyTimeOnly());
        });
    }
}
