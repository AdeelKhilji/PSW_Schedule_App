import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Employee} from '../../models/EmployeeModel/employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  
  baseUrl: string = "https://localhost:7045/api/employees"
  constructor(private http: HttpClient) { }

  getAllEmployees(): Observable<Employee[]>{
    return this.http.get<Employee[]>(this.baseUrl);
  }
}
