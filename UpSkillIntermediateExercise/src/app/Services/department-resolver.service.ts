import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Department } from '../Models/Department';
import { DepartmentServiceService } from './department-service.service';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DepartmentResolverService implements Resolve<any> {

  constructor(private departmentservice:DepartmentServiceService, private tstr:ToastrService ) { }
 
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
 
    return this.departmentservice.GetDepartments().pipe
    (
      map (
        (res:Department[])=>{
          return res as Department[];
        }
      )
    );
  }
  
}
