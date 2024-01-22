import {Component, Input, OnInit} from '@angular/core';
import {Employee} from 'src/app/models/employee';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {EmployeeService} from "../../services/employee.service";

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {

  @Input() Title = '';
  @Input() employee: Employee | null = null;
  isSubmit = false;

  employeeForm!: FormGroup;

  constructor(public activeModal: NgbActiveModal,
              private employeeService: EmployeeService) {

  }

  ngOnInit() {
    this.employeeForm = new FormGroup({
      fullName: new FormControl<string | null>(this.employee?.fullName ?? null,
        [Validators.required]),
      department: new FormControl<string | null>(this.employee?.department ?? null,
        [Validators.required]),
      salary: new FormControl<number | null>(this.employee?.salary ?? null,
        [Validators.required]),
      dateOfBirth: new FormControl<Date | null>(this.employee?.dateOfBirth ?? null,
        [Validators.required]),
      employmentDate: new FormControl<Date | null>(this.employee?.employmentDate ?? null,
        [Validators.required])
    });

  }

  get fullName() {
    return this.employeeForm.get('fullName');
  }

  get department() {
    return this.employeeForm.get('department');
  }

  get salary() {
    return this.employeeForm.get('salary');
  }

  get dateOfBirth() {
    return this.employeeForm.get('dateOfBirth');
  }

  get employmentDate() {
    return this.employeeForm.get('employmentDate');
  }


  onSubmit() {
    this.isSubmit = true;

    if (this.employeeForm.invalid) {
      console.log('form invalid')
      return;
    }

    let employeeRequest: Employee = {
      id: this.employee === null ? '' : this.employee!.id,
      fullName: this.fullName?.value,
      department: this.department?.value,
      salary: this.salary?.value,
      dateOfBirth: this.dateOfBirth?.value,
      employmentDate: this.employmentDate?.value
    };

    if (employeeRequest.id == '') {
      this.employeeService.createEmployee(employeeRequest).subscribe(data=>
        console.log(data));
    }
    else{
      this.employeeService.updateEmployee(employeeRequest).subscribe(data=>
      console.log(data));
    }

    this.isSubmit = false;
    this.activeModal.close();
  }


}
