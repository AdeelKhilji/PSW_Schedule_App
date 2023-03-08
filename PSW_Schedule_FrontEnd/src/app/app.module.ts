import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
// import { RouterTestingModule } from '@angular/router/testing';
// import {HttpClientTestingModule} from '@angular/common/http/testing'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { GetEmployeesComponent } from './components/employees/getEmployeesComponent/get-employees.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AddEmployeesComponent } from './components/employees/addEmployeesComponent/add-employee.component';
import { EditEmployeeComponent } from './components/employees/editEmployeeComponent/edit-employee.component';
import { GetEmployeeByIdComponent } from './components/employees/getEmployeeById/get-employee-by-id.component';



@NgModule({
  declarations: [
    AppComponent,
    GetEmployeesComponent,
    AddEmployeesComponent,
    EditEmployeeComponent,
    GetEmployeeByIdComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    NgbModule
    // RouterTestingModule,
    // HttpClientTestingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
