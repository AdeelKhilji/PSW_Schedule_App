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

  addEmployee(addNewEmployee: Employee): Observable<Employee>{
    addNewEmployee.id = '0';
    return this.http.post<Employee>(this.baseUrl, addNewEmployee);
  }

  getEmployeeById(id: string): Observable<Employee>{
    return this.http.get<Employee>(this.baseUrl + "/" + id);
  }

  updateEmployee(id: string, updateEmployeeRequest: Employee): Observable<Employee>{
    return this.http.put<Employee>(this.baseUrl + "/" + id, updateEmployeeRequest);
  }

  deleteEmployee(id: string):Observable<Employee>{
    return this.http.delete<Employee>(this.baseUrl + "/" + id);
  }
}
