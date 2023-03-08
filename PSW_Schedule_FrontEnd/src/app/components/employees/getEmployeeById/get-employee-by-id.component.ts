import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from 'src/app/services/EmployeeServices/employee.service';
import { Employee } from 'src/app/models/EmployeeModel/employee.model';

@Component({
  selector: 'app-get-employee-by-id',
  templateUrl: './get-employee-by-id.component.html',
  styleUrls: ['./get-employee-by-id.component.css']
})
export class GetEmployeeByIdComponent implements OnInit {

  employeeDetails: Employee = {
    id: '',
    name: '',
    schedules: []
  }

  constructor(private route: ActivatedRoute, private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) =>{
        const id = params.get('id');

        if(id){
          this.employeeService.getEmployeeById(id).subscribe({
            next: (response) =>{
              console.log(response);
              this.employeeDetails = response;
            }
          })
        }
      }
    })
  }
  
  // getEmpById()
  // {
  //   const id = this.route.snapshot.paramMap.get('id');
  //   this.employeeService.getEmployeeById(id).subscribe(employee =>{
  //     console.log(employee.name);
  //   })
  // }
}

