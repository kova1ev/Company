﻿// <auto-generated />
using System;
using Company.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Company.Data.Migrations
{
    [DbContext(typeof(CompanyDbContext))]
    partial class CompanyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Company.Data.Entity.EmployeeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateOnly>("EmploymentDate")
                        .HasColumnType("date");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Employees", (string)null);

                    b.HasCheckConstraint("CK_Employee_Salary", "Salary > 0");

                    b.HasData(
                        new
                        {
                            Id = new Guid("924cdcdf-5d69-4c10-a25c-567a459238b9"),
                            DateOfBirth = new DateOnly(1990, 9, 9),
                            Department = "Продажи",
                            EmploymentDate = new DateOnly(2020, 5, 20),
                            FullName = "Петров Петр Петрович",
                            Salary = 50000
                        },
                        new
                        {
                            Id = new Guid("da3799fb-b0cf-44a2-9ab8-d25f963a0d54"),
                            DateOfBirth = new DateOnly(1980, 9, 9),
                            Department = "Продажи",
                            EmploymentDate = new DateOnly(2020, 5, 20),
                            FullName = "Иванов Иван Иванович",
                            Salary = 150000
                        },
                        new
                        {
                            Id = new Guid("2e46f77a-495e-4a87-b45a-e8581cc93689"),
                            DateOfBirth = new DateOnly(1999, 12, 31),
                            Department = "Доставка",
                            EmploymentDate = new DateOnly(2022, 1, 1),
                            FullName = "Максимов максим Максимович",
                            Salary = 75000
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
