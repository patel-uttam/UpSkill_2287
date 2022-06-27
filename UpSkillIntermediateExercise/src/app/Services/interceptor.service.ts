import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, EMPTY, Observable, tap } from 'rxjs';
import { GlobalHandlerServiceService } from './global-handler-service.service';

@Injectable({
  providedIn: 'root'
})
export class InterceptorService implements HttpInterceptor {

  constructor(private router:Router,private globalHandler:GlobalHandlerServiceService)
  {

  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    var request = req.clone({url:req.url.replace("https://","http://")});
    request;
    console.log(request.url);
    return next.handle(request).pipe(
      tap((res)=>{
        console.log("res" , res);
      }),
      catchError(
        (err,caught)=>{
          this.globalHandler.handleError(err);
          this.router.navigate(['error']);
          return EMPTY;
        }
      )
    )
  }
}
