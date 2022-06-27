import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from '../Models/Login';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http:HttpClient) { }

  Login(login:Login)
  {
    return this.http.post("https://localhost:5001/api/Login",login);
  }
}
