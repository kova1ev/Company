import {Component, Input} from '@angular/core';
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {Employee} from "../../models/employee";
import {EmployeeService} from "../../services/employee.service";


@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent {
  title = 'Удаление Сотрудника'
  @Input() employee: Employee | undefined;

  constructor(public activeModal: NgbActiveModal,
              private employeeService: EmployeeService) {
  }

  delete() {
    console.log(this.employee?.id + "" + this.employee?.fullName + " DELETED");
    this.employeeService.deleteEmployee(this.employee!.id).subscribe();
    this.activeModal.close();
  }
}
