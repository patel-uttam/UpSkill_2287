import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { DepartmentServiceService } from './department-service.service';

@Injectable({
  providedIn: 'root'
})
export class DeptEmpHistoryResolverService implements Resolve<any> {

  constructor(private departmentservice:DepartmentServiceService) { }
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    
  }
}
