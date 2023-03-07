export class Employee 
{
  id?: any;
  name?: string;
  // schedules?:any[];

  schedules?: [{
    id?: any;
    clientName?: string;
    employeeId?: any;
  }];
}
