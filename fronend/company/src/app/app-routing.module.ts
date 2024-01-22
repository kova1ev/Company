import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from './pages/home/home.component';
import {EmployeesComponent} from './pages/employees/employees.component';
import {UpdateComponent} from './employee/update/update.component';


const routes: Routes = [
  {path: "", component: HomeComponent},
  {path: "employees", component: EmployeesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
