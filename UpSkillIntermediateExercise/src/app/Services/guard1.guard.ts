import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateChild, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class Guard1Guard implements CanActivateChild {
  constructor(private router:Router)
  {

  }
  
  canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    var local = localStorage.getItem("login");
    if(local?.toString()=="true")
    {
      console.log("auth");
      return true;
    }
    else
    {
      this.router.navigate(['Login']);
      return false;
    }
  }
}
