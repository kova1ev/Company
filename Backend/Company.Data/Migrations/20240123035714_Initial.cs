using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    EmploymentDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.CheckConstraint("CK_Employee_Salary", "Salary > 0");
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "Department", "EmploymentDate", "FullName", "Salary" },
                values: new object[] { new Guid("2e46f77a-495e-4a87-b45a-e8581cc93689"), new DateOnly(1999, 12, 31), "Доставка", new DateOnly(2022, 1, 1), "Максимов максим Максимович", 75000 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "Department", "EmploymentDate", "FullName", "Salary" },
                values: new object[] { new Guid("924cdcdf-5d69-4c10-a25c-567a459238b9"), new DateOnly(1990, 9, 9), "Продажи", new DateOnly(2020, 5, 20), "Петров Петр Петрович", 50000 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "Department", "EmploymentDate", "FullName", "Salary" },
                values: new object[] { new Guid("da3799fb-b0cf-44a2-9ab8-d25f963a0d54"), new DateOnly(1980, 9, 9), "Продажи", new DateOnly(2020, 5, 20), "Иванов Иван Иванович", 150000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
