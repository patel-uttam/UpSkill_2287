import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { forkJoin, map, Observable } from 'rxjs';
import { Department } from '../Models/Department';

@Injectable({
  providedIn: 'root'
})
export class DepartmentServiceService {
  [x: string]: any;

  constructor(private http:HttpClient) { }

  GetDepartments():Observable<Department[]>
  {
    return this.http.get<Department[]>("https://localhost:5001/api/Departments");
  }

  GetDeptEmpHistory():Observable<any>
  {
    return forkJoin({
      department: this.http.get("https://localhost:5001/api/Departments"),
      empdepthistory: this.http.get("https://localhost:5001/api/DeptEmpHistory")
    }).pipe(
      map((res: any) => {

        let result: any = { department: [], EmpDeptHistory: [] };
        let department = <Array<any>>res.department;
        let empdepthistory = <Array<any>>res.empdepthistory;
        result.department = department;
        result.empdepthistory = empdepthistory;

        return result;
      })
    );
  }
}
