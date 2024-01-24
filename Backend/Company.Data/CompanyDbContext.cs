using Company.Core.Constants;
using Company.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Company.Data;
public class CompanyDbContext : DbContext
{
    public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
    {
    }

    public DbSet<EmployeeEntity> Employees => Set<EmployeeEntity>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

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

        modelBuilder.Entity<EmployeeEntity>().HasData(new EmployeeEntity
        {
            Id = Guid.NewGuid(),
            FullName = "Петров Петр Петрович",
            Salary = 50000,
            Department = "Продажи",
            DateOfBirth = new DateOnly(1990, 9, 9),
            EmploymentDate = new DateOnly(2020, 5, 20)
        },
        new EmployeeEntity
        {
            Id = Guid.NewGuid(),
            FullName = "Иванов Иван Иванович",
            Salary = 150000,
            Department = "Продажи",
            DateOfBirth = new DateOnly(1980, 9, 9),
            EmploymentDate = new DateOnly(2020, 5, 20)
        },
        new EmployeeEntity
        {
            Id = Guid.NewGuid(),
            FullName = "Максимов максим Максимович",
            Salary = 75000,
            Department = "Доставка",
            DateOfBirth = new DateOnly(1999, 12, 31),
            EmploymentDate = new DateOnly(2022, 1, 1)
        });

        base.OnModelCreating(modelBuilder);
    }
}
