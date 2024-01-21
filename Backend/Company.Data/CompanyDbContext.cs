using Company.Core.Constants;
using Company.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Company.Data;
public class CompanyDbContext : DbContext
{
    public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<EmployeeEntity> Employees => Set<EmployeeEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeEntity>()
            .ToTable("Employees")
            .HasKey(e => e.Id);
        modelBuilder.Entity<EmployeeEntity>()
            .Property(e => e.FullName)
            .HasMaxLength(EmployeeConstants.FullNameMaxLength)
            .IsRequired();
        modelBuilder.Entity<EmployeeEntity>()
            .Property(e => e.Department)
            .HasMaxLength(EmployeeConstants.DepartmentMaxLength)
            .IsRequired();
        modelBuilder.Entity<EmployeeEntity>()
            .HasCheckConstraint("CK_Employee_Salary", "Salary > 0");

        base.OnModelCreating(modelBuilder);
    }
}
