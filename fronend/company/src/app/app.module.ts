import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {NgbDatepickerModule, NgbModal, NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {NavbarComponent} from './common/navbar/navbar.component';
import {HomeComponent} from './pages/home/home.component';
import {EmployeesComponent} from './pages/employees/employees.component';
import {HttpClientModule} from "@angular/common/http";
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {UpdateComponent} from "./employee/update/update.component";
import {DeleteComponent} from './employee/delete/delete.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    EmployeesComponent,
    UpdateComponent,
    DeleteComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    NgbDatepickerModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
