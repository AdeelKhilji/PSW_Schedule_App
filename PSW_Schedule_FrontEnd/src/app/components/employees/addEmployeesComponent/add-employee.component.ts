import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/EmployeeModel/employee.model';
import { EmployeeService } from 'src/app/services/EmployeeServices/employee.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-employees.component',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeesComponent implements OnInit {

  addNewEmployee: Employee ={
    id: '',
    name: '',
    schedules: [] = []
  }
  constructor(private employeeService: EmployeeService, private router: Router) { }

  ngOnInit(): void {
  }

  addEmployee(){
    this.employeeService.addEmployee(this.addNewEmployee).subscribe({
      next: (employee) =>{
        this.router.navigate(['employees']);
        console.log(employee);
      }
    });
    // console.log(this.addNewEmployee);
  }
}
