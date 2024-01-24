using Company.Data;
using Microsoft.EntityFrameworkCore;

namespace Company.Api.ServicesConfiguration;
public static class ApplyMigration
{
    public async static void ApplyLatestMigration(this WebApplication app)
    {
        var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<CompanyDbContext>();
        if ((await context.Database.GetPendingMigrationsAsync()).Any())
        {
            await context.Database.MigrateAsync();
        }
    }

}
