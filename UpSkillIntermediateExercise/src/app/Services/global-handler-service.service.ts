import { ErrorHandler, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GlobalHandlerServiceService implements ErrorHandler{
  
  constructor()
  {
    
  }

  handleError(error: any): void {
    if(error)
    {
      if(error?.["error"]?.statusCode)
      {
        alert(error?.["error"]?.statusCode+"\n"+error?.["error"]?.errorMessage+"\n");
      }
    }
    
  }
}
