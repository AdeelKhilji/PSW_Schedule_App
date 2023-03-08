import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { GetEmployeesComponent } from './components/employees//getEmployeesComponent/get-employees.component';
import { AddEmployeesComponent } from './components/employees/addEmployeesComponent/add-employee.component';
import { EditEmployeeComponent } from './components/employees/editEmployeeComponent/edit-employee.component';
import { GetEmployeeByIdComponent } from './components/employees/getEmployeeById/get-employee-by-id.component';

const routes: Routes = [
  {path: '', redirectTo: '', pathMatch: 'full'},
  {path: 'employees', component: GetEmployeesComponent},
  {path: 'employees/add', component: AddEmployeesComponent},
  {path: 'employees/:id', component: GetEmployeeByIdComponent},
  {path: 'employees/edit/:id', component: EditEmployeeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
