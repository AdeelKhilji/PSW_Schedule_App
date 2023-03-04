import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { GetEmployeesComponent } from './components/get-employees/get-employees.component';
import { AddEmployeeComponent } from './components/add-employee/add-employee.component';

const routes: Routes = [
  {path: '', redirectTo: '', pathMatch: 'full'},
  {path: 'employees', component: GetEmployeesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
