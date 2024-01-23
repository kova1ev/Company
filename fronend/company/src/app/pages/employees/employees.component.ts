import {Component, OnInit} from '@angular/core';
import {Employee} from 'src/app/models/employee';
import {EmployeeService} from 'src/app/services/employee.service';
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {UpdateComponent} from "../../employee/update/update.component";
import {DeleteComponent} from "../../employee/delete/delete.component";
import {SearchParams} from "../../models/SearchParams";
import {Column, Sort, SortParams} from "../../models/sortParams";

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})


export class EmployeesComponent implements OnInit {
  employees: Employee[] = [];

  _sortByFullName = false;
  _sortByDepartment = false;
  _sortBySalary = false;
  _sortByBirth = false;
  _sortByEmploymentDate = false;


  search: SearchParams = new SearchParams();

  constructor(private employeeService: EmployeeService,
              private modalService: NgbModal) {
  }

  ngOnInit() {
    this.pullEmployees();
    this.employeeService.refreshData.subscribe(a => this.pullEmployees());
  }

  searchEmployee() {

  }

  pullEmployees() {
    this.employeeService.getEmployees(this.search).subscribe(data => {
      this.employees = data;
    });
  }

  openCreateEmployee() {
    const modalRef = this.modalService.open(UpdateComponent);
    modalRef.componentInstance.Title = "Создание Сотрудника";
    modalRef.componentInstance.employee = null;
  }

  openUpdateEmployee(employee: Employee) {
    const modalRef = this.modalService.open(UpdateComponent);
    modalRef.componentInstance.Title = "Редактирование Сотрудника";
    modalRef.componentInstance.employee = employee;
  }

  openDeleteEmployee(employee: Employee) {
    const modalRef = this.modalService.open(DeleteComponent);
    modalRef.componentInstance.employee = employee;

  }

  sortByDepartment() {
    let sort: SortParams;
    if (this._sortByDepartment) {
      sort = new SortParams(Column.Department, Sort.Asc);
      this.employeeService.getEmployees(this.search, sort).subscribe(data => {
        this.employees = data;
      });
      this._sortByDepartment = false;
    } else {
      sort = new SortParams(Column.Department, Sort.Desc);
      this.employeeService.getEmployees(this.search, sort).subscribe(data => {
        this.employees = data;
        this._sortByDepartment = true;
      });
    }
  }

  sortByFullName() {
    let sort: SortParams;
    if (this._sortByFullName) {
      sort = new SortParams(Column.FullName, Sort.Asc);
      this.employeeService.getEmployees(this.search, sort).subscribe(data => {
        this.employees = data;
      });
      this._sortByFullName = false;
    } else {
      sort = new SortParams(Column.FullName, Sort.Desc);
      this.employeeService.getEmployees(this.search, sort).subscribe(data => {
        this.employees = data;
        this._sortByFullName = true;
      });
    }

  }

  sortBySalary() {
    let sort: SortParams;
    if (this._sortBySalary) {
      sort = new SortParams(Column.Salary, Sort.Asc);
      this.employeeService.getEmployees(this.search, sort).subscribe(data => {
        this.employees = data;
      });
      this._sortBySalary = false;
    } else {
      sort = new SortParams(Column.Salary, Sort.Desc);
      this.employeeService.getEmployees(this.search, sort).subscribe(data => {
        this.employees = data;
        this._sortBySalary = true;
      });
    }
  }

  sortByBirth() {
    let sort: SortParams;
    if (this._sortByBirth) {
      sort = new SortParams(Column.DateOfBirth, Sort.Asc);
      this.employeeService.getEmployees(this.search, sort).subscribe(data => {
        this.employees = data;
      });
      this._sortByBirth = false;
    } else {
      sort = new SortParams(Column.DateOfBirth, Sort.Desc);
      this.employeeService.getEmployees(this.search, sort).subscribe(data => {
        this.employees = data;
        this._sortByBirth = true;
      });
    }
  }

  sortByEmploymentDate() {
    let sort: SortParams;
    if (this._sortByEmploymentDate) {
      sort = new SortParams(Column.EmploymentDate, Sort.Asc);
      this.employeeService.getEmployees(this.search, sort).subscribe(data => {
        this.employees = data;
      });
      this._sortByEmploymentDate = false;
    } else {
      sort = new SortParams(Column.EmploymentDate, Sort.Desc);
      this.employeeService.getEmployees(this.search, sort).subscribe(data => {
        this.employees = data;
        this._sortByEmploymentDate = true;
      });
    }
  }
}
