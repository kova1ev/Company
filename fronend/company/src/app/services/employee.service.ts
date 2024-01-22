import {Injectable} from '@angular/core';
import {Employee} from '../models/employee';
import {HttpClient} from "@angular/common/http";
import {Observable, Subject, tap} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  baseUrl = "https://localhost:7183/api/employee/";
   _refreshData = new Subject<void>();

  constructor(private httpClient: HttpClient) {
  }

  get refreshData() {
    return this._refreshData;
  }


  getEmployees(): Observable<Employee[]> {
    return this.httpClient.get<Employee[]>(this.baseUrl)
  }

  getEmployeeById(id: string): Observable<Employee> {
    return this.httpClient.get<Employee>(this.baseUrl + id);
  }

  deleteEmployee(id: string) {
    return this.httpClient.delete(this.baseUrl + id).pipe(tap(() => {
      this._refreshData.next();
    }));
  }

  createEmployee(employee: Employee) {
    return this.httpClient.post(this.baseUrl, employee).pipe(tap(() => {
      this._refreshData.next();
    }));
  }

  updateEmployee(employee: Employee) {
    return this.httpClient.put(this.baseUrl + employee.id, employee).pipe(tap(() => {
      this._refreshData.next();
    }));
  }
}
