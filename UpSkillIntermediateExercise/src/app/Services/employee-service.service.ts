import { HttpClient, HttpParams, HttpParamsOptions } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRoute, QueryParamsHandling } from '@angular/router';

import { map, Observable, tap } from 'rxjs';
import { Employee } from '../Models/Employee';
import { Paging } from '../Models/paging';

@Injectable({
  providedIn: 'root'
})
export class EmployeeServiceService {
  
  constructor(private http:HttpClient , private route : ActivatedRoute) 
  {}

  // get employees

  GetEmployees(query:Paging):any
  {
    let queryparam:Paging = {
      pageNumber: 0,
      itemPerPage: 0,
      jobTitle:[],
      organizationLevel: '',
      startVacation: '',
      endVacation: '',
      startSickleave: '',
      endSickleave: ''
    };
    queryparam.itemPerPage = query.itemPerPage;
    queryparam.pageNumber = query.pageNumber;
    queryparam.jobTitle = query.jobTitle;
    queryparam.organizationLevel = query.organizationLevel;
    queryparam.startVacation = query.startVacation;
    queryparam.endVacation = query.endVacation;
    queryparam.startSickleave = query.startSickleave;
    queryparam.endSickleave = query.endSickleave;
    
    console.log(queryparam.pageNumber, queryparam.itemPerPage);

    const params = new HttpParams({'fromObject':{pageNumber:queryparam.pageNumber,itemPerPage:queryparam.itemPerPage , jobTitle:queryparam.jobTitle , organizationLevel:queryparam.organizationLevel , startVacation:queryparam.startVacation,endVacation:queryparam.endVacation,startSickleave:queryparam.startSickleave,endSickleave:queryparam.endSickleave}})
    return this.http.get<Observable<any>>("http://localhost:5001/api/Employees",{params}).pipe
    (
      
      map(res => {
        let data = (<any>res);
        console.log(data);
        return data;
      })
    )

  }

  GetEmployeesByDepartment(Deptid:number):Observable<Employee[]>
  {
    return this.http.get<Employee[]>("https://localhost:5001/api/Employees/EmpByDept/"+Deptid).pipe
    (
      map((res:Employee[]) => {
        res=[];
        return res;
      })
    )
    
  }
}
