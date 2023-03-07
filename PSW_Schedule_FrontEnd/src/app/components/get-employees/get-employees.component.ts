import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/EmployeeModel/employee.model';
import { EmployeeService } from 'src/app/services/EmployeeServices/employee.service';

@Component({
  selector: 'app-get-employees',
  templateUrl: './get-employees.component.html',
  styleUrls: ['./get-employees.component.css']
})
export class GetEmployeesComponent implements OnInit {
  employees?: Employee[];
  
  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.getAllEmployees();
  }

  getAllEmployees(): void{
    this.employeeService.getAllEmployees().subscribe({
      next: (employees) =>{
        this.employees = employees;
        console.log(employees);
      },
      error: (response) =>{
        console.log(response);
      }
    });
  }
}
