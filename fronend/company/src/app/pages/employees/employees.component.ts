import {Component, OnInit, TemplateRef} from '@angular/core';
import {Employee} from 'src/app/models/employee';
import {EmployeeService} from 'src/app/services/employee.service';
import {inject} from "@angular/core/testing";
import {ModalDismissReasons, NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {UpdateComponent} from "../../employee/update/update.component";
import {DeleteComponent} from "../../employee/delete/delete.component";

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  employees: Employee[] = [];

  constructor(private employeeService: EmployeeService,
              private modalService: NgbModal) {
    // this.employeeService.getData().subscribe(data => this.employees = data)
  }

  ngOnInit() {
    this.pullEmployees();
    this.employeeService.refreshData.subscribe(a => this.pullEmployees());
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


  pullEmployees() {
    this.employeeService.getEmployees().subscribe(data => {
      this.employees = data;
    });
  }

}
