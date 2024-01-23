use employeeDB;
go

Select * from Employees;

select * from Employees
where Salary > 10000;

select * from Employees 
where  datediff(year,  DateOfBirth,getdate())  > 70

Update Employees
set salary = 15000
where salary < 15000