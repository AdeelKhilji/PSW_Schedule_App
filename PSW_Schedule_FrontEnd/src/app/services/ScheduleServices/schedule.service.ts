import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Schedule} from '../../models/ScheduleModel/schedule.model';

@Injectable({
  providedIn: 'root'
})
export class ScheduleService {
  
  baseUrl: string = "https://localhost:7045/api/schedules"
  constructor(private http: HttpClient) { }

  getAllScheules(id?: number): Observable<Schedule[]>{
    return this.http.get<Schedule[]>(this.baseUrl);
  }
}
