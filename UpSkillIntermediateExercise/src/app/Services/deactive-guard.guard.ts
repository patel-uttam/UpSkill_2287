import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanDeactivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { DepartmentDepartmentComponent } from '../department/department-department/department-department.component';

@Injectable({
  providedIn: 'root'
})
export class DeactiveGuardGuard implements CanDeactivate<unknown> {
  canDeactivate(
    component: DepartmentDepartmentComponent,
    currentRoute: ActivatedRouteSnapshot,
    currentState: RouterStateSnapshot,
    nextState?: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      return component.canExit();
  }
  
}
