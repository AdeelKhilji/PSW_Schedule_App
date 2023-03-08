import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from 'src/app/services/EmployeeServices/employee.service';
import { Employee } from 'src/app/models/EmployeeModel/employee.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-employee.component',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent implements OnInit {
  
  employeeDetails: Employee = {
    id: '',
    name: '',
    schedules: []
  };
  constructor(private route: ActivatedRoute, private employeeService: EmployeeService, private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get("id");

        if(id){
          this.employeeService.getEmployeeById(id).subscribe({
            next: (response) =>{
              console.log(this.employeeDetails);
              this.employeeDetails = response;
            }
          })
        }
      }
    })
  }

  editEmployee(){
    this.employeeService.updateEmployee(this.employeeDetails.id,this.employeeDetails).subscribe({
      next: (response) => {
        this.router.navigate(['employees']);
      }
    })
  }
}
